using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Jornada
    {
        #region Fields
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;
        #endregion
        #region Properties
        public List<Alumno> Alumnos { get { return this._alumnos; } set { ;} }
        public Gimnasio.EClases Clase { get { return this._clase; } set { this._clase = value; } }
        public Instructor Instructor { get { return this._instructor; } set { this._instructor = value; } }
        #endregion
        #region Constructors
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        public Jornada(Gimnasio.EClases clase, Instructor instructor) :this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>true si el alumno esta en la jornada, false si no</returns>
        public static bool operator ==(Jornada j,Alumno a)
        {
            bool flag = false;
            if (!object.Equals(a, null) && !object.Equals(j, null))
            {
                foreach (Alumno item in j._alumnos)
                {
                    if (object.Equals(item,a))
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
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>true si el alumno no esta en la jornada, false si esta</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Sobrecarga del operador + "Agrega el alumno a la jornada"
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Jornada con el alumno cargado</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!object.Equals(a, null) && !object.Equals(j, null))
            {
                if (j != a)
                {
                    j._alumnos.Add(a);
                }
            }
            return j;
        }
        /// <summary>
        /// Sobrecarga del metodo ToString() "Recolecta los datos de la jornada"
        /// </summary>
        /// <returns>String con los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();
            texto.Append("CLASE DE " + this._clase + " POR ");
            texto.AppendLine(this._instructor.ToString());
            texto.AppendLine("ALUMNOS:");
            foreach (Alumno item in this._alumnos)
            {
                texto.AppendLine(item.ToString());
            }
            texto.AppendLine("<------------------------------------------------>");
            return texto.ToString();
        }
        /// <summary>
        /// Guarda los datos de la jornada en un archivo txt
        /// </summary>
        /// <param name="jornada">Jornada</param>
        /// <returns>True si se logro, false si no</returns>
        public static bool Guardar(Jornada jornada)
        {
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Jornada.txt";
            Texto texto = new Texto();
            try
            {
                texto.Guardar(ruta, jornada.ToString());
                return true;
            }
            catch (Exception Exc)
            {
                throw new Excepciones.ArchivosException(Exc);
            }
            
        }
        /// <summary>
        /// Lee los datos de la jornada de un archivo txt
        /// </summary>
        /// <param name="path">string de la ubicacion del archivo</param>
        /// <returns>string con los datos de la jornada</returns>
        public static bool Leer(out String datos)
        {
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Jornada.txt";
            Texto texto = new Texto();
            try
            {
                texto.Leer(ruta, out datos);
                return true;
            }
            catch (Exception exc)
            {
                datos = "";
                throw new Excepciones.ArchivosException(exc);
            }
        }
        #endregion
    }
}
