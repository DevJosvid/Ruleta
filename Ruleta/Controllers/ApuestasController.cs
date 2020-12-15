using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;

namespace Ruleta.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<apuesta> Get()
        {
            using (RouletteEntities2 db = new RouletteEntities2())
            {
                return db.apuesta.ToList();
            }
        }

        // GET: api/Apuestas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Apuestas
        public HttpResponseMessage Post([FromBody]apuesta ap)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (RouletteEntities2 entities = new RouletteEntities2())
                {
                    entities.Entry(ap).State = EntityState.Added;
                    resp = entities.SaveChanges();
                    msg = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception ex)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return msg;
        }

        // PUT: api/Apuestas/5
        public HttpResponseMessage Put([FromBody]apuesta ap)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (RouletteEntities2 entities = new RouletteEntities2())
                {
                    entities.Entry(ap).State = EntityState.Modified;
                    resp = entities.SaveChanges();
                    msg = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception ex)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return msg;
        }

        // DELETE: api/Apuestas/5
        public HttpResponseMessage Delete([FromBody] apuesta ap)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (RouletteEntities2 entities = new RouletteEntities2())
                {
                    entities.Entry(ap).State = EntityState.Deleted;
                    resp = entities.SaveChanges();
                    msg = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception ex)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return msg;
        }
    }
}
