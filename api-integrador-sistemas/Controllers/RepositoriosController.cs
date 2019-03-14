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
    public class RepositoriosController : ApiController
    {
        private ModeloDados db = new ModeloDados();

        // GET: api/Repositorios
        public IQueryable<Repositorio> GetRepositorio()
        {
            return db.Repositorio;
        }

        // GET: api/Repositorios/5
        [ResponseType(typeof(Repositorio))]
        public IHttpActionResult GetRepositorio(int id)
        {
            Repositorio repositorio = db.Repositorio.Find(id);
            if (repositorio == null)
            {
                return NotFound();
            }

            return Ok(repositorio);
        }

        // PUT: api/Repositorios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRepositorio(int id, Repositorio repositorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != repositorio.Id)
            {
                return BadRequest();
            }

            db.Entry(repositorio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepositorioExists(id))
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

        // POST: api/Repositorios
        [ResponseType(typeof(Repositorio))]
        public IHttpActionResult PostRepositorio(Repositorio repositorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Repositorio.Add(repositorio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = repositorio.Id }, repositorio);
        }

        // DELETE: api/Repositorios/5
        [ResponseType(typeof(Repositorio))]
        public IHttpActionResult DeleteRepositorio(int id)
        {
            Repositorio repositorio = db.Repositorio.Find(id);
            if (repositorio == null)
            {
                return NotFound();
            }

            db.Repositorio.Remove(repositorio);
            db.SaveChanges();

            return Ok(repositorio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RepositorioExists(int id)
        {
            return db.Repositorio.Count(e => e.Id == id) > 0;
        }
    }
}