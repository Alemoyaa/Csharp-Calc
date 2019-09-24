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
    }
    public class Expresion
    {
        private static double SubExpressao(double operando1, double operando2, char sinal)
        {// esto hace las calculaciones
            switch (sinal)
            {
                case '+': return operando1 + operando2;

                case '-': return operando1 - operando2;

                case '*': return operando1 * operando2;

                case '/': return operando1 / operando2;

                default: return 0; //Retorno estándar, solo para satisfacer al compilador

            }
        }
    }
}
