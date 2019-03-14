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
    public class SistemasController : ApiController
    {
        private ModeloDados db = new ModeloDados();

        // GET: api/Sistemas
        public IQueryable<Sistema> GetSistema()
        {
            return db.Sistema;
        }

        // GET: api/Sistemas/5
        [ResponseType(typeof(Sistema))]
        public IHttpActionResult GetSistema(int id)
        {
            Sistema sistema = db.Sistema.Find(id);
            if (sistema == null)
            {
                return NotFound();
            }

            return Ok(sistema);
        }

        // PUT: api/Sistemas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSistema(int id, Sistema sistema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sistema.Id)
            {
                return BadRequest();
            }

            db.Entry(sistema).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SistemaExists(id))
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

        // POST: api/Sistemas
        [ResponseType(typeof(Sistema))]
        public IHttpActionResult PostSistema(Sistema sistema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sistema.Add(sistema);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sistema.Id }, sistema);
        }

        // DELETE: api/Sistemas/5
        [ResponseType(typeof(Sistema))]
        public IHttpActionResult DeleteSistema(int id)
        {
            Sistema sistema = db.Sistema.Find(id);
            if (sistema == null)
            {
                return NotFound();
            }

            db.Sistema.Remove(sistema);
            db.SaveChanges();

            return Ok(sistema);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SistemaExists(int id)
        {
            return db.Sistema.Count(e => e.Id == id) > 0;
        }
    }
}