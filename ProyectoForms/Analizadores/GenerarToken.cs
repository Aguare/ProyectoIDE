using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoForms.Analizadores
{
    public class GenerarToken
    {
        private ListasAceptacion listas = new ListasAceptacion();
        private String formadoTemporal = "";
        private String formado = "";
        private Boolean esAceptado = false;
        private int tipoActual = -1;
        private Boolean retornarDirecto = false;
        private Boolean saltoSiguiente = false;

        //Automatas para evaluar tipo de token
        private Automata entero;
        private Automata decimall;
        private Automata cadena;
        private Automata comentarioUno;
        private Automata nombreVariable;

        public GenerarToken()
        {
            generarAutomatas();
        }

        public Boolean obtenerSalto()
        {
            return saltoSiguiente;
        }

        public void setSalto(Boolean set)
        {
            saltoSiguiente = set;
        }
        public Token analizarCaracter(Char caracter, char segundoCaracter, int linea, int columna)
        {
            int tipo = compararCaracteres(caracter);
            int tipoRelacional = -1;

            if (tipo != -1)
            {
                if (!char.IsWhiteSpace(segundoCaracter))
                {
                    tipoRelacional = compararRelacionales("" + caracter + segundoCaracter);
                }
                if (tipoRelacional != -1)
                {
                    saltoSiguiente = true;
                    return new Token(tipo, "" + caracter + segundoCaracter, linea, columna, true);
                }
                retornarDirecto = true;
                return new Token(tipo, "" + caracter, linea, columna, true);
            }
            else
            {
                formadoTemporal += "" + caracter;
                return verificarTipo(caracter, linea, columna);
            }
        }

        private Token verificarTipo(char caracter, int linea, int columna)
        {
            int tipo = compararPalabras(caracter);
            if (tipo != -1)
            {
                esAceptado = true;
                formado = formadoTemporal;
                tipoActual = tipo;
                return new Token(tipoActual, formado, linea, (columna - (formado.Length - 1)), true);
            }
            return null;
        }

        public void reiniciarEstados()
        {
            esAceptado = false;
            borrarTokenFormado();
            retornarDirecto = false;
            tipoActual = -1;
            generarAutomatas();
        }

        public Token errorLexico(int linea, int columna)
        {
            if (!formadoTemporal.Equals("") && tipoActual == -1)
            {
                formado = "";
                formadoTemporal = "";
                return new Token(-1, formadoTemporal, (linea + 1), columna, false);
            }
            return null;
        }

        private void borrarTokenFormado()
        {
            if (retornarDirecto)
            {
                formado = "";
                formadoTemporal = "";
            }
            else
            {
                char[] formadoAct = formado.ToCharArray();
                char[] formadoTemp = formadoTemporal.ToCharArray();
                String queda = "";
                for (int i = formadoAct.Length; i < formadoTemp.Length; i++)
                {
                    if (!char.IsWhiteSpace(formadoTemp[i]))
                    {
                        queda += formadoTemp[i];
                    }
                }
                formado = "";
                formadoTemporal = queda;
            }
        }

        private int compararRelacionales(String dosCaracteres)
        {
            List<String> operadorRela = listas.obtenerRelacionales();
            foreach (String rela in operadorRela)
            {
                if (dosCaracteres.Equals(rela))
                {
                    if (dosCaracteres.Equals(">=") || dosCaracteres.Equals("<=") || dosCaracteres.Equals("==") || dosCaracteres.Equals("!="))
                    {
                        return TipoDato.operadorRelacional;
                    }
                }
            }
            return -1;
        }

        private int compararCaracteres(char caracter)
        {
            String comparacion = "" + caracter;
            List<String> operadoresArit = listas.obtenerAritmeticos();
            foreach (String op in operadoresArit)
            {
                if (comparacion.Equals(op))
                {
                    return TipoDato.operadorAritmetico;
                }
            }

            List<String> operadorRela = listas.obtenerRelacionales();
            foreach (String rela in operadorRela)
            {
                if (comparacion.Equals(rela))
                {
                    if (rela.Equals("!"))
                    {
                        return TipoDato.operadorLogico;
                    }
                    else if (rela.Equals("("))
                    {
                        retornarDirecto = true;
                        return TipoDato.abreParentesis;
                    }
                    else if (rela.Equals(")"))
                    {
                        retornarDirecto = true;
                        return TipoDato.cierraParentesis;
                    }
                    else
                    {
                        return TipoDato.operadorRelacional;
                    }
                }
            }

            if (comparacion.Equals("{"))
            {
                retornarDirecto = true;
                return TipoDato.abreLlaves;
            }
            else if (comparacion.Equals("}"))
            {
                retornarDirecto = true;
                return TipoDato.cierraLlaves;
            }
            else if (comparacion.Equals(";"))
            {
                retornarDirecto = true;
                return TipoDato.puntoComa;
            }
            else if (comparacion.Equals("="))
            {
                return TipoDato.igual;
            }
            else if (comparacion.Equals(","))
            {
                return TipoDato.coma;
            }
            else if (comparacion.Equals("."))
            {
                return TipoDato.punto;
            }
            return -1;
        }

        private int compararPalabras(char caracter)
        {
            List<String> datos = listas.obtenerDatos();
            foreach (String dato in datos)
            {
                if (formadoTemporal.Equals(dato))
                {
                    if (formadoTemporal.Equals("verdadero") || formadoTemporal.Equals("falso"))
                    {
                        return TipoDato.boleano;
                    }
                    return TipoDato.variable;
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

            if (formadoTemporal.Equals("principal"))
            {
                return TipoDato.principal;
            }
            else if (formadoTemporal.Equals("imprimir"))
            {
                return TipoDato.imprimir;
            }
            else if (formadoTemporal.Equals("leer"))
            {
                return TipoDato.leer;
            }
            else if (formadoTemporal.Equals("||") || formadoTemporal.Equals("&&"))
            {
                return TipoDato.operadorLogico;
            }
            return analizarConAutomata(caracter);
        }

        private int analizarConAutomata(char caracter)
        {
            entero.analizarCaracter(caracter);
            decimall.analizarCaracter(caracter);
            cadena.analizarCaracter(caracter);
            comentarioUno.analizarCaracter(caracter);
            nombreVariable.analizarCaracter(caracter);
            //MessageBox.Show("Contenido:" + nombreVariable.obtenerCadena() + " Aceptado:" + nombreVariable.esAceptadoAutomata());
            if (entero.esAceptadoAutomata() && !entero.getRompe())
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
            else if (nombreVariable.esAceptadoAutomata())
            {
                return TipoDato.variableNombre;
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
            estados8.Add(new Estado("B", false, "comillas,C/cualquiera,B"));
            estados8.Add(new Estado("C", true, ""));
            List<String> acepta8 = new List<String>();
            acepta8.Add("cualquiera");
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
            acepta2.Add("ast");
            comentarioUno = new Automata(estados2, acepta2, estados2[0], lista);

            List<Estado> estados3 = new List<Estado>();
            estados3.Add(new Estado("A", false, "_,B"));
            estados3.Add(new Estado("B", false, "[A-Z],C"));
            estados3.Add(new Estado("C", false, "_,D/[A-Z],C/[0-9],C"));
            estados3.Add(new Estado("D", true, ""));
            List<String> acepta3 = new List<string>();
            acepta3.Add("_");
            acepta3.Add("[A-Z]");
            acepta3.Add("[0-9]");
            nombreVariable = new Automata(estados3, acepta3, estados3[0], lista);
        }

    }
}
