using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaNoticia
    {
        public static int Agregar(Noticia pNoticia) 
        {
            if (pNoticia is Nacionales)
            {
               return PersistenciaNacionales.Agregar((Nacionales)pNoticia);
            }
            else
            {
               return PersistenciaInternacionales.Agregar((Internacionales)pNoticia);
                
            }
        }

        public static List<Noticia> ListarNoticias() 
        {
            List<Noticia> colNoticias = PersistenciaNacionales.ListarNoticiasNacionales();
            colNoticias.AddRange(PersistenciaInternacionales.ListarNoticiasInternacionales());

            return colNoticias;
        }
    }
}
