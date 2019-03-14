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
    public class PermissoesController : ApiController
    {
        private ModeloDados db = new ModeloDados();

        // GET: api/Permissoes
        public IQueryable<Permissao> GetPermissao()
        {
            return db.Permissao;
        }

        // GET: api/Permissoes/5
        [ResponseType(typeof(Permissao))]
        public IHttpActionResult GetPermissao(int id)
        {
            Permissao permissao = db.Permissao.Find(id);
            if (permissao == null)
            {
                return NotFound();
            }

            return Ok(permissao);
        }

        // PUT: api/Permissoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPermissao(int id, Permissao permissao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != permissao.Id)
            {
                return BadRequest();
            }

            db.Entry(permissao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissaoExists(id))
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

        // POST: api/Permissoes
        [ResponseType(typeof(Permissao))]
        public IHttpActionResult PostPermissao(Permissao permissao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Permissao.Add(permissao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = permissao.Id }, permissao);
        }

        // DELETE: api/Permissoes/5
        [ResponseType(typeof(Permissao))]
        public IHttpActionResult DeletePermissao(int id)
        {
            Permissao permissao = db.Permissao.Find(id);
            if (permissao == null)
            {
                return NotFound();
            }

            db.Permissao.Remove(permissao);
            db.SaveChanges();

            return Ok(permissao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PermissaoExists(int id)
        {
            return db.Permissao.Count(e => e.Id == id) > 0;
        }
    }
}