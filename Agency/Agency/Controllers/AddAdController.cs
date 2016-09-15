using Agency.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
            List<Ad> ad = db.Ads.Where(c => c.PUBLISHED == true).ToList();                               
            return View(ad);
        }

        // GET: AddAd/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AddAd/Create
        public ActionResult Create()
        {
            ViewBag.DISCOUNT = new SelectList(db.DISCOUNTs, "Id", "Value");
            ViewBag.OBJECT_KIND = new SelectList(db.OBJECT_KIND, "Id", "NAME");
            ViewBag.OBJECT_TYPE = new SelectList(db.OBJECT_TYPE, "Id", "NAME");
            ViewBag.AD_TYPE = new SelectList(db.AD_TYPE, "Id", "NAME");
            return View();
        }

        // POST: AddAd/Create
        [HttpPost]
        public ActionResult Create(AddAdModel model)
        {
            try
            {           
                foreach (var i in model.Files)
                {
                    if (i.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(i.FileName);
                        var fileNameWithPath = Path.Combine(Server.MapPath("~/Files"), fileName);
                        i.SaveAs(fileNameWithPath);
                        //Make filepath relative
                        Uri fromPath = new Uri(fileNameWithPath);
                        Uri toPath = new Uri(Server.MapPath("./Files"));
                        Uri path = toPath.MakeRelativeUri(fromPath);
                        model.obj.IMAGE += path + ";";
                        //String path = UploadImage(i);
                    }
                }
                model.advert.ADDITION_DATE = DateTime.Today;
                db.OBJs.Add(model.obj);
                db.SaveChanges();             
                model.advert.OBJECT_ID = model.obj.Id;
                db.Ads.Add(model.advert);
                db.SaveChanges();
                return RedirectToAction("Index", "Ads");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                ViewBag.DISCOUNT = new SelectList(db.DISCOUNTs, "Id", "Value");
                ViewBag.OBJECT_KIND = new SelectList(db.OBJECT_KIND, "Id", "NAME");
                ViewBag.OBJECT_TYPE = new SelectList(db.OBJECT_TYPE, "Id", "NAME");
                ViewBag.AD_TYPE = new SelectList(db.AD_TYPE, "Id", "NAME");
                return View();
            }
        }


        public string UploadImage(HttpPostedFileBase image)
        {
            var httpWReq =
                (HttpWebRequest)WebRequest.Create("http://www.imageshack.us/upload_api.php");

            httpWReq.Method = "POST";
            httpWReq.ContentType = "multipart/form-data";
            httpWReq.KeepAlive = true;

            var stream = httpWReq.GetRequestStream();
            var encoding = new UTF8Encoding();
            var postData = "key=GZC2V0FT62e1caa7d54d699a56959989f31a5af2";
            postData += "&fileupload=";
            byte[] data = encoding.GetBytes(postData);
            stream.Write(data, 0, data.Length);
            var buffer = new byte[4096];
            int bytesread;
            while ((bytesread = image.InputStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                stream.Write(buffer, 0, bytesread);
            }
            stream.Close();


            var response = (HttpWebResponse)httpWReq.GetResponse();

            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
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
