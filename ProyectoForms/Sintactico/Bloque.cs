using Microsoft.VisualBasic.CompilerServices;
using ProyectoForms.Analizadores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoForms.Sintactico
{
    public class Bloque
    {
        private List<String> errores = new List<String>();
        private List<String> tokensEsperados;
        private Mensaje mensaje = new Mensaje();
        public String nombre { get; set; }
        public int cantidad { get; set; }
        public Boolean aceptacion { get; set; }

        public Bloque(List<String> tokensEsperados, String nombre)
        {
            this.tokensEsperados = tokensEsperados;
            this.nombre = nombre;
            this.cantidad = tokensEsperados.Count;
        }

        public void analizarTokens(List<Token> listaAnalizar)
        {
            int contador = 0;
            if (tokensEsperados.Count == listaAnalizar.Count)
            {
                for (int i = 0; i < tokensEsperados.Count; i++)
                {
                    String[] condiciones = tokensEsperados[i].Split(",");
                    int contadorCondicion = 0;
                    foreach (String condicion in condiciones)
                    {
                        if (condicion.Equals(listaAnalizar[i].tipoToken))
                        {
                            listaAnalizar[i].aceptado = true;
                            contador++;
                            contadorCondicion++;
                        }
                        if (condicion.Equals(condiciones[condiciones.Length - 1]))
                        {
                            if (contadorCondicion == 0)
                            {
                                errores.Add(mensaje.obtenerMensaje(condiciones[0]));
                            }
                        }
                    }
                    contadorCondicion = 0;
                }
            }
            verificarAceptacion(contador);
        }

        private void verificarAceptacion(int contador)
        {
            if (tokensEsperados.Count == contador)
            {
                aceptacion = true;
            }
            else
            {
                aceptacion = false;
            }
        }
    }
}
