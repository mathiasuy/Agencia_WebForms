using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesPersonalizadas
{
    public class ExcepcionPersistencia : ExcepcionSistema
        {
            public ExcepcionPersistencia()
            {
            }

            public ExcepcionPersistencia(string mensaje)
                :base(mensaje)
            {
        }
    }
}
