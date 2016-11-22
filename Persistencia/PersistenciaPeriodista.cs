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
    public class PersistenciaPeriodista
    {
        public static Periodista BuscarPeriodista(int id)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BuscarPeriodista";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                Periodista periodista = null;

                if (lectorDatos.Read())
                {
                    string nombre = lectorDatos["Nombre"].ToString();
                    string documentoIdentidad = (string)lectorDatos["DocumentoIdentidad"];
                    string direccion = lectorDatos["Direccion"] != DBNull.Value ? lectorDatos["Direccion"].ToString() : null;
                    string telefono = (string)lectorDatos["Telefono"];
                    
                    periodista = new Periodista(id, nombre, documentoIdentidad, direccion, telefono);
                }

                return periodista;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersistencia("No se pudo buscar el Periodista.");
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


        public static int AltaPeriodista(Periodista p)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);
                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "AltaPeriodista";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", p.Id);
                comando.Parameters.AddWithValue("@Nombre", p.Nombre);
                comando.Parameters.AddWithValue("@DocumentoIdentidad", p.DocumentoIdentidad);
                comando.Parameters.AddWithValue("@direccion", p.Direccion);
                comando.Parameters.AddWithValue("@Telefono", p.Telefono);

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
                throw new ExcepcionPersistencia("No se pudo dar de alta el Periodista.");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }
     
        public static int BajaPeriodista(int id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BajaPeriodista";
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
                throw new ExcepcionPersistencia("No se pudo dar de baja el Periodista.");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }
   
        public static int ModificarPeriodista(Periodista p)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ModificarPeriodista";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@DocumentoIdentidad", p.DocumentoIdentidad);

                comando.Parameters.AddWithValue("@Direccion", p.Direccion);
                
                comando.Parameters.AddWithValue("@Nombre", p.Nombre);
                comando.Parameters.AddWithValue("@Id", p.Id);
                comando.Parameters.AddWithValue("@Telefono", p.Telefono);

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
                throw new ExcepcionPersistencia("No se pudo modificar el Periodista.");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static List<Fuente> ListarPeriodistas()
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarPeriodistas";
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<Fuente> periodistas = new List<Fuente>();

                Periodista pe = null;

                while (lectorDatos.Read())
                {
                    pe = new Periodista(
                        (int)lectorDatos["IdF"],
                        (string)lectorDatos["nombre"],
                        (string)lectorDatos["DocumentoIdentidad"],
                        (string)lectorDatos["direccion"],
                        (string)lectorDatos["telefono"]
                        );

                    periodistas.Add(pe);
                }

                return periodistas;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersistencia("No se pudo listar los periodistas.");
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
