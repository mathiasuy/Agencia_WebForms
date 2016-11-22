using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntidadesCompartidas
{
    public class Edicion
    {
        private int _numero;
        private DateTime _fechaPublicacion;

        private List<Articulo> _articulos;

        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        public DateTime FechaPublicacion
        {
            get
            {
                return _fechaPublicacion;
            }

            set
            {
                _fechaPublicacion = value;
            }
        }

        public Edicion()
            : this(1, DateTime.Today)
        {
        }

        public Edicion(int numero, DateTime fechaPublicacion)
        {
            Numero = numero;
            FechaPublicacion = fechaPublicacion;

            _articulos = new List<Articulo>();
        }

        public Articulo BuscarArticulo(int id)
        {
            Articulo articuloEncontrado = null;

            foreach (Articulo a in _articulos)
            {
                if (a.Id == id)
                {
                    articuloEncontrado = a;

                    break;
                }
            }

            return articuloEncontrado;
        }

        public void AgregarArticulo(Articulo articulo)
        {
                _articulos.Add(articulo);
        }

        public void LimpiarArticulos()
        {
            _articulos.Clear();
        }

        public List<Articulo> ListarArticulos()
        {
            return _articulos.ToList<Articulo>();
        }

        public override string ToString()
        {
            return "Número: " + Numero + ", Fecha de publicación: " + FechaPublicacion;
        }
    }
}
