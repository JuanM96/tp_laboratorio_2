using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Alumno :PersonaGimnasio
    {
        public enum EEstadoCuenta
        {
            MesPrueba,
            Deudor,
            AlDia
        }

        #region Fields
        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;
        #endregion
        #region Constructors
        public Alumno() : base() { }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Reune los datos y los devuelve como string
        /// </summary>
        /// <returns>string con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder texto = new StringBuilder();
            
            texto.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);
            return base.MostrarDatos() +texto.ToString()+ this.ParticiparEnClase();
        }
        /// <summary>
        /// Sobrecarga del metodo ParticiparEnClase para que devuelva un string mostrando el atributo
        /// </summary>
        /// <returns>string con el dato</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder texto = new StringBuilder();
            texto.AppendLine("TOMA CLASE DE: " + this._claseQueToma);
            return texto.ToString();
        }
        /// <summary>
        /// Hace publico MostrarDatos
        /// </summary>
        /// <returns>string con los datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Sobrecarga del operador == para que evalue si un alumno toma la clase
        /// </summary>
        /// <param name="a">Alumno a evaluar</param>
        /// <param name="clase">Clase a evaluar</param>
        /// <returns>true si el alumno cursa esa clase, false si no</returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            bool flag = false;
            if (!object.Equals(a,null))
            {
                if (object.Equals(a._claseQueToma,clase)&& !object.Equals(a._estadoCuenta,EEstadoCuenta.Deudor))
                {
                    flag = true;
                }
            }
            return flag;
        }
        /// <summary>
        /// Sobrecarga del operador != para que evalue si un alumno toma la clase
        /// </summary>
        /// <param name="a">Alumno a evaluar</param>
        /// <param name="clase">Clase a evaluar</param>
        /// <returns>true si el alumno no cursa esa clase, false si cursa la clase</returns>
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            return !(a == clase);
        }
        #endregion
    }
}
