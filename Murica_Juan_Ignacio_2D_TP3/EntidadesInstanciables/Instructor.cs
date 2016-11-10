using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Instructor :PersonaGimnasio
    {
        #region Fields
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;
        #endregion
        #region Constructors
        public Instructor() : base() { }
        static Instructor()
        {
            Instructor._random = new Random();
        }
        public Instructor(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad) :base (id,nombre,apellido,dni,nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Setea Clases random al instructor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(0,4));
            }
        }
        /// <summary>
        /// Recolecta los datos del instructor en un string
        /// </summary>
        /// <returns>string con los datos del instructor</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos()+this.ParticiparEnClase();
        }
        /// <summary>
        /// Sobrecarga del ParticiparEnClase()
        /// </summary>
        /// <returns>string con las clases del instructor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder texto = new StringBuilder();
            texto.AppendLine("CLASES DEL DIA:");
            foreach (Gimnasio.EClases clase in this._clasesDelDia)
            {
                texto.AppendLine(clase.ToString());
            }
            return texto.ToString() ;
        }
        /// <summary>
        /// Hace publico MostrarDatos()
        /// </summary>
        /// <returns>String con los datos del instructor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="i">instructor</param>
        /// <param name="clase">Gimnasio.Eclases</param>
        /// <returns>True si el instructor da la clase, False si no</returns>
        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            bool flag = false;
            if (!object.Equals(i,null))
            {
                foreach (Gimnasio.EClases item in i._clasesDelDia)
                {
                    if (object.Equals(item,clase))
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;

        }
        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="i">instructor</param>
        /// <param name="clase">Gimnasio.Eclases</param>
        /// <returns>True si el instructor no da la clase, False si la da</returns>
        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
