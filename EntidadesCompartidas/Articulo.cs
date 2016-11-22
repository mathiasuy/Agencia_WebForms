using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntidadesCompartidas
{
    public class Articulo
    {
        private int _id;
        private string _seccion;
        private bool _imagenIlustrativa;
        private decimal _costo;
        private string _contenido;

        private Fuente _fuente;

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

        public string Seccion
        {
            get
            {
                return _seccion;
            }

            set
            {
                _seccion = value;
            }
        }

        public bool ImagenIlustrativa
        {
            get
            {
                return _imagenIlustrativa;
            }

            set
            {
                _imagenIlustrativa = value;
            }
        }

        public decimal Costo
        {
            get
            {
                return _costo;
            }

            set
            {
                _costo = value;
            }
        }

        public string Contenido
        {
            get
            {
                return _contenido;
            }

            set
            {
                _contenido = value;
            }
        }

        public Fuente Fuente
        {
            get
            {
                return _fuente;
            }

            set
            {
                _fuente = value;
            }
        }

        public string ATexto
        {
            get
            {
                return ToString();
            }
        }

        public Articulo()
            : this(0, "N/D", false, 0, "N/D", new Periodista())
        {
        }

        public Articulo(int _id, string seccion, bool imagenIlustrativa, decimal costo, string contenido, Fuente fuente)
        {
            Id = _id;
            Seccion = seccion;
            ImagenIlustrativa = imagenIlustrativa;
            Costo = costo;
            Contenido = contenido;
            Fuente = fuente;
        }

        public override string ToString()
        {
            return "Id: " + Id + ", Fuente: " + Fuente.Nombre + ", Sección: " + Seccion + ", Imagen ilustrativa: " + (ImagenIlustrativa ? "Sí" : "No") + ", Costo: " + Costo;
        }
    }
}
