using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaSeccion
    {
        public static Secciones Buscar (string pCodigoSec)
        {
            Secciones oSeccion = null;
            oSeccion = PersistenciaSecciones.Buscar(pCodigoSec);

            return oSeccion;
        }

        public static void Agregar(Secciones pSeccion) 
        {
            PersistenciaSecciones.Agregar((Secciones)pSeccion);
        }

        public static void Modificar(Secciones pSeccion) 
        {
            PersistenciaSecciones.Modificar((Secciones)pSeccion);
        }

        public static void Eliminar(Secciones pSeccion) 
        {
            PersistenciaSecciones.Eliminar((Secciones)pSeccion);
        }

        public static List<Secciones> ListarSecciones() 
        {
            List<Secciones> colSeccion = PersistenciaSecciones.ListarSecciones();
            return colSeccion;
        }
    }
}
