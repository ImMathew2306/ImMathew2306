using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Periodista
    {
        private int codigoPeriodista;
        private string nombre, apellido, mail;

        public int CodigoPeriodista 
        {
            get { return codigoPeriodista; }
            set 
            {
                if (value < 1000 && value > 9999)
                {
                    throw new Exception("El Codigo de Periodista debe tener 4 digitos");
                }

                codigoPeriodista = value;
            }
        }

        public string Nombre 
        {
            get { return nombre; }
            set 
            {
                if (value == "")
                {
                    throw new Exception("El nombre no puede estar vacio");
                }
                else if (value.Trim().Length > 20)
                {
                    throw new Exception("El nombre no puede contener mas de 20 caracteres");
                }
                nombre = value;
            }
        }

        public string Apellido 
        {
            get { return apellido; }
            set 
            {
                if (value == "")
                {
                    throw new Exception("El apellido no puede estar vacio");
                }

                else if (value.Trim().Length > 20)
                {
                    throw new Exception("El apellido no puede ser mayor a 20 caracteres");
                }
                apellido = value;
            }
        }

        public string Mail 
        {
            get { return mail; }
            set 
            {
                if (value == "")
                {
                    throw new Exception("El Mail no puede estar vacio");
                }

                else if (value.Trim().Length > 40)
                {
                    throw new Exception("El Mail no puede ser mayor a 40 caracteres");
                }

                mail = value;
            }
        }

        public Periodista(int pCodigoPeriodista, string pNombre, string pApellido, string pMail)
        {
            CodigoPeriodista= pCodigoPeriodista;
            Nombre = pNombre;
            Apellido = pApellido;
            Mail = pMail;
        }
        public virtual string MostrarPerri
        {

            get { return "Codigo: " + codigoPeriodista + " Apellido: " + apellido; }
        }
    }
}
