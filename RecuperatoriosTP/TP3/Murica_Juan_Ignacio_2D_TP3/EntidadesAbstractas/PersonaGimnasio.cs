using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class PersonaGimnasio : Persona
    {

        #region Fields
        private int _identificador;
        #endregion
        #region Builders
        /// <summary>
        /// Constructor para Serializar
        /// </summary>
        public PersonaGimnasio() : base() { }
        /// <summary>
        /// Constructor que setea los atributos de persona
        /// </summary>
        /// <param name="id">es un int que setea el identificador de la persona</param>
        /// <param name="nombre">es un string que setea el nombre</param>
        /// <param name="apellido">es un string que setea el apellido</param>
        /// <param name="dni">es un int que setea el dni</param>
        /// <param name="nacionalidad">ENacionalidad que indica la nacionalidad de la persona</param>
        public PersonaGimnasio(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this._identificador = id;
        }
        #endregion     
        #region Methods
        /// <summary>
        /// Pasa los datos de la PersonaGimnasio a un string
        /// </summary>
        /// <returns>String con los datos</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.ToString());
            retorno.AppendLine("CARNET NUMERO: " + this._identificador.ToString());
            return retorno.ToString();
        }
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Sobrecarga del metodo Object.equals para que evalue a personaGimnasio
        /// </summary>
        /// <param name="obj">Objecto con que comparar a la personaGimnasio</param>
        /// <returns>Bool true si son iguales , false si no</returns>
        public override bool Equals(object obj)
        {
            return (obj is PersonaGimnasio);
        }
        /// <summary>
        /// Sobrecarga del operador == de 2 personaGimnasio
        /// </summary>
        /// <param name="pg1">Primer objeto a comparar</param>
        /// <param name="pg2">Segundo objeto a comparar</param>
        /// <returns>Bool true si son iguales , false si no</returns>
        public static bool operator == (PersonaGimnasio pg1,PersonaGimnasio pg2)
        {
            bool retorno = false;
            if (!object.Equals(pg1, null) && !object.Equals(pg2, null) && pg1.Equals(pg2) && (pg1.Dni == pg2.Dni || pg1._identificador == pg2._identificador))
                retorno = true;
            return retorno;
        }
        /// <summary>
        /// Sobrecarga del operador != de 2 personaGimnasio
        /// </summary>
        /// <param name="pg1">Primer objeto a comparar</param>
        /// <param name="pg2">Segundo objeto a comparar</param>
        /// <returns>Bool true si no son iguales , false si son iguales</returns>
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
