using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LogicaEdicion
    {
        public static Edicion BuscarEdicion(int numero)
        {
            Edicion e = PersistenciaEdicion.BuscarEdicion(numero);
            if (e == null) throw new ExcepcionLogica("No se encontró una edición con ese número");
            return e;
        }

        public static void AltaEdicion(Edicion e)
        {
            ValidarEdicion(e);
            int resultado = PersistenciaEdicion.AltaEdicion(e);
            if (resultado == -1)
            {
                throw new ExcepcionLogica("El número de edición ya está en uso.");
            }
            
            List<Articulo> articulos = e.ListarArticulos();

            foreach (Articulo a in articulos)
            {
                PersistenciaEdicion.AgregarAEdicion(e.Numero, a.Id);
            }
        }

        public static void BajaEdicion(int numero)
        {
            if (PersistenciaEdicion.BajaEdicion(numero) == -1)
            {
                throw new ExcepcionLogica("No existe esa edición.");
            }
        }

        public static void ModificarEdicion(Edicion e)
        {
            ValidarEdicion(e);
                LogicaEdicion.BajaEdicion(e.Numero);
                LogicaEdicion.AltaEdicion(e);
        }

        public static List<Edicion> ListarEdiciones()
        {
            return PersistenciaEdicion.ListarEdiciones();
        }

        public static List<Fuente> ListarAgenciasXEdicion(int numero)
        {
            List<Fuente> fuentes = null;
            fuentes = PersistenciaEdicion.ListarAgenciasXEdicion(numero);

            return fuentes;
        }

        public static List<Fuente> ListarPeriodistasXEdicion(int numero)
        {
            List<Fuente> fuentes = null;
            fuentes = PersistenciaEdicion.ListarPeriodistasXEdicion(numero);

            return fuentes;
        }

        public static List<Articulo> ListarArticulosXEdicion(int numero)
        {
            return PersistenciaEdicion.ListarArticulosXEdicion(numero);
        }

        public static void ValidarEdicion(Edicion e)
        {
            if (e == null)
            {
                throw new ExcepcionLogica("La Edicion es nula.");
            }

            if (e.Numero <= 0)
            {
                throw new ExcepcionLogica("El Numero de Edicion no es válido, debe ser mayor que cero.");
            }
            
            if (e.FechaPublicacion > DateTime.Today)
            {
                throw new ExcepcionLogica("La fecha de edicion es anterior a la de hoy.");
            }
        }
    }
}
