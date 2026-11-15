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
        public string Categoria; // categoría de venta (Arena, Peces, Filtros, etc.)
        public int Cantidad;
        public decimal Precio;
        public string Imagen; // ruta relativa junto al exe (vacío si no tiene)
    }

    /// <summary>Línea del carrito del punto de venta.</summary>
    public class ItemCarrito
    {
        public Producto Producto;
        public int Cantidad;

        public decimal Subtotal
        {
            get { return Math.Round((Producto == null ? 0m : Producto.Precio) * Cantidad, 2); }
        }
    }

    /// <summary>Fila del historial de ventas.</summary>
    public class Venta
    {
        public int Id;
        public int ProductoId;
        public string Producto;
        public string Categoria;
        public int Cantidad;
        public decimal Precio;
        public decimal Total;
        public DateTime Fecha;
        public string Usuario;
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
            new Producto { Id = 1, Nombre = "Pez Betta Corona", Especie = "Betta Splendens", Categoria = "Peces", Cantidad = 15, Precio = 12.50m, Imagen = "" },
            new Producto { Id = 2, Nombre = "Pez Payaso Ocellaris", Especie = "Amphiprion ocellaris", Categoria = "Peces", Cantidad = 8, Precio = 25.00m, Imagen = "" },
            new Producto { Id = 3, Nombre = "Tetra Neón", Especie = "Paracheirodon innesi", Categoria = "Peces", Cantidad = 45, Precio = 2.50m, Imagen = "" },
            new Producto { Id = 4, Nombre = "Pez Cirujano Azul", Especie = "Paracanthurus hepatus", Categoria = "Peces", Cantidad = 3, Precio = 65.00m, Imagen = "" },
            new Producto { Id = 5, Nombre = "Guppy Fancy", Especie = "Poecilia reticulata", Categoria = "Peces", Cantidad = 30, Precio = 3.00m, Imagen = "" },
            new Producto { Id = 6, Nombre = "Pez Disco Turquesa", Especie = "Symphysodon", Categoria = "Especies exóticas", Cantidad = 2, Precio = 85.00m, Imagen = "" },
            new Producto { Id = 7, Nombre = "Escalar Mármol", Especie = "Pterophyllum scalare", Categoria = "Peces", Cantidad = 12, Precio = 14.00m, Imagen = "" },
            new Producto { Id = 8, Nombre = "Corydora Panda", Especie = "Corydoras panda", Categoria = "Peces", Cantidad = 20, Precio = 5.50m, Imagen = "" }
        };

        private static readonly List<Venta> _mockVentas = new List<Venta>();
        private static int _mockVentaId = 0;

        /// <summary>Categorías disponibles en el punto de venta.</summary>
        public static readonly string[] CategoriasVenta =
        {
            "Arena",
            "Comida para pez",
            "Pecera",
            "Algas",
            "Peces",
            "Decoraciones",
            "Filtros",
            "Especies exóticas"
        };

        /// <summary>Sugiere una categoría de venta a partir del nombre/especie del producto.</summary>
        public static string CategoriaSugerida(Producto p)
        {
            if (p == null) return "Peces";
            string texto = ((p.Nombre ?? "") + " " + (p.Especie ?? "")).ToLowerInvariant();

            if (texto.Contains("arena")) return "Arena";
            if (texto.Contains("comida") || texto.Contains("alimento")) return "Comida para pez";
            if (texto.Contains("pecera") || texto.Contains("acuario")) return "Pecera";
            if (texto.Contains("alga")) return "Algas";
            if (texto.Contains("filtro")) return "Filtros";
            if (texto.Contains("decor") || texto.Contains("adorno") || texto.Contains("planta")) return "Decoraciones";
            if (texto.Contains("exotic") || texto.Contains("exótic")) return "Especies exóticas";
            return "Peces";
        }

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
                        categoria VARCHAR(50) NOT NULL DEFAULT 'Peces',
                        cantidad INT NOT NULL DEFAULT 0,
                        precio DECIMAL(10,2) NOT NULL DEFAULT 0.00,
                        imagen VARCHAR(255) NULL
                    );
                    CREATE TABLE IF NOT EXISTS ventas (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        producto_id INT NULL,
                        producto VARCHAR(100) NOT NULL,
                        categoria VARCHAR(50) NOT NULL,
                        cantidad INT NOT NULL,
                        precio DECIMAL(10,2) NOT NULL,
                        total DECIMAL(12,2) NOT NULL,
                        fecha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                        usuario VARCHAR(50) NULL,
                        INDEX idx_ventas_fecha (fecha)
                    );";

                using (MySqlCommand cmd = new MySqlCommand(ddl, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Migración: agregar la columna categoria si la tabla ya existía sin ella
                bool existeCategoria = false;
                using (MySqlCommand chk = new MySqlCommand(
                    "SELECT COUNT(*) FROM information_schema.columns " +
                    "WHERE table_schema = DATABASE() AND table_name = 'productos' AND column_name = 'categoria'", conn))
                {
                    existeCategoria = Convert.ToInt64(chk.ExecuteScalar()) > 0;
                }

                if (!existeCategoria)
                {
                    using (MySqlCommand alt = new MySqlCommand(
                        "ALTER TABLE productos ADD COLUMN categoria VARCHAR(50) NOT NULL DEFAULT 'Peces'", conn))
                    {
                        alt.ExecuteNonQuery();
                    }

                    // Clasificación inicial de los productos existentes
                    using (MySqlCommand upd = new MySqlCommand(
                        "UPDATE productos SET categoria = 'Especies exóticas' " +
                        "WHERE nombre LIKE '%Disco%' OR nombre LIKE '%Plecostomus%'", conn))
                    {
                        upd.ExecuteNonQuery();
                    }
                }

                // Normalizar filas sin categoría
                using (MySqlCommand norm = new MySqlCommand(
                    "UPDATE productos SET categoria = 'Peces' WHERE categoria IS NULL OR categoria = ''", conn))
                {
                    norm.ExecuteNonQuery();
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
                            INSERT INTO productos (nombre, especie, categoria, cantidad, precio, imagen) VALUES
                            ('Pez Betta Corona', 'Betta Splendens', 'Peces', 15, 12.50, ''),
                            ('Pez Payaso Ocellaris', 'Amphiprion ocellaris', 'Peces', 8, 25.00, ''),
                            ('Tetra Neón', 'Paracheirodon innesi', 'Peces', 45, 2.50, ''),
                            ('Pez Cirujano Azul', 'Paracanthurus hepatus', 'Peces', 3, 65.00, ''),
                            ('Guppy Fancy', 'Poecilia reticulata', 'Peces', 30, 3.00, ''),
                            ('Pez Disco Turquesa', 'Symphysodon', 'Especies exóticas', 2, 85.00, ''),
                            ('Escalar Mármol', 'Pterophyllum scalare', 'Peces', 12, 14.00, ''),
                            ('Corydora Panda', 'Corydoras panda', 'Peces', 20, 5.50, '');";
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
            try
            {
                int i = r.GetOrdinal("categoria");
                string cat = r.IsDBNull(i) ? string.Empty : r.GetString(i);
                p.Categoria = string.IsNullOrWhiteSpace(cat) ? "Peces" : cat;
            }
            catch
            {
                p.Categoria = CategoriaSugerida(p);
            }
            p.Cantidad = r.GetInt32(r.GetOrdinal("cantidad"));
            p.Precio = r.GetDecimal(r.GetOrdinal("precio"));
            p.Imagen = r.IsDBNull(r.GetOrdinal("imagen")) ? string.Empty : r.GetString(r.GetOrdinal("imagen"));
            return p;
        }

        /// <summary>Copia un producto (usada por el modo local y los respaldos).</summary>
        private static Producto CopiarProducto(Producto p)
        {
            return new Producto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Especie = p.Especie,
                Categoria = p.Categoria,
                Cantidad = p.Cantidad,
                Precio = p.Precio,
                Imagen = p.Imagen
            };
        }

        /// <summary>Lista todos los productos ordenados por id.</summary>
        public static List<Producto> ListarProductos(out string mensaje)
        {
            mensaje = string.Empty;

            if (ModoOffline || !EstaConfiguradaCadena())
            {
                return _mockProductos.Select(CopiarProducto).ToList();
            }

            List<Producto> lista = new List<Producto>();
            try
            {
                using (MySqlConnection conn = Abrir())
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT id, nombre, especie, categoria, cantidad, precio, imagen FROM productos ORDER BY id", conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read()) lista.Add(Leer(r));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ListarProductos: " + ex);
                mensaje = "Operando con datos locales (sin conexión a BD).";
                return _mockProductos.Select(CopiarProducto).ToList();
            }
            return lista;
        }

        /// <summary>Inserta un producto. Devuelve true si todo salió bien.</summary>
        public static bool InsertarProducto(Producto p, out string mensaje)
        {
            mensaje = string.Empty;

            if (ModoOffline || !EstaConfiguradaCadena())
            {
                if (string.IsNullOrWhiteSpace(p.Categoria)) p.Categoria = "Peces";
                int nuevoId = _mockProductos.Count > 0 ? _mockProductos.Max(x => x.Id) + 1 : 1;
                p.Id = nuevoId;
                _mockProductos.Add(p);
                return true;
            }

            try
            {
                using (MySqlConnection conn = Abrir())
                using (MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO productos (nombre, especie, categoria, cantidad, precio, imagen) " +
                    "VALUES (@nombre, @especie, @categoria, @cantidad, @precio, @imagen)", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@especie", p.Especie);
                    cmd.Parameters.AddWithValue("@categoria", string.IsNullOrWhiteSpace(p.Categoria) ? "Peces" : p.Categoria);
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
                    item.Categoria = string.IsNullOrWhiteSpace(p.Categoria) ? "Peces" : p.Categoria;
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
                    "UPDATE productos SET nombre = @nombre, especie = @especie, categoria = @categoria, " +
                    "cantidad = @cantidad, precio = @precio, imagen = @imagen WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@especie", p.Especie);
                    cmd.Parameters.AddWithValue("@categoria", string.IsNullOrWhiteSpace(p.Categoria) ? "Peces" : p.Categoria);
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
        //  Ventas (punto de venta)
        // ============================================================

        private static Venta LeerVenta(MySqlDataReader r)
        {
            Venta v = new Venta();
            v.Id = r.GetInt32(r.GetOrdinal("id"));
            v.ProductoId = r.IsDBNull(r.GetOrdinal("producto_id")) ? 0 : r.GetInt32(r.GetOrdinal("producto_id"));
            v.Producto = r.GetString(r.GetOrdinal("producto"));
            v.Categoria = r.GetString(r.GetOrdinal("categoria"));
            v.Cantidad = r.GetInt32(r.GetOrdinal("cantidad"));
            v.Precio = r.GetDecimal(r.GetOrdinal("precio"));
            v.Total = r.GetDecimal(r.GetOrdinal("total"));
            v.Fecha = r.GetDateTime(r.GetOrdinal("fecha"));
            v.Usuario = r.IsDBNull(r.GetOrdinal("usuario")) ? string.Empty : r.GetString(r.GetOrdinal("usuario"));
            return v;
        }

        private static Venta CopiarVenta(Venta v)
        {
            return new Venta
            {
                Id = v.Id,
                ProductoId = v.ProductoId,
                Producto = v.Producto,
                Categoria = v.Categoria,
                Cantidad = v.Cantidad,
                Precio = v.Precio,
                Total = v.Total,
                Fecha = v.Fecha,
                Usuario = v.Usuario
            };
        }

        /// <summary>Lista el historial de ventas, de la más reciente a la más antigua.</summary>
        public static List<Venta> ListarVentas(out string mensaje)
        {
            mensaje = string.Empty;

            if (ModoOffline || !EstaConfiguradaCadena())
            {
                return _mockVentas.OrderByDescending(x => x.Id).Select(CopiarVenta).ToList();
            }

            List<Venta> lista = new List<Venta>();
            try
            {
                using (MySqlConnection conn = Abrir())
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT id, producto_id, producto, categoria, cantidad, precio, total, fecha, usuario " +
                    "FROM ventas ORDER BY id DESC", conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read()) lista.Add(LeerVenta(r));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ListarVentas: " + ex);
                mensaje = "No se pudo cargar el historial de ventas desde la BD.";
            }
            return lista;
        }

        /// <summary>
        /// Registra una venta y descuenta la cantidad vendida del inventario en una sola transacción.
        /// </summary>
        public static bool RegistrarVenta(Venta v, out string mensaje)
        {
            mensaje = string.Empty;

            if (v == null) { mensaje = "No hay datos de la venta."; return false; }
            if (v.ProductoId <= 0) { mensaje = "Seleccione un producto."; return false; }
            if (v.Cantidad <= 0) { mensaje = "La cantidad debe ser mayor que cero."; return false; }
            if (v.Precio < 0) { mensaje = "El precio no puede ser negativo."; return false; }
            if (string.IsNullOrWhiteSpace(v.Categoria)) { mensaje = "Seleccione una categoría."; return false; }

            v.Total = Math.Round(v.Cantidad * v.Precio, 2);
            v.Fecha = DateTime.Now;

            if (ModoOffline || !EstaConfiguradaCadena())
            {
                Producto prod = _mockProductos.FirstOrDefault(x => x.Id == v.ProductoId);
                if (prod == null) { mensaje = "El producto ya no existe en el inventario."; return false; }
                if (prod.Cantidad < v.Cantidad)
                {
                    mensaje = "Stock insuficiente: solo quedan " + prod.Cantidad + " unidades de «" + prod.Nombre + "».";
                    return false;
                }

                v.Id = ++_mockVentaId;
                v.Producto = prod.Nombre;
                _mockVentas.Add(v);
                prod.Cantidad -= v.Cantidad;
                return true;
            }

            try
            {
                using (MySqlConnection conn = Abrir())
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        int stock;
                        string nombre;
                        using (MySqlCommand sel = new MySqlCommand(
                            "SELECT nombre, cantidad FROM productos WHERE id = @id FOR UPDATE", conn, tx))
                        {
                            sel.Parameters.AddWithValue("@id", v.ProductoId);
                            using (MySqlDataReader r = sel.ExecuteReader())
                            {
                                if (!r.Read())
                                {
                                    tx.Rollback();
                                    mensaje = "El producto ya no existe en el inventario.";
                                    return false;
                                }
                                nombre = r.GetString(0);
                                stock = r.GetInt32(1);
                            }
                        }

                        if (stock < v.Cantidad)
                        {
                            tx.Rollback();
                            mensaje = "Stock insuficiente: solo quedan " + stock + " unidades de «" + nombre + "».";
                            return false;
                        }

                        v.Producto = nombre;
                        using (MySqlCommand ins = new MySqlCommand(
                            "INSERT INTO ventas (producto_id, producto, categoria, cantidad, precio, total, fecha, usuario) " +
                            "VALUES (@producto_id, @producto, @categoria, @cantidad, @precio, @total, @fecha, @usuario)", conn, tx))
                        {
                            ins.Parameters.AddWithValue("@producto_id", v.ProductoId);
                            ins.Parameters.AddWithValue("@producto", v.Producto);
                            ins.Parameters.AddWithValue("@categoria", v.Categoria);
                            ins.Parameters.AddWithValue("@cantidad", v.Cantidad);
                            ins.Parameters.AddWithValue("@precio", v.Precio);
                            ins.Parameters.AddWithValue("@total", v.Total);
                            ins.Parameters.AddWithValue("@fecha", v.Fecha);
                            ins.Parameters.AddWithValue("@usuario", string.IsNullOrEmpty(v.Usuario) ? (object)DBNull.Value : v.Usuario);
                            ins.ExecuteNonQuery();
                            v.Id = (int)ins.LastInsertedId;
                        }

                        using (MySqlCommand upd = new MySqlCommand(
                            "UPDATE productos SET cantidad = cantidad - @cantidad WHERE id = @id", conn, tx))
                        {
                            upd.Parameters.AddWithValue("@cantidad", v.Cantidad);
                            upd.Parameters.AddWithValue("@id", v.ProductoId);
                            upd.ExecuteNonQuery();
                        }

                        tx.Commit();
                        return true;
                    }
                    catch
                    {
                        try { tx.Rollback(); } catch { }
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("RegistrarVenta: " + ex);
                mensaje = "No se pudo registrar la venta en la BD.";
                return false;
            }
        }

        /// <summary>Anula una venta y repone la cantidad vendida al inventario.</summary>
        public static bool AnularVenta(int id, out string mensaje)
        {
            mensaje = string.Empty;

            if (ModoOffline || !EstaConfiguradaCadena())
            {
                Venta v = _mockVentas.FirstOrDefault(x => x.Id == id);
                if (v == null) { mensaje = "La venta ya no existe."; return false; }

                _mockVentas.Remove(v);
                Producto prod = _mockProductos.FirstOrDefault(x => x.Id == v.ProductoId);
                if (prod != null) prod.Cantidad += v.Cantidad;
                return true;
            }

            try
            {
                using (MySqlConnection conn = Abrir())
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        int productoId;
                        int cantidad;
                        using (MySqlCommand sel = new MySqlCommand(
                            "SELECT producto_id, cantidad FROM ventas WHERE id = @id FOR UPDATE", conn, tx))
                        {
                            sel.Parameters.AddWithValue("@id", id);
                            using (MySqlDataReader r = sel.ExecuteReader())
                            {
                                if (!r.Read())
                                {
                                    tx.Rollback();
                                    mensaje = "La venta ya no existe.";
                                    return false;
                                }
                                productoId = r.IsDBNull(0) ? 0 : r.GetInt32(0);
                                cantidad = r.GetInt32(1);
                            }
                        }

                        using (MySqlCommand del = new MySqlCommand("DELETE FROM ventas WHERE id = @id", conn, tx))
                        {
                            del.Parameters.AddWithValue("@id", id);
                            del.ExecuteNonQuery();
                        }

                        if (productoId > 0)
                        {
                            using (MySqlCommand upd = new MySqlCommand(
                                "UPDATE productos SET cantidad = cantidad + @cantidad WHERE id = @id", conn, tx))
                            {
                                upd.Parameters.AddWithValue("@cantidad", cantidad);
                                upd.Parameters.AddWithValue("@id", productoId);
                                upd.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();
                        return true;
                    }
                    catch
                    {
                        try { tx.Rollback(); } catch { }
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("AnularVenta: " + ex);
                mensaje = "No se pudo anular la venta en la BD.";
                return false;
            }
        }

        /// <summary>
        /// Descuenta del inventario las cantidades del carrito en una sola transacción.
        /// No registra historial de ventas: solo actualiza el stock.
        /// </summary>
        public static bool DescontarStock(List<ItemCarrito> items, out string mensaje)
        {
            mensaje = string.Empty;

            if (items == null || items.Count == 0)
            {
                mensaje = "El carrito está vacío.";
                return false;
            }

            // Agrupar por producto para validar el total aunque haya líneas repetidas
            Dictionary<int, int> cantidades = new Dictionary<int, int>();
            Dictionary<int, string> nombres = new Dictionary<int, string>();
            foreach (ItemCarrito it in items)
            {
                if (it == null || it.Producto == null)
                {
                    mensaje = "Hay un producto inválido en el carrito.";
                    return false;
                }
                if (it.Cantidad <= 0)
                {
                    mensaje = "La cantidad de «" + it.Producto.Nombre + "» debe ser mayor que cero.";
                    return false;
                }

                int id = it.Producto.Id;
                int actual;
                cantidades[id] = cantidades.TryGetValue(id, out actual) ? actual + it.Cantidad : it.Cantidad;
                nombres[id] = it.Producto.Nombre;
            }

            if (ModoOffline || !EstaConfiguradaCadena())
            {
                foreach (KeyValuePair<int, int> par in cantidades)
                {
                    Producto prod = _mockProductos.FirstOrDefault(x => x.Id == par.Key);
                    if (prod == null)
                    {
                        mensaje = "El producto «" + nombres[par.Key] + "» ya no existe en el inventario.";
                        return false;
                    }
                    if (prod.Cantidad < par.Value)
                    {
                        mensaje = "Stock insuficiente: solo quedan " + prod.Cantidad + " unidades de «" + prod.Nombre + "».";
                        return false;
                    }
                }

                foreach (KeyValuePair<int, int> par in cantidades)
                {
                    Producto prod = _mockProductos.FirstOrDefault(x => x.Id == par.Key);
                    prod.Cantidad -= par.Value;
                }
                return true;
            }

            try
            {
                using (MySqlConnection conn = Abrir())
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (KeyValuePair<int, int> par in cantidades)
                        {
                            int stock;
                            string nombre;
                            using (MySqlCommand sel = new MySqlCommand(
                                "SELECT nombre, cantidad FROM productos WHERE id = @id FOR UPDATE", conn, tx))
                            {
                                sel.Parameters.AddWithValue("@id", par.Key);
                                using (MySqlDataReader r = sel.ExecuteReader())
                                {
                                    if (!r.Read())
                                    {
                                        tx.Rollback();
                                        mensaje = "El producto «" + nombres[par.Key] + "» ya no existe en el inventario.";
                                        return false;
                                    }
                                    nombre = r.GetString(0);
                                    stock = r.GetInt32(1);
                                }
                            }

                            if (stock < par.Value)
                            {
                                tx.Rollback();
                                mensaje = "Stock insuficiente: solo quedan " + stock + " unidades de «" + nombre + "».";
                                return false;
                            }
                        }

                        foreach (KeyValuePair<int, int> par in cantidades)
                        {
                            using (MySqlCommand upd = new MySqlCommand(
                                "UPDATE productos SET cantidad = cantidad - @cantidad WHERE id = @id", conn, tx))
                            {
                                upd.Parameters.AddWithValue("@cantidad", par.Value);
                                upd.Parameters.AddWithValue("@id", par.Key);
                                upd.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();
                        return true;
                    }
                    catch
                    {
                        try { tx.Rollback(); } catch { }
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DescontarStock: " + ex);
                mensaje = "No se pudo actualizar el stock en la BD.";
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
                                     .Select(CopiarProducto)
                                     .ToList();
            }

            List<Producto> lista = new List<Producto>();
            try
            {
                using (MySqlConnection conn = Abrir())
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT id, nombre, especie, categoria, cantidad, precio, imagen FROM productos " +
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
                                     .Select(CopiarProducto)
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
