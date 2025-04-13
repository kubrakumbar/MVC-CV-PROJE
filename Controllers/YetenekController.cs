using MVC_CV.Repositories;
using MVC_CV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
      YetenekRepository repo = new YetenekRepository();
        //GenericRepository<TBLYETENEKLERIM> repo = new GenericRepository<TBLYETENEKLERIM>();
        #region YETENEK LİSTELEME
        public ActionResult Index()
        {
            return View(repo.List());
        }
        #endregion

        #region YETENEK EKLEME
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(TBLYETENEKLERIM ytnk)
        {
            repo.TAdd(ytnk);
            return RedirectToAction("Index");
        }
        #endregion

        #region YETENEK SİLME
        
        public ActionResult YetenekSil(int id)
        {
           TBLYETENEKLERIM sil= repo.Find(x => x.ID == id);
            repo.TDelete(sil);

            return RedirectToAction("Index");
        }
        #endregion

        #region YETENEK GÜNCELLEME
        [HttpGet]
        public ActionResult YetenekGuncelle(int id)
        {
            TBLYETENEKLERIM y = repo.Find(x => x.ID == id);
            return View(y);
        }
        [HttpPost]
        public ActionResult YetenekGuncelle(TBLYETENEKLERIM mdl)
        {
            TBLYETENEKLERIM guncel = repo.Find(x => x.ID == mdl.ID);
            guncel.ORAN = mdl.ORAN;
            guncel.YETENEK = mdl.YETENEK;
            repo.TUpdate(guncel); 
            return RedirectToAction("Index");
        }


        #endregion
    }
}