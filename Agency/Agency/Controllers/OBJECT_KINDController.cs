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
    public class OBJECT_KINDController : Controller
    {
        private agencyEntities db = new agencyEntities();

        // GET: OBJECT_KIND
        public async Task<ActionResult> Index()
        {
            return View(await db.OBJECT_KIND.ToListAsync());
        }

        // GET: OBJECT_KIND/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBJECT_KIND oBJECT_KIND = await db.OBJECT_KIND.FindAsync(id);
            if (oBJECT_KIND == null)
            {
                return HttpNotFound();
            }
            return View(oBJECT_KIND);
        }

        // GET: OBJECT_KIND/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OBJECT_KIND/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NAME")] OBJECT_KIND oBJECT_KIND)
        {
            if (ModelState.IsValid)
            {
                db.OBJECT_KIND.Add(oBJECT_KIND);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(oBJECT_KIND);
        }

        // GET: OBJECT_KIND/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBJECT_KIND oBJECT_KIND = await db.OBJECT_KIND.FindAsync(id);
            if (oBJECT_KIND == null)
            {
                return HttpNotFound();
            }
            return View(oBJECT_KIND);
        }

        // POST: OBJECT_KIND/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NAME")] OBJECT_KIND oBJECT_KIND)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oBJECT_KIND).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(oBJECT_KIND);
        }

        // GET: OBJECT_KIND/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBJECT_KIND oBJECT_KIND = await db.OBJECT_KIND.FindAsync(id);
            if (oBJECT_KIND == null)
            {
                return HttpNotFound();
            }
            return View(oBJECT_KIND);
        }

        // POST: OBJECT_KIND/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OBJECT_KIND oBJECT_KIND = await db.OBJECT_KIND.FindAsync(id);
            db.OBJECT_KIND.Remove(oBJECT_KIND);
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
