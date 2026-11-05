# Base de datos Veterinaria

## Orden de ejecución

1. 00_crear_bd.sql
2. 01_datos_prueba.sql
3. 02_pruebas.sql

## Importante

La base de datos local NO se sincroniza automáticamente con GitHub.

GitHub conserva los scripts SQL. Cada integrante puede reconstruir
la misma base ejecutando los archivos en el orden indicado.

ADVERTENCIA:
00_crear_bd.sql contiene DROP DATABASE IF EXISTS Veterinaria.
Al ejecutarlo se elimina la base local Veterinaria y se crea nuevamente.