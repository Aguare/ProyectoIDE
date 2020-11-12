using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoForms.Analizadores
{
    public class Token
    {
        private int tipo;
        private String contenido;
        private int linea;
        private int columna;
        private Boolean esAceptado;

        public Token(int tipo, string contenido, int linea, int columna, bool esAceptado)
        {
            this.tipo = tipo;
            this.contenido = contenido;
            this.linea = linea;
            this.columna = columna;
            this.esAceptado = esAceptado;
        }
        public Boolean obtenerAceptado()
        {
            return esAceptado;
        }

        public int obtenerLinea()
        {
           return linea;
        }

        public int obtenerColumna()
        {
            return columna;
        }

        public String obtenerContenido()
        {
            return contenido;
        }

        public int obtenerTipo()
        {
            return tipo;
        }
    }
}
