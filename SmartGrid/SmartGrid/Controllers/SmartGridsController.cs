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
using SmartGrid.Models;

namespace SmartGrid.Controllers
{
    public class SmartGridsController : ApiController
    {
        private SmartGridContext db = new SmartGridContext();

        // GET: api/SmartGrids
        public IQueryable<Models.SmartGrid> GetSmartGrid()
        {
            return db.SmartGrid;
        }

        // GET: api/SmartGrids/5
        [ResponseType(typeof(Models.SmartGrid))]
        public IHttpActionResult GetSmartGrid(int id)
        {
            Models.SmartGrid smartGrid = db.SmartGrid.Find(id);
            if (smartGrid == null)
            {
                return NotFound();
            }

            return Ok(smartGrid);
        }

        // PUT: api/SmartGrids/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSmartGrid(int id, Models.SmartGrid smartGrid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != smartGrid.Id)
            {
                return BadRequest();
            }

            db.Entry(smartGrid).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmartGridExists(id))
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

        // POST: api/SmartGrids
        [ResponseType(typeof(Models.SmartGrid))]
        public IHttpActionResult PostSmartGrid(Models.SmartGrid smartGrid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SmartGrid.Add(smartGrid);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SmartGridExists(smartGrid.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = smartGrid.Id }, smartGrid);
        }

        // DELETE: api/SmartGrids/5
        [ResponseType(typeof(Models.SmartGrid))]
        public IHttpActionResult DeleteSmartGrid(int id)
        {
            Models.SmartGrid smartGrid = db.SmartGrid.Find(id);
            if (smartGrid == null)
            {
                return NotFound();
            }

            db.SmartGrid.Remove(smartGrid);
            db.SaveChanges();

            return Ok(smartGrid);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SmartGridExists(int id)
        {
            return db.SmartGrid.Count(e => e.Id == id) > 0;
        }
    }
}