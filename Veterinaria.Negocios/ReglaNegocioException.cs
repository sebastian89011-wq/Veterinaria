using System;
using System.Collections.Generic;
using System.Text;

namespace Veterinaria.Negocios;

public class ReglaNegocioException : Exception
{
    public ReglaNegocioException(string mensaje)
        : base(mensaje)
    {
    }
}