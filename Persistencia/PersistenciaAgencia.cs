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
    public class PersistenciaAgencia
    {
        public static Agencia BuscarAgencia(int id)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BuscarAgencia";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                Agencia agencia = null;

                if (lectorDatos.Read())
                {
                    string nombre = lectorDatos["Nombre"].ToString();
                    string paisOrigen = lectorDatos["PaisOrigen"].ToString();

                    agencia = new Agencia(id, nombre, paisOrigen);
                }

                return agencia;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersistencia("No se pudo buscar la Agencia de Noticias.");
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

        public static int AltaAgencia(Agencia a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);
                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "AltaAgencia";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@PaisOrigen", a.PaisOrigen);
                comando.Parameters.AddWithValue("@Id", a.Id);
                comando.Parameters.AddWithValue("@Nombre", a.Nombre);

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
                throw new ExcepcionPersistencia("No se pudo dar de alta la Agencia.");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        
        public static int BajaAgencia(int id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BajaAgencia";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add(valorRetorno);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -2)
                {
                    throw new Exception();
                }

                return (int)valorRetorno.Value;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersistencia("No se pudo dar de baja la Agenica.");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }
        
        public static int ModificarAgencia(Agencia a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ModificarAgencia";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", a.Id);
                comando.Parameters.AddWithValue("@Nombre", a.Nombre);
                comando.Parameters.AddWithValue("@PaisOrigen", a.PaisOrigen);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add(valorRetorno);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -2)
                {
                    throw new Exception();
                }

                return (int)valorRetorno.Value;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersistencia("No se pudo modificar la Agencia.");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static List<Fuente> ListarAgencias()
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarAgencias";
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<Fuente> agencias = new List<Fuente>();

                Agencia ag = null;

                while (lectorDatos.Read())
                {
                    ag = new Agencia(
                        (int)lectorDatos["IdF"],
                        (string)lectorDatos["nombre"],
                        (string)lectorDatos["PaisOrigen"]
                        );

                    agencias.Add(ag);
                }

                return agencias;
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



    }
}
