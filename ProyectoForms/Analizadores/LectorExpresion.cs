using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ProyectoForms.Analizadores
{
    public class LectorExpresion
    {
        private GenerarToken generarToken = new GenerarToken();
        private List<Token> listaTokens = new List<Token>();
        private ListasAceptacion listas = new ListasAceptacion();

        public LectorExpresion()
        {
        }

        public List<Token> obtenerTokenLista()
        {
            return listaTokens;
        }

        public void generarTokensCodigo(String[] codigo)
        {
            for (int i = 0; i < codigo.Length; i++)
            {
                if (!comprobarComentario(codigo[i]))
                {
                    analizarLinea(codigo[i], i);
                }
            }
        }

        public void analizarLinea(String linea, int noLinea)
        {
            if (!linea.Equals(""))
            {
                generarTokens(linea, noLinea);
            }
        }

        private Boolean comprobarComentario(String linea)
        {
            char[] caracteres = linea.ToCharArray();
            if (caracteres.Length > 1)
            {
                if (caracteres[0] == '/' && caracteres[1] == '/')
                {
                    return true;
                }
            }
            return false;
        }

        private void generarTokens(String linea, int noLinea)
        {
            char[] partes = linea.ToCharArray();
            for (int i = 0; i < partes.Length; i++)
            {
                if (!char.IsWhiteSpace(partes[i]))
                {
                    if (i < partes.Length - 1)
                    {
                        Token tokenGenerado = generarToken.analizarCaracter(partes[i], partes[i + 1], (noLinea + 1), (i + 1));
                        if (ingresarListaToken(tokenGenerado))
                        {
                            i++;
                        }
                    }
                    else
                    {
                        Token tokenGenerado = generarToken.analizarCaracter(partes[i], ' ', (noLinea + 1), (i + 1));
                        if (ingresarListaToken(tokenGenerado))
                        {
                            i++;
                        }
                    }

                }
            }
            verificarErrores(noLinea);
        }

        private Boolean ingresarListaToken(Token tokenGenerado)
        {
            if (tokenGenerado != null)
            {
                listaTokens.Add(tokenGenerado);
                generarToken.reiniciarEstados();
                if (generarToken.obtenerSalto())
                {
                    generarToken.setSalto(false);
                    return true;
                }

            }
            return false;
        }

        private void verificarErrores(int noLinea)
        {
            Token tokenError = generarToken.errorLexico(noLinea, 1);
            if (tokenError != null)
            {
                listaTokens.Add(tokenError);
            }
        }
    }
}
