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
    public class RolController : ApiController
    {
        // GET: api/Rol
        public IEnumerable<Rol> Get()
        {
            using (RouletteEntities2 db = new RouletteEntities2())
            {
                return db.Rol.ToList();
            }
        }

        // GET: api/Rol/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rol
        public HttpResponseMessage Post([FromBody]Rol Ro)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (RouletteEntities2 entities =  new RouletteEntities2())
                {
                    entities.Entry(Ro).State = EntityState.Added;
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

        // PUT: api/Rol/5
        public HttpResponseMessage Put([FromBody]Rol Ro)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (RouletteEntities2 entities = new RouletteEntities2())
                {
                    entities.Entry(Ro).State = EntityState.Modified;
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

        // DELETE: api/Rol/5
        public HttpResponseMessage Delete([FromBody] Rol Ro)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (RouletteEntities2 entities = new RouletteEntities2())
                {
                    entities.Entry(Ro).State = EntityState.Deleted;
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
