using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_prospecto.Models
{
    public class Observacion
    {
        public string observaciones { get; set; }
        

        public Observacion() { }

        public Observacion(string Observaciones)
        {
            observaciones = Observaciones;
            
        }
    }
}