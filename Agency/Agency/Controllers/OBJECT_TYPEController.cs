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
    public class OBJECT_TYPEController : Controller
    {
        private agencyEntities db = new agencyEntities();

        // GET: OBJECT_TYPE
        public async Task<ActionResult> Index()
        {
            return View(await db.OBJECT_TYPE.ToListAsync());
        }

        // GET: OBJECT_TYPE/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBJECT_TYPE oBJECT_TYPE = await db.OBJECT_TYPE.FindAsync(id);
            if (oBJECT_TYPE == null)
            {
                return HttpNotFound();
            }
            return View(oBJECT_TYPE);
        }

        // GET: OBJECT_TYPE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OBJECT_TYPE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NAME")] OBJECT_TYPE oBJECT_TYPE)
        {
            if (ModelState.IsValid)
            {
                db.OBJECT_TYPE.Add(oBJECT_TYPE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(oBJECT_TYPE);
        }

        // GET: OBJECT_TYPE/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBJECT_TYPE oBJECT_TYPE = await db.OBJECT_TYPE.FindAsync(id);
            if (oBJECT_TYPE == null)
            {
                return HttpNotFound();
            }
            return View(oBJECT_TYPE);
        }

        // POST: OBJECT_TYPE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NAME")] OBJECT_TYPE oBJECT_TYPE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oBJECT_TYPE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(oBJECT_TYPE);
        }

        // GET: OBJECT_TYPE/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBJECT_TYPE oBJECT_TYPE = await db.OBJECT_TYPE.FindAsync(id);
            if (oBJECT_TYPE == null)
            {
                return HttpNotFound();
            }
            return View(oBJECT_TYPE);
        }

        // POST: OBJECT_TYPE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OBJECT_TYPE oBJECT_TYPE = await db.OBJECT_TYPE.FindAsync(id);
            db.OBJECT_TYPE.Remove(oBJECT_TYPE);
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
