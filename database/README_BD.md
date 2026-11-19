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