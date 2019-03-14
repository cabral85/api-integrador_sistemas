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
    public class MetodosController : ApiController
    {
        private ModeloDados db = new ModeloDados();

        // GET: api/Metodos
        public IQueryable<Metodo> GetMetodo()
        {
            return db.Metodo;
        }

        // GET: api/Metodos/5
        [ResponseType(typeof(Metodo))]
        public IHttpActionResult GetMetodo(int id)
        {
            Metodo metodo = db.Metodo.Find(id);
            if (metodo == null)
            {
                return NotFound();
            }

            return Ok(metodo);
        }

        // PUT: api/Metodos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMetodo(int id, Metodo metodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != metodo.Id)
            {
                return BadRequest();
            }

            db.Entry(metodo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetodoExists(id))
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

        // POST: api/Metodos
        [ResponseType(typeof(Metodo))]
        public IHttpActionResult PostMetodo(Metodo metodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Metodo.Add(metodo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = metodo.Id }, metodo);
        }

        // DELETE: api/Metodos/5
        [ResponseType(typeof(Metodo))]
        public IHttpActionResult DeleteMetodo(int id)
        {
            Metodo metodo = db.Metodo.Find(id);
            if (metodo == null)
            {
                return NotFound();
            }

            db.Metodo.Remove(metodo);
            db.SaveChanges();

            return Ok(metodo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MetodoExists(int id)
        {
            return db.Metodo.Count(e => e.Id == id) > 0;
        }
    }
}