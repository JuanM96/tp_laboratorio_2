﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Automovil : Vehiculo
    {
        public Automovil(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        /// <summary>
        /// Los automoviles tienen 4 ruedas
        /// </summary>
        protected short CantidadRuedas
        {
            get
            {
                return 4;
            }
        }
        /// <summary>
        /// Devuelve un string con la informacion del automovil
        /// </summary>
        /// <returns>String</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS : "+this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
