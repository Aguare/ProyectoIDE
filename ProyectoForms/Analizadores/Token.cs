using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoForms.Analizadores
{
    class Token
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

    }
}
