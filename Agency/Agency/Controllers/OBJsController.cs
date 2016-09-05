using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Agency.Models;

namespace Agency.Controllers
{
    public class OBJsController : Controller
    {
        private agencyEntities db = new agencyEntities();

        // GET: OBJs
        public async Task<ActionResult> Index()
        {
            return View(await db.OBJs.ToListAsync());
        }

        // GET: OBJs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBJ oBJ = await db.OBJs.FindAsync(id);
            if (oBJ == null)
            {
                return HttpNotFound();
            }
            return View(oBJ);
        }

        // GET: OBJs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OBJs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ADDRESS,GeoLong,GeoLat,ROOMS,FLOOR,KIND_ID,TYPE_ID")] OBJ oBJ)
        {
            if (ModelState.IsValid)
            {
                db.OBJs.Add(oBJ);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(oBJ);
        }

        // GET: OBJs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBJ oBJ = await db.OBJs.FindAsync(id);
            if (oBJ == null)
            {
                return HttpNotFound();
            }
            return View(oBJ);
        }

        // POST: OBJs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ADDRESS,GeoLong,GeoLat,ROOMS,FLOOR,KIND_ID,TYPE_ID")] OBJ oBJ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oBJ).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(oBJ);
        }

        // GET: OBJs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBJ oBJ = await db.OBJs.FindAsync(id);
            if (oBJ == null)
            {
                return HttpNotFound();
            }
            return View(oBJ);
        }

        // POST: OBJs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OBJ oBJ = await db.OBJs.FindAsync(id);
            db.OBJs.Remove(oBJ);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
