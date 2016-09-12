using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tp1_Calculadora_Juan_Ignacio_Murcia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbOperacion.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        #region botones
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Calculadora.Limpiar(this.txtNumero1, this.txtNumero2, this.lblResultado);
        }
        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero num1 = new Numero(this.txtNumero1.Text);
            Numero num2 = new Numero(this.txtNumero2.Text);
            this.lblResultado.Text = Calculadora.operar(num1,num2,(string)cmbOperacion.SelectedItem).ToString();
        }
        #endregion
    }
}
