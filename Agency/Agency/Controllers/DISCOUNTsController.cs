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
    public class DISCOUNTsController : Controller
    {
        private agencyEntities db = new agencyEntities();

        // GET: DISCOUNTs
        public async Task<ActionResult> Index()
        {
            return View(await db.DISCOUNTs.ToListAsync());
        }

        // GET: DISCOUNTs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCOUNT dISCOUNT = await db.DISCOUNTs.FindAsync(id);
            if (dISCOUNT == null)
            {
                return HttpNotFound();
            }
            return View(dISCOUNT);
        }

        // GET: DISCOUNTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DISCOUNTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Value")] DISCOUNT dISCOUNT)
        {
            if (ModelState.IsValid)
            {
                db.DISCOUNTs.Add(dISCOUNT);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dISCOUNT);
        }

        // GET: DISCOUNTs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCOUNT dISCOUNT = await db.DISCOUNTs.FindAsync(id);
            if (dISCOUNT == null)
            {
                return HttpNotFound();
            }
            return View(dISCOUNT);
        }

        // POST: DISCOUNTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Value")] DISCOUNT dISCOUNT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dISCOUNT).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dISCOUNT);
        }

        // GET: DISCOUNTs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCOUNT dISCOUNT = await db.DISCOUNTs.FindAsync(id);
            if (dISCOUNT == null)
            {
                return HttpNotFound();
            }
            return View(dISCOUNT);
        }

        // POST: DISCOUNTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DISCOUNT dISCOUNT = await db.DISCOUNTs.FindAsync(id);
            db.DISCOUNTs.Remove(dISCOUNT);
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
