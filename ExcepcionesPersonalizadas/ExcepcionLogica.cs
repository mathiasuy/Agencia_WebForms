using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesPersonalizadas
{
    public class ExcepcionLogica : ExcepcionSistema
    {
        public ExcepcionLogica()
        {
        }

        public ExcepcionLogica(string mensaje)
            :base(mensaje)
        {
        }
    }
}
