﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Clase_12_Library
{
    public class Moto : Vehiculo
    {
        public Moto(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        /// <summary>
        /// Las motos tienen 2 ruedas
        /// </summary>
        protected short CantidadRuedas
        {
            get
            {
                return 2;
            }
        }
        /// <summary>
        /// Devuelve un string con la informacion de la moto
        /// </summary>
        /// <returns>String</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS : "+this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString() ;
        }
    }
}
