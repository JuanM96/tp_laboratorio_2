using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Yamaha, Chevrolet, Ford, Iveco, Scania, BMW
        }
        EMarca _marca;
        string _patente;
        ConsoleColor _color;

        public Vehiculo(string patente,EMarca marca,ConsoleColor color)
        {
            this._patente = patente;
            this._marca = marca;
            this._color = color;
        }
        /// <summary>
        /// Retornará la cantidad de ruedas del vehículo
        /// </summary>
        public abstract short CantidadRuedas { get; set; }
        /// <summary>
        /// Devuelve String con la informacion del vehiculo
        /// </summary>
        /// <returns>String</returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("PATENTE: {0}\r\n", this._patente);
            sb.AppendFormat("MARCA  : {0}\r\n", this._marca.ToString());
            sb.AppendFormat("COLOR  : {0}\r\n", this._color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehículos son iguales si comparten la misma patente
        /// </summary>
        /// <param name="v1">Primer Vehiculo</param>
        /// <param name="v2">Segundo Vehiculo</param>
        /// <returns>true si son distintos , caso contrario false</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            bool flag = false;
            if (!object.Equals(v1,null)&&!object.Equals(v2,null))
            {
                if (object.Equals(v1._patente,v2._patente))
                {
                    flag = true;
                }
            }
            return flag;
        }
        /// <summary>
        /// Dos vehículos son distintos si su patente es distinta
        /// </summary>
        /// <param name="v1">Primer Vehiculo</param>
        /// <param name="v2">Segundo Vehiculo</param>
        /// <returns>true si son distintos , caso contrario false</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
    }
}
