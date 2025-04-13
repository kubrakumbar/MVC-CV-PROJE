using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<TBLSOSYALMEDYA> repo = new GenericRepository<TBLSOSYALMEDYA>();
        // GET: SosyalMedya
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        //modal üzerinden ekleme işlemi yapma
        public ActionResult Ekle()
        {

            return PartialView();
        }
        [HttpPost]
        public ActionResult Ekle(TBLSOSYALMEDYA s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }
        //güncelleme 
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult Guncelle(TBLSOSYALMEDYA s)
        {
            var hesap = repo.Find(x => x.ID == s.ID);
            hesap.AD = s.AD;
            hesap.DURUM = true;
            hesap.LINK = s.LINK;
            hesap.ICON = s.ICON;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }


        //durum : aktif - pasif 
        public ActionResult Sil(int id) {
            var hesap = repo.Find(x => x.ID == id);
            hesap.DURUM = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }


    }
}