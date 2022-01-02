using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    //El modificaro internal hace que la clase se comporte como publica solo dentra de
    //esta biblioteca de clases (PERSISTENCIA)
    internal class Conexion
    {
        //Otra forma de hacerlo, con una constante
        public const string STR = "Data Source=AFTERDELAFTER;Initial Catalog=OWBD;Integrated Security=True;";
        //Public Const string STR = "Server=(local); DataBase=Biblioteca; Trusted Connection=true";
    }
}
