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
            textBoxEjercicio.Text += "0";
        }

        private void BotónUno_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text += "1";
        }

        private void BotónDos_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text += "2";
        }

        private void BotónTres_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text += "3";
        }

        private void BotónCuatro_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text += "4";
        }

        private void BotónCinco_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text += "5";
        }

        private void BotónSeis_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text += "6";
        }

        private void BotónSiete_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text += "7";
        }

        private void BotónOcho_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text += "8";
        }

        private void BotónNueve_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text += "9";
        }

        private void BotonCE_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text = "";
        }

        private void BotónDividir_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text += "/";
        }

        private void BotónMultiplicar_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text += "*";
        }

        private void BotónAbrirParentesis_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text += "(";
        }

        private void BotónCerrarParentesis_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text += ")";
        }

        private void BotónRestar_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text += "-";
        }

        private void BotónSuma_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text += "+";
        }

        private void BotónComa_Click(object sender, EventArgs e)
        {
            textBoxEjercicio.Text += ",";
        }

        private void BotónIgual_Click(object sender, EventArgs e)
        {
            textBoxRespuesta.Text = DivisionDeParentesis(textBoxEjercicio.Text);
            textBoxEjercicio.Text = "";
        }

        public string Calcular(string texto)
        {
            double respuestaFinal = RestarYSumar(texto);
            return respuestaFinal.ToString();
            
        }
    
        public string DivisionDeParentesis(string texto)
        {
            while(texto.Contains('(') && texto.Contains(')'))
            {
                int abierto = 0;
                int cerrado = 0;

                for (int i = 0; i < texto.Length; i++)
                {
                    if (texto[i] == '(')
                    {
                        abierto = i;
                    }
                    if (texto[i] == ')')
                    {
                        cerrado = i;

                        texto = texto.Remove(abierto,cerrado-abierto+1).Insert(abierto, ResolverParentesis(abierto, cerrado, texto)); //borra parentesis y lo remplaza con el resultado de lo que estaba adentro

                        break;
                    }
                }
            }


            for (int i = 1; i < texto.Length; i++)
            {
                if (texto[i]=='-' && (texto[i-1]=='*' || texto[i-1] == '/'))
                {
                    for (int j = i-1; j >= 0 ; j--)
                    {
                        if (texto[j]=='+')
                        {
                            StringBuilder texto1 = new StringBuilder(texto);
                            texto1[j] = '-';
                            texto = texto1.ToString();
                            texto = texto.Remove(i, 1);
                            break;
                        }
                        else if (texto[j]=='-')
                        {
                            StringBuilder texto1 = new StringBuilder(texto);
                            texto1[j] = '+';
                            texto = texto1.ToString();
                            texto = texto.Remove(i, 1);
                            break;
                        }
                    }
                }
            }

            for (int i = 1; i < texto.Length; i++)
            {
                if (texto[i] == '-' && (texto[i - 1] == '-' || texto[i - 1] == '+'))
                {
                    if (texto[i - 1] == '-')
                    {
                        StringBuilder texto1 = new StringBuilder(texto);
                        texto1[i] = '+';
                        texto = texto1.ToString();
                        texto = texto.Remove(i - 1, 1);
                    }
                    else
                    {
                        StringBuilder texto1 = new StringBuilder(texto);
                        texto1[i] = '-';
                        texto = texto1.ToString();
                        texto = texto.Remove(i - 1, 1);
                    }

                }else if(texto[i] == '+' && (texto[i - 1] == '-' || texto[i - 1] == '+'))
                {
                    if (texto[i - 1] == '-')
                    {
                        StringBuilder texto1 = new StringBuilder(texto);
                        texto1[i] = '-';
                        texto = texto1.ToString();
                        texto = texto.Remove(i - 1, 1);
                    }
                    else
                    {
                        StringBuilder texto1 = new StringBuilder(texto);
                        texto1[i] = '+';
                        texto = texto1.ToString();
                        texto = texto.Remove(i - 1, 1);
                    }
                }
            }

            if (texto[0] == '-')
            {
                texto = '0' + texto;
            }

            return Calcular(texto);
        }

        private string ResolverParentesis(int abierto, int cerrado, string texto)
        {
            string respuestaPartentesis = Calcular(texto.Substring(abierto + 1, cerrado - abierto - 1));
            return respuestaPartentesis;
        }

        public double RestarYSumar(string textoCalc)
        {
            string[] texto = textoCalc.Split('-');
            List<string> listaTexto = new List<string>();

            for (int i = 0; i < texto.Length; i++)
            {
                listaTexto.Add(texto[i]);
                if (i != texto.Length - 1)
                {
                    listaTexto.Add("-");
                }
            }

            for (int i = 0; i < listaTexto.Count; i++)
            {
                if (listaTexto[i].Contains('+') && listaTexto[i].Length>1)
                {
                    string[] parteDelTexto = listaTexto[i].Split('+');

                    listaTexto.RemoveAt(i);

                    for (int j = parteDelTexto.Length-1; j >= 0; j--)
                    {
                        listaTexto.Insert(i,parteDelTexto[j]);
                        if (j!=0)
                        {
                            listaTexto.Insert(i,"+");
                        }
                    }
                }
                
            }

            double total;

            if (listaTexto[0].Contains('*') || listaTexto[0].Contains('/'))
            {
                total = DivisionYMultiplicacion(listaTexto[0]);
            }
            else
            {
                total = Convert.ToDouble(listaTexto[0]);
            }

            for (int i = 2; i < listaTexto.Count; i+=2)
            {
                if (listaTexto[i - 1] == "-")
                {
                    total = total - DivisionYMultiplicacion(listaTexto[i]);
                }
                else if (listaTexto[i - 1] == "+")
                {
                    total = total + DivisionYMultiplicacion(listaTexto[i]);
                }
                
            }

            return total;
        }
        
        private double DivisionYMultiplicacion(string textoCalc)
        {
            string[] texto = textoCalc.Split('*');
            List<string> listaTexto = new List<string>();

            for (int i = 0; i < texto.Length; i++)
            {
                listaTexto.Add(texto[i]);
                if (i != texto.Length - 1)
                {
                    listaTexto.Add("*");
                }
            }

            for (int i = 0; i < listaTexto.Count; i++)
            {
                if (listaTexto[i].Contains('/') && listaTexto[i].Length > 1)
                {
                    string[] parteDelTexto = listaTexto[i].Split('/');

                    listaTexto.RemoveAt(i);

                    for (int j = parteDelTexto.Length - 1; j >= 0; j--)
                    {
                        listaTexto.Insert(i, parteDelTexto[j]);
                        if (j != 0)
                        {
                            listaTexto.Insert(i, "/");
                        }
                    }
                }

            }

            double total = Convert.ToDouble(listaTexto[0]);
            for (int i = 2; i < listaTexto.Count; i += 2)
            {
                if (listaTexto[i - 1] == "/")
                {
                    total = total / Convert.ToDouble(listaTexto[i]);
                }
                else if (listaTexto[i - 1] == "*")
                {
                    total = total * Convert.ToDouble(listaTexto[i]);
                }

            }

            return total;
        }

    }
}
