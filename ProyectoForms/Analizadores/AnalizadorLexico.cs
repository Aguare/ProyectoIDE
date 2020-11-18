using ProyectoForms.Clases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ProyectoForms.Analizadores
{
    public class AnalizadorLexico
    {
        private byte[] charAnalizar;
        private ManejadorCodigo manejador;
        private PanelTexto editor;
        private Automata automata;
        private int estadoActual = 0;
        private int columnaAutomata = 0;
        private String auxTokenAceptado = "";
        private String auxCadenaMomentanea = "";
        private String auxRutaToken = "";
        private PanelTexto ingresoCodigoRich;
        private int fila = 1;
        private int columna = 1;

        public AnalizadorLexico(byte[] charAnalizar, ManejadorCodigo manejador, PanelTexto editor)
        {
            this.charAnalizar = charAnalizar;
            this.manejador = manejador;
            this.editor = editor;
            this.ingresoCodigoRich = editor;
            automata = new Automata();
        }

        public void ejecutarAnalizador()
        {
            for (int i = 0; i < charAnalizar.Length; i++)
            {
                int charActual = charAnalizar[i];
                columnaAutomata = automata.devolverColumna(charActual, estadoActual);

                int transicion = automata.retornarTransicion(estadoActual, columnaAutomata);
                //MessageBox.Show("Llega " + transicion + " Pos: " + i);
                if (transicion == -1)
                {
                    if (automata.esEstadoAceptacion(estadoActual))
                    {
                        i--;
                    }
                    else
                    {
                        if (estadoActual == 0)
                        {
                            moverColumnaFila(charActual);
                            agregarTokenErroneoNuevo(Char.ToString((char)charActual), i + 1);
                        }
                        else
                        {
                            String tokenErroneo = auxCadenaMomentanea.Substring(auxTokenAceptado.Length);
                            agregarTokenErroneoNuevo(tokenErroneo, i);
                            i--;
                        }
                    }
                    estadoActual = 0;
                    auxTokenAceptado = "";
                    auxCadenaMomentanea = "";
                    auxRutaToken = "";
                }
                else
                {
                    String cadenaTransicion = Char.ToString((char)charActual);
                    moverColumnaFila(charActual);
                    establecerRuta(transicion);
                    auxCadenaMomentanea += cadenaTransicion;
                    if (automata.esEstadoAceptacion(transicion))
                    {
                        eliminarPosibleTokenRepetido(auxTokenAceptado);
                        auxTokenAceptado = auxCadenaMomentanea;

                        String tipoToken;
                        if (transicion == 5 || transicion == 8)
                        {
                            tipoToken = automata.devolverTipoToken(auxRutaToken);
                        }
                        else
                        {
                            tipoToken = automata.devolverPorEstado(transicion);
                            if (tipoToken.Equals("Palabra"))
                            {
                                tipoToken = automata.devolverTipoTokenPR(auxTokenAceptado);
                            }
                        }
                        agregarTokenAceptadoNuevo(tipoToken, i + 1);
                    }
                    estadoActual = transicion;
                }
            }

            if (!automata.esEstadoAceptacion(estadoActual))
            {
                String ultimaCadenaErronea = auxCadenaMomentanea.Substring(auxTokenAceptado.Length);
                agregarTokenErroneoNuevo(ultimaCadenaErronea, charAnalizar.Length);
            }
        }

        private void moverColumnaFila(int charActual)
        {
            if (charActual == 10)
            {
                fila++;
                columna = 1;
            }
            else
            {
                columna++;
            }
        }

        private void establecerRuta(int transicion)
        {
            if (estadoActual == 0)
            {
                auxRutaToken = columnaAutomata + "-" + transicion;
            }
            else
            {
                if (estadoActual != transicion)
                {
                    auxRutaToken += "," + columnaAutomata + "-" + transicion;
                }
            }
        }

        private void eliminarPosibleTokenRepetido(String ultimoTokenAceptado)
        {
            if (manejador.ultimoTokenIgual(ultimoTokenAceptado))
            {
                manejador.quitarTokenReciente();
            }
        }

        private void agregarTokenAceptadoNuevo(String tipoToken, int posicionToken)
        {
            manejador.agregarTokenNuevo(new Token(tipoToken, auxTokenAceptado, fila, (columna - 1), posicionToken));
        }

        private void agregarTokenErroneoNuevo(String tokenErroneo, int posicionToken)
        {
            manejador.agregarTokenNuevo(new Token("Erroneo", tokenErroneo, fila, (columna - 1), posicionToken));
        }
    }
}
