using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using api_integrador_sistemas.Models;

namespace api_integrador_sistemas.Controllers
{
    public class IntegracaoSistemasController : ApiController
    {
        private ModeloDados db = new ModeloDados();

        // GET: api/IntegracaoSistemas
        public IQueryable<IntegracaoSistema> GetIntegracaoSistema()
        {
            return db.IntegracaoSistema;
        }

        // GET: api/IntegracaoSistemas/5
        [ResponseType(typeof(IntegracaoSistema))]
        public IHttpActionResult GetIntegracaoSistema(int id)
        {
            IntegracaoSistema integracaoSistema = db.IntegracaoSistema.Find(id);
            if (integracaoSistema == null)
            {
                return NotFound();
            }

            return Ok(integracaoSistema);
        }

        // PUT: api/IntegracaoSistemas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIntegracaoSistema(int id, IntegracaoSistema integracaoSistema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != integracaoSistema.Id)
            {
                return BadRequest();
            }

            db.Entry(integracaoSistema).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntegracaoSistemaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/IntegracaoSistemas
        [ResponseType(typeof(IntegracaoSistema))]
        public IHttpActionResult PostIntegracaoSistema(IntegracaoSistema integracaoSistema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IntegracaoSistema.Add(integracaoSistema);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = integracaoSistema.Id }, integracaoSistema);
        }

        // DELETE: api/IntegracaoSistemas/5
        [ResponseType(typeof(IntegracaoSistema))]
        public IHttpActionResult DeleteIntegracaoSistema(int id)
        {
            IntegracaoSistema integracaoSistema = db.IntegracaoSistema.Find(id);
            if (integracaoSistema == null)
            {
                return NotFound();
            }

            db.IntegracaoSistema.Remove(integracaoSistema);
            db.SaveChanges();

            return Ok(integracaoSistema);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IntegracaoSistemaExists(int id)
        {
            return db.IntegracaoSistema.Count(e => e.Id == id) > 0;
        }
    }
}