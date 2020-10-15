using ProyectoForms.ManejoArchivos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoForms.Analizadores
{
    public class ListasAceptacion
    {
        //Objetos para el manerjo del analizador
        Archivo archivos = new Archivo();

        //Listas de caracteres de aceptacion para su analisis
        List<String> aritmeticos = new List<string>();
        Color colorAritmeticos;
        List<String> datos = new List<string>();
        List<Color> colorDatos = new List<Color>();
        List<String> palabrasR = new List<string>();
        Color colorPalabrasR;
        List<String> relacionales = new List<string>();
        Color colorRelacionales;
        List<String> asignacionFin = new List<string>();
        Color colorAsignacionFin;

        public ListasAceptacion()
        {
            cargarListas();
        }

        public List<String> obtenerAritmeticos()
        {
            return aritmeticos;
        }

        public List<String> obtenerDatos()
        {
            return datos;
        }

        public List<String> obtenerPalabrasR()
        {
            return palabrasR;
        }

        public List<String> obtenerRelacionales()
        {
            return relacionales;
        }

        public List<String> obtenerAsignacionFin()
        {
            return asignacionFin;
        }

        public Color obtenerColorAritmeticos()
        {
            return colorAritmeticos;
        }

        public List<Color> obtenerColorDatos()
        {
            return colorDatos;
        }

        public Color obtenerColorPalabrasR()
        {
            return colorPalabrasR;
        }

        public Color obtenerColorRelacionales()
        {
            return colorRelacionales;
        }

        public Color obtenerColorAsignacionFin()
        {
            return colorAsignacionFin;
        }

        public Color obtenerColorDato(String dato)
        {
            for (int i = 0; i < datos.Count; i++)
            {
                if (datos[i].Equals(dato))
                {
                    return colorDatos[i];
                }
            }
            return Color.Red;
        }

        private void cargarListas()
        {
            String path = "..\\..\\..\\ArchivosAceptados\\Aritmeticos.txt";
            aritmeticos = archivos.obtenerListaTexto(path);
            colorAritmeticos = obtenerColorInicio(aritmeticos);

            path = "..\\..\\..\\ArchivosAceptados\\AsignacionFin.txt";
            asignacionFin = archivos.obtenerListaTexto(path);
            colorAsignacionFin = obtenerColorInicio(asignacionFin);

            path = "..\\..\\..\\ArchivosAceptados\\PalabrasR.txt";
            palabrasR = archivos.obtenerListaTexto(path);
            colorPalabrasR = obtenerColorInicio(palabrasR);

            path = "..\\..\\..\\ArchivosAceptados\\RelacionalesLogicos.txt";
            relacionales = archivos.obtenerListaTexto(path);
            colorRelacionales = obtenerColorInicio(relacionales);

            cargarListaDatos();
        }

        private Color obtenerColorInicio(List<String> lista)
        {
            String linea = lista[0];
            String[] rgb = linea.Split(",");
            lista.RemoveAt(0);
            return Color.FromArgb(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2]));
        }

        private void cargarListaDatos()
        {
            String path = "..\\..\\..\\ArchivosAceptados\\Datos.txt";
            List<String> temporal = archivos.obtenerListaTexto(path);
            foreach (String linea in temporal)
            {
                String[] partes = linea.Split(",");
                datos.Add(partes[0]);
                colorDatos.Add(Color.FromArgb(int.Parse(partes[1]), int.Parse(partes[2]), int.Parse(partes[3])));
            }
        }


    }
}
