
-- 1. Clientes registrados
SELECT
    id_cliente,
    nombre,
    apellido_paterno,
    telefono,
    correo
FROM cliente
ORDER BY id_cliente;

-- 2. Mascotas y propietario
SELECT 
    m.id_mascota,
    m.nombre AS mascota,
    m.especie,
    m.raza,
    c.id_cliente,
    CONCAT(
        c.nombre,
        ' ',
        c.apellido_paterno
    ) AS propietario
FROM mascota m
INNER JOIN cliente c
    ON c.id_cliente = m.id_cliente
ORDER BY m.id_mascota;

-- 3. Cantidad de mascotas por cliente
SELECT
    c.id_cliente,
    CONCAT(
        c.nombre,
        ' ',
        c.apellido_paterno
    ) AS cliente,
    COUNT(m.id_mascota) AS total_mascotas
FROM cliente c
LEFT JOIN mascota m
    ON m.id_cliente = c.id_cliente
GROUP BY
    c.id_cliente,
    c.nombre,
    c.apellido_paterno
ORDER BY c.id_cliente;

-- 4. Datos utilizados en las pruebas de P6
SELECT *
FROM cliente
WHERE correo = 'prueba.p6@local.test';

SELECT *
FROM mascota
WHERE nombre = 'PixelP6';