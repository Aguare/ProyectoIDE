using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ProyectoForms.Analizadores
{
    public class Automata
    {
        //Objetos auxiliares al automata
        ListasAceptacion listasAceptacion;
        //Atributos del automata
        private List<Estado> estados;
        private Boolean esAceptado = false;
        private Boolean esAnalizable = true;
        private List<String> abecedario;
        private Estado estadoActual;
        private String cadena = "";

        public Automata(List<Estado> estados, List<String> abecedario, Estado estadoInicial, ListasAceptacion listas)
        {
            this.estados = estados;
            this.abecedario = abecedario;
            this.estadoActual = estadoInicial;
            this.listasAceptacion = listas;
        }

        public Boolean esAceptadoAutomata()
        {
            return esAceptado;
        }

        public String obtenerCadena()
        {
            return cadena;
        }

        public void analizarCaracter(char caracter)
        {
            if (esAnalizable)
            {
                cadena += caracter;
                foreach (Estado estado in estados)
                {
                    if (estado.Equals(estadoActual))
                    {
                        realizarTransicion(estado.obtenerNombre(), estado, caracter);
                        break;
                    }
                }
            }
            else
            {
                esAceptado = false;
            }            
        }

        private void realizarTransicion(String nombreEstado, Estado estado, char caracter)
        {
            String caracterRecibido = char.ToString(caracter);
            List<String> transicion = estado.obtenerTransiciones();
            for (int i = 0; i < transicion.Count; i++)
            {
                String[] condiciones = transicion[i].Split(",");
                String entrada = condiciones[0];
                String estadoResultante = condiciones[1];
                if (verificarEntrada(caracter, entrada))
                {
                    estadoActual = buscarEstado(estadoResultante);
                    verificarEstadoAceptacion();
                    break;
                }   
            }
        }

        private void verificarEstadoAceptacion()
        {
            foreach (Estado estado in estados)
            {
                if (estado.esDeAceptacion() && estado.obtenerNombre().Equals(estadoActual.obtenerNombre()))
                {
                    esAceptado = true;
                    break;
                }
                else
                {
                    esAceptado = false;
                }
            }
        }

        private Boolean verificarEntrada(char caracter, String condicion)
        {
            switch (condicion)
            {
                case "[0-9]":
                    if (char.IsDigit(caracter))
                    {
                        return true;
                    }
                    break;
                case "[A-Z]":
                    if (char.IsLetter(caracter))
                    {
                        return true;
                    }
                    break;
                case "espa":
                    if (char.IsWhiteSpace(caracter))
                    {
                        return true;
                    }
                    break;
                case "arit":
                    List<String> aritmeticos = listasAceptacion.obtenerAritmeticos();
                    String c = char.ToString(caracter);
                    foreach (String ar in aritmeticos)
                    {
                        if (ar.Equals(c))
                        {
                            return true;
                        }
                    }
                    break;
                case "rela":
                    List<String> relacionales = listasAceptacion.obtenerRelacionales();
                    String ca = char.ToString(caracter);
                    foreach (String ar in relacionales)
                    {
                        if (ar.Equals(ca))
                        {
                            return true;
                        }
                    }
                    break;
                case "()":
                    String ingreso = char.ToString(caracter);
                    if (ingreso.Equals("(") || ingreso.Equals(")"))
                    {
                        return true;
                    }
                    break;
                case "asig":
                    List<String> asignacion = listasAceptacion.obtenerAsignacionFin();
                    foreach (String asig in asignacion)
                    {
                        if (asig.Equals(char.ToString(caracter)))
                        {
                            return true;
                        }
                    }
                    break;
                case "cualquiera":
                    return true;
                case "comillas":
                    char comi = '"';
                    if (caracter.Equals(comi))
                    {
                        return true;
                    }
                    break;
                case "slash":
                    char slash = '/';
                    if (caracter.Equals(slash))
                    {
                        return true;
                    }
                    break;
                case "ast":
                    char ast = '*';
                    if (caracter.Equals(ast))
                    {
                        return true;
                    }
                    break;
                default:
                    if (condicion.Equals(char.ToString(caracter)))
                    {
                        return true;
                    }
                    break;
            }
            esAnalizable = false;
            return false;
        }

        public void limpiarCadena()
        {
            cadena = "";
        }

        private Estado buscarEstado(String nombre)
        {
            foreach (Estado estado in estados)
            {
                if (estado.obtenerNombre().Equals(nombre))
                {
                    return estado;
                }
            }
            return null;
        }
    }
}
