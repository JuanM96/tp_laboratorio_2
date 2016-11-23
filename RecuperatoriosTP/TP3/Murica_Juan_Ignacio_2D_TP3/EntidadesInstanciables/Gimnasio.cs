using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Gimnasio
    {
        public enum EClases
        {
            CrossFit,
            Pilates,
            Natacion,
            Yoga
        }
        #region Fields
        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornadas;
        #endregion
        #region Properties
        public Jornada this[int jornada] 
        {
            get 
            {
                if (this._jornadas.Count > jornada && jornada >= 0)
                {
                    return this._jornadas[jornada];
                }
                else
                    return null;
            }
        }
        public List<Alumno> Alumnos 
        {
            get
            {
                return this._alumnos;
            }
        }
        public List<Instructor> Instructores
        {
            get
            {
                return this._instructores;
            }
        }
        public List<Jornada> Jornadas
        {
            get
            {
                return this._jornadas;
            }
        }
        #endregion
        #region Constructors
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornadas = new List<Jornada>();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="a">Alumno</param>
        /// <returns>true si el alumno esta en el gimnasio, false si no</returns>
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            bool retorno = false;
            if (!object.Equals(g, null) && !object.Equals(a, null))
            {
                foreach (Alumno alumno in g._alumnos)
                {
                    if (alumno == a)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="a">Alumno</param>
        /// <returns>true si el alumno no esta en el gimnasio, false si esta</returns>
        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="i">Intructor</param>
        /// <returns>true si el instructor esta en el gimnasio, false si no</returns>
        public static bool operator ==(Gimnasio g, Instructor i)
        {
            bool flag = false;
            if (!object.Equals(g, null) && !object.Equals(i, null))
            {
                foreach (Instructor item in g._instructores)
                {
                    if (object.Equals(item, i))
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }
        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="i">Intructor</param>
        /// <returns>true si el instructor no esta en el gimnasio, false si esta</returns>
        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="clase">EClases</param>
        /// <returns>El primer instructor que puede dar la clase</returns>
        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            if (!object.Equals(g, null))
            {
                foreach (Instructor i in g._instructores)
                {
                    if (i == clase)
                    {
                        return i;
                    }
                }
            }
            throw new SinInstructorException();
        }
        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="clase">EClases</param>
        /// <returns>El Primer instructor que no de esa clase</returns>
        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            if (!object.Equals(g, null))
            {
                foreach (Instructor i in g._instructores)
                {
                    if (i != clase)
                    {
                        return i;
                    }
                }
            }
            throw new SinInstructorException();
        }
        /// <summary>
        /// Sobrecarga del operador + "Agrega el alumno al gimnasio"
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="a">Alumno</param>
        /// <returns>Gimnasio con el alumno cargado</returns>
        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (!object.Equals(g, null) && !object.Equals(a, null))
            {
                if (g != a)
                {
                    g._alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }
            return g;
        }
        /// <summary>
        /// Sobrecarga del operador + "Agrega el instructor al gimnasio"
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="i">Instructor</param>
        /// <returns>Gimnasio con el instructor cargado</returns>
        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (!object.Equals(g, null) && !object.Equals(i, null))
            {
                if (g != i)
                {
                    g._instructores.Add(i);
                }
            }
            return g;
        }
        /// <summary>
        /// Sobrecarga del operador + "Crea una jornada de la clase y la agrega al gimnasio"
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="clase">EClase</param>
        /// <returns>Gimnasio con la nueva clase cargada</returns>
        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            if (!object.Equals(g, null))
            {
                Instructor instructor = (g == clase);
                if (instructor != null)
                {
                    Jornada jornadaAgregar = new Jornada(clase, instructor);
                    for (int i = 0; i < g._alumnos.Count; i++)
                    {
                        if (g._alumnos[i] == clase)
                            jornadaAgregar += g._alumnos[i];
                    }
                    g._jornadas.Add(jornadaAgregar);
                }
                
            }
            return g;
        }
        /// <summary>
        /// Recolecta los datos de gimnasio
        /// </summary>
        /// <param name="gim">Gimnasio</param>
        /// <returns>String con los datos del gimnasio</returns>
        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder texto = new StringBuilder();
            texto.AppendLine("JORNADAS: ");
            foreach (Jornada item in gim._jornadas)
            {
                texto.AppendLine(item.ToString());
            }
            return texto.ToString();
        }
        /// <summary>
        /// Hace publico mostrardatos()
        /// </summary>
        /// <returns>string con los datos del gimnasio</returns>
        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }
        /// <summary>
        /// Guarda los datos de gim en un archivo XML
        /// </summary>
        /// <param name="gim">Gimnasio</param>
        /// <returns>true si se logro guardar, false si no</returns>
        public static bool Guardar(Gimnasio gim)
        {
            Archivos.Xml<Gimnasio> miXml = new Archivos.Xml<Gimnasio>();
            try
            {
                String path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Gimnasio.xml";
                miXml.Guardar(path, gim);
                return true;
            }
            catch (Exception exc)
            {
                throw new ArchivosException(exc);
            }
        }
        /// <summary>
        /// Recupera los datos del Gimnasio de un archivo xml
        /// </summary>
        /// <returns>Gimnasio con los datos recuperados</returns>
        public static bool Leer(out Gimnasio gim)
        {
            Archivos.Xml<Gimnasio> miXml = new Archivos.Xml<Gimnasio>();
            try
            {
                String path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Gimnasio.xml";
                miXml.Leer(path, out gim);
                return true;
            }
            catch (Exception exc)
            {
                throw new ArchivosException(exc);
            }
        }
        #endregion

    }
}
