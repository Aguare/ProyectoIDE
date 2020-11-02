using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoForms.Analizadores
{
    class GenerarToken
    {
        private List<Token> tokens = new List<Token>();
        private ListasAceptacion listas = new ListasAceptacion();
        private String formadoTemporal = "";
        private String formado = "";
        private Boolean esAceptado = false;
        private int tipoActual = -1;

        //Automatas para evaluar tipo de token
        private Automata entero;
        private Automata decimall;
        private Automata cadena;
        private Automata comentarioUno;

        public GenerarToken()
        {
            generarAutomatas();
        }

        public void analizarCaracter(Char caracter, int linea, int columna)
        {
            formadoTemporal = "" + caracter;
            int tipo = seGeneraToken(caracter);
            if (tipo != -1)
            {
                esAceptado = true;
                formado = formadoTemporal;
                tipoActual = tipo;
            }
            else
            {
                if (esAceptado)
                {
                    if (tipoActual != TipoDato.comentario)
                    {
                        tokens.Add(new Token(tipoActual, formado, linea, columna, true));
                    }
                    esAceptado = false;
                    formado = "";
                    formadoTemporal = "";
                    tipoActual = -1;
                    generarAutomatas();
                    analizarCaracter(caracter, linea, columna);
                }

            }
        }

        private int seGeneraToken(char caracter)
        {
            List<String> datos = listas.obtenerDatos();
            foreach (String dato in datos)
            {
                if (formadoTemporal.Equals(dato))
                {
                    return TipoDato.variable;
                }
            }

            List<String> operadoresArit = listas.obtenerAritmeticos();
            foreach (String op in operadoresArit)
            {
                if (formadoTemporal.Equals(op))
                {
                    return TipoDato.operadorAritmetico;
                }
            }

            List<String> operadorRela = listas.obtenerRelacionales();
            foreach (String rela in operadorRela)
            {
                if (formadoTemporal.Equals(rela))
                {
                    if (rela.Equals("||") || rela.Equals("&&") || rela.Equals("!"))
                    {
                        return TipoDato.operadorLogico;
                    }
                    else if (rela.Equals("(") || rela.Equals(")"))
                    {
                        return TipoDato.signoAgrupacion;
                    }
                    else
                    {
                        return TipoDato.operadorRelacional;
                    }
                }
            }

            List<String> palabrasReservadas = listas.obtenerPalabrasR();
            foreach (String palabra in palabrasReservadas)
            {
                if (formadoTemporal.Equals(palabra))
                {
                    return TipoDato.palabraReservada;
                }
            }

            if (formadoTemporal.Equals("{") || formadoTemporal.Equals("}"))
            {
                return TipoDato.llaves;
            }
            else if (formadoTemporal.Equals("principal"))
            {
                return TipoDato.principal;
            }
            else if (formadoTemporal.Equals(";"))
            {
                return TipoDato.puntoComa;
            }
            else if (formadoTemporal.Equals("verdadero") || formadoTemporal.Equals("falso"))
            {
                return TipoDato.boleano;
            }
            return analizarConAutomata(caracter);
        }

        private int analizarConAutomata(char caracter)
        {
            entero.analizarCaracter(caracter);
            decimall.analizarCaracter(caracter);
            cadena.analizarCaracter(caracter);
            comentarioUno.analizarCaracter(caracter);
            if (entero.esAceptadoAutomata())
            {
                return TipoDato.entero;
            }
            else if (decimall.esAceptadoAutomata())
            {
                return TipoDato.decimall;
            }
            else if (cadena.esAceptadoAutomata())
            {
                return TipoDato.cadena;
            }
            else if (comentarioUno.esAceptadoAutomata())
            {
                return TipoDato.comentario;
            }
            return -1;
        }

        private void generarAutomatas()
        {
            List<Estado> estados = new List<Estado>();
            ListasAceptacion lista = new ListasAceptacion();
            estados.Add(new Estado("A", false, "[0-9],B"));
            estados.Add(new Estado("B", true, "[0-9],B"));
            List<String> acepta = new List<string>();
            acepta.Add("[0-9]");
            entero = new Automata(estados, acepta, estados[0], lista);

            List<Estado> estados1 = new List<Estado>();
            estados1.Add(new Estado("A", false, "[0-9],B"));
            estados1.Add(new Estado("B", false, "[0-9],B/.,C"));
            estados1.Add(new Estado("C", false, "[0-9],D"));
            estados1.Add(new Estado("D", true, "[0-9],D"));
            List<String> acepta1 = new List<string>();
            acepta1.Add("[0-9]");
            acepta1.Add(".");
            decimall = new Automata(estados1, acepta1, estados1[0], lista);

            List<Estado> estados8 = new List<Estado>();
            estados8.Add(new Estado("A", false, "comillas,B"));
            estados8.Add(new Estado("B", false, "cualquiera,B/comillas,C"));
            estados8.Add(new Estado("C", true, ""));
            List<String> acepta8 = new List<String>();
            acepta8.Add("cualquiera");
            acepta8.Add("espa");
            acepta8.Add("comillas");
            cadena = new Automata(estados8, acepta8, estados8[0], lista);

            List<Estado> estados2 = new List<Estado>();
            estados2.Add(new Estado("A", false, "slash,B"));
            estados2.Add(new Estado("B", false, "ast,C"));
            estados2.Add(new Estado("C", false, "cualquiera,C/ast,D"));
            estados2.Add(new Estado("D", false, "slash,E"));
            estados2.Add(new Estado("E", true, ""));
            List<String> acepta2 = new List<string>();
            acepta2.Add("cualquiera");
            acepta2.Add("espa");
            acepta2.Add("slash");
            comentarioUno = new Automata(estados2, acepta2, estados2[0], lista);
        }

    }
}
