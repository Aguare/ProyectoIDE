using ProyectoForms.Analizadores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoForms.Sintactico
{
    public class Complejo
    {
        private List<String> aceptacion;
        private List<Bloque> bloquesCodigo;
        public List<String> errores { get; set; }
        private List<Token> listaTokens;
        private Mensaje mensaje = new Mensaje();

        public Complejo(List<String> aceptacion, List<Bloque> bloquesCodigo)
        {
            this.aceptacion = aceptacion;
            this.bloquesCodigo = bloquesCodigo;
            this.errores = new List<String>();
        }


        public List<String> obtenerErrores()
        {
            foreach (Token token in listaTokens)
            {
                if (!token.aceptado && !token.tipoToken.Equals("Comentario"))
                {
                    errores.Add("No cumple con la sentencia -> " + token.tipoToken + " F:" + token.fila + " C:" + token.columna);
                }
            }
            return errores;
        }

        public void analizarEntrada(List<Token> listaTokens)
        {
            this.listaTokens = listaTokens;
            for (int i = 0; i < aceptacion.Count; i++)
            {
                String[] partes = aceptacion[i].Split(",");
                foreach (String bloque in partes)
                {
                    Bloque parte = buscarBloque(bloque);
                    if (parte != null)
                    {
                        parte.analizarTokens(extraerTokens(parte.cantidad));
                        if (parte.aceptacion)
                        {
                            listaTokens[0].aceptado = true;
                            eliminarTokens(parte.cantidad);
                        }
                    }
                    else if (bloque.Equals(listaTokens[0].tipoToken))
                    {
                        listaTokens[0].aceptado = true;
                        eliminarTokens(1);
                    }
                }
            }
        }

        private List<Token> extraerTokens(int cantidad)
        {
            List<Token> nuevaLista = new List<Token>();
            for (int i = 0; i < cantidad; i++)
            {
                if (i < listaTokens.Count)
                {
                    nuevaLista.Add(listaTokens[i]);
                }
            }
            return nuevaLista;
        }

        private void eliminarTokens(int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                listaTokens.RemoveAt(0);
            }
        }

        private Bloque buscarBloque(String nombre)
        {
            foreach (Bloque bloque in bloquesCodigo)
            {
                if (bloque.nombre.Equals(nombre))
                {
                    return bloque;
                }
            }
            return null;
        }
    }
}
