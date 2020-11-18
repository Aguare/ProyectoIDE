using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoForms.Sintactico
{
    public class Mensaje
    {

        public String obtenerMensaje(String opcion)
        {
            switch (opcion)
            {
                case "Entero":
                    return "Se esperaba un número entero";
                case "Decimal":
                    return "Se esperaba un número decimal";
                case "Cadena":
                    return "Se esperaba una cadena de texto";
                case "Booleano":
                    return "Se esperaba un valor de boleano";
                case "Char":
                    return "Se esperaba un caracter Char";
                case "TD":
                    return "Se esperaba una palabra reservada";
                case "ID":
                    return "Se esperaba el tipo de variable";
                case "Id":
                    return "Se esperaba nombre de una variable";
                case "Fin Sentencia":
                    return "Se esperaba un punto y coma";
                case "Operador Logico":
                    return "Se esperaba un operador lógico";
                case "Operador Relacional":
                    return "Se esperaba un operador relacional";
                case "Operador Aritmetico Division":
                    return "Se esperaba un operador aritmético";
                case "Parentesis Apertura":
                    return "Se esperaba apertura de parentesis";
                case "Parentesis Cierre":
                    return "Se esperaba cierre de parentesis";
                case "Asignacion":
                    return "Se esperaba un signo igual de asignación";
                case "Llave Apertura":
                    return "Se esperaba apertura de llaves";
                case "Llave Cierre":
                    return "Se esperaba cierre de llaves";
                case "PR_Principal":
                    return "Se esperaba inicializar el método principal";
                case "PR_Imprimir":
                    return "Se esperaba la palabra imprimir";
                case "PR_Leer":
                    return "Se esperaba la palabra leer";
                case "COD":
                    return "Se esperaba un bloque de codigo";
                case "EXIT":
                    return "El código debe estar dentro del método principal";
                default:
                    return "Error Sintáctico, revise la sentencia";
            }
        }

    }
}
