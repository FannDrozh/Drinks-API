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
using Bar_API.Models;
using Bar_API.Entities;

namespace Bar_API.Controllers
{
    public class DrinksController : ApiController
    {
        private Bar_ShenEntities db = new Bar_ShenEntities();

        // GET: api/Drinks
        [ResponseType(typeof(List<DrinksModel>))]
        public IHttpActionResult GetDrinks()
        {
            return Ok(db.Drinks.ToList().ConvertAll(x => new DrinksModel(x)));
        }

        // GET: api/Drinks/5
        [ResponseType(typeof(Drinks))]
        public IHttpActionResult GetDrinks(int id)
        {
            Drinks drinks = db.Drinks.Find(id);
            if (drinks == null)
            {
                return NotFound();
            }

            return Ok(drinks);
        }

        // PUT: api/Drinks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrinks(int id, Drinks drinks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drinks.ID_Drink)
            {
                return BadRequest();
            }

            db.Entry(drinks).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinksExists(id))
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

        // POST: api/Drinks
        [ResponseType(typeof(Drinks))]
        public IHttpActionResult PostDrinks(Drinks drinks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Drinks.Add(drinks);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = drinks.ID_Drink }, drinks);
        }

        // DELETE: api/Drinks/5
        [ResponseType(typeof(Drinks))]
        public IHttpActionResult DeleteDrinks(int id)
        {
            Drinks drinks = db.Drinks.Find(id);
            if (drinks == null)
            {
                return NotFound();
            }

            db.Drinks.Remove(drinks);
            db.SaveChanges();

            return Ok(drinks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrinksExists(int id)
        {
            return db.Drinks.Count(e => e.ID_Drink == id) > 0;
        }
    }
}