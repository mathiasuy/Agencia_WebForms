using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesPersonalizadas
{
    public class ExcepcionSistema : ApplicationException
    {
        public ExcepcionSistema()
        {
        }

        public ExcepcionSistema(string mensaje)
            :base(mensaje)
        {
        }
    }
}
