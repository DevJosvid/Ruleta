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
    public class UsuariosController : ApiController
    {
        // GET: api/Usuarios
        public IEnumerable<Usuarios> Get()
        {
            using (RouletteEntities2 db = new RouletteEntities2())
            {
                return db.Usuarios.ToList();
            }
        }

        // GET: api/Usuarios/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuarios
        public HttpResponseMessage Post([FromBody]Usuarios us)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (RouletteEntities2 entities = new RouletteEntities2())
                {
                    entities.Entry(us).State = EntityState.Added;
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

        // PUT: api/Usuarios/5
        public HttpResponseMessage Put([FromBody]Usuarios us)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (RouletteEntities2 entities = new RouletteEntities2())
                {
                    entities.Entry(us).State = EntityState.Modified;
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

        // DELETE: api/Usuarios/5
        public HttpResponseMessage Delete([FromBody] Usuarios us)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (RouletteEntities2 entities = new RouletteEntities2())
                {
                    entities.Entry(us).State = EntityState.Deleted;
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
