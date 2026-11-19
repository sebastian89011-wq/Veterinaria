# Pruebas Backend

## Arquitectura

- Web sin SQL: Aprobado. En `Veterinaria.Web` no hay `SELECT`, `INSERT INTO`, `UPDATE` ni `DELETE FROM`.
- Web sin MySqlConnection: Aprobado. En `Veterinaria.Web` no hay `MySqlConnection`, `MySqlCommand` ni `MySqlDataReader`.
- Negocios usa Datos: Aprobado. `Veterinaria.Negocios` referencia a `Veterinaria.Datos`, y Web sólo referencia a Negocios y Entidades.
- Datos usa MySql.Data: Aprobado. `Veterinaria.Datos` usa el paquete `MySql.Data` 26.10.0.

## Reglas

- Cliente con Mascotas: Aprobado. Al eliminar el cliente 1 se muestra `No se puede eliminar el cliente porque tiene mascotas registradas.` y el registro se conserva.
- Mascota con Consultas: Aprobado. Al eliminar a Max (id 1) se muestra `No se puede eliminar la mascota porque tiene consultas registradas.` y el registro se conserva.
- Fecha futura: Aprobado. `Agregar` y `Modificar` rechazan la fecha de mañana con `La fecha de nacimiento no puede ser futura.` y no se guarda nada.

## Consultas parametrizadas

- ClienteDatos: Aprobado. Todos los valores usan parámetros (`@idCliente`, `@texto`, `@nombre`, `@apellidoPaterno`, `@apellidoMaterno`, `@telefono`, `@correo`, `@direccion`). Una búsqueda con `' OR '1'='1' -- ` no devuelve registros.
- MascotaDatos: Aprobado. Todos los valores usan parámetros (`@idMascota`, `@idCliente`, `@nombre`, `@especie`, `@raza`, `@sexo`, `@fechaNacimiento`, `@color`, `@senasParticulares`).

## Manejo de errores y conexión

- Errores técnicos: Aprobado. Sin conexión configurada, `Clientes/Eliminar` y `Mascotas/Eliminar` responden con un mensaje amigable, sin error 500 ni detalle técnico.
- `ReglaNegocioException`: Aprobado. Existe en `Veterinaria.Negocios` y la usan `ClienteNegocio` y `MascotaNegocio`.
- `Program.cs`: Aprobado. Lee `ConnectionStrings:Veterinaria`, no contiene contraseña, no duplica `CreateBuilder` ni `AddRazorPages`, y la aplicación arranca aunque falte la cadena.
- Compilación: Aprobado. 0 errores y 0 advertencias.

## Correcciones realizadas

- `MascotaNegocio.Validar`: se agregó el rechazo de fechas de nacimiento futuras.
- `Clientes/Eliminar.cshtml.cs`: la carga del cliente en `OnPost` quedó dentro del `try`.
- `Mascotas/Eliminar.cshtml.cs`: la carga de la mascota y su propietario en `OnPost` quedó dentro del `try`.
