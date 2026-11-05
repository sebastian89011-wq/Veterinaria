USE Veterinaria;

INSERT INTO rol (nombre, descripcion)
VALUES
('Administrador', 'Control general del sistema'),
('Secretaria', 'Gestión administrativa de clientes y mascotas'),
('Veterinario', 'Atención clínica y recetas');

INSERT INTO cliente
(nombre, apellido_paterno, apellido_materno,
 telefono, correo, direccion)
VALUES
('Ana', 'López', 'García',
 '6461234567', 'ana@correo.com', 'Ensenada'),

('Carlos', 'Ramírez', 'Torres',
 '6467654321', 'carlos@correo.com', 'Ensenada');

INSERT INTO mascota
(id_cliente, nombre, especie, raza,
 sexo, fecha_nacimiento, color, senas_particulares)
VALUES
(1, 'Max', 'Perro', 'Labrador',
 'Macho', '2021-04-15', 'Dorado', NULL),

(1, 'Luna', 'Gato', 'Siamés',
 'Hembra', '2022-08-10', 'Crema', NULL),

(2, 'Rocky', 'Perro', 'Pastor Alemán',
 'Macho', '2020-06-20', 'Negro y café', NULL);

INSERT INTO veterinario
(nombre, apellido_paterno, apellido_materno,
 cedula, especialidad, telefono, correo)
VALUES
('Laura', 'Martínez', NULL,
 'VET-001', 'Medicina general',
 '6461112233', 'laura@veterinaria.com');

INSERT INTO consulta
(id_mascota, id_veterinario, fecha,
 motivo_consulta, peso, temperatura,
 sintomas, diagnostico, tratamiento)
VALUES
(1, 1, '2026-10-20 10:00:00',
 'Falta de apetito', 28.50, 39.1,
 'Falta de apetito',
 'Infección gastrointestinal',
 'Hidratación y medicamento');

INSERT INTO receta
(id_consulta, indicaciones_generales)
VALUES
(1, 'Administrar medicamentos con alimento.');

INSERT INTO medicamento
(nombre, presentacion, concentracion)
VALUES
('Amoxicilina', 'Tabletas', '250 mg'),
('Probiótico veterinario', 'Sobres', '5 g');

INSERT INTO detalle_receta
(id_receta, id_medicamento,
 dosis, frecuencia, duracion,
 via_administracion, indicaciones)
VALUES
(1, 1, '250 mg', 'Cada 12 horas',
 '7 días', 'Oral', 'Después de alimento'),

(1, 2, '1 sobre', 'Cada 24 horas',
 '5 días', 'Oral', 'Mezclar con alimento');