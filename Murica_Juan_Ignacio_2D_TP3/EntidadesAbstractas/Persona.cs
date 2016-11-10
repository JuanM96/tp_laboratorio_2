using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region Fields
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;
        #endregion
        #region Properties
        /// <summary>
        /// Get Devuelve el apellido y Set Guarda el apellido validandolo
        /// </summary>
        public string Apellido
        { 
            get 
            {
                return this._apellido ;
            } 
            set 
            {
                this._apellido = this.ValidarNombreApellido(value);
            } 
        }
        /// <summary>
        /// Get Devuelve la Nacionalidad y Set Guarda la Nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }
        /// <summary>
        /// Get Devuelve el DNI y Set Guarda el DNI validandolo
        /// </summary>
        public int DNI 
        {
            get 
            {
                return this._dni;
            }
            set 
            {
                this._dni = this.ValidarDNI(this.Nacionalidad, value);
            } 
        }

        /// <summary>
        /// Get Devuelve el Nombre y Set Guarda el Nombre validandolo
        /// </summary>
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = this.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Set Guarda el DNI(string) validandolo y transformandolo a Entero
        /// </summary>
        public string StringToDNI 
        {
            set
            {
                this._dni = this.ValidarDNI(this.Nacionalidad, value);
            }
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor para Serializar
        /// </summary>
        public Persona() { }
        /// <summary>
        /// Constructor que setea los atributos de persona
        /// </summary>
        /// <param name="nombre">es un string que setea el nombre</param>
        /// <param name="apellido">es un string que setea el apellido</param>
        /// <param name="nacionalidad">ENacionalidad que indica la nacionalidad de la persona</param>
        public Persona(string nombre,string apellido,ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor que setea los atributos de persona
        /// </summary>
        /// <param name="nombre">es un string que setea el nombre</param>
        /// <param name="apellido">es un string que setea el apellido</param>
        /// <param name="dni">es un int que setea el dni</param>
        /// <param name="nacionalidad">ENacionalidad que indica la nacionalidad de la persona</param>
        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad) :this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Constructor que setea los atributos de persona
        /// </summary>
        /// <param name="nombre">es un string que setea el nombre</param>
        /// <param name="apellido">es un string que setea el apellido</param>
        /// <param name="dni">es un string que setea el dni</param>
        /// <param name="nacionalidad">ENacionalidad que indica la nacionalidad de la persona</param>
        public Persona(string nombre, string apellido,string dni, ENacionalidad nacionalidad) :this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Valida el Dni por nacionaliad
        /// </summary>
        /// <param name="nacionalidad">ENacionalidad parametro para validar</param>
        /// <param name="dato">int que se validara</param>
        /// <returns>El dato ya validado</returns>
        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                    {
                        throw new DniInvalidoException();
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 89999999 || dato > 99999999)
                    {
                        throw new DniInvalidoException();
                    }
                    break;
                default:
                    throw new NacionalidadInvalidaException();
                    break;
            }
            return dato;
        }
        /// <summary>
        /// Valida el Dni por nacionaliad
        /// </summary>
        /// <param name="nacionalidad">ENacionalidad parametro para validar</param>
        /// <param name="dato">string que se validara</param>
        /// <returns>El dato ya validado y parseado si se puede</returns>
        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            dato = dato.Replace(".", "");
            if (dato.Length < 1 || dato.Length > 8)
            {
                throw new DniInvalidoException();
            }
            int auxDni;
            if (!Int32.TryParse(dato, out auxDni))
            {
                throw new DniInvalidoException();
            }
            return this.ValidarDNI(nacionalidad, auxDni);
        }
        /// <summary>
        /// Valida el nombre o apellido
        /// </summary>
        /// <param name="dato">String que se validara</param>
        /// <returns>String Validado</returns>
        private string ValidarNombreApellido(string dato)
        {
            Regex regex = new Regex(@"[a-zA-Z]*");

            Match match = regex.Match(dato);

            if (match.Success)
                return match.Value;
            else
                return "";
        }
        /// <summary>
        /// Devuelve los Datos de persona en una cadena de caracteres
        /// </summary>
        /// <returns>String con los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();
            texto.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            texto.AppendLine("NACIONALIDAD: "+this.Nacionalidad);
            texto.AppendLine();
            
            return texto.ToString();
        }
        #endregion

    }
}
