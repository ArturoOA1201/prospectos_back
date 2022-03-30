using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using back_prospecto.Models;

namespace back_prospecto.Controllers
{
    [EnableCors(origins: "*", headers:"*", methods:"GET,POST,PUT,DELETE,OPTIONS")]
    public class ProspectoController : ApiController
    {
        // GET: api/Prospecto
        public IEnumerable<Prospectos> Get()
        {
            GestorProspectos gProspecto = new GestorProspectos();
            return gProspecto.GetProspectos();
        }

        // GET: api/Prospecto/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Prospecto
        public bool Post([FromBody]Prospectos prospectos)
        {
            GestorProspectos gProspecto = new GestorProspectos();
            bool res = gProspecto.addProspecto(prospectos);

            return res;
        }

        // PUT: api/Prospecto/5
        public bool Put(int id, [FromBody] Observacion observaciones)
        {
            GestorProspectos gProspecto = new GestorProspectos();
            bool res = gProspecto.AceptarProspecto(id, observaciones.observaciones);

            return res;
        }

        // DELETE: api/Prospecto/5
        public bool Delete(int id, [FromBody] Observacion observaciones)
        {
            GestorProspectos gProspecto = new GestorProspectos();
            bool res = gProspecto.RechazarProspecto(id, observaciones.observaciones);

            return res;
        }
    }
}
