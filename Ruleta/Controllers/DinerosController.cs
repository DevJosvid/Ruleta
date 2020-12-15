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
    public class DinerosController : ApiController
    {
        // GET: api/Dineros
        public IEnumerable<dineros> Get()
        {
            using (RouletteEntities2 db = new RouletteEntities2())
            {
                return db.dineros.ToList();
            }
        }

        // GET: api/Dineros/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Dineros
        public HttpResponseMessage Post([FromBody]dineros di)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (RouletteEntities2 entities = new RouletteEntities2())
                {
                    entities.Entry(di).State = EntityState.Added;
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

        // PUT: api/Dineros/5
        public HttpResponseMessage Put([FromBody]dineros di)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (RouletteEntities2 entities = new RouletteEntities2())
                {
                    entities.Entry(di).State = EntityState.Modified;
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

        // DELETE: api/Dineros/5
        public HttpResponseMessage Delete([FromBody] dineros di)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (RouletteEntities2 entities = new RouletteEntities2())
                {
                    entities.Entry(di).State = EntityState.Deleted;
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
