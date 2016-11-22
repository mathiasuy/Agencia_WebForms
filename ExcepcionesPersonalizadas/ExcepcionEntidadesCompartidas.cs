using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesPersonalizadas
{
    public class ExcepcionEntidadesCompartidas : ExcepcionSistema
    {
            public ExcepcionEntidadesCompartidas()
            {
            }

            public ExcepcionEntidadesCompartidas(string mensaje)
                : base(mensaje)
            {
            }
    }
}
