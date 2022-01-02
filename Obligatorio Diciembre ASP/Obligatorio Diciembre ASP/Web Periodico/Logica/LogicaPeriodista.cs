using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPeriodista
    {
        public static void Agregar(Periodista pPeriodista) 
        {
           PersistenciaPeriodista.Agregar((Periodista)pPeriodista);
        }

        public static void Modificar(Periodista pPeriodista) 
        {
            PersistenciaPeriodista.Modificar((Periodista)pPeriodista);
        }

        public static void Eliminar(Periodista pPeriodista) 
        {
            PersistenciaPeriodista.Eliminar((Periodista)pPeriodista);
        }

        public static Periodista Buscar(int pCodigoPeriodista) 
        {
            Periodista oPeriodista = null;
            oPeriodista = PersistenciaPeriodista.Buscar(pCodigoPeriodista);

            return oPeriodista;
        }

        public static List<Periodista> ListarPeriodistas()
        {
            List<Periodista> colPeriodista = PersistenciaPeriodista.ListarPeriodistas();
            return colPeriodista;
        }
    }
}
