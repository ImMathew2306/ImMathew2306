using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
     public class Secciones
    {
         private string codigoSecciones, nombreSeccion;

         public string CodigoSecciones
         {
             get { return codigoSecciones; }
             set 
             {
                 if (value.Trim().Length != 3)
                 {
                     throw new Exception("El codigo de la seccion debe contener 3 caracteres Ej:(ABC)");
                 }
                
                 codigoSecciones = value.ToUpper();
             }
         }

         public string NombreSeccion 
         {
             get { return nombreSeccion; }
             set 
             {
                 if (value == "")
                     throw new Exception("El nombre de la seccion no puede estar vacio");
                 else if (value.Trim().Length > 30)
                 {
                     throw new Exception("El nombre de la seccion no puede ser mayor a 30 caracteres");
                 }

                 nombreSeccion = value;
             }
         }

         public Secciones(string pCodigoSecciones, string pNombreSeccion) 
         {
             CodigoSecciones = pCodigoSecciones;
             NombreSeccion = pNombreSeccion;
         }

         public string MostrarSec
         {
             get { return "Codigo: " + codigoSecciones + " Nombre: " + nombreSeccion; }
         }
    }
}
