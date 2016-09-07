using Agency.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agency.Controllers
{
    public class AddAdController : Controller
    {
        private agencyEntities db = new agencyEntities();
        // GET: AddAd
        public ActionResult Index()
        {
            List<AddAdModel> model = new List<AddAdModel>();
            AddAdModel fullAd = new AddAdModel();
            List<OBJ> objList = db.OBJs.ToList();
                       
            return View(fullAd);
        }

        // GET: AddAd/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AddAd/Create
        public ActionResult Create()
        {
            ViewBag.OBJECT_KIND = new SelectList(db.OBJECT_KIND.Select(c => c.NAME).ToList());
            ViewBag.OBJECT_TYPE = new SelectList(db.OBJECT_TYPE.Select(c => c.NAME).ToList());
            ViewBag.AD_TYPE = new SelectList(db.AD_TYPE.Select(c => c.NAME).ToList());
            return View();
        }

        // POST: AddAd/Create
        [HttpPost]
        public ActionResult Create(AddAdModel model)
        {
            try
            {
                OBJ newObj = new OBJ();
                Ad newAd = new Ad();
                foreach (var i in model.Files)
                {
                    if (i.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(i.FileName);
                        var fileNameWithPath = Path.Combine(Server.MapPath("~/App_Data/Files"), fileName);
                        i.SaveAs(fileNameWithPath);
                        //Make filepath relative
                        Uri fromPath = new Uri(fileNameWithPath);
                        Uri toPath = new Uri(Server.MapPath("./Files"));
                        Uri path = toPath.MakeRelativeUri(fromPath);                     
                        newObj.IMAGE += path + ";";
                    }
                }              
                newObj = model.obj;
                newAd = model.advert;
                db.OBJs.Add(newObj);
                db.SaveChanges();             
                newAd.OBJECT_ID = newObj.Id;
                db.Ads.Add(newAd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());  
                ViewBag.OBJECT_KIND = new SelectList(db.OBJECT_KIND.Select(c => c.NAME).ToList());
                ViewBag.OBJECT_TYPE = new SelectList(db.OBJECT_TYPE.Select(c => c.NAME).ToList());
                ViewBag.AD_TYPE = new SelectList(db.AD_TYPE.Select(c => c.NAME).ToList());
                return View();
            }
        }

        // GET: AddAd/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AddAd/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AddAd/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AddAd/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
