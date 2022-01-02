using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
   public class Internacionales : Noticia
    {
       private string pais;

       public string Pais 
       {
           get { return pais; }

           set 
           {
               if (value == "")
               {
                   throw new Exception("El Pais no puede estar vacio");
               }

               else if (value.Trim().Length > 20)
               {
                   throw new Exception("El pais no puede contener mas de 20 caracteres");
               }

               pais = value;
           }
       }

       public Internacionales(int pNumero, string pTitulo, string pResumen, string pContenido, DateTime pFecha, Periodista pPerri, string pPais)
           : base(pNumero, pTitulo, pResumen, pContenido, pFecha, pPerri)
       {
           Pais = pPais;
       }
       public override string ToString()
       {
           return base.ToString()+"Pais: "+pais;
       }
    }
}
