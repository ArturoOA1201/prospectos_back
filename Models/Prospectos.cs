using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_prospecto.Models
{
    public class Prospectos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string calle { get; set; }
        public string numero { get; set; }
        public string colonia { get; set; }
        public string cp { get; set; }
        public string telefono { get; set; }
        public string rfc { get; set; }
        public int status { get; set; }
        public string observaciones { get; set; }

        public Prospectos() { }

        public Prospectos(int Id,string Nombre, string Primer_apellido, string Segundo_apellido, string Calle, string Numero, string Colonia, string CP, string Telefono, string RFC, int Status, string Observaciones)
        {
            id= Id;
            nombre = Nombre;
            primer_apellido = Primer_apellido;
            segundo_apellido = Segundo_apellido;
            calle = Calle;
            numero = Numero;
            colonia = Colonia;
            cp = CP;
            telefono = Telefono;
            rfc = RFC;
            status = Status;
            observaciones = Observaciones;
        }


    }
}