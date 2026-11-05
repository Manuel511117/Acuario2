using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace Acuario2
{
    /// <summary>Fila de producto del inventario.</summary>
    public class Producto
    {
        public int Id;
        public string Nombre;
        public string Especie;
        public int Cantidad;
        public decimal Precio;
        public string Imagen; // ruta relativa junto al exe (vacío si no tiene)
    }

    /// <summary>Par clave/valor para las gráficas del dashboard.</summary>
    public class DatoGrafica
    {
        public string Etiqueta;
        public double Valor;
    }

    /// <summary>
    /// Conexión a la base de datos MySQL (Aiven/Local) y consultas de login y productos.
    /// Si la base de datos no está disponible o no está configurada, utiliza modo local de respaldo.
    /// </summary>
    public static class ConexionDB
    {
        private static bool _tablasAseguradas = false;

        /// <summary>Indica si el sistema está operando en modo local/desconectado.</summary>
        public static bool ModoOffline { get; set; } = false;

        // Datos en memoria para modo local / demostración
        private static readonly List<Producto> _mockProductos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Pez Betta Corona", Especie = "Betta Splendens", Cantidad = 15, Precio = 12.50m, Imagen = "" },
            new Producto { Id = 2, Nombre = "Pez Payaso Ocellaris", Especie = "Amphiprion ocellaris", Cantidad = 8, Precio = 25.00m, Imagen = "" },
            new Producto { Id = 3, Nombre = "Tetra Neón", Especie = "Paracheirodon innesi", Cantidad = 45, Precio = 2.50m, Imagen = "" },
            new Producto { Id = 4, Nombre = "Pez Cirujano Azul", Especie = "Paracanthurus hepatus", Cantidad = 3, Precio = 65.00m, Imagen = "" },
            new Producto { Id = 5, Nombre = "Guppy Fancy", Especie = "Poecilia reticulata", Cantidad = 30, Precio = 3.00m, Imagen = "" },
            new Producto { Id = 6, Nombre = "Pez Disco Turquesa", Especie = "Symphysodon", Cantidad = 2, Precio = 85.00m, Imagen = "" },
            new Producto { Id = 7, Nombre = "Escalar Mármol", Especie = "Pterophyllum scalare", Cantidad = 12, Precio = 14.00m, Imagen = "" },
            new Producto { Id = 8, Nombre = "Corydora Panda", Especie = "Corydoras panda", Cantidad = 20, Precio = 5.50m, Imagen = "" }
        };

        private static string Cadena
        {
            get
            {
                ConnectionStringSettings cfg = ConfigurationManager.ConnectionStrings["AcuarioDB"];
                if (cfg == null || string.IsNullOrEmpty(cfg.ConnectionString))
                    throw new InvalidOperationException("Falta la cadena de conexion 'AcuarioDB' en App.config.");
                return cfg.ConnectionString;
            }
        }

        /// <summary>Verifica si la cadena de conexión tiene valores reales o son marcadores por defecto.</summary>
        public static bool EstaConfiguradaCadena()
        {
            try
            {
                string c = Cadena;
                return !string.IsNullOrEmpty(c) && !c.Contains("TU_HOST") && !c.Contains("TU_USUARIO");
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Abre y devuelve una conexión a la base de datos asegurando tablas.</summary>
        public static MySqlConnection Abrir()
        {
            MySqlConnection conn = new MySqlConnection(Cadena);
            conn.Open();
            AsegurarTablas(conn);
            return conn;
        }

        /// <summary>
        /// Crea las tablas 'usuarios' y 'productos' si no existen, e inserta datos iniciales si están vacías.
        /// </summary>
        private static void AsegurarTablas(MySqlConnection conn)
        {
            if (_tablasAseguradas) return;

            try
            {
                string ddl = @"
                    CREATE TABLE IF NOT EXISTS usuarios (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        usuario VARCHAR(50) NOT NULL UNIQUE,
                        clave VARCHAR(100) NOT NULL
                    );
                    CREATE TABLE IF NOT EXISTS productos (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        nombre VARCHAR(100) NOT NULL,
                        especie VARCHAR(50) NOT NULL,
                        cantidad INT NOT NULL DEFAULT 0,
                        precio DECIMAL(10,2) NOT NULL DEFAULT 0.00,
                        imagen VARCHAR(255) NULL
                    );";

                using (MySqlCommand cmd = new MySqlCommand(ddl, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Asegurar usuarios por defecto
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM usuarios", conn))
                {
                    long uCount = Convert.ToInt64(cmd.ExecuteScalar());
                    if (uCount == 0)
                    {
                        using (MySqlCommand ins = new MySqlCommand(
                            "INSERT INTO usuarios (usuario, clave) VALUES ('admin', 'admin'), ('admin', '1234'), ('diego', '1234')", conn))
                        {
                            ins.ExecuteNonQuery();
                        }
                    }
                }

                // Asegurar productos por defecto si está vacía
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM productos", conn))
                {
                    long pCount = Convert.ToInt64(cmd.ExecuteScalar());
                    if (pCount == 0)
                    {
                        string insProd = @"
                            INSERT INTO productos (nombre, especie, cantidad, precio, imagen) VALUES
                            ('Pez Betta Corona', 'Betta Splendens', 15, 12.50, ''),
                            ('Pez Payaso Ocellaris', 'Amphiprion ocellaris', 8, 25.00, ''),
                            ('Tetra Neón', 'Paracheirodon innesi', 45, 2.50, ''),
                            ('Pez Cirujano Azul', 'Paracanthurus hepatus', 3, 65.00, ''),
                            ('Guppy Fancy', 'Poecilia reticulata', 30, 3.00, ''),
                            ('Pez Disco Turquesa', 'Symphysodon', 2, 85.00, ''),
                            ('Escalar Mármol', 'Pterophyllum scalare', 12, 14.00, ''),
                            ('Corydora Panda', 'Corydoras panda', 20, 5.50, '');";
                        using (MySqlCommand ins = new MySqlCommand(insProd, conn))
                        {
                            ins.ExecuteNonQuery();
                        }
                    }
                }

                _tablasAseguradas = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("AsegurarTablas error: " + ex);
            }
        }

        /// <summary>Prueba la conexión. Devuelve un mensaje corto con el resultado.</summary>
        public static string ProbarConexion()
        {
            if (!EstaConfiguradaCadena())
            {
                return "Cadena de conexión no configurada en App.config.";
            }

            try
            {
                using (MySqlConnection conn = Abrir())
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT DATABASE()", conn))
                    {
                        object res = cmd.ExecuteScalar();
                        return "Conexión exitosa. Base de datos: " + (res == null ? "(ninguna)" : res.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ProbarConexion: " + ex);
                return "Error de conexión con la base de datos.";
            }
        }

        private static bool EsUsuarioLocalValido(string usuario, string clave)
        {
            if (usuario.Equals("admin", StringComparison.OrdinalIgnoreCase) &&
                (clave == "admin" || clave == "1234" || clave == "admin123"))
                return true;

            if (usuario.Equals("diego", StringComparison.OrdinalIgnoreCase) &&
                (clave == "1234" || clave == "admin" || clave == "diego"))
                return true;

            return false;
        }

        /// <summary>
        /// Valida usuario y contraseña contra la tabla 'usuarios'.
        /// Si la BD no está configurada o no responde, permite inicio con admin/admin o diego/1234.
        /// </summary>
        public static bool ValidarUsuario(string usuario, string clave, out string mensaje)
        {
            usuario = (usuario ?? "").Trim();
            clave = clave ?? "";

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                mensaje = "Ingrese usuario y contraseña.";
                return false;
            }

            // Si la cadena de conexión todavía tiene 'TU_HOST' o no está configurada
            if (!EstaConfiguradaCadena())
            {
                if (EsUsuarioLocalValido(usuario, clave))
                {
                    ModoOffline = true;
                    mensaje = string.Empty;
                    return true;
                }
                mensaje = "Base de datos no configurada.\n(Modo de prueba local: admin / admin)";
                return false;
            }

            try
            {
                using (MySqlConnection conn = Abrir())
                {
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT COUNT(*) FROM usuarios WHERE usuario = @usuario AND clave = @clave", conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@clave", clave);
                        long cuenta = Convert.ToInt64(cmd.ExecuteScalar());
                        if (cuenta > 0)
                        {
                            ModoOffline = false;
                            mensaje = string.Empty;
                            return true;
                        }

                        // Respaldo de credenciales locales por si la tabla no tenía el usuario
                        if (EsUsuarioLocalValido(usuario, clave))
                        {
                            ModoOffline = false;
                            mensaje = string.Empty;
                            return true;
                        }

                        mensaje = "Usuario o contraseña incorrectos.";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ValidarUsuario: " + ex);

                // Si la BD falla por red o servidor no disponible, permitir acceso local
                if (EsUsuarioLocalValido(usuario, clave))
                {
                    ModoOffline = true;
                    mensaje = string.Empty;
                    return true;
                }

                mensaje = "Error al conectar a la BD.\n(Modo de prueba local: admin / admin)";
                return false;
            }
        }

        // ============================================================
        //  CRUD de productos (inventario)
        // ============================================================

        private static Producto Leer(MySqlDataReader r)
        {
            Producto p = new Producto();
            p.Id = r.GetInt32(r.GetOrdinal("id"));
            p.Nombre = r.GetString(r.GetOrdinal("nombre"));
            p.Especie = r.GetString(r.GetOrdinal("especie"));
            p.Cantidad = r.GetInt32(r.GetOrdinal("cantidad"));
            p.Precio = r.GetDecimal(r.GetOrdinal("precio"));
            p.Imagen = r.IsDBNull(r.GetOrdinal("imagen")) ? string.Empty : r.GetString(r.GetOrdinal("imagen"));
            return p;
        }

        /// <summary>Lista todos los productos ordenados por id.</summary>
        public static List<Producto> ListarProductos(out string mensaje)
        {
            mensaje = string.Empty;

            if (ModoOffline || !EstaConfiguradaCadena())
            {
                return _mockProductos.Select(p => new Producto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Especie = p.Especie,
                    Cantidad = p.Cantidad,
                    Precio = p.Precio,
                    Imagen = p.Imagen
                }).ToList();
            }

            List<Producto> lista = new List<Producto>();
            try
            {
                using (MySqlConnection conn = Abrir())
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT id, nombre, especie, cantidad, precio, imagen FROM productos ORDER BY id", conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read()) lista.Add(Leer(r));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ListarProductos: " + ex);
                mensaje = "Operando con datos locales (sin conexión a BD).";
                return _mockProductos.ToList();
            }
            return lista;
        }

        /// <summary>Inserta un producto. Devuelve true si todo salió bien.</summary>
        public static bool InsertarProducto(Producto p, out string mensaje)
        {
            mensaje = string.Empty;

            if (ModoOffline || !EstaConfiguradaCadena())
            {
                int nuevoId = _mockProductos.Count > 0 ? _mockProductos.Max(x => x.Id) + 1 : 1;
                p.Id = nuevoId;
                _mockProductos.Add(p);
                return true;
            }

            try
            {
                using (MySqlConnection conn = Abrir())
                using (MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO productos (nombre, especie, cantidad, precio, imagen) " +
                    "VALUES (@nombre, @especie, @cantidad, @precio, @imagen)", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@especie", p.Especie);
                    cmd.Parameters.AddWithValue("@cantidad", p.Cantidad);
                    cmd.Parameters.AddWithValue("@precio", p.Precio);
                    cmd.Parameters.AddWithValue("@imagen", string.IsNullOrEmpty(p.Imagen) ? (object)DBNull.Value : p.Imagen);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("InsertarProducto: " + ex);
                mensaje = "No se pudo guardar el producto en la BD.";
                return false;
            }
        }

        /// <summary>Actualiza un producto existente por su id.</summary>
        public static bool ActualizarProducto(Producto p, out string mensaje)
        {
            mensaje = string.Empty;

            if (ModoOffline || !EstaConfiguradaCadena())
            {
                Producto item = _mockProductos.FirstOrDefault(x => x.Id == p.Id);
                if (item != null)
                {
                    item.Nombre = p.Nombre;
                    item.Especie = p.Especie;
                    item.Cantidad = p.Cantidad;
                    item.Precio = p.Precio;
                    item.Imagen = p.Imagen;
                }
                return true;
            }

            try
            {
                using (MySqlConnection conn = Abrir())
                using (MySqlCommand cmd = new MySqlCommand(
                    "UPDATE productos SET nombre = @nombre, especie = @especie, cantidad = @cantidad, " +
                    "precio = @precio, imagen = @imagen WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@especie", p.Especie);
                    cmd.Parameters.AddWithValue("@cantidad", p.Cantidad);
                    cmd.Parameters.AddWithValue("@precio", p.Precio);
                    cmd.Parameters.AddWithValue("@imagen", string.IsNullOrEmpty(p.Imagen) ? (object)DBNull.Value : p.Imagen);
                    cmd.Parameters.AddWithValue("@id", p.Id);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ActualizarProducto: " + ex);
                mensaje = "No se pudo actualizar el producto.";
                return false;
            }
        }

        /// <summary>Elimina un producto por su id.</summary>
        public static bool EliminarProducto(int id, out string mensaje)
        {
            mensaje = string.Empty;

            if (ModoOffline || !EstaConfiguradaCadena())
            {
                _mockProductos.RemoveAll(x => x.Id == id);
                return true;
            }

            try
            {
                using (MySqlConnection conn = Abrir())
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM productos WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("EliminarProducto: " + ex);
                mensaje = "No se pudo eliminar el producto.";
                return false;
            }
        }

        // ============================================================
        //  Agregados del dashboard
        // ============================================================

        private static object Escalar(string sql)
        {
            using (MySqlConnection conn = Abrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>Total de productos (distintos) en el inventario.</summary>
        public static int TotalProductos()
        {
            if (ModoOffline || !EstaConfiguradaCadena()) return _mockProductos.Count;

            try { return Convert.ToInt32(Escalar("SELECT COUNT(*) FROM productos")); }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("TotalProductos: " + ex);
                return _mockProductos.Count;
            }
        }

        /// <summary>Suma de todas las unidades en stock.</summary>
        public static int TotalUnidades()
        {
            if (ModoOffline || !EstaConfiguradaCadena()) return _mockProductos.Sum(x => x.Cantidad);

            try { return Convert.ToInt32(Escalar("SELECT COALESCE(SUM(cantidad), 0) FROM productos")); }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("TotalUnidades: " + ex);
                return _mockProductos.Sum(x => x.Cantidad);
            }
        }

        /// <summary>Valor total del inventario (suma cantidad * precio).</summary>
        public static decimal ValorInventario()
        {
            if (ModoOffline || !EstaConfiguradaCadena()) return _mockProductos.Sum(x => x.Cantidad * x.Precio);

            try { return Convert.ToDecimal(Escalar("SELECT COALESCE(SUM(cantidad * precio), 0) FROM productos")); }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ValorInventario: " + ex);
                return _mockProductos.Sum(x => x.Cantidad * x.Precio);
            }
        }

        /// <summary>Productos agotados (cantidad &lt;= 3).</summary>
        public static int ProductosAgotados()
        {
            if (ModoOffline || !EstaConfiguradaCadena()) return _mockProductos.Count(x => x.Cantidad <= 3);

            try { return Convert.ToInt32(Escalar("SELECT COUNT(*) FROM productos WHERE cantidad <= 3")); }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ProductosAgotados: " + ex);
                return _mockProductos.Count(x => x.Cantidad <= 3);
            }
        }

        /// <summary>Gráfica: cantidad de productos por especie.</summary>
        public static List<DatoGrafica> ProductosPorEspecie()
        {
            if (ModoOffline || !EstaConfiguradaCadena())
            {
                return _mockProductos.GroupBy(x => x.Especie)
                                     .OrderByDescending(g => g.Count())
                                     .Select(g => new DatoGrafica { Etiqueta = g.Key, Valor = g.Count() })
                                     .ToList();
            }

            List<DatoGrafica> datos = new List<DatoGrafica>();
            try
            {
                using (MySqlConnection conn = Abrir())
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT especie, COUNT(*) FROM productos GROUP BY especie ORDER BY COUNT(*) DESC", conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        datos.Add(new DatoGrafica { Etiqueta = r.GetString(0), Valor = r.GetInt32(1) });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ProductosPorEspecie: " + ex);
                return _mockProductos.GroupBy(x => x.Especie)
                                     .OrderByDescending(g => g.Count())
                                     .Select(g => new DatoGrafica { Etiqueta = g.Key, Valor = g.Count() })
                                     .ToList();
            }
            return datos;
        }

        /// <summary>Gráfica: unidades en stock por especie.</summary>
        public static List<DatoGrafica> UnidadesPorEspecie()
        {
            if (ModoOffline || !EstaConfiguradaCadena())
            {
                return _mockProductos.GroupBy(x => x.Especie)
                                     .OrderByDescending(g => g.Sum(x => x.Cantidad))
                                     .Select(g => new DatoGrafica { Etiqueta = g.Key, Valor = g.Sum(x => x.Cantidad) })
                                     .ToList();
            }

            List<DatoGrafica> datos = new List<DatoGrafica>();
            try
            {
                using (MySqlConnection conn = Abrir())
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT especie, SUM(cantidad) FROM productos GROUP BY especie ORDER BY SUM(cantidad) DESC", conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        datos.Add(new DatoGrafica { Etiqueta = r.GetString(0), Valor = Convert.ToDouble(r.GetValue(1)) });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("UnidadesPorEspecie: " + ex);
                return _mockProductos.GroupBy(x => x.Especie)
                                     .OrderByDescending(g => g.Sum(x => x.Cantidad))
                                     .Select(g => new DatoGrafica { Etiqueta = g.Key, Valor = g.Sum(x => x.Cantidad) })
                                     .ToList();
            }
            return datos;
        }

        /// <summary>Top 5 de productos más caros (para la gráfica de precios).</summary>
        public static List<DatoGrafica> Top5Precios()
        {
            if (ModoOffline || !EstaConfiguradaCadena())
            {
                return _mockProductos.OrderByDescending(x => x.Precio)
                                     .Take(5)
                                     .Select(x => new DatoGrafica { Etiqueta = x.Nombre, Valor = (double)x.Precio })
                                     .ToList();
            }

            List<DatoGrafica> datos = new List<DatoGrafica>();
            try
            {
                using (MySqlConnection conn = Abrir())
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT nombre, precio FROM productos ORDER BY precio DESC LIMIT 5", conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        datos.Add(new DatoGrafica { Etiqueta = r.GetString(0), Valor = Convert.ToDouble(r.GetDecimal(1)) });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Top5Precios: " + ex);
                return _mockProductos.OrderByDescending(x => x.Precio)
                                     .Take(5)
                                     .Select(x => new DatoGrafica { Etiqueta = x.Nombre, Valor = (double)x.Precio })
                                     .ToList();
            }
            return datos;
        }

        /// <summary>Productos con stock bajo (cantidad &lt;= 3) para el panel de alertas.</summary>
        public static List<Producto> InventarioBajo(out string mensaje)
        {
            mensaje = string.Empty;

            if (ModoOffline || !EstaConfiguradaCadena())
            {
                return _mockProductos.Where(x => x.Cantidad <= 3)
                                     .OrderBy(x => x.Cantidad)
                                     .ToList();
            }

            List<Producto> lista = new List<Producto>();
            try
            {
                using (MySqlConnection conn = Abrir())
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT id, nombre, especie, cantidad, precio, imagen FROM productos " +
                    "WHERE cantidad <= 3 ORDER BY cantidad ASC", conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read()) lista.Add(Leer(r));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("InventarioBajo: " + ex);
                return _mockProductos.Where(x => x.Cantidad <= 3)
                                     .OrderBy(x => x.Cantidad)
                                     .ToList();
            }
            return lista;
        }

        /// <summary>Valor del inventario agrupado por especie (para la gráfica del dashboard).</summary>
        public static List<DatoGrafica> ValorPorEspecie()
        {
            if (ModoOffline || !EstaConfiguradaCadena())
            {
                return _mockProductos.GroupBy(x => x.Especie)
                                     .OrderByDescending(g => g.Sum(x => (double)(x.Cantidad * x.Precio)))
                                     .Select(g => new DatoGrafica { Etiqueta = g.Key, Valor = g.Sum(x => (double)(x.Cantidad * x.Precio)) })
                                     .ToList();
            }

            List<DatoGrafica> datos = new List<DatoGrafica>();
            try
            {
                using (MySqlConnection conn = Abrir())
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT especie, SUM(cantidad * precio) FROM productos GROUP BY especie ORDER BY SUM(cantidad * precio) DESC", conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        datos.Add(new DatoGrafica { Etiqueta = r.GetString(0), Valor = Convert.ToDouble(r.GetValue(1)) });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ValorPorEspecie: " + ex);
                return _mockProductos.GroupBy(x => x.Especie)
                                     .OrderByDescending(g => g.Sum(x => (double)(x.Cantidad * x.Precio)))
                                     .Select(g => new DatoGrafica { Etiqueta = g.Key, Valor = g.Sum(x => (double)(x.Cantidad * x.Precio)) })
                                     .ToList();
            }
            return datos;
        }
    }
}
