using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.RegularExpressions;

namespace EntidadesCompartidas
{
    public class Periodista : Fuente
    {
        private string _documentoIdentidad;
        private string _direccion;
        private string _telefono;

        public string DocumentoIdentidad
        {
            get
            {
                return _documentoIdentidad;
            }

            set
            {
                _documentoIdentidad = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                _direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
        }

        public Periodista()
            : this(1, "N/D", "0.000.000-0", string.Empty, string.Empty)
        {
        }

        public Periodista(int id, string nombre, string documentoIdentidad, string direccion, string telefono)
            : base(id, nombre)
        {
            DocumentoIdentidad = documentoIdentidad;
            Direccion = direccion;
            Telefono = telefono;
        }

        public override string ToString()
        {
            return base.ToString() + ", Documento de identidad: " + DocumentoIdentidad + ", Dirección: " + Direccion + ", Teléfono: " + Telefono;
        }
    }
}
