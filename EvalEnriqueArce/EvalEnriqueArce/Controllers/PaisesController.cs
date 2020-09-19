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
using EvalEnriqueArce.Models;

namespace EvalEnriqueArce.Controllers
{
    public class PaisesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Paises
        
        public IQueryable<Pais> GetPais()
        {
            return db.Pais;
        }

        // GET: api/Paises/5
        [ResponseType(typeof(Pais))]
        public IHttpActionResult GetPais(string id)
        {
            Pais pais = db.Pais.Find(id);
            if (pais == null)
            {
                return NotFound();
            }

            return Ok(pais);
        }

        // PUT: api/Paises/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPais(string id, Pais pais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pais.Name)
            {
                return BadRequest();
            }

            db.Entry(pais).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisExists(id))
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

        // POST: api/Paises
        [ResponseType(typeof(Pais))]
        public IHttpActionResult PostPais(Pais pais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pais.Add(pais);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PaisExists(pais.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pais.Name }, pais);
        }

        // DELETE: api/Paises/5
        [ResponseType(typeof(Pais))]
        public IHttpActionResult DeletePais(string id)
        {
            Pais pais = db.Pais.Find(id);
            if (pais == null)
            {
                return NotFound();
            }

            db.Pais.Remove(pais);
            db.SaveChanges();

            return Ok(pais);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaisExists(string id)
        {
            return db.Pais.Count(e => e.Name == id) > 0;
        }
    }
}