-- ========================================================
-- Script de Base de Datos para el Sistema Acuario
-- Compatible con MySQL / MariaDB / Aiven MySQL
-- ========================================================

CREATE DATABASE IF NOT EXISTS defaultdb;
USE defaultdb;

-- Tabla de Usuarios para el Inicio de Sesión
CREATE TABLE IF NOT EXISTS usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    usuario VARCHAR(50) NOT NULL UNIQUE,
    clave VARCHAR(100) NOT NULL
);

-- Tabla de Productos para el Inventario
CREATE TABLE IF NOT EXISTS productos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    especie VARCHAR(50) NOT NULL,
    cantidad INT NOT NULL DEFAULT 0,
    precio DECIMAL(10,2) NOT NULL DEFAULT 0.00,
    imagen VARCHAR(255) NULL
);

-- Usuarios por defecto
INSERT IGNORE INTO usuarios (usuario, clave) VALUES
('admin', 'admin'),
('admin', '1234'),
('diego', '1234');

-- Productos iniciales de ejemplo
INSERT INTO productos (nombre, especie, cantidad, precio, imagen)
SELECT * FROM (
    SELECT 1 AS id, 'Pez Betta Corona' AS nombre, 'Betta Splendens' AS especie, 15 AS cantidad, 12.50 AS precio, '' AS imagen
    UNION ALL SELECT 2, 'Pez Payaso Ocellaris', 'Amphiprion ocellaris', 8, 25.00, ''
    UNION ALL SELECT 3, 'Tetra Neón', 'Paracheirodon innesi', 45, 2.50, ''
    UNION ALL SELECT 4, 'Pez Cirujano Azul', 'Paracanthurus hepatus', 3, 65.00, ''
    UNION ALL SELECT 5, 'Guppy Fancy', 'Poecilia reticulata', 30, 3.00, ''
    UNION ALL SELECT 6, 'Pez Disco Turquesa', 'Symphysodon', 2, 85.00, ''
    UNION ALL SELECT 7, 'Escalar Mármol', 'Pterophyllum scalare', 12, 14.00, ''
    UNION ALL SELECT 8, 'Corydora Panda', 'Corydoras panda', 20, 5.50, ''
) AS tmp
WHERE NOT EXISTS (SELECT 1 FROM productos LIMIT 1);
