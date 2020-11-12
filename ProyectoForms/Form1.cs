using ProyectoForms.Analizadores;
using ProyectoForms.Clases;
using ProyectoForms.EntradasTexto;
using ProyectoForms.ManejoArchivos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using InputKey;
using System.Linq;

namespace ProyectoForms
{
    public partial class ventanaPrincipal : Form
    {
        private ArrayList ventanas = new ArrayList();
        private List<TabPage> pestanas = new List<TabPage>();
        private String pathProyecto = null;
        private Archivo archivos;
        private ListasAceptacion analizar = new ListasAceptacion();

        public ventanaPrincipal()
        {
            InitializeComponent();
            archivos = new Archivo();
            iniciarEventos();
        }

        private void iniciarEventos()
        {
            itemAbrir.Click += new System.EventHandler(this.itemAbrir_Click);
            itemCrear.Click += new System.EventHandler(this.itemCrear_Click);
            itemGuardarCambios.Click += new System.EventHandler(this.buttonGuardar_Click);
            buttonCrear.Click += new System.EventHandler(this.buttonCrear_Click);
            buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            buttonCerrarArch.Click += new System.EventHandler(this.buttonCerrarArch_Click);
            buttonCompilar.Click += new System.EventHandler(this.buttonCompilar_Click);
        }

        private void buttonCompilar_Click(object sender, System.EventArgs e)
        {
            textErrores.Clear();
            List<Token> tokens;
            foreach (PanelTexto panel in ventanas)
            {
                tokens = panel.Compilar();
                foreach (Token token in tokens)
                {
                    if (!token.obtenerAceptado())
                    {
                        textErrores.AppendText("Error en Linea: " + token.obtenerLinea() + " Columna: " + token.obtenerColumna() + "\n");
                    }
                    else
                    {
                        textErrores.AppendText("Tipo de Token: " + token.obtenerTipo() + " Contenido: " + token.obtenerContenido() + " F:" + token.obtenerLinea() + " C:" + token.obtenerColumna() + "\n");
                    }
                }
            }
        }

        private void buttonCerrarArch_Click(object sender, System.EventArgs e)
        {
            if (ventanas.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar los cambios?", "Cerrar Archivo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    cerrarPestana(true);
                }
                else
                {
                    cerrarPestana(false);
                }
            }
        }

        private void cerrarPestana(Boolean guardar)
        {
            int index = tablaControl.SelectedIndex;
            TabControl.TabPageCollection pesta = tablaControl.TabPages;
            int contador = 0;
            foreach (TabPage item in pesta)
            {
                if (contador == index)
                {
                    if (guardar)
                    {
                        int cont = 0;
                        foreach (PanelTexto panel in ventanas)
                        {

                            if (cont == index)
                            {
                                guardarUno(panel);
                                break;
                            }
                            cont++;
                        }
                    }
                    ventanas.RemoveAt(index);
                    pestanas.Remove(item);
                    tablaControl.TabPages.Remove(item);
                    break;
                }
                contador++;
            }
        }

        private void guardarUno(PanelTexto panel)
        {
            guardarArchivos(panel);
        }

        private void buttonGuardar_Click(object sender, System.EventArgs e)
        {
            foreach (PanelTexto item in ventanas)
            {
                guardarArchivos(item);
            }
        }

        private void guardarArchivos(PanelTexto panel)
        {
            if (!archivos.guardarPanel(panel))
            {
                MessageBox.Show("ERROR AL GUARDAR ARCHIVO");
            }
        }

        private void buttonCrear_Click(object sender, System.EventArgs e)
        {
            if (pathProyecto != null)
            {
                String nombre = InputDialog.mostrar("Ingrese el nombre del archivo") + ".gt";
                String path = pathProyecto + "\\" + nombre;
                if (archivos.existeArchivoCreado(nombre, pathProyecto))
                {
                    MessageBox.Show("El DOCUMENTO YA EXISTE");
                }
                else
                {
                    crearDoc(nombre, path, false);
                }
            }
            else
            {
                MessageBox.Show("Debe tener algún Proyecto Abierto");
            }
        }

        private void crearDoc(String nombre, String path, Boolean cargar)
        {
            PanelTexto nuevo = null;
            if (cargar)
            {
                nuevo = new PanelTexto(nombre, path, cargar);
            }
            else
            {
                nuevo = new PanelTexto(nombre, path);
                guardarArchivos(nuevo);
            }
            TabPage pesta = new TabPage(nombre);
            pesta.Controls.Add(nuevo);
            tablaControl.Controls.Add(pesta);
            ventanas.Add(nuevo);
            pestanas.Add(pesta);
            int index = tablaControl.TabPages.IndexOf(pesta);
            tablaControl.SelectedIndex = index;
            llenarArbol(pathProyecto);
        }

        private void itemCrear_Click(object sender, System.EventArgs e)
        {
            CrearProyecto crear = new CrearProyecto();
            crear.ShowDialog();
            if (crear.isCreado())
            {
                llenarArbol(crear.obtenerPath());
            }
        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void itemAbrir_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            llenarArbol(folder.SelectedPath);
        }

        private void llenarArbol(String path)
        {
            arbolArchivos.Nodes.Clear();
            try
            {
                DirectoryInfo informacion = new DirectoryInfo(path);
                arbolArchivos.Nodes.Add(crearRamas(informacion));
                this.pathProyecto = path;
                arbolArchivos.ExpandAll();
            }
            catch (Exception)
            {
                MessageBox.Show("DEBE SELECCIONAR LA CARPETA DEL PROYECTO");
            }

        }

        private TreeNode crearRamas(DirectoryInfo informacion)
        {
            TreeNode arbol = new TreeNode(informacion.Name);
            foreach (var ramita in informacion.GetDirectories())
            {
                arbol.Nodes.Add(crearRamas(ramita));
            }

            foreach (var ramita in informacion.GetFiles())
            {
                arbol.Nodes.Add(new TreeNode(ramita.Name));
            }

            return arbol;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tablaControl_SizeChanged(object sender, EventArgs e)
        {
            foreach (PanelTexto item in ventanas)
            {
                item.SetBounds(0, 0, tablaControl.Size.Width, tablaControl.Size.Height - 30);
            }
        }

        private void tablaControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void arbolArchivos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                String nombre = arbolArchivos.SelectedNode.Text;
                if (seleccionArchivo(nombre))
                {
                    String path = pathProyecto + "\\" + nombre;
                    if (!existeArchivoAbierto(nombre))
                    {
                        crearDoc(nombre, path, true);
                    }
                }
            }
            catch (NullReferenceException)
            {
            }

        }

        private Boolean seleccionArchivo(String nombre)
        {
            char separador = '.';
            String[] nombreArchivo = nombre.Split(separador);
            if (nombreArchivo.Length > 1)
            {
                if (nombreArchivo[1].Equals("gt"))
                {
                    return true;
                }
            }
            return false;
        }

        private Boolean existeArchivoAbierto(String nombre)
        {
            foreach (TabPage pesta in pestanas)
            {
                int index = tablaControl.TabPages.IndexOf(pesta);
                if (pesta.Text.Equals(nombre))
                {
                    tablaControl.SelectedIndex = index;
                    return true;
                }

            }
            return false;
        }

    }
}
