USE Veterinaria;

-- =========================================================
-- 1. TOTAL DE TABLAS
-- Esperado: 9
-- =========================================================

SELECT COUNT(*) AS total_tablas
FROM information_schema.tables
WHERE table_schema = 'Veterinaria'
  AND table_type = 'BASE TABLE';


-- =========================================================
-- 2. NOMBRES DE LAS 9 TABLAS
-- =========================================================

SELECT table_name
FROM information_schema.tables
WHERE table_schema = 'Veterinaria'
  AND table_type = 'BASE TABLE'
ORDER BY table_name;


-- =========================================================
-- 3. CLAVES PRIMARIAS
-- Esperado: 9 PK
-- =========================================================

SELECT
    table_name,
    column_name
FROM information_schema.key_column_usage
WHERE table_schema = 'Veterinaria'
  AND constraint_name = 'PRIMARY'
ORDER BY table_name;


-- =========================================================
-- 4. LLAVES FORÁNEAS
-- Esperado: 8 FK
-- =========================================================

SELECT
    table_name,
    column_name,
    constraint_name,
    referenced_table_name,
    referenced_column_name
FROM information_schema.key_column_usage
WHERE table_schema = 'Veterinaria'
  AND referenced_table_name IS NOT NULL
ORDER BY table_name, column_name;


-- =========================================================
-- 5. REGLAS DE INTEGRIDAD REFERENCIAL
-- Esperado en P5:
-- UPDATE = CASCADE
-- DELETE = RESTRICT
-- =========================================================

SELECT
    table_name,
    constraint_name,
    referenced_table_name,
    update_rule,
    delete_rule
FROM information_schema.referential_constraints
WHERE constraint_schema = 'Veterinaria'
ORDER BY table_name, constraint_name;


-- =========================================================
-- 6. CONTEO INFORMATIVO DE REGISTROS
-- Un valor 0 NO significa automáticamente que exista un error.
-- Por ejemplo, usuario puede estar vacío en los datos de prueba.
-- =========================================================

SELECT 'rol' AS tabla, COUNT(*) AS filas
FROM rol

UNION ALL
SELECT 'usuario', COUNT(*)
FROM usuario

UNION ALL
SELECT 'cliente', COUNT(*)
FROM cliente

UNION ALL
SELECT 'mascota', COUNT(*)
FROM mascota

UNION ALL
SELECT 'veterinario', COUNT(*)
FROM veterinario

UNION ALL
SELECT 'consulta', COUNT(*)
FROM consulta

UNION ALL
SELECT 'receta', COUNT(*)
FROM receta

UNION ALL
SELECT 'medicamento', COUNT(*)
FROM medicamento

UNION ALL
SELECT 'detalle_receta', COUNT(*)
FROM detalle_receta;


-- =========================================================
-- 7. CLIENTES
-- =========================================================

SELECT
    id_cliente,
    nombre,
    apellido_paterno,
    telefono,
    correo
FROM cliente
ORDER BY id_cliente;


-- =========================================================
-- 8. MASCOTAS CON PROPIETARIO
-- =========================================================

SELECT
    m.id_mascota,
    m.nombre AS mascota,
    m.especie,
    m.raza,
    CONCAT(
        c.nombre,
        ' ',
        c.apellido_paterno
    ) AS propietario
FROM mascota m
INNER JOIN cliente c
    ON c.id_cliente = m.id_cliente
ORDER BY m.id_mascota;


-- =========================================================
-- 9. MASCOTAS CON CONSULTAS
-- Max debe conservar al menos su consulta de datos iniciales.
-- =========================================================

SELECT
    m.id_mascota,
    m.nombre AS mascota,
    COUNT(q.id_consulta) AS consultas
FROM mascota m
LEFT JOIN consulta q
    ON q.id_mascota = m.id_mascota
GROUP BY
    m.id_mascota,
    m.nombre
ORDER BY m.id_mascota;


-- =========================================================
-- 10. DATOS TEMPORALES DE ACEPTACIÓN
-- Al finalizar A-13 y A-14, ambas consultas deben devolver 0 filas.
-- =========================================================

SELECT *
FROM cliente
WHERE correo = 'prueba.p7@local.test';

SELECT *
FROM mascota
WHERE nombre = 'PixelP7';