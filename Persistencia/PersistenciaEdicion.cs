using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;

namespace Persistencia
{
    public class PersistenciaEdicion
    {
        private static Fuente BuscarFuente(int idF)
        {
            Fuente f = PersistenciaPeriodista.BuscarPeriodista(idF);
            if (f == null)
            {
                f = PersistenciaAgencia.BuscarAgencia(idF);
            }
            return f;
        }

        public static Edicion BuscarEdicion(int numero)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BuscarEdicion";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@numero", numero);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                Edicion e = null;

                if (lectorDatos.Read())
                {
                    e = new Edicion(
                        (int)lectorDatos["NumeroEdicion"],
                        (DateTime)lectorDatos["FechaPublicacion"]
                    );
                }

                return e;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersistencia("No se pudo buscar La Edicion.");
            }
            finally
            {
                if (lectorDatos != null)
                {
                    lectorDatos.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static int AltaEdicion(Edicion e)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "AltaEdicion";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Numero", e.Numero);
                comando.Parameters.AddWithValue("@FechaPublicacion", e.FechaPublicacion);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add(valorRetorno);

                conexion.Open();

                comando.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -2)
                {
                    throw new Exception();
                }

                return (int)valorRetorno.Value;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersistencia("No se pudo dar de alta la Edicion.");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        //Modifca la edicion existente 

        public static void AgregarAEdicion(int numero, int id)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "AgregarAEdicion";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id",id );
                comando.Parameters.AddWithValue("@numero",numero);
                
                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add(valorRetorno);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

               if ((int)valorRetorno.Value == -2 && filasAfectadas <= 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersistencia("No se pudieron agregar artículos a la Edicion.");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static int BajaEdicion(int numero)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BajaEdicion";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Numero", numero);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add(valorRetorno);

                conexion.Open();

                comando.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -2)
                {
                    throw new Exception();
                }

                return (int)valorRetorno.Value;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersistencia("No se pudo dar de baja la Edicion.");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

   
        public static List<Edicion> ListarEdiciones()
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarEdiciones";
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<Edicion> ediciones = new List<Edicion>();

                Edicion e;

                while (lectorDatos.Read())
                {
                    e = new Edicion(
                        (int)lectorDatos["NumeroEdicion"],
                        (DateTime)lectorDatos["FechaPublicacion"]
                        );

                    ediciones.Add(e);
                }

                return ediciones;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersistencia("No se pudo listar las Ediciones.");
            }
            finally
            {
                if (lectorDatos != null)
                {
                    lectorDatos.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static List<Fuente> ListarAgenciasXEdicion(int numero)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarAgenciasXEdicion";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@numero", numero);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<Fuente> fuentes = new List<Fuente>();

                Fuente f = null;

                while (lectorDatos.Read())
                {
                    f = new Agencia(
                        (int)lectorDatos["IdF"],
                        (string)lectorDatos["nombre"],
                        (string)lectorDatos["PaisOrigen"]
                        );

                    fuentes.Add(f);
                }

                return fuentes;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersistencia("No se pudo listar las Agencias.");
            }
            finally
            {
                if (lectorDatos != null)
                {
                    lectorDatos.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static List<Fuente> ListarPeriodistasXEdicion(int numero)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarPeriodistasXEdicion";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@numero", numero);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<Fuente> fuentes = new List<Fuente>();

                Fuente f = null;

                while (lectorDatos.Read())
                {
                    f = new Periodista(
                        (int)lectorDatos["IdF"],
                        (string)lectorDatos["nombre"],
                        (string)lectorDatos["DocumentoIdentidad"],
                        (string)lectorDatos["Direccion"],
                        (string)lectorDatos["Telefono"]
                        );

                    fuentes.Add(f);
                }

                return fuentes;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersistencia("No se pudo listar los Periodistas.");
            }
            finally
            {
                if (lectorDatos != null)
                {
                    lectorDatos.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }


        public static List<Articulo> ListarArticulosXEdicion(int NumeroEdicion)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarArticulosXEdicion";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@numero", NumeroEdicion);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<Articulo> articulos = new List<Articulo>();

                Articulo a = null;

                while (lectorDatos.Read())
                {
                    a = new Articulo (
                        (int)lectorDatos["IdArticulo"],
                        (string)lectorDatos["Seccion"],
                        (bool)lectorDatos["Imagen"],
                        (decimal)lectorDatos["Costo"],
                        (string)lectorDatos["Contenido"],
                        BuscarFuente((int)lectorDatos["IdF"])
                        );
        
                    articulos.Add(a);
                }

                return articulos;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersistencia("No se pudo listar los apartamentos.");
            }
            finally
            {
                if (lectorDatos != null)
                {
                    lectorDatos.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static Fuente f { get; set; }
    }
}
