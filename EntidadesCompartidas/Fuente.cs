using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntidadesCompartidas
{
    public abstract class Fuente
    {
        private int _id;
        private string _nombre;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public Fuente()
            : this(1, "N/D")
        {
        }

        public Fuente(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return "Id: " + Id + ", Nombre: " + Nombre;
        }
    }
}
