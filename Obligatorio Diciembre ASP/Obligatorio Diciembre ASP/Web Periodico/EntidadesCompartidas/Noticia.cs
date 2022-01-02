using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
     public abstract class Noticia
    {
         private string titulo, resumen, contenido;
         private DateTime fecha;
         private int numero;
         private Periodista perri;

         public string Titulo 
         {
             get { return titulo; }
             set 
             {
                 if (value.Trim() == "")
                     throw new Exception("El titulo no puede estar vácio");
                 if (value.Trim().Length > 30)
                 {
                     throw new Exception("El titulo no puede tener mas de 30 caracteres");
                 }

                 titulo = value;
             }
         }

         public int Numero
         {
            get {return numero;}
             set { numero = value; }
         }

         public string Resumen 
         {
             get { return resumen; }
             set 
             {
                 if (value.Trim() == "")
                     throw new Exception("El resumen no puede estar vacio");
                 
                 if (value.Trim().Length > 100)
                 {
                     throw new Exception("El resumen no puede tener mas de 100 caracteres");
                 }
                 resumen = value;
             }
         }

         public string Contenido 
         {
             get { return contenido; }
             set 
             {
                 if (value.Trim() == "")
                     throw new Exception("El contenido no puede estar Vacio");
                 if (value.Trim().Length < 100)
                 {
                     throw new Exception("El contenido no puede ser menor a 100 caracteres");
                 }
                 else if (value.Trim().Length > 300)
                 {
                     throw new Exception("El contenido no puede ser mayor a 300 caracteres");
                 }
                 else
                 {
                     contenido = value;
                 }
             }
         }

         public DateTime Fecha 
         {
             get { return fecha; }
             set 
             {
                 if (value > DateTime.Today)
                 {
                     throw new Exception("La fecha no puede ser posterior al dia de hoy");
                 }
                 fecha = value;
             }
         }

         public Periodista Perri 
         {
             get { return perri; }
             set 
             {
                 if (value == null)
                 {
                     throw new Exception("La noticia debe tener un periodista asociado");
                 }
                 perri = value;
             }
         }

         public int CodigoPerri 
         {
             get { return perri.CodigoPeriodista; }
         }

         public Noticia(int pNumero ,string pTitulo, string pResumen, string pContenido, DateTime pFecha, Periodista pPerri) 
         {
             Numero = pNumero;
             Titulo = pTitulo;
             Resumen = pResumen;
             Contenido = pContenido;
             Fecha = pFecha;
             Perri = pPerri;
         }

         public override string ToString()
         {
             return "Nº :"+ numero +" Titulo: "+titulo+ " Resumen : "+resumen+ " Contenido: " +contenido+ "Fecha: "+fecha.ToShortDateString()+"Periodista: "+perri;
         }

         public virtual int MostrarPeriodista
         {
             get{return perri.CodigoPeriodista;}
          
          
         }
    }
}
