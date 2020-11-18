using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ProyectoForms.Analizadores
{
    public class Automata
    {
        private int[,] tablaTransiciones = new int[19, 26];
        private List<int> estadosAceptacion;
        private List<EstadoAceptacion> listEstadosAceptacion;
        private List<PalabraReservada> listadoPalabrasReservadas;

        public Automata()
        {
            estadosAceptacion = new List<int>();
            listEstadosAceptacion = new List<EstadoAceptacion>();
            listadoPalabrasReservadas = new List<PalabraReservada>();
            llenarTabla();
            setearTransiciones();
            setearEstadosAceptacion();
            ingresarCaminos();
            setearPalabrasReservadas();
        }

        private void llenarTabla()
        {
            for (int i = 0; i < tablaTransiciones.GetLength(0); i++)
            {
                for (int j = 0; j < tablaTransiciones.GetLength(1); j++)
                {
                    tablaTransiciones[i, j] = -1;
                }
            }
        }

        private void setearTransiciones()
        {
            //Transiciones desde el estado 0
            tablaTransiciones[0, 0] = 1;
            tablaTransiciones[0, 1] = 7;
            tablaTransiciones[0, 2] = 6;
            tablaTransiciones[0, 3] = 5;
            tablaTransiciones[0, 4] = 4;
            tablaTransiciones[0, 5] = 17;
            tablaTransiciones[0, 6] = 2;
            tablaTransiciones[0, 7] = 3;
            tablaTransiciones[0, 8] = 8;
            tablaTransiciones[0, 9] = 8;
            tablaTransiciones[0, 10] = 8;
            tablaTransiciones[0, 11] = 8;
            tablaTransiciones[0, 12] = 9;
            tablaTransiciones[0, 13] = 10;
            tablaTransiciones[0, 14] = 5;
            tablaTransiciones[0, 15] = 5;
            tablaTransiciones[0, 16] = 5;
            tablaTransiciones[0, 18] = 5;
            tablaTransiciones[0, 19] = 5;
            tablaTransiciones[0, 20] = 5;
            tablaTransiciones[0, 21] = 5;
            tablaTransiciones[0, 23] = 5;
            tablaTransiciones[0, 24] = 5;
            tablaTransiciones[0, 25] = 5;

            //Transiciones desde el estado 1
            tablaTransiciones[1, 0] = 5;
            tablaTransiciones[1, 6] = 2;

            //Transiciones desde el estado 2
            tablaTransiciones[2, 6] = 2;
            tablaTransiciones[2, 17] = 11;

            //Transiciones desde el estado 3
            tablaTransiciones[3, 7] = 5;
            tablaTransiciones[3, 22] = 3;
            tablaTransiciones[3, 23] = 3;
            tablaTransiciones[3, 24] = 3;
            tablaTransiciones[3, 25] = 3;

            //Transiciones desde el estado 4
            tablaTransiciones[4, 4] = 12;
            tablaTransiciones[4, 5] = 12;

            //Transiciones desde el estado 6
            tablaTransiciones[6, 2] = 13;
            tablaTransiciones[6, 3] = 14;

            //Transiciones desde el estado 7
            tablaTransiciones[7, 1] = 5;

            //Transiciones desde el estado 8
            tablaTransiciones[8, 10] = 5;

            //Transiciones desde el estado 9
            tablaTransiciones[9, 12] = 5;

            //Transiciones desde el estado 10
            tablaTransiciones[10, 13] = 5;

            //Transiciones desde el estado 11
            tablaTransiciones[11, 6] = 15;

            //Transiciones desde el estado 12
            tablaTransiciones[12, 4] = 12;
            tablaTransiciones[12, 5] = 12;

            //Transiciones desde el estado 13
            tablaTransiciones[13, 22] = 13;
            tablaTransiciones[13, 23] = 13;
            tablaTransiciones[13, 24] = 13;

            //Transiciones desde el estado 14
            tablaTransiciones[14, 3] = 16;
            tablaTransiciones[14, 22] = 14;
            tablaTransiciones[14, 23] = 14;
            tablaTransiciones[14, 24] = 14;
            tablaTransiciones[14, 25] = 14;

            //Transiciones desde el estado 15
            tablaTransiciones[15, 6] = 15;

            //Transiciones desde el estado 16
            tablaTransiciones[16, 2] = 5;
            tablaTransiciones[16, 3] = 16;
            tablaTransiciones[16, 22] = 14;
            tablaTransiciones[16, 23] = 14;
            tablaTransiciones[16, 24] = 14;
            tablaTransiciones[16, 25] = 14;

            //Transiciones desde el estado 17
            tablaTransiciones[17, 4] = 18;

            //Transiciones desde el estado 18
            tablaTransiciones[18, 4] = 18;
            tablaTransiciones[18, 6] = 18;
        }

        private void setearPalabrasReservadas()
        {
            listadoPalabrasReservadas.Add(new PalabraReservada("verdadero", "Booleano"));
            listadoPalabrasReservadas.Add(new PalabraReservada("falso", "Booleano"));
            listadoPalabrasReservadas.Add(new PalabraReservada("Entero", "TD"));
            listadoPalabrasReservadas.Add(new PalabraReservada("Decimal", "TD"));
            listadoPalabrasReservadas.Add(new PalabraReservada("Cadena", "TD"));
            listadoPalabrasReservadas.Add(new PalabraReservada("Boolean", "TD"));
            listadoPalabrasReservadas.Add(new PalabraReservada("Chart", "TD"));
            listadoPalabrasReservadas.Add(new PalabraReservada("SI", "PR_Si"));
            listadoPalabrasReservadas.Add(new PalabraReservada("SINO", "PR_Sino"));
            listadoPalabrasReservadas.Add(new PalabraReservada("SINO_SI", "PR_Sino_Si"));
            listadoPalabrasReservadas.Add(new PalabraReservada("MIENTRAS", "PR_Mientras"));
            listadoPalabrasReservadas.Add(new PalabraReservada("HACER", "PR_Hacer"));
            listadoPalabrasReservadas.Add(new PalabraReservada("DESDE", "PR_Desde"));
            listadoPalabrasReservadas.Add(new PalabraReservada("HASTA", "PR_Hasta"));
            listadoPalabrasReservadas.Add(new PalabraReservada("INCREMENTO", "PR_Incremento"));
            listadoPalabrasReservadas.Add(new PalabraReservada("principal", "PR_Principal"));
            listadoPalabrasReservadas.Add(new PalabraReservada("imprimir", "PR_Imprimir"));
            listadoPalabrasReservadas.Add(new PalabraReservada("leer", "PR_Leer"));
        }

        private void setearEstadosAceptacion()
        {
            estadosAceptacion.Add(1);
            estadosAceptacion.Add(2);
            estadosAceptacion.Add(4);
            estadosAceptacion.Add(5);
            estadosAceptacion.Add(6);
            estadosAceptacion.Add(7);
            estadosAceptacion.Add(8);
            estadosAceptacion.Add(12);
            estadosAceptacion.Add(13);
            estadosAceptacion.Add(15);
            estadosAceptacion.Add(18);
        }

        private void ingresarCaminos()
        {
            listEstadosAceptacion.Add(new EstadoAceptacion(1, "Operador Aritmetico Menos"));
            listEstadosAceptacion.Add(new EstadoAceptacion(2, "Entero"));
            listEstadosAceptacion.Add(new EstadoAceptacion(4, "Char"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Cadena", "7-3,7-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Operador Relacional", "8-8,10-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Operador Relacional", "9-8,10-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Operador Relacional", "10-8,10-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Operador Relacional", "11-8,10-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Operador Aritmetico Incre-Decre", "1-7,1-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Operador Aritmetico Incre-Decre", "0-1,0-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Comentario", "2-6,3-14,3-16,2-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Operador Aritmetico Multi", "3-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Fin Sentencia", "14-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Coma", "18-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Potencia", "19-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Llave Apertura", "20-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Llave Cierre", "21-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Espacio Blanco", "23-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Espacio Blanco", "24-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Espacio Blanco", "25-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Parentesis Apertura", "15-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Parentesis Cierre", "16-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Operador Logico", "12-9,12-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(5, "Operador Logico", "13-10,13-5"));
            listEstadosAceptacion.Add(new EstadoAceptacion(6, "Operador Aritmetico Division"));
            listEstadosAceptacion.Add(new EstadoAceptacion(7, "Operador Aritmetico Mas"));
            listEstadosAceptacion.Add(new EstadoAceptacion(8, "Operador Relacional", "8-8"));
            listEstadosAceptacion.Add(new EstadoAceptacion(8, "Operador Relacional", "9-8"));
            listEstadosAceptacion.Add(new EstadoAceptacion(8, "Asignacion", "10-8"));
            listEstadosAceptacion.Add(new EstadoAceptacion(8, "Operador Logico NOT", "11-8"));
            listEstadosAceptacion.Add(new EstadoAceptacion(12, "Palabra"));
            listEstadosAceptacion.Add(new EstadoAceptacion(13, "Comentario"));
            listEstadosAceptacion.Add(new EstadoAceptacion(15, "Decimal"));
            listEstadosAceptacion.Add(new EstadoAceptacion(18, "Id"));
        }

        public String devolverTipoToken(String ruta)
        {
            for (int i = 0; i < listEstadosAceptacion.Count; i++)
            {
                if (listEstadosAceptacion[i].caminoAceptacion != null)
                {
                    if (listEstadosAceptacion[i].caminoAceptacion.Equals(ruta))
                    {
                        return listEstadosAceptacion[i].tipoToken;
                    }
                }
            }
            return "";
        }

        public String devolverPorEstado(int estadoAceptacion)
        {
            for (int i = 0; i < listEstadosAceptacion.Count; i++)
            {
                if (listEstadosAceptacion[i].numeroEstado == estadoAceptacion)
                {
                    return listEstadosAceptacion[i].tipoToken;
                }
            }
            return "";
        }

        public String devolverTipoTokenPR(String palabra)
        {
            for (int i = 0; i < listadoPalabrasReservadas.Count; i++)
            {
                if (listadoPalabrasReservadas[i].palabraReservada.Equals(palabra))
                {
                    return listadoPalabrasReservadas[i].tipoToken;
                }
            }
            return "Erroneo";
        }

        public Boolean esEstadoAceptacion(int estadoActual)
        {
            if (estadosAceptacion.Contains(estadoActual))
            {
                return true;
            }
            return false;
        }

        public int devolverColumna(int codigoASCCI, int estadoActual)
        {
            //Estados particulares que puede venir cualquier char
            if (estadoActual == 3 || estadoActual == 13 || estadoActual == 14 || estadoActual == 16)
            {
                return columnaEstadosEspecificos(codigoASCCI, estadoActual);
            }

            if (codigoASCCI == 45)
            {
                //Signo menos
                return 0;
            }
            else if (codigoASCCI == 43)
            {
                //Signo mas
                return 1;
            }
            else if (codigoASCCI == 47)
            {
                return 2;
                //barra inclinada
            }
            else if (codigoASCCI == 42)
            {
                return 3;
                //asterisco
            }
            else if ((codigoASCCI >= 65 && codigoASCCI <= 90) || (codigoASCCI >= 97 && codigoASCCI <= 122)
                || codigoASCCI >= 160 && codigoASCCI <= 165 || codigoASCCI == 130 || codigoASCCI == 181
                || codigoASCCI == 144 || codigoASCCI == 214 || codigoASCCI == 224 || codigoASCCI == 233)
            {
                //cualquier letra
                return 4;
            }
            else if (codigoASCCI == 95)
            {
                //guion bajo
                return 5;
            }
            else if (codigoASCCI >= 48 && codigoASCCI <= 57)
            {
                //numero
                return 6;
            }
            else if (codigoASCCI == 34)
            {
                //comillas dobles
                return 7;
            }
            else if (codigoASCCI == 62)
            {
                //mayor que
                return 8;
            }
            else if (codigoASCCI == 60)
            {
                //menor que
                return 9;
            }
            else if (codigoASCCI == 61)
            {
                //igual
                return 10;
            }
            else if (codigoASCCI == 33)
            {
                //signo admiracion
                return 11;
            }
            else if (codigoASCCI == 124)
            {
                //barra vertical
                return 12;
            }
            else if (codigoASCCI == 38)
            {
                //ampersand o signo de &
                return 13;
            }
            else if (codigoASCCI == 59)
            {
                //punto y coma
                return 14;
            }
            else if (codigoASCCI == 40)
            {
                //abrir parentesis
                return 15;
            }
            else if (codigoASCCI == 41)
            {
                //cerrar parentesis
                return 16;
            }
            else if (codigoASCCI == 46)
            {
                //punto
                return 17;
            }
            else if (codigoASCCI == 44)
            {
                //coma
                return 18;
            }
            else if (codigoASCCI == 94)
            {
                //simbolo de potencia
                return 19;
            }
            else if (codigoASCCI == 123)
            {
                //llave apertura
                return 20;
            }
            else if (codigoASCCI == 125)
            {
                //llave cierre
                return 21;
            }
            else if ((codigoASCCI >= 33 && codigoASCCI <= 126) || (codigoASCCI >= 128 && codigoASCCI <= 253))
            {
                //cualquier char
                return 22;
            }
            else if (codigoASCCI == 9)
            {
                //tab
                return 23;
            }
            else if (codigoASCCI == 32)
            {
                //espacio
                return 24;
            }
            else if (codigoASCCI == 10)
            {
                //enter
                return 25;
            }

            return -1;
        }

        private int columnaEstadosEspecificos(int codigoASCCI, int estadoActual)
        {
            if (estadoActual == 3)
            {
                if (codigoASCCI == 34)
                {
                    return 7; //Comillas dobles
                }
            }
            else if (estadoActual == 14)
            {
                if (codigoASCCI == 42)
                {
                    return 3; //Asterisco
                }
            }
            else if (estadoActual == 16)
            {
                if (codigoASCCI == 47)
                {
                    return 2; //Barra inclinada
                }
                else if (codigoASCCI == 42)
                {
                    return 3; //Asterisco
                }
            }

            //Comprobar espacios en blanco o cualquier char
            if ((codigoASCCI >= 33 && codigoASCCI <= 126) || (codigoASCCI >= 128 && codigoASCCI <= 253))
            {
                //cualquier char
                return 22;
            }
            else if (codigoASCCI == 9)
            {
                //tab
                return 23;
            }
            else if (codigoASCCI == 32)
            {
                //espacio
                return 24;
            }
            else if (codigoASCCI == 10)
            {
                //enter
                return 25;
            }
            return -1;
        }

        public int retornarTransicion(int fila, int columna)
        {
            return tablaTransiciones[fila, columna];
        }
    }
}
