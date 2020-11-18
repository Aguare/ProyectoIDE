using ProyectoForms.Analizadores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoForms.Sintactico
{
    public class AnalizadorSintactico
    {
        private List<Bloque> bloques = new List<Bloque>();
        private List<Token> tokens;
        Complejo c1;
        public AnalizadorSintactico(List<Token> tokens)
        {
            crearBloques();
            crearComplejos();
            this.tokens = tokens;
        }

        public List<String> analizarTokens()
        {
            c1.analizarEntrada(tokens);
            return c1.obtenerErrores();
        }

        private void crearComplejos()
        {
            List<String> estructuraSI = new List<String>();
            estructuraSI.Add("PR_Principal");
            estructuraSI.Add("Parentesis Apertura");
            estructuraSI.Add("Parentesis Cierre");
            estructuraSI.Add("Llave Apertura");
            estructuraSI.Add("Declarar Variable");
            estructuraSI.Add("Llave Cierre");
            c1 = new Complejo(estructuraSI, bloques);
        }
        private void crearBloques()
        {
            List<String> declararVariable = new List<String>();
            declararVariable.Add("TD");
            declararVariable.Add("Id");
            declararVariable.Add("Asignacion");
            declararVariable.Add("Entero,Decimal,Cadena,Booleano");
            declararVariable.Add("Fin Sentencia");
            bloques.Add(new Bloque(declararVariable, "Declarar Variable"));
        }
    }
}
