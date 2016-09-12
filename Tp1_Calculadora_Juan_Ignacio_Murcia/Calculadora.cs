using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1_Calculadora_Juan_Ignacio_Murcia
{
    class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Recibe 2 textbox y 1 label y los establece en 0
        /// </summary>
        /// <param name="txtNum1">TextBox del primer numero</param>
        /// <param name="txtNum2">TextBox del segundo numero</param>
        /// <param name="lblRes">Label del resultado</param>
        public static void Limpiar(System.Windows.Forms.TextBox txtNum1,System.Windows.Forms.TextBox txtNum2,System.Windows.Forms.Label lblRes)
        {
            txtNum1.Text = "0";
            txtNum2.Text = "0";
            lblRes.Text = "0";
        }
        /// <summary>
        /// Recibe 2 numeros , el operador , realiza la operacion y devuelve el resultado(double)
        /// </summary>
        /// <param name="num1">Primer Numero (Numero)</param>
        /// <param name="num2">Segundo Numero (Numero)</param>
        /// <param name="operador">Operando (string)</param>
        /// <returns>Resultado (double)</returns>
        public static double operar(Numero num1, Numero num2, string operador)
        {
            double res;
            operador = validarOperador(operador);
            switch (operador)
            {
                case "+":
                    res = num1.getNumero() + num2.getNumero();
                    break;
                case "-":
                    res = num1.getNumero() - num2.getNumero();
                    break;
                case "/":
                    if (num2.getNumero() == 0)
                    {
                        res = 0;
                    }
                    else
                    {
                        res = num1.getNumero() / num2.getNumero();
                    }
                    break;
                case "*":
                    res = num1.getNumero() * num2.getNumero();
                    break;
                default:
                    res = num1.getNumero() + num2.getNumero();
                    break;
            }
            return res;
        }
        /// <summary>
        /// Recibe el operador y lo valida entre los existentes
        /// </summary>
        /// <param name="operador">String que indica el operador</param>
        /// <returns>El operador si es uno de los correctos, sino devuelve +</returns>
        public static string validarOperador(string operador)
        {
            string ret;
            switch (operador)
            {
                case "+":
                    ret = "+";
                    break;
                case "-":
                    ret = "-";
                    break;
                case "/":
                    ret = "/";
                    break;
                case "*":
                    ret = "*";
                    break;
                default:
                    ret = "+";
                    break;
            }
            return ret;
        }
        #endregion
    }
}
