DROP DATABASE IF EXISTS Veterinaria;

CREATE DATABASE Veterinaria
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;

USE Veterinaria;

CREATE TABLE rol
(
    id_rol INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL UNIQUE,
    descripcion VARCHAR(150)
);

CREATE TABLE cliente
(
    id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(60) NOT NULL,
    apellido_paterno VARCHAR(60) NOT NULL,
    apellido_materno VARCHAR(60),
    telefono VARCHAR(20) NOT NULL,
    correo VARCHAR(120),
    direccion VARCHAR(200),
    fecha_registro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE veterinario
(
    id_veterinario INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(60) NOT NULL,
    apellido_paterno VARCHAR(60) NOT NULL,
    apellido_materno VARCHAR(60),
    cedula VARCHAR(30) NOT NULL UNIQUE,
    especialidad VARCHAR(100),
    telefono VARCHAR(20),
    correo VARCHAR(120)
);

CREATE TABLE usuario
(
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    id_rol INT NOT NULL,
    id_veterinario INT NULL,
    nombre_completo VARCHAR(120) NOT NULL,
    nombre_usuario VARCHAR(50) NOT NULL UNIQUE,
    contrasena VARCHAR(255) NOT NULL, -- guardar HASH, nunca contraseña en texto plano
    correo VARCHAR(120),
    fecha_registro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,

    CONSTRAINT fk_usuario_rol
        FOREIGN KEY (id_rol)
        REFERENCES rol(id_rol)
        ON UPDATE CASCADE
        ON DELETE RESTRICT,

    CONSTRAINT fk_usuario_veterinario
        FOREIGN KEY (id_veterinario)
        REFERENCES veterinario(id_veterinario)
        ON UPDATE CASCADE
        ON DELETE RESTRICT,

    CONSTRAINT uq_usuario_veterinario
        UNIQUE (id_veterinario)
);

CREATE TABLE mascota
(
    id_mascota INT AUTO_INCREMENT PRIMARY KEY,
    id_cliente INT NOT NULL,
    nombre VARCHAR(60) NOT NULL,
    especie VARCHAR(40) NOT NULL,
    raza VARCHAR(60),
    sexo VARCHAR(15),
    fecha_nacimiento DATE,
    color VARCHAR(50),
    senas_particulares VARCHAR(200),

    CONSTRAINT fk_mascota_cliente
        FOREIGN KEY (id_cliente)
        REFERENCES cliente(id_cliente)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
);

CREATE TABLE consulta
(
    id_consulta INT AUTO_INCREMENT PRIMARY KEY,
    id_mascota INT NOT NULL,
    id_veterinario INT NOT NULL,
    fecha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    motivo_consulta VARCHAR(250),
    peso DECIMAL(6,2),
    temperatura DECIMAL(4,1),
    sintomas TEXT,
    diagnostico TEXT,
    tratamiento TEXT,
    observaciones TEXT,

    CONSTRAINT fk_consulta_mascota
        FOREIGN KEY (id_mascota)
        REFERENCES mascota(id_mascota)
        ON UPDATE CASCADE
        ON DELETE RESTRICT,

    CONSTRAINT fk_consulta_veterinario
        FOREIGN KEY (id_veterinario)
        REFERENCES veterinario(id_veterinario)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
);

CREATE TABLE receta
(
    id_receta INT AUTO_INCREMENT PRIMARY KEY,
    id_consulta INT NOT NULL UNIQUE,
    fecha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    indicaciones_generales TEXT,

    CONSTRAINT fk_receta_consulta
        FOREIGN KEY (id_consulta)
        REFERENCES consulta(id_consulta)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
);

CREATE TABLE medicamento
(
    id_medicamento INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    presentacion VARCHAR(100),
    concentracion VARCHAR(60)
);

CREATE TABLE detalle_receta
(
    id_detalle INT AUTO_INCREMENT PRIMARY KEY,
    id_receta INT NOT NULL,
    id_medicamento INT NOT NULL,
    dosis VARCHAR(80) NOT NULL,
    frecuencia VARCHAR(80),
    duracion VARCHAR(80),
    via_administracion VARCHAR(60),
    indicaciones VARCHAR(250),

    CONSTRAINT fk_detalle_receta
        FOREIGN KEY (id_receta)
        REFERENCES receta(id_receta)
        ON UPDATE CASCADE
        ON DELETE RESTRICT,

    CONSTRAINT fk_detalle_medicamento
        FOREIGN KEY (id_medicamento)
        REFERENCES medicamento(id_medicamento)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
);