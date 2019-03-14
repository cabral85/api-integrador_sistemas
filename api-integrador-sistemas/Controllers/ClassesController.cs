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
    public class ClassesController : ApiController
    {
        private ModeloDados db = new ModeloDados();

        // GET: api/Classes
        public IQueryable<Classe> GetClasse()
        {
            return db.Classe;
        }

        // GET: api/Classes/5
        [ResponseType(typeof(Classe))]
        public IHttpActionResult GetClasse(int id)
        {
            Classe classe = db.Classe.Find(id);
            if (classe == null)
            {
                return NotFound();
            }

            return Ok(classe);
        }

        // PUT: api/Classes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClasse(int id, Classe classe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classe.Id)
            {
                return BadRequest();
            }

            db.Entry(classe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasseExists(id))
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

        // POST: api/Classes
        [ResponseType(typeof(Classe))]
        public IHttpActionResult PostClasse(Classe classe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Classe.Add(classe);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ClasseExists(classe.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = classe.Id }, classe);
        }

        // DELETE: api/Classes/5
        [ResponseType(typeof(Classe))]
        public IHttpActionResult DeleteClasse(int id)
        {
            Classe classe = db.Classe.Find(id);
            if (classe == null)
            {
                return NotFound();
            }

            db.Classe.Remove(classe);
            db.SaveChanges();

            return Ok(classe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClasseExists(int id)
        {
            return db.Classe.Count(e => e.Id == id) > 0;
        }
    }
}