using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntidadesCompartidas
{
    public class Agencia : Fuente
    {
        private string _paisOrigen;

        public string PaisOrigen
        {
            get
            {
                return _paisOrigen;
            }

            set
            {
                _paisOrigen = value;
            }
        }

        public Agencia()
            : this(1, "N/D", string.Empty)
        {
        }

        public Agencia(int id, string nombre, string paisOrigen)
            : base(id, nombre)
        {
            PaisOrigen = paisOrigen;
        }

        public override string ToString()
        {
            return base.ToString() + ", País de origen: " + PaisOrigen;
        }
    }
}
