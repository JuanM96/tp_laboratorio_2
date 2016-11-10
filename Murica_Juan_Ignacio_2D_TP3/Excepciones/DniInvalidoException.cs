using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public class DniInvalidoException : Exception
    {
        static string mensaje = "El DNI ingresado no es un número válido.";
        public DniInvalidoException() 
            : base(mensaje) { }
        public DniInvalidoException(string message)
            : this(message, null) { }
        public DniInvalidoException(Exception e)
            : base(mensaje, e) { }
        public DniInvalidoException(string message, Exception e)
            : base(mensaje + message, e) { }
    }
}
