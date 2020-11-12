using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ProyectoForms.Analizadores;
using System.Xml.Serialization;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace ProyectoForms.Clases
{
    public partial class PanelTexto : UserControl
    {
        private ListasAceptacion listas = new ListasAceptacion();
        private LectorExpresion lector;
        private String path;
        private String nombre;

        public PanelTexto(String nombre, String path)
        {
            InitializeComponent();
            this.path = path;
            this.nombre = nombre;
        }

        public PanelTexto(String nombre, String path, Boolean cargar)
        {
            InitializeComponent();
            this.path = path;
            this.nombre = nombre;
            cargarArchivo();
        }

        public List<Token> Compilar()
        {
            cambiarColores();
            lector = new LectorExpresion();
            lector.generarTokensCodigo(textEntrada.Lines);
            return lector.obtenerTokenLista();
        }

        private void cambiarConfiguracion()
        {
            textEntrada.SelectionStart = textEntrada.TextLength;
            textEntrada.ForeColor = Color.Black;
        }

        private void cargarArchivo()
        {
            try
            {
                textEntrada.LoadFile(this.path);
            }
            catch (Exception)
            {
                MessageBox.Show("NO SE CARGÓ CORRECTAMENTE EL ARCHIVO: " + path);
            }
        }

        public String obtenerPath()
        {
            return path;
        }

        public String obtenerNombre()
        {
            return nombre;
        }
        //Estos seran los métodos para obtener los componentes y poder guardar el texto
        public RichTextBox obtenerTexto()
        {
            return textEntrada;
        }

        private void textEntrada_TextChanged(object sender, EventArgs e)
        {
            lineasNumeros.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int caracter = 0;
            int altura = textEntrada.GetPositionFromCharIndex(0).Y;

            if (textEntrada.Lines.Length > 1)
            {
                for (int i = 0; i < textEntrada.Lines.Length; i++)
                {
                    String num = "" + (i + 1);
                    e.Graphics.DrawString(num, textEntrada.Font, Brushes.White, lineasNumeros.Width - (e.Graphics.MeasureString(num, textEntrada.Font).Width + 5), altura);
                    caracter = textEntrada.GetFirstCharIndexFromLine(i + 1);
                    altura = textEntrada.GetPositionFromCharIndex(caracter).Y;
                }
            }
            else
            {
                e.Graphics.DrawString("1", textEntrada.Font, Brushes.White, lineasNumeros.Width - (e.Graphics.MeasureString("1", textEntrada.Font).Width + 5), altura);
            }
        }

        private void textEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            lineasNumeros.Refresh();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private void textEntrada_VScroll(object sender, EventArgs e)
        {
            lineasNumeros.Refresh();
        }

        private void textEntrada_SelectionChanged(object sender, EventArgs e)
        {
            int ubicacion = textEntrada.SelectionStart;
            int fila = textEntrada.GetLineFromCharIndex(ubicacion);
            int primerCaracter = textEntrada.GetFirstCharIndexFromLine(fila);
            int columna = ubicacion - primerCaracter;
            fila += 1;
            labelPoint.Text = ("Fila: " + fila + " Columna: " + columna);
        }

        private void cambiarColores()
        {
            try
            {
                SuspendLayout();
                textEntrada.SelectionStart = 0;
                textEntrada.SelectionLength = textEntrada.Text.Length;
                textEntrada.SelectionColor = textEntrada.ForeColor;
                List<String> relacionales = listas.obtenerRelacionales();
                List<String> aritmeticos = listas.obtenerAritmeticos();
                List<String> asignacion = listas.obtenerAsignacionFin();
                List<String> datos = listas.obtenerDatos();
                List<Color> colores = listas.obtenerColorDatos();
                List<String> palabras = listas.obtenerPalabrasR();

                foreach (String caracter in aritmeticos)
                {
                    int inicio = 0;
                    while (inicio <= textEntrada.Text.LastIndexOf(caracter))
                    {
                        textEntrada.Find(caracter, inicio, textEntrada.TextLength, RichTextBoxFinds.WholeWord);
                        textEntrada.SelectionColor = listas.obtenerColorAritmeticos();
                        inicio = textEntrada.Text.IndexOf(caracter, inicio) + 1;
                    }
                }
                foreach (String caracter in asignacion)
                {
                    int inicio = 0;
                    while (inicio <= textEntrada.Text.LastIndexOf(caracter))
                    {
                        textEntrada.Find(caracter, inicio, textEntrada.TextLength, RichTextBoxFinds.WholeWord);
                        textEntrada.SelectionColor = listas.obtenerColorAsignacionFin();
                        inicio = textEntrada.Text.IndexOf(caracter, inicio) + 1;
                    }
                }
                foreach (String caracter in relacionales)
                {
                    int inicio = 0;
                    while (inicio <= textEntrada.Text.LastIndexOf(caracter))
                    {
                        textEntrada.Find(caracter, inicio, textEntrada.TextLength, RichTextBoxFinds.WholeWord);
                        textEntrada.SelectionColor = Color.Blue;
                        inicio = textEntrada.Text.IndexOf(caracter, inicio) + 1;
                    }
                }
                foreach (String caracter in datos)
                {
                    int inicio = 0;
                    while (inicio <= textEntrada.Text.LastIndexOf(caracter))
                    {
                        textEntrada.Find(caracter, inicio, textEntrada.TextLength, RichTextBoxFinds.WholeWord);
                        textEntrada.SelectionColor = listas.obtenerColorDato(caracter);
                        inicio = textEntrada.Text.IndexOf(caracter, inicio) + 1;
                    }
                }

                foreach (String caracter in palabras)
                {
                    Color color = listas.obtenerColorPalabrasR();
                    int inicio = 0;
                    while (inicio <= textEntrada.Text.LastIndexOf(caracter))
                    {
                        textEntrada.Find(caracter, inicio, textEntrada.TextLength, RichTextBoxFinds.WholeWord);
                        textEntrada.SelectionColor = color;
                        inicio = textEntrada.Text.IndexOf(caracter, inicio) + 1;
                    }
                }
                foreach (Match expresion in Regex.Matches(textEntrada.Text, "[0-9]+"))
                {
                    textEntrada.Select(textEntrada.Find(expresion.ToString()), expresion.ToString().Length);
                    textEntrada.SelectionColor = Color.FromArgb(125, 5, 119);
                }
                foreach (Match expresion in Regex.Matches(textEntrada.Text, "//.*?"))
                {
                    textEntrada.Select(textEntrada.Find(expresion.ToString()), expresion.ToString().Length);
                    textEntrada.SelectionColor = Color.FromArgb(255, 0, 0);
                }
                foreach (Match expresion in Regex.Matches(textEntrada.Text, "/*.*?.*/"))
                {
                    textEntrada.Select(textEntrada.Find(expresion.ToString()), expresion.ToString().Length);
                    textEntrada.SelectionColor = Color.FromArgb(255, 0, 0);
                }
                foreach (Match expresion in Regex.Matches(textEntrada.Text, "\".*?\""))
                {
                    textEntrada.Select(textEntrada.Find(expresion.ToString()), expresion.ToString().Length);
                    textEntrada.SelectionColor = Color.Gray;
                }
                ResumeLayout();
                cambiarConfiguracion();
            }
            catch (Exception)
            {
                MessageBox.Show("NO SE PUEDEN MODIFICAR LOS COLORES");
            }
        }
    }

}
