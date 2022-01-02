using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public  class PersistenciaSecciones
    {
        public static int Agregar(Secciones pSeccion )
        { 
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("altaSeccion",oConexion);

            oComando.CommandType= CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigosec",pSeccion.CodigoSecciones);
            oComando.Parameters.AddWithValue("@nombresec", pSeccion.NombreSeccion);

            SqlParameter oRetorno = new SqlParameter("@retorno", SqlDbType.Int);

            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);
            int resultado = 0;
            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@retorno"].Value;
                if (resultado == -1)
                {
                    throw new Exception("Ya existe una seccion con este codigo- No se crea");
                    
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
            return resultado;


        
        
        }

        public static Secciones Buscar(string pCodesec)
        {
            string nombreSeccion;
            
            Secciones oSeccion = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarSec",oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codesec", pCodesec);
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        nombreSeccion = (string)oReader["NombreSeccion"];

                        oSeccion = new Secciones(pCodesec, nombreSeccion);
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
            return oSeccion;
            
       }

        public static void Modificar(Secciones pSeccion)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("modificarSec",oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codesec", pSeccion.CodigoSecciones);
            oComando.Parameters.AddWithValue("@Nombre", pSeccion.NombreSeccion);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);

            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);
            
            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int resultado = Convert.ToInt32(oRetorno.Value);
                if (resultado == -1)
                {
                    throw new Exception("No existe la seccion-No se modifica");

                }
                else if (resultado == -2)
                {
                    throw new Exception("Ocurriò un error Inesperado");
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

        public static void Eliminar(Secciones pSeccion)
        {
           SqlConnection oConexion = new SqlConnection(Conexion.STR);
           SqlCommand oComando =  new SqlCommand("EliminarSec",oConexion);
           oComando.CommandType= CommandType.StoredProcedure;

           oComando.Parameters.AddWithValue("@codigosec", pSeccion.CodigoSecciones);
           SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);


            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);
            try 
	         {	      
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int resultado = Convert.ToInt32(oRetorno.Value);
                if (resultado == -1)
                 {
                     throw new Exception("No existe una seccion con este cogido");
                
                 }
                else if (resultado == -2)
                {
                    throw new Exception("Ocurrio un error al intentar eliminar las Noticias y/o las Secciones");
                    
                
                }
        
              }
	        catch (Exception ex )
	         {
		
		      throw new Exception (ex.Message);
	         }
              finally
            {
                oConexion.Close();
            
            
            }


            




        
        }

        public static List<Secciones> ListarSecciones() 
        {
            string codigoSec, nombre;

            Secciones oSeccion;

            List<Secciones> colSeccion = new List<Secciones>();

            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("listarSec", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        codigoSec = (string)oReader["CodigoSecciones"];
                        nombre = (string)oReader["NombreSeccion"];

                        oSeccion = PersistenciaSecciones.Buscar(codigoSec);

                        oSeccion = new Secciones(codigoSec, nombre);
                        colSeccion.Add(oSeccion);
                    }
                }
                oReader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { oConexion.Close(); }
            return colSeccion;
        }
    }
}
