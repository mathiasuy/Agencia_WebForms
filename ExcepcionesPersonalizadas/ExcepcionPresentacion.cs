using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesPersonalizadas
{
    public class ExcepcionPresentacion : ExcepcionSistema
    {
        public ExcepcionPresentacion()
        {
        }

        public ExcepcionPresentacion(string mensaje)
            :base(mensaje)
        {
        }
    }
}
