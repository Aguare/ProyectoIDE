using ProyectoForms.Clases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ProyectoForms.Analizadores
{
    public class ManejadorCodigo
    {
        private String codigoAnalizar;
        private AnalizadorLexico analizador;
        private List<String> tokensInvalidos;
        private List<Token> listaTokens;
        private PanelTexto editor;

        public ManejadorCodigo(PanelTexto editor)
        {
            this.editor = editor;
            tokensInvalidos = new List<String>();
            listaTokens = new List<Token>();
        }

        public void ejecutarManejador()
        {
            if (tokensInvalidos != null)
            {
                tokensInvalidos.Clear();
                listaTokens.Clear();
            }
            byte[] asciiBytes = Encoding.ASCII.GetBytes(codigoAnalizar);
            analizador = new AnalizadorLexico(asciiBytes, this, editor);
            analizador.ejecutarAnalizador();
        }

        public void recibirCodigo(String codigoAnalizar)
        {
            this.codigoAnalizar = codigoAnalizar;
        }

        public void agregarTokenErroneo(String token)
        {
            if (!token.Equals(""))
            {
                char posibleEspacioBlanco = token[0];
                if ((int)posibleEspacioBlanco != 9 && (int)posibleEspacioBlanco != 10 && (int)posibleEspacioBlanco != 32)
                {
                    tokensInvalidos.Add(token);
                }
            }
        }

        public void agregarTokenNuevo(Token tokenNuevo)
        {
            listaTokens.Add(tokenNuevo);
        }

        public void quitarTokenReciente()
        {
            listaTokens.RemoveAt(listaTokens.Count - 1);
        }

        public Boolean ultimoTokenIgual(String contenidoUltimoToken)
        {
            if (numeroTokens() > 0 && listaTokens[numeroTokens() - 1].contenido.Equals(contenidoUltimoToken))
            {
                return true;
            }
            return false;
        }

        public int numeroTokens()
        {
            return listaTokens.Count;
        }

        public List<Token> obtenerTokensInvalidos()
        {
            List<Token> tokensInvalidos = new List<Token>();
            for (int i = 0; i < numeroTokens(); i++)
            {
                if (listaTokens[i].tipoToken.Equals("Erroneo"))
                {
                    tokensInvalidos.Add(listaTokens[i]);
                }
            }
            return tokensInvalidos;
        }

        public List<Token> obtenerTokensValidos()
        {
            List<Token> tokenValidos = new List<Token>();
            for (int i = 0; i < numeroTokens(); i++)
            {
                if (!listaTokens[i].tipoToken.Equals("Erroneo") && !listaTokens[i].tipoToken.Equals("Espacio Blanco"))
                {
                    tokenValidos.Add(listaTokens[i]);
                }
            }
            return tokenValidos;
        }

    }
}
