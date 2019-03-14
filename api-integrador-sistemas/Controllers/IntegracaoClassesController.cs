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
    public class IntegracaoClassesController : ApiController
    {
        private ModeloDados db = new ModeloDados();

        // GET: api/IntegracaoClasses
        public IQueryable<IntegracaoClasse> GetIntegracaoClasse()
        {
            return db.IntegracaoClasse;
        }

        // GET: api/IntegracaoClasses/5
        [ResponseType(typeof(IntegracaoClasse))]
        public IHttpActionResult GetIntegracaoClasse(int id)
        {
            IntegracaoClasse integracaoClasse = db.IntegracaoClasse.Find(id);
            if (integracaoClasse == null)
            {
                return NotFound();
            }

            return Ok(integracaoClasse);
        }

        // PUT: api/IntegracaoClasses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIntegracaoClasse(int id, IntegracaoClasse integracaoClasse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != integracaoClasse.Id)
            {
                return BadRequest();
            }

            db.Entry(integracaoClasse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntegracaoClasseExists(id))
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

        // POST: api/IntegracaoClasses
        [ResponseType(typeof(IntegracaoClasse))]
        public IHttpActionResult PostIntegracaoClasse(IntegracaoClasse integracaoClasse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IntegracaoClasse.Add(integracaoClasse);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (IntegracaoClasseExists(integracaoClasse.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = integracaoClasse.Id }, integracaoClasse);
        }

        // DELETE: api/IntegracaoClasses/5
        [ResponseType(typeof(IntegracaoClasse))]
        public IHttpActionResult DeleteIntegracaoClasse(int id)
        {
            IntegracaoClasse integracaoClasse = db.IntegracaoClasse.Find(id);
            if (integracaoClasse == null)
            {
                return NotFound();
            }

            db.IntegracaoClasse.Remove(integracaoClasse);
            db.SaveChanges();

            return Ok(integracaoClasse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IntegracaoClasseExists(int id)
        {
            return db.IntegracaoClasse.Count(e => e.Id == id) > 0;
        }
    }
}