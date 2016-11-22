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
    public class PersistenciaArticulo
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

        public static Articulo BuscarArticulo(int id)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BuscarArticulo";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                Articulo a = null;

                if (lectorDatos.Read())
                {
                    a = new Articulo
                    (id, 
                    (string)lectorDatos["Seccion"], 
                    (bool)lectorDatos["Imagen"], 
                    (decimal)lectorDatos["Costo"], 
                    (string)lectorDatos["Contenido"],
                    BuscarFuente((int)lectorDatos["IdF"])
                    );
                }
                
                return a;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersistencia("No se pudo buscar el Artículo.");
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

        public static int AltaArticulo(Articulo a,out int id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "AltaArticulo";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Seccion", a.Seccion);
                comando.Parameters.AddWithValue("@Imagen", a.ImagenIlustrativa);
                comando.Parameters.AddWithValue("@Fuente", a.Fuente.Id);
                comando.Parameters.AddWithValue("@Costo", a.Costo);
                comando.Parameters.AddWithValue("@Contenido", a.Contenido);
                
                SqlParameter pid = new SqlParameter("@Id", SqlDbType.Int);
                pid.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pid);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add(valorRetorno);

                conexion.Open();

                comando.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -2)
                {
                    throw new Exception();
                }

                id = Convert.ToInt32(pid.Value);

                return (int)valorRetorno.Value;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersistencia("No se pudo dar de alta el Artículo.");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static int BajaArticulo(int id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BajaArticulo";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id);

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
                throw new ExcepcionPersistencia("No se pudo dar de baja el Articulo.");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static int ModificarArticulo(Articulo a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ModificarArticulo";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", a.Id);
                comando.Parameters.AddWithValue("@Seccion", a.Seccion);
                comando.Parameters.AddWithValue("@Imagen", a.ImagenIlustrativa);
                comando.Parameters.AddWithValue("@Fuente", a.Fuente.Id);
                comando.Parameters.AddWithValue("@Costo", a.Costo);
                comando.Parameters.AddWithValue("@Contenido", a.Contenido);

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
                throw new ExcepcionPersistencia("No se pudo modificar el Artículo.");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static List<Articulo> ListarArticulos()
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarArticulos";
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<Articulo> articulos = new List<Articulo>();

                Articulo a;

                while (lectorDatos.Read())
                {
                    a = new Articulo(
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
                throw new ExcepcionPersistencia("No se pudo listar los Artículos.");
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
  
        public static List<Articulo> ListarArticulosXFuente(int IdF)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarArticulosXFuente";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdF",IdF);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<Articulo> articulos = new List<Articulo>();

                Articulo a;

                while (lectorDatos.Read())
                {
                    a = new Articulo(
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
                throw new ExcepcionPersistencia("No se pudo listar los Artículos.");
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
    }
}
