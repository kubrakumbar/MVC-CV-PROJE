using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;

namespace MVC_CV.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DB_MVC_CVEntities db;
        public ActionResult Index()
        {
            using (db = new DB_MVC_CVEntities())
            {
                var degerler = db.TBLHAKKIMDA.ToList();
                return View(degerler);
            }

        }
        public PartialViewResult Deneyim()
        {
            using (db = new DB_MVC_CVEntities())
            {
                var degerler = db.TBLDENEYIMLER.ToList();
                return PartialView(degerler);
            }
        }
        public PartialViewResult SosyalMedya()
        {
            using (db = new DB_MVC_CVEntities())
            {
                var sosyal = db.TBLSOSYALMEDYA.Where(x=>x.DURUM==true).ToList();
                return PartialView(sosyal);
            }
        }
        public PartialViewResult Egitim()
        {
            using (db = new DB_MVC_CVEntities())
            {
                var degerler = db.TBLEGITIMLERIM.ToList();
                return PartialView(degerler);
            }
        }
        public PartialViewResult Yetenek()
        {
            using (db = new DB_MVC_CVEntities())
            {
                var degerler = db.TBLYETENEKLERIM.ToList();
                return PartialView(degerler);
            }
        }
        public PartialViewResult Hobiler()
        {
            using (db = new DB_MVC_CVEntities())
            {
                var degerler = db.TBLHOBILERIM.ToList();
                return PartialView(degerler);
            }
        }
        public PartialViewResult Sertifika()
        {
            using (db = new DB_MVC_CVEntities())
            {
                var degerler = db.TBLSERTIFIKALARIM.ToList();
                return PartialView(degerler);
            }
        }
        public PartialViewResult Iletisim()
        {
            return PartialView(new TBLILETISIM());
        }
        [HttpPost]
        public PartialViewResult Iletisim(TBLILETISIM model)
        {
            using (db = new DB_MVC_CVEntities())
            {
                model.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString()); 
                db.TBLILETISIM.Add(model);
                db.SaveChanges();

            }
            return PartialView();
        }
    }
}