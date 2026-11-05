USE Veterinaria;

-- PRUEBA 1. Clientes
SELECT *
FROM cliente
ORDER BY apellido_paterno, nombre;

-- PRUEBA 2. Cliente y sus mascotas
SELECT
    c.id_cliente,
    CONCAT(c.nombre, ' ', c.apellido_paterno) AS cliente,
    m.id_mascota,
    m.nombre AS mascota,
    m.especie,
    m.raza
FROM cliente c
INNER JOIN mascota m
    ON c.id_cliente = m.id_cliente
ORDER BY c.id_cliente, m.nombre;

-- PRUEBA 3. Expediente básico
SELECT
    m.nombre AS mascota,
    c.fecha,
    c.peso,
    c.temperatura,
    c.sintomas,
    c.diagnostico,
    c.tratamiento
FROM mascota m
INNER JOIN consulta c
    ON m.id_mascota = c.id_mascota
WHERE m.id_mascota = 1;

-- PRUEBA 4. Receta con medicamentos
SELECT
    m.nombre AS mascota,
    med.nombre AS medicamento,
    dr.dosis,
    dr.frecuencia,
    dr.duracion
FROM mascota m
INNER JOIN consulta c
    ON m.id_mascota = c.id_mascota
INNER JOIN receta r
    ON c.id_consulta = r.id_consulta
INNER JOIN detalle_receta dr
    ON r.id_receta = dr.id_receta
INNER JOIN medicamento med
    ON dr.id_medicamento = med.id_medicamento
WHERE m.id_mascota = 1;

-- PRUEBA 5. Integridad referencial.
-- Ejecutar esta sentencia POR SEPARADO.
-- Debe producir error porque el cliente 999 no existe.
--
-- INSERT INTO mascota
-- (id_cliente, nombre, especie)
-- VALUES
-- (999, 'Prueba', 'Perro');