using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoForms.Analizadores
{
    public class PalabraReservada
    {
        public String palabraReservada { get; set; }
        public String tipoToken { get; set; }

        public PalabraReservada(string palabraReservada, string tipoToken)
        {
            this.palabraReservada = palabraReservada;
            this.tipoToken = tipoToken;
        }
    }
}
