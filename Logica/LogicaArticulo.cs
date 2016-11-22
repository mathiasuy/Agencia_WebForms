using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LogicaArticulo
    {
        public static Articulo BuscarArticulo(int id)
        {
            Articulo a = PersistenciaArticulo.BuscarArticulo(id);
            if (a == null)
                throw new ExcepcionLogica("No se encontró el artículo.");
            return a;
        }

        public static void DarAltaArticulo(Articulo a,out int ide)
        {
            ValidarArticulo(a);

            List<Articulo> articulos = LogicaArticulo.ListarArticulos();

            bool perteneceArticulo = false;

            foreach (Articulo ar in articulos)
            {
                if (ar.Id == a.Id)
                {
                    perteneceArticulo = true;

                    break;
                }
            }

            if (perteneceArticulo) throw new ExcepcionLogica("El artículo ya pertenece a la edicion.");

            if (Persistencia.PersistenciaArticulo.AltaArticulo(a, out ide) == -1)
            {
                throw new ExcepcionLogica("Ya hay un artículo con ese identificador.");
            }
        }

        public static void DarBajaArticulo(int id)
        {
            if (id <= 0)
            {
                throw new ExcepcionLogica("El Id de Articulo no es válido, debe ser mayor que cero.");
            }
            int resultado = PersistenciaArticulo.BajaArticulo(id);
            if (resultado == -1)
                throw new ExcepcionLogica("No se encontró un Artículo con ese identificador.");
            else if (resultado == -3)
                throw new ExcepcionLogica("El Artículo pertenece a 1 o más ediciónes en la base de datos, no se puede eliminar.");
         }

        public static void ModificarArticulo(Articulo a)
        {
            ValidarArticulo(a);
            if (a.Id <= 0)
            {
                throw new ExcepcionLogica("El Id de Articulo no es válido, debe ser mayor que cero.");
            }
            if (PersistenciaArticulo.ModificarArticulo(a) == -1)
            {
                throw new ExcepcionLogica("No se encontró el Articulo");
            }
        }

        public static List<Articulo> ListarArticulos()
        {
            return PersistenciaArticulo.ListarArticulos();
        }

        public static List<Articulo> ListarArticulosXFuente(int IdF)
        {
            return PersistenciaArticulo.ListarArticulosXFuente(IdF);
        }


        public static void ValidarArticulo(Articulo a)
        {
            if (a == null)
            {
                throw new ExcepcionLogica("El Articulo es nula.");
            }

            if (a.Fuente == null)
            {
                throw new ExcepcionLogica("Debe seleccionar una fuente.");
            }

            if (string.IsNullOrWhiteSpace(a.Seccion))
            {
                throw new ExcepcionLogica("Debe proporcionar una sección.");
            }

            if (string.IsNullOrWhiteSpace(a.Contenido))
            {
                throw new ExcepcionLogica("Debe proporcionar un contenido.");
            }

            if (a.Costo < 0)
            {
                throw new ExcepcionLogica("El costo del artículo no puede ser negativo.");
            }
        }
    }
}
