using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class HobiController : Controller
    {
        GenericRepository<TBLHOBILERIM> repo = new GenericRepository<TBLHOBILERIM>();
        // ındex (tek sayfada) sayfasında listeleme ve güncelleme işlemi
        [HttpGet]
        #region HOBİ LİSTELE - GÜNCELLE
        public ActionResult Index()
        {
            var list = repo.List();
            return View(list);
        }
        [HttpPost] //güncelleme işlemi
        public ActionResult Index(List<TBLHOBILERIM> h)
        {
            foreach (var item in h) //ındex sayfasında liste oldugu için
            {
                var hobi = repo.Find(x => x.ID == item.ID);
                hobi.ACIKLAMA1 = item.ACIKLAMA1;
                hobi.ACIKLAMA2 = item.ACIKLAMA2;
                repo.TUpdate(hobi);
            }
            return RedirectToAction("Index");
        }
        #endregion

    }
}