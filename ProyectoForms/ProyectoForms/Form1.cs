using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoForms
{
    public partial class ventanaPrincipal : Form
    {
        public ventanaPrincipal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textEntrada_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
