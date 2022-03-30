using back_prospecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace back_prospecto.Controllers
{
    public class DocumentosController : ApiController
    {
        // GET: api/Documentos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Documentos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Documentos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Documentos/5
       
            public bool Put(int id, [FromBody] Observacion observaciones)
        {
            GestorProspectos gProspecto = new GestorProspectos();
            bool res = gProspecto.RechazarProspecto(id, observaciones.observaciones);

            return res;
        }

        // DELETE: api/Documentos/5
        public void Delete(int id)
        {
        }
    }
}
