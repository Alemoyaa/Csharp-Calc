using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
        }

        private void BotónCero_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + "0";
        }

        private void BotónUno_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + "1";
        }

        private void BotónDos_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + "2";
        }

        private void BotónTres_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + "3";
        }

        private void BotónCuatro_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + "4";
        }

        private void BotónCinco_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + "5";
        }

        private void BotónSeis_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + "6";
        }

        private void BotónSiete_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + "7";
        }

        private void BotónOcho_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + "8";
        }

        private void BotónNueve_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + "9";
        }

        private void BotónDividir_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + "/";
        }

        private void BotónMultiplicar_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + "*";
        }

        private void BotónAbrirParentesis_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + "(";
        }

        private void BotónCerrarParentesis_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + ")";
        }

        private void BotónRestar_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + "-";
        }

        private void BotónSuma_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + "+";
        }

        private void BotónComa_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = textBoxEjercicio.Text + ",";
        }
    }
    public class Expresion
    {
        private static double SubExpressao(double op1, double op2, char sinal)
        {// esto hace las calculaciones
            switch (sinal)
            {
                case '+': return op1 + op2;

                case '-': return op1 - op2;

                case '*': return op1 * op2;

                case '/': return op1 / op2;

                default: return 0; //Retorno estándar, solo para satisfacer al compilador

            }
        }
    }
}
