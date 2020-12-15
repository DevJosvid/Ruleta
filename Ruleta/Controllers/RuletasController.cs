using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using Ruleta.Areas.HelpPage.ModelDescriptions;

namespace Ruleta.Controllers
{
    public class RuletasController : ApiController
    {
        // GET: api/Ruletas
        public IEnumerable<Ruletas> Get()
        {
            using (RouletteEntities2 db  = new RouletteEntities2())
            {
                return db.Ruletas.ToList();
            }
        }

        // GET: api/Ruletas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ruletas
        public HttpResponseMessage Post([FromBody]Ruletas Ru)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (RouletteEntities2 entities = new RouletteEntities2())
                {
                    entities.Entry(Ru).State = EntityState.Added;
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

        // PUT: api/Ruletas/5
        public HttpResponseMessage Put([FromBody]Ruletas Ru)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (RouletteEntities2 entities = new RouletteEntities2())
                {
                    entities.Entry(Ru).State = EntityState.Modified;
                    resp = entities.SaveChanges();
                    msg = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception ex )
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return msg;
        }

        // DELETE: api/Ruletas/5
        public HttpResponseMessage Delete([FromBody]Ruletas Ru)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (RouletteEntities2 entities = new RouletteEntities2())
                {
                    entities.Entry(Ru).State = EntityState.Deleted;
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
