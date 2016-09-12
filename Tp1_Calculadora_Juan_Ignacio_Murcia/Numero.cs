using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1_Calculadora_Juan_Ignacio_Murcia
{
    class Numero
    {
        #region Atributos
        private double numero;
        #endregion
        #region Metodos
        /// <summary>
        /// Obtiene el numero del objeto
        /// </summary>
        /// <returns>devuelve el numero (double)</returns>
        public double getNumero()
        {
            return this.numero;
        }
        /// <summary>
        /// Parsea el numero si es posible.
        /// </summary>
        /// <param name="num">Numero string</param>
        /// <returns>devuelve en caso que sea posible parsear el numero, sino 0</returns>
        private static double validarNumero(string num)
        {
            double retorno;
            if (double.TryParse(num,out retorno))
            {
                return retorno;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Guarda el numero validado en el objeto Numero.
        /// </summary>
        /// <param name="num">Numero String</param>
        private void setNumero(string num)
        {
            this.numero = validarNumero(num);
        }
        #endregion
        #region Constructores
        /// <summary>
        /// Estable el numero en 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Recibe un string y lo establece en numero parseandolo
        /// </summary>
        /// <param name="num">Numero a parsear y establecer</param>
        public Numero(string num)
        {
            setNumero(num);
        }
        /// <summary>
        /// Recibe un Double numero y lo establece en numero;
        /// </summary>
        /// <param name="num">Numero a establecer</param>
        public Numero(double num)
        {
            this.numero = num;
        }
        #endregion
    }
}
