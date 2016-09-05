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
    public class AD_TYPEController : Controller
    {
        private agencyEntities db = new agencyEntities();

        // GET: AD_TYPE
        public async Task<ActionResult> Index()
        {
            return View(await db.AD_TYPE.ToListAsync());
        }

        // GET: AD_TYPE/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AD_TYPE aD_TYPE = await db.AD_TYPE.FindAsync(id);
            if (aD_TYPE == null)
            {
                return HttpNotFound();
            }
            return View(aD_TYPE);
        }

        // GET: AD_TYPE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AD_TYPE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NAME")] AD_TYPE aD_TYPE)
        {
            if (ModelState.IsValid)
            {
                db.AD_TYPE.Add(aD_TYPE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aD_TYPE);
        }

        // GET: AD_TYPE/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AD_TYPE aD_TYPE = await db.AD_TYPE.FindAsync(id);
            if (aD_TYPE == null)
            {
                return HttpNotFound();
            }
            return View(aD_TYPE);
        }

        // POST: AD_TYPE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NAME")] AD_TYPE aD_TYPE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aD_TYPE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(aD_TYPE);
        }

        // GET: AD_TYPE/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AD_TYPE aD_TYPE = await db.AD_TYPE.FindAsync(id);
            if (aD_TYPE == null)
            {
                return HttpNotFound();
            }
            return View(aD_TYPE);
        }

        // POST: AD_TYPE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AD_TYPE aD_TYPE = await db.AD_TYPE.FindAsync(id);
            db.AD_TYPE.Remove(aD_TYPE);
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
