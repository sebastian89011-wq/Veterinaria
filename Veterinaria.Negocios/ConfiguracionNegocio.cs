using Veterinaria.Datos;

namespace Veterinaria.Negocios;

public static class ConfiguracionNegocio
{
    public static void Inicializar(string cadenaConexion)
    {
        Conexion.Configurar(cadenaConexion);
    }

    public static int ProbarConexion()
    {
        return Conexion.Probar();
    }
}