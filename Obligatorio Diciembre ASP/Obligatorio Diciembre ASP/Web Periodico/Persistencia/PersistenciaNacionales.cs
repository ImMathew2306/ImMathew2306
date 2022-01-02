using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;


using System.Data.SqlClient;

using EntidadesCompartidas;


namespace Persistencia
{
   public class PersistenciaNacionales
    {
       public static int Agregar(Nacionales pNacionales) 
       {
           SqlConnection oConexion = new SqlConnection(Conexion.STR);
           SqlCommand oComando = new SqlCommand("CrearNac", oConexion);
           oComando.CommandType = CommandType.StoredProcedure;

           oComando.Parameters.AddWithValue("@CodigoP", pNacionales.CodigoPerri);
           oComando.Parameters.AddWithValue("@FechaC", pNacionales.Fecha);
           oComando.Parameters.AddWithValue("@Titulo", pNacionales.Titulo);
           oComando.Parameters.AddWithValue("@Resumen", pNacionales.Resumen);
           oComando.Parameters.AddWithValue("@Contenido", pNacionales.Contenido);
           oComando.Parameters.AddWithValue("@CodeSec", pNacionales.Seccion.CodigoSecciones);

           SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
           oRetorno.Direction = ParameterDirection.ReturnValue;
           oComando.Parameters.Add(oRetorno);

           int resultado = 0;
           
           try
           {
               oConexion.Open();
               oComando.ExecuteNonQuery();

               resultado = Convert.ToInt32(oRetorno.Value);

               if (resultado == -1)
               {
                   throw new Exception("No existe esa seccion para dar de alta la noticia. -  no se crea");
               }
               else if (resultado == -2)
               {
                   throw new Exception("No existe un periodista asociado para dar de alta la noticia - no se crea");
               }
               else if (resultado == -3)
               {
                   throw new Exception("Ocurrio un error al intentar crear la noticia");
               }
               else if (resultado == -4)
               {
                   throw new Exception("Ocurrio un error al intentar crear la noticia nacional");
               }

           }
           catch (Exception ex)
           {

               throw ex;
           }
           finally 
           { 
               oConexion.Close(); 
           }
           return resultado;
       }

       public static List<Noticia>ListarNoticiasNacionales()
       {
           string titulo, resumen, contenido, codigoSec;
           int codigoNoticia, oCodigoPeriodista;
           DateTime fecha;
           Periodista oPeriodista;
           Nacionales pNacionales;
           Secciones oSeccion;
           SqlDataReader oReader;

           List<Noticia> oNoticias = new List<Noticia>();
           
          
           SqlConnection oConexion = new SqlConnection(Conexion.STR);
           SqlCommand oComando = new SqlCommand("ListarNacionales", oConexion);
           oComando.CommandType = CommandType.StoredProcedure;

           try
           {
               oConexion.Open();
               oReader = oComando.ExecuteReader();

               if (oReader.HasRows)
               {
                   while (oReader.Read())
                   {
                       codigoNoticia = (int)oReader["CodigoNoticias"];
                       titulo = (string)oReader["titulo"];
                       resumen = (string)oReader["resumen"];
                       contenido = (string)oReader["contenido"];
                       fecha = Convert.ToDateTime(oReader["fecha"]);
                       oCodigoPeriodista = (int)oReader["codigoPeriodista"];
                       codigoSec = (string)oReader["CodigoSecciones"];
                       oPeriodista = PersistenciaPeriodista.Buscar(oCodigoPeriodista);
                       oSeccion = PersistenciaSecciones.Buscar(codigoSec);

                       pNacionales = new Nacionales(codigoNoticia, titulo, resumen, contenido, fecha, oPeriodista, oSeccion);
                       oNoticias.Add(pNacionales);
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
           return oNoticias;
       }
    }
}
