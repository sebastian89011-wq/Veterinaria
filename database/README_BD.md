# Base de datos Veterinaria

## Orden de ejecución

1. 00_crear_bd.sql
2. 01_datos_prueba.sql
3. 02_pruebas.sql
4. 03_verificacion_p6.sql

## Importante

La base de datos local NO se sincroniza automáticamente con GitHub.

GitHub conserva los scripts SQL. Cada integrante puede reconstruir
la misma base ejecutando los archivos en el orden indicado.

ADVERTENCIA:
00_crear_bd.sql contiene DROP DATABASE IF EXISTS Veterinaria.
Al ejecutarlo se elimina la base local Veterinaria y se crea nuevamente.

03_verificacion_p6.sql
Este script NO crea nuevamente la base.
Se utiliza para comprobar las operaciones realizadas
desde la aplicación Web durante la Práctica 6.

## Práctica 7

Archivo agregado:

- 04_verificacion_final_p7.sql

Finalidad:
comprobar el estado final de la base
durante las pruebas de aceptación,
incluyendo las 9 tablas, sus PK, sus FK
y las reglas de integridad referencial.

Orden recomendado:

1. 00_crear_bd.sql
2. 01_datos_prueba.sql
3. 02_pruebas.sql
4. 03_verificacion_p6.sql
5. 04_verificacion_final_p7.sql

## Respaldo final

scripts
00_crear_bd.sql
01_datos_prueba.sql
02_pruebas.sql
03_verificacion_p6.sql
04_verificacion_final_p7.sql

orden de ejecución
00, 01, 02, 03, 04

DROP DATABASE

04_verificacion_final_p7.sql
Se deben de mostrar las 9 filas con 9 PKs y 8 FKs junto con los datos de prueba

respaldo final
backup/respaldo_veterinaria_p7.sql

procedimiento de restauración
Ejecutar
backup/respaldo_veterinaria_p7.sql

resultado de verificación de 9 tablas

resultado de 9 PK y 8 FK
cliente	id_cliente
consulta	id_consulta
detalle_receta	id_detalle
mascota	id_mascota
medicamento	id_medicamento
receta	id_receta
rol	id_rol
usuario	id_usuario
veterinario	id_veterinario

consulta	id_mascota	fk_consulta_mascota
consulta	id_veterinario	fk_consulta_veterinario
detalle_receta	id_medicamento	fk_detalle_medicamento
detalle_receta	id_receta	fk_detalle_receta
mascota	id_cliente	fk_mascota_cliente
receta	id_consulta	fk_receta_consulta
usuario	id_rol	fk_usuario_rol
usuario	id_veterinario	fk_usuario_veterinario

Archivo:
`backups/respaldo_veterinaria_p7.sql`

Estado:
generado después de aprobar P7.

Restauración:
- si el dump incluye CREATE DATABASE, ejecutarlo directamente;
- si no lo incluye, ejecutar antes `00_crear_bd.sql`.