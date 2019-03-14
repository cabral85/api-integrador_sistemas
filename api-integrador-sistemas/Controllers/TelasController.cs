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
    public class TelasController : ApiController
    {
        private ModeloDados db = new ModeloDados();

        // GET: api/Telas
        public IQueryable<Tela> GetTela()
        {
            return db.Tela;
        }

        // GET: api/Telas/5
        [ResponseType(typeof(Tela))]
        public IHttpActionResult GetTela(int id)
        {
            Tela tela = db.Tela.Find(id);
            if (tela == null)
            {
                return NotFound();
            }

            return Ok(tela);
        }

        // PUT: api/Telas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTela(int id, Tela tela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tela.Id)
            {
                return BadRequest();
            }

            db.Entry(tela).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelaExists(id))
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

        // POST: api/Telas
        [ResponseType(typeof(Tela))]
        public IHttpActionResult PostTela(Tela tela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tela.Add(tela);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tela.Id }, tela);
        }

        // DELETE: api/Telas/5
        [ResponseType(typeof(Tela))]
        public IHttpActionResult DeleteTela(int id)
        {
            Tela tela = db.Tela.Find(id);
            if (tela == null)
            {
                return NotFound();
            }

            db.Tela.Remove(tela);
            db.SaveChanges();

            return Ok(tela);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelaExists(int id)
        {
            return db.Tela.Count(e => e.Id == id) > 0;
        }
    }
}