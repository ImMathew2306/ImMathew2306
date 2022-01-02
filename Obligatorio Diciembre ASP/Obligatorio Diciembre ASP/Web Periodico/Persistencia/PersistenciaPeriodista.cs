using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using System.Data;
using EntidadesCompartidas;


namespace Persistencia
{
    public class PersistenciaPeriodista
    {
        public static Periodista Buscar(int pCodigoPeriodista)

        {
            string  nombre,apellido,mail;
            SqlDataReader oReader ;
            Periodista oPeriodista = null;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);

            SqlCommand oComando = new SqlCommand("BuscarPeriodista",oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoP", pCodigoPeriodista);

            try
            {
                
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        nombre = (string)oReader["Nombre"];
                        apellido = (string)oReader["Apellido"];
                        mail = (string)oReader["Mail"];


                        oPeriodista = new Periodista(pCodigoPeriodista, nombre, apellido, mail);
                    
                    
                    }
                
                
                }
                oReader.Close();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            
            }
            return oPeriodista;


        
        
        
        }

        public static void Agregar(Periodista pPeriodista)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);

            SqlCommand oComando = new SqlCommand("AltaPeriodista", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigop",pPeriodista.CodigoPeriodista);
            oComando.Parameters.AddWithValue("@nombre",pPeriodista.Nombre);
            oComando.Parameters.AddWithValue("@apellido",pPeriodista.Apellido);
            oComando.Parameters.AddWithValue("@Mail",pPeriodista.Mail);

            SqlParameter oRetorno = new SqlParameter("@retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int resultado = Convert.ToInt32(oRetorno.Value);
                if(resultado==-1)
                {
                    throw new Exception("Ya existe un Periodista con Este codigo - No se Agrega");
                }
                else if (resultado==-2)
                    throw new Exception("Ocurriò un error inesperado");

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

        
        
        }

        public static void Modificar(Periodista pPeriodista)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);

            SqlCommand oComando = new SqlCommand("EditarPeri", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigop", pPeriodista.CodigoPeriodista);
            oComando.Parameters.AddWithValue("@nombre", pPeriodista.Nombre);
            oComando.Parameters.AddWithValue("@apellido", pPeriodista.Apellido);
            oComando.Parameters.AddWithValue("@Mail", pPeriodista.Mail);

            SqlParameter oRetorno = new SqlParameter("@retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);
            try
            {
                oConexion.Open();

                oComando.ExecuteNonQuery();
                int resultado = Convert.ToInt32(oRetorno.Value);
                if (resultado == -1)
                {
                    throw new Exception("El Periodista no se encuentra registrado- No se modifica");

                }
                else if (resultado == -2)
                {
                    throw new Exception("Ocurriò un error inesperado");
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            
            }

        
        
        }

        public static void Eliminar(Periodista pPeriodista)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);

            SqlCommand oComando = new SqlCommand("EliminarPeri", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigop", pPeriodista.CodigoPeriodista);

            SqlParameter oRetorno = new SqlParameter("@retorno", SqlDbType.Int);

            oRetorno.Direction=ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);
            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int resultado =(int)oComando.Parameters["@retorno"].Value;
                if (resultado == -1)
                {
                    throw new Exception("El Periodista no esta Registrado-No se borra");

                }
                else if (resultado == -2)
                {
                    throw new Exception("Periodista con Noticias Asociadas-No se Borra ");

                }
                else if (resultado == -3)
                {
                    throw new Exception("Ocurriò un error inesperado");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

           
        
        }

        public static List<Periodista> ListarPeriodistas()
        {
            string nombre, apellido, mail;
            int codigo;
            Periodista perri;

            List<Periodista> colPeriodistas = new List<Periodista>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarPeri", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        codigo = (int)oReader["CodigoPeriodista"];
                        nombre = (string)oReader["Nombre"];
                        apellido = (string)oReader["Apellido"];
                        mail = (string)oReader["Mail"];

                        perri = PersistenciaPeriodista.Buscar(codigo);

                        perri = new Periodista(codigo, nombre, apellido, mail);
                        colPeriodistas.Add(perri);


                    }
                
                
                }
                oReader.Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return colPeriodistas;

        
        }
    }
}
