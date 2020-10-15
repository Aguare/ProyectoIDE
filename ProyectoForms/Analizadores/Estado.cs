using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ProyectoForms.Analizadores
{
    public class Estado
    {
        private String nombre;
        private Boolean esAceptacion;
        private List<String> transiciones;

        public Estado(String nombre, Boolean esAceptacion, String tran)
        {
            this.nombre = nombre;
            this.esAceptacion = esAceptacion;
            this.transiciones = agregarTransicion(tran);
        }

        private List<String> agregarTransicion(String entrada)
        {
            List<String> nuevaLista = new List<string>();
            String[] partes = entrada.Split("/");
            foreach (String orden in partes)
            {
                nuevaLista.Add(orden);
            }
            return nuevaLista;
        }

        public String obtenerNombre()
        {
            return nombre;
        }

        public Boolean esDeAceptacion()
        {
            return esAceptacion;
        }

        public List<String> obtenerTransiciones()
        {
            return transiciones;
        }
    }
}
