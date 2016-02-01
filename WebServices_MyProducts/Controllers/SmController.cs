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
using WebServices_MyProducts.Models;

namespace WebServices_MyProducts.Controllers
{
    public class SmController : ApiController
    {
        private SmartPhonesContext db = new SmartPhonesContext();

        // GET: api/Sm
        public IQueryable<Smartphone> GetSmartphones()
        {
            return db.Smartphones;
        }

        // GET: api/Sm/5
        [ResponseType(typeof(Smartphone))]
        public IHttpActionResult GetSmartphone(int id)
        {
            Smartphone smartphone = db.Smartphones.Find(id);
            if (smartphone == null)
            {
                return NotFound();
            }

            return Ok(smartphone);
        }

        // PUT: api/Sm/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSmartphone(int id, Smartphone smartphone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != smartphone.Id)
            {
                return BadRequest();
            }

            db.Entry(smartphone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmartphoneExists(id))
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

        // POST: api/Sm
        [ResponseType(typeof(Smartphone))]
        public IHttpActionResult PostSmartphone(Smartphone smartphone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Smartphones.Add(smartphone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = smartphone.Id }, smartphone);
        }

        // DELETE: api/Sm/5
        [ResponseType(typeof(Smartphone))]
        public IHttpActionResult DeleteSmartphone(int id)
        {
            Smartphone smartphone = db.Smartphones.Find(id);
            if (smartphone == null)
            {
                return NotFound();
            }

            db.Smartphones.Remove(smartphone);
            db.SaveChanges();

            return Ok(smartphone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SmartphoneExists(int id)
        {
            return db.Smartphones.Count(e => e.Id == id) > 0;
        }
    }
}