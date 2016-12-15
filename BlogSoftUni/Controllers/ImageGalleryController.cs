using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using BlogSoftUni.Models;

namespace BlogSoftUni.Controllers
{
    public class ImageGalleryController : Controller
    {
        // GET: ImageGallery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            List<ImageGallery> all=new List<ImageGallery>();
            //Here MyTableEntities is our context
            using (MyTableEntities dc=new MyTableEntities())
            {
                all = dc.ImageGalleries.ToList();
            }
            return View(all);
        }
        
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(ImageGallery IG)
        {
            //Apply Validation mere
           
            if (IG.FIle.ContentLength > (3*1024*1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 3 mb");
                return View(IG);
            }
            if (!(IG.FIle.ContentType == "image/jpeg" || IG.FIle.ContentType == "image/gif"))
            {
                ModelState.AddModelError("CustomError", "File type allowed: jpeg and gif");
                return View();
            }
            IG.FileName = IG.FIle.FileName;
            IG.ImageSize = IG.FIle.ContentLength;
            byte[] data = new byte[IG.FIle.ContentLength];
            IG.FIle.InputStream.Read(data, 0, IG.FIle.ContentLength);
            IG.ImageData = data;
            using (MyTableEntities dc = new MyTableEntities())
            {
                dc.ImageGalleries.Add(IG);
                dc.SaveChanges();
            }
            return RedirectToAction("Gallery");
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete(int? id)
        {
            return View();
        }
    }
}