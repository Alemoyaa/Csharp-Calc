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
        public int NumNeg = 0;
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
        }

        public string Calcular(string texto)
        {
            double respuestaFinal = RestarYSumar(texto);
            return respuestaFinal.ToString();
            
        }
    
        public string DivisionDeParentesis(string texto) // si esta con parentesis entra aca primero
        {
            while(texto.Contains('(') && texto.Contains(')'))
            {
                int abierto = 0;
                int cerrado = 0;
                
                for (int i = 0; i < texto.Length; i++)
                {
                    if (texto[i] == '(')// guarda la posicion del primer parentesis
                    {
                        abierto = i;
                    }
                    if (texto[i] == ')')// guarda la posicion del segundo parentesis
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

        private string ResolverParentesis(int abierto, int cerrado, string texto)// agrega un 0 adelante del - asi no se rompa 
        {
            string textoTemp = texto.Substring(abierto + 1, cerrado - abierto - 1);
            if (textoTemp[0] == '-')
            {
                textoTemp = '0' + textoTemp;
            }
            string respuestaPartentesis = Calcular(textoTemp);
            return respuestaPartentesis;
        }

        public double RestarYSumar(string textoCalc)
        {
            for (int i = 1; i < textoCalc.Length; i++)
			{
                if(textoCalc[i]=='-' && (textoCalc[i-1]=='*' || textoCalc[i-1]=='/'))//cambia un numero negativo a positivo y guarda que es negativo
                {
                    textoCalc = textoCalc.Remove(i, 1);
                    NumNeg = 1;
                }
                if (textoCalc[i] == '-' && textoCalc[i - 1] == '+') // agrega entre +- un cero ej 9+0-9
                {
                    textoCalc = textoCalc.Insert(i,"0");
                }
            }

            string[] texto = textoCalc.Split('-');
            List<string> listaTexto = new List<string>();

            for (int i = 0; i < texto.Length; i++) // hace el calculo de un positivo y negativo(cambiado a positivo) y despues agrega un negativo
            {
                if(texto[i]!=""){
                    listaTexto.Add(texto[i]);
                }
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
                if (textoCalc[0]=='+')//-9*-9 --> problem was "","+","9*9" so it removes the empty and puts 0 --> "0","+","9*9"
                {
                    listaTexto.Insert(0,"0");
                    listaTexto.RemoveAt(1);
                }
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
                    if(NumNeg==1){
                        total = total*-1;
                        NumNeg = 0;
                    }
                }
                else if (listaTexto[i - 1] == "*" )
                {
                    total = total * Convert.ToDouble(listaTexto[i]);
                    if(NumNeg==1){
                        total = total*-1;
                        NumNeg = 0;
                    }
                }

            }

            return total;
        }
        
    }
}
