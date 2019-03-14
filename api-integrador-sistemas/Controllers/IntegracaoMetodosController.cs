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
    public class IntegracaoMetodosController : ApiController
    {
        private ModeloDados db = new ModeloDados();

        // GET: api/IntegracaoMetodos
        public IQueryable<IntegracaoMetodo> GetIntegracaoMetodo()
        {
            return db.IntegracaoMetodo;
        }

        // GET: api/IntegracaoMetodos/5
        [ResponseType(typeof(IntegracaoMetodo))]
        public IHttpActionResult GetIntegracaoMetodo(int id)
        {
            IntegracaoMetodo integracaoMetodo = db.IntegracaoMetodo.Find(id);
            if (integracaoMetodo == null)
            {
                return NotFound();
            }

            return Ok(integracaoMetodo);
        }

        // PUT: api/IntegracaoMetodos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIntegracaoMetodo(int id, IntegracaoMetodo integracaoMetodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != integracaoMetodo.Id)
            {
                return BadRequest();
            }

            db.Entry(integracaoMetodo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntegracaoMetodoExists(id))
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

        // POST: api/IntegracaoMetodos
        [ResponseType(typeof(IntegracaoMetodo))]
        public IHttpActionResult PostIntegracaoMetodo(IntegracaoMetodo integracaoMetodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IntegracaoMetodo.Add(integracaoMetodo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = integracaoMetodo.Id }, integracaoMetodo);
        }

        // DELETE: api/IntegracaoMetodos/5
        [ResponseType(typeof(IntegracaoMetodo))]
        public IHttpActionResult DeleteIntegracaoMetodo(int id)
        {
            IntegracaoMetodo integracaoMetodo = db.IntegracaoMetodo.Find(id);
            if (integracaoMetodo == null)
            {
                return NotFound();
            }

            db.IntegracaoMetodo.Remove(integracaoMetodo);
            db.SaveChanges();

            return Ok(integracaoMetodo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IntegracaoMetodoExists(int id)
        {
            return db.IntegracaoMetodo.Count(e => e.Id == id) > 0;
        }
    }
}