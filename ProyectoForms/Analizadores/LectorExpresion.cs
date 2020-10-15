using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoForms.Analizadores
{
    public class LectorExpresion
    {
        ListasAceptacion listas = new ListasAceptacion();
        //([a-z|0-9]+(signo aritmetico)([a-z|0-9])+)+;
        private Automata operacionAritmetica;
        //([a-z|0-9]+(signo relacional)([a-z|0-9])+)+
        private Automata operacionRelacional;
        //([a-z|0-9])+
        private Automata entradaNumerosyTexto;
        //([a-z|0-9])+espacio'='espacio
        private Automata entradaVariableIgual;
        //("cualquier+" | [a-z|0-9] )( '+' )*;
        private Automata entradaCadena;
        private Automata soloCadena;
        //(=|;)
        private Automata entradaAsignacion;
        //SOLO LETRAS;
        private Automata entradaTexto;
        private AutomataComplejo decim;

        //automatas complejos para evaluar las líneas a examinar
        private AutomataComplejo entero;
        private AutomataComplejo cadena;
        private AutomataComplejo boleano;

        public LectorExpresion()
        {
            generarAutomatas();
            generarAutomatasComplejos();
        }

        public Boolean analizarLinea(String linea)
        {
            String[] partes = linea.Split(" ");
            String lineaNueva = "";
            if (partes.Length > 2)
            {
                lineaNueva += partes[1] + " " + partes[2] + " ";
            }
            for (int i = 3; i < partes.Length; i++)
            {              
                lineaNueva += partes[i];
            }
            switch (partes[0])
            {
                case "Entero":
                    return analizarConAutomata(entero, lineaNueva);
                case "Decimal":
                    return analizarConAutomata(decim, lineaNueva);
                case "Cadena":
                    return analizarConAutomata(cadena, lineaNueva);
                case "Boolean":
                    return analizarConAutomata(boleano, lineaNueva);
                case "Chart":
                    return true;
                default:
                    List<String> lista = listas.obtenerPalabrasR();
                    foreach (String palabra in lista)
                    {
                        if (palabra.Equals(partes[0]))
                        {
                            return true;
                        }
                    }
                    return false;
            }
        }

        private Boolean analizarConAutomata(AutomataComplejo auto, String linea)
        {
            char[] caracteres = linea.ToCharArray();
            foreach (char caracter in caracteres)
            {
                auto.analizar(caracter);
            }
            return auto.verificarAceptacion();
        }

        private void generarAutomatasComplejos()
        {
            List<Automata> listEntero = new List<Automata>();
            listEntero.Add(entradaNumerosyTexto);
            listEntero.Add(entradaAsignacion);
            listEntero.Add(operacionAritmetica);
            entero = new AutomataComplejo(listEntero, listEntero[0]);

            decim = new AutomataComplejo(listEntero, listEntero[0]);

            List<Automata> listCadena = new List<Automata>();
            listCadena.Add(entradaNumerosyTexto);
            listCadena.Add(entradaAsignacion);
            listCadena.Add(entradaCadena);
            cadena = new AutomataComplejo(listCadena,listCadena[0]);

            List<Automata> listBooleano = new List<Automata>();
            listBooleano.Add(entradaNumerosyTexto);
            listBooleano.Add(entradaAsignacion);
            listBooleano.Add(entradaTexto);
            boleano = new AutomataComplejo(listBooleano, listBooleano[0]);

            List<Automata> listTexto = new List<Automata>();
            listTexto.Add(entradaNumerosyTexto);
            listTexto.Add(entradaAsignacion);
            listTexto.Add(entradaTexto);
            AutomataComplejo texto = new AutomataComplejo(listTexto,listTexto[0]);
        }

        private void generarAutomatas()
        {
            List<Estado> estados = new List<Estado>();
            ListasAceptacion lista = new ListasAceptacion();
            estados.Add(new Estado("A", false, "[A-Z],B/[0-9],C"));
            estados.Add(new Estado("B", true, "[A-Z],B/[0-9],C"));
            estados.Add(new Estado("C", true, "[0-9],C/[A-Z],B"));
            List<String> acepta = new List<string>();
            acepta.Add("[A-Z]");
            acepta.Add("[0-9]");
            entradaNumerosyTexto = new Automata(estados, acepta, estados[0], lista);

            List<Estado> estados2 = new List<Estado>();
            List<String> acepta2 = new List<string>();
            estados2.Add(new Estado("A", false, "[A-Z],B/[0-9],C"));
            estados2.Add(new Estado("B", true, "[A-Z],B/[0-9],C/arit,D"));
            estados2.Add(new Estado("C", true, "[A-Z],B/[0-9],C/arit,D"));
            estados2.Add(new Estado("D", false, "[A-Z],E/[0-9],F"));
            estados2.Add(new Estado("E", false, "[A-Z],G/[0-9],H"));
            estados2.Add(new Estado("F", true, "[A-Z],G/[0-9],H"));
            estados2.Add(new Estado("G", false, "[A-Z],G/[0-9],H/arit,D"));
            estados2.Add(new Estado("H", true, "[A-Z],G/[0-9],H/arit,D"));
            acepta2.Add("[A-Z]");
            acepta2.Add("[0-9]");
            acepta2.Add("arit");
            acepta2.Add("()");
            acepta2.Add(";");
            operacionAritmetica = new Automata(estados2, acepta2, estados2[0], lista);

            List<Estado> estados3 = new List<Estado>();
            List<String> acepta3 = new List<string>();
            estados3.Add(new Estado("A", false, "[A-Z],B/[0-9],C"));
            estados3.Add(new Estado("B", false, "[A-Z],B/[0-9],C/rela,D"));
            estados3.Add(new Estado("C", false, "[A-Z],B/[0-9],C/rela,D"));
            estados3.Add(new Estado("D", false, "[A-Z],E/[0-9],F"));
            estados3.Add(new Estado("E", false, "[A-Z],G/[0-9],H"));
            estados3.Add(new Estado("F", false, "[A-Z],G/[0-9],H"));
            estados3.Add(new Estado("G", false, "[A-Z],G/[0-9],H/rela,D"));
            estados3.Add(new Estado("H", true, "[A-Z],G/[0-9],H/rela,D"));
            acepta3.Add("espa");
            acepta3.Add("[A-Z]");
            acepta3.Add("[0-9]");
            acepta3.Add("rela");
            acepta3.Add("()");
            acepta3.Add(".");
            acepta3.Add(";");
            operacionRelacional = new Automata(estados3, acepta3, estados3[0], lista);

            List<Estado> estados4 = new List<Estado>();
            estados4.Add(new Estado("A", false, "[A-Z],B/[0-9],C"));
            estados4.Add(new Estado("B", false, "[A-Z],B/[0-9],C/=,D"));
            estados4.Add(new Estado("C", false, "[0-9],C/[A-Z],B/=,D"));
            estados4.Add(new Estado("D", true, "[0-9],C/[A-Z],B"));
            List<String> acepta4 = new List<string>();
            acepta4.Add("[A-Z]");
            acepta4.Add("[0-9]");
            acepta4.Add("espa");
            acepta4.Add("=");
            entradaVariableIgual = new Automata(estados4, acepta4, estados4[0], lista);

            List<Estado> estados5 = new List<Estado>();
            estados5.Add(new Estado("A", false, "[A-Z],B/[0-9],C/comillas,E"));
            estados5.Add(new Estado("B", false, "[A-Z],B/[0-9],C/arit,D"));
            estados5.Add(new Estado("C", false, "[A-Z],B/[0-9],C/arit,D"));
            estados5.Add(new Estado("D", false, "[A-Z],B/[0-9],C/arit,D/comillas,E/asig,H"));
            estados5.Add(new Estado("E", false, "cualquiera,F"));
            estados5.Add(new Estado("F", false, "comillas,H/cualquiera,F"));
            estados5.Add(new Estado("G", false, "arit,d/asig,H"));
            estados5.Add(new Estado("H", true, "[A-Z],A/[0-9],A/rela,D"));
            List<String> acepta5 = new List<string>();
            acepta5.Add("[A-Z]");
            acepta5.Add("[0-9]");
            acepta5.Add("()");
            acepta5.Add("espa");
            acepta5.Add("arit");
            acepta5.Add("comillas");
            acepta5.Add("cualquiera");
            entradaCadena = new Automata(estados5, acepta5, estados5[0], lista);

            List<Estado> estados6 = new List<Estado>();
            estados6.Add(new Estado("A", false, "asig,B"));
            estados6.Add(new Estado("B", true, "asig,B"));
            List<String> acepta6 = new List<string>();
            acepta6.Add("espa");
            acepta6.Add("asig");
            entradaAsignacion = new Automata(estados6, acepta6, estados6[0], lista);

            List<Estado> estados7 = new List<Estado>();
            ListasAceptacion lista7 = new ListasAceptacion();
            estados7.Add(new Estado("A", false, "[A-Z],B"));
            estados7.Add(new Estado("B", true, "[A-Z],B"));
            List<String> acepta7 = new List<string>();
            acepta.Add("[A-Z]");
            entradaTexto = new Automata(estados7, acepta7, estados7[0], lista);

            List<Estado> estados8 = new List<Estado>();
            estados8.Add(new Estado("A", false, "comillas,B"));
            estados8.Add(new Estado("B", false, "cualquiera,B"));
            estados8.Add(new Estado("C", false, "cualquiera,C/comillas,D"));
            estados8.Add(new Estado("D", true, "cualquiera,A"));
            List<String> acepta8 = new List<string>();
            acepta8.Add("cualquiera");
            acepta8.Add("espa");
            acepta8.Add("comillas");
            soloCadena = new Automata(estados8, acepta8, estados8[0], lista);
        }
    }
}
