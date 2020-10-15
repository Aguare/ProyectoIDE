using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProyectoForms.EntradasTexto
{
    public partial class CrearProyecto : Form
    {
        private String pathCreacion = "";
        private Boolean esCreado = false;

        public CrearProyecto()
        {
            InitializeComponent();
        }

        public String obtenerPath()
        {
            return pathCreacion;
        }

        public Boolean isCreado()
        {
            return esCreado;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSeleccion_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            textPath.Clear();
            textPath.Text = folder.SelectedPath;
        }

        private void textNombreProyecto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == Convert.ToChar(Keys.Space);
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            String nombreProyecto = textNombreProyecto.Text;
            String path = textPath.Text;
            if (!nombreProyecto.Equals("") && !path.Equals(""))
            {
                path += "/"+nombreProyecto;
                this.pathCreacion = path;
                if (verificarExisteCarpeta(path))
                {
                    MessageBox.Show("EL PROYECTO YA EXISTE");
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    esCreado = true;
                    this.Dispose();
                }
                
            }
            else
            {
                MessageBox.Show("Asegurese de cumplir con todos los campos");
            }
            
        }

        private Boolean verificarExisteCarpeta(String path)
        {
            return Directory.Exists(path);
        }
    }
}
