using ProyectoForms.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace ProyectoForms.ManejoArchivos
{
    public partial class Archivo
    {
        public Archivo()
        {

        }

        public Boolean guardarPanel(PanelTexto panel)
        {
            String path = panel.obtenerPath();
            RichTextBox text = panel.obtenerTexto();
            try
            {
                text.SaveFile(path); 
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR AL GUARDAR EL ARCHIVO: "+path);
                return false;
            }
        }

        public RichTextBox cargarArchivo(String path)
        {
            RichTextBox text = null;
            try
            {
                text.LoadFile(path);
                return text;
            }
            catch (Exception )
            {
                MessageBox.Show("ERROR AL CARGAR EL ARCHIVO");
            }
            return null;
        }

        public Boolean existeArchivoCreado(String nombre, String pathProyecto)
        {
            String path = pathProyecto + "\\" + nombre;
            if (System.IO.File.Exists(path))
            {
                return true;
            }
            return false;
        }

        public List<String> obtenerListaTexto(String path)
        {
            List<String> lista = new List<string>();
            using (StreamReader ReaderObject = new StreamReader(path))
            {
                string linea;
                while ((linea = ReaderObject.ReadLine()) != null)
                {
                    lista.Add(linea);
                }
                return lista;   
            }
        }

    }
}
