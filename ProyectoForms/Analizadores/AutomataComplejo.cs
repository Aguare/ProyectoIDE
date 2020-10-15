using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ProyectoForms.Analizadores
{
    public class AutomataComplejo
    {
        private List<Automata> automatas;
        private Boolean esAceptado = false;
        private Boolean terminado = false;
        private Automata actual;
        private String cadena;

        public AutomataComplejo(List<Automata> automatas, Automata actual)
        {
            this.automatas = automatas;
            this.actual = actual;
        }

        public Boolean estaTerminado()
        {
            return terminado;
        }

        public void analizar(char caracter)
        {
            if (!terminado)
            {
                if (actual.Equals(automatas[automatas.Count-1]))
                {
                    if (caracter.ToString().Equals(";"))
                    {
                        terminado = true;
                    }
                    else
                    {
                        cadena += caracter.ToString();
                        enviarCaracterAutomata(caracter);
                    }                    
                }
                else
                {
                    if (char.IsWhiteSpace(caracter))
                    {
                        cadena += caracter.ToString();
                        actual = obtenerSiguiente();
                        if (actual == null)
                        {
                            terminado = true;
                        }
                    }
                    else
                    {
                        cadena += caracter.ToString();
                        enviarCaracterAutomata(caracter);
                    }
                }
                
            }
        }

        private void enviarCaracterAutomata(char caracter)
        {
            foreach (Automata automata in automatas)
            {
                if (automata.Equals(actual))
                {
                    automata.analizarCaracter(caracter);
                    esAceptado = automata.esAceptadoAutomata();
                    break;
                }
            }
        }

        private Automata obtenerSiguiente()
        {
            for (int i = 0; i < automatas.Count; i++)
            {
                if (i< automatas.Count && automatas[i].Equals(actual))
                {
                    return automatas[i + 1];
                }
            }
            return null;
        }

        public Boolean verificarAceptacion()
        {
            foreach (Automata auto in automatas)
            {
                if (!auto.esAceptadoAutomata())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
