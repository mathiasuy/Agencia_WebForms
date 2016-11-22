using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LogicaFuente
    {

        public static void AltaFuente(Fuente fuente)
        {
            
            int resultado = 0;

            if (fuente is Periodista)
            {
                ValidarPeriodista(fuente);
                resultado = PersistenciaPeriodista.AltaPeriodista((Periodista)fuente);
            }
            else if (fuente is Agencia)
            {
                ValidarAgencia(fuente);
                resultado =  PersistenciaAgencia.AltaAgencia((Agencia)fuente);
            }
            else
            {
                throw new ExcepcionLogica("Fuente no reconocida.");
            }
            if (resultado == -1) throw new ExcepcionLogica("El identificador ya se encuentra en uso.");
            else if (resultado == -3) throw new ExcepcionLogica("El documento " + ((Periodista)fuente).DocumentoIdentidad + " ya existe en la base de datos.");
        }


        public static void ModificarFuente(Fuente fuente)
        {
            int resultado = 0;

            if (fuente is Periodista)
            {
                ValidarPeriodista(fuente);
                resultado = PersistenciaPeriodista.ModificarPeriodista((Periodista)fuente);
                if (resultado == -1)
                    throw new ExcepcionLogica("No se encontró un periodista con ese identificador.");
            }
            else if (fuente is Agencia)
            {
                ValidarAgencia(fuente);
                resultado =  PersistenciaAgencia.ModificarAgencia((Agencia)fuente);
                if (resultado == -1)
                    throw new ExcepcionLogica("No se encontró una Agencia con ese identificador.");
            }
            else
            {
                throw new ExcepcionLogica("Tipo de Fuente no reconocido.");
            }
        }


        public static void BajaPeriodista(int id)
        {
            int resultado =  PersistenciaPeriodista.BajaPeriodista(id);
            if (resultado == -1)
                throw new ExcepcionLogica("No se encontró un periodista con ese identificador.");
            else if (resultado == -3)
                throw new ExcepcionLogica("El periodista tiene artículos en la base de datos, no se puede eliminar.");
        }

        public static void BajaAgencia(int id)
        {
            int resultado = PersistenciaAgencia.BajaAgencia(id);
            if (resultado == -1)
                throw new ExcepcionLogica("No se encontró una Agencia con ese identificador.");
            else if (resultado == -3)
                throw new ExcepcionLogica("La Agencia tiene artículos en la base de datos, no se puede eliminar.");
 
        }

        public static Periodista BuscarPeriodista(int id)
        {
            Periodista p = PersistenciaPeriodista.BuscarPeriodista(id);
            if (p == null)
            {
                throw new ExcepcionLogica("No se encontró el periodista.");
            }
            return p;
        }

        public static Agencia BuscarAgencia(int id)
        {
            Agencia a = PersistenciaAgencia.BuscarAgencia(id);
            if (a == null)
            {
                throw new ExcepcionLogica("No se encontró la Agencia.");
            }
            return a;
        }

        public static Fuente BuscarFuente(int id)
        {
            Fuente f = PersistenciaPeriodista.BuscarPeriodista(id);
            if (f == null)
            {
                f = PersistenciaAgencia.BuscarAgencia(id);
            }
            return f;
        }

        public static List<Fuente> ListarFuentes()
        {
            List<Fuente> fuentes = Persistencia.PersistenciaAgencia.ListarAgencias();
            fuentes.AddRange(PersistenciaPeriodista.ListarPeriodistas());
            return fuentes;
        }

        public static void ValidarFuente(Fuente fuente)
        {
            if (fuente == null)
            {
                throw new ExcepcionLogica("La Fuente es nula.");
            }

            if (fuente.Id <= 0)
            {
                throw new ExcepcionLogica("La Id no es válida, debe ser mayor que cero.");
            }

            if (string.IsNullOrWhiteSpace(fuente.Nombre))
            {
                throw new ExcepcionLogica("Debe introducir un nombre.");
            }

            if (fuente.Nombre.Length > 50)
            {
                throw new ExcepcionLogica("El nombre no debe superar los 50 caracteres.");
            }
        }
        
        public static void ValidarPeriodista(Fuente fu)
        {
            ValidarFuente(fu);

            Periodista p = (Periodista)fu;

            if (string.IsNullOrWhiteSpace(p.Direccion))
            {
                throw new ExcepcionLogica("Debe proporcionar una Direccion para el Periodista.");
            }

            if (string.IsNullOrWhiteSpace(p.DocumentoIdentidad))
            {
                throw new ExcepcionLogica("Debe proporcionar un Documento.");
            }

            if (p.DocumentoIdentidad.Length > 9)
            {
                throw new ExcepcionLogica("El Documento del Periodista no es válido, debe contener menos caracteres.");
            }

            try
            {
                int n = Convert.ToInt32(p.DocumentoIdentidad);
            }
            catch
            {
                throw new ExcepcionLogica("Documento: Solo se permiten números.");
            }

            if (p.DocumentoIdentidad.Length < 8)
            {
                throw new ExcepcionLogica("El Documento del Periodista no es válido.");
            }

            if (p.Telefono.Length > 10)
            {
                throw new ExcepcionLogica("El Teléfono del Periodista no es válido, debe contener menos caracteres.");
            }

            try
            {
                int n = Convert.ToInt32(p.Telefono);
            }
            catch
            {
                throw new ExcepcionLogica("Teléfono: Solo se permiten números.");
            }          
 
            if (p.Telefono.Length < 0)
            {
                throw new ExcepcionLogica("El teléfono del Periodista no es válido.");
            }
        }

        public static void ValidarAgencia(Fuente fu)
        {
            ValidarFuente(fu);

            Agencia a = (Agencia)fu;

            if (string.IsNullOrWhiteSpace(a.PaisOrigen))
            {
                throw new ExcepcionLogica("Debe proporcionar un País de origen para la Agencia.");
            }
        }
    }
}
