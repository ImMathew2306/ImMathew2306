using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;


using EntidadesCompartidas;


namespace Persistencia
{
    public class PersistenciaInternacionales
    {
        public static int Agregar(Internacionales pInternacional) 
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("CrearInter", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CodigoP",pInternacional.CodigoPerri);
            oComando.Parameters.AddWithValue("@FechaC", pInternacional.Fecha);
            oComando.Parameters.AddWithValue("@Titulo",pInternacional.Titulo);
            oComando.Parameters.AddWithValue("@Resumen", pInternacional.Resumen);
            oComando.Parameters.AddWithValue("@Contenido", pInternacional.Contenido);
            oComando.Parameters.AddWithValue("@Pais",pInternacional.Pais);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            int resultado;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                resultado = Convert.ToInt32(oRetorno.Value);

                if (resultado == -1 )
                {
                    throw new Exception("No existe periodista para dar de alta la noticia - no se crea");
                }
                else if (resultado == -2)
                {
                    throw new Exception("Ocurrio un error al intentar crear la noticia - no se crea");
                }
                else if (resultado == -3)
                {
                    throw new Exception("Ocurrio un error al intentar crear la noticia internacional - no se crea");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally{oConexion.Close();}
            return resultado;
        }

        public static List<Noticia> ListarNoticiasInternacionales() 
        {
            int codigoNoticia, codigoPerri;
            string titulo, resumen, contenido, pais;
            DateTime fecha;
            SqlDataReader oReader;

            List<Noticia> oNoticias = new List<Noticia>();
            Internacionales pInternacionales;
            Periodista oPeriodista;
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarInter", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        codigoNoticia = Convert.ToInt32(oReader["CodigoNoticias"]);
                        titulo = (string)oReader["titulo"];
                        resumen = (string)oReader["resumen"];
                        contenido = (string)oReader["contenido"];
                        fecha = Convert.ToDateTime(oReader["fecha"]);
                        codigoPerri = Convert.ToInt32(oReader["CodigoPeriodista"]);
                        pais = (string)oReader["pais"];

                        oPeriodista = PersistenciaPeriodista.Buscar(codigoPerri);
                        pInternacionales = new Internacionales(codigoNoticia, titulo, resumen, contenido, fecha, oPeriodista, pais);
                        oNoticias.Add(pInternacionales);
                       
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { oConexion.Close(); }
            return oNoticias;
        }
    }
}
