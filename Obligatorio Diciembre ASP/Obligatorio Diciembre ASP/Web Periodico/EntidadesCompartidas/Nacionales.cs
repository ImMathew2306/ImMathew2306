using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
     public class Nacionales : Noticia
    {
         private Secciones seccion;
         
         public Secciones Seccion 
         {
             get { return seccion; }
             set 
             {
                 if (value == null)
                 {
                     throw new Exception("Se necesita una seccion existente para crear una noticia nacional");
                 }

                 seccion = value;
             }
         }

         public Nacionales(int pNumero, string pTitulo, string pResumen, string pContenido,DateTime pFecha, Periodista pPerri, Secciones pSeccion)
             : base(pNumero, pTitulo, pResumen, pContenido, pFecha, pPerri) 
         {
             Seccion = pSeccion;
         }

         public override string ToString()
         {
             return base.ToString()+" Seccion: "+seccion;
         }

         
         
    }
}
