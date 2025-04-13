using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC_CV.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TBLSERTIFIKALARIM> repo = new GenericRepository<TBLSERTIFIKALARIM>();

        #region SERTİFİKA LİSTELE        
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        #endregion

        #region SERTİFİKA GÜNCELLE
        [HttpGet]
        public ActionResult SertifikaGuncelle(int id)
        {
            TBLSERTIFIKALARIM s = repo.Find(x => x.ID == id);
            return View(s);
        }
        [HttpPost]
        public ActionResult SertifikaGuncelle(TBLSERTIFIKALARIM mdl)
        {
            TBLSERTIFIKALARIM s = repo.Find(x => x.ID == mdl.ID);
            s.ACIKLAMA = mdl.ACIKLAMA;
            s.TARIH = mdl.TARIH;
            repo.TUpdate(s);
            return RedirectToAction("Index");
        }
        #endregion

        #region SERTİFİKA EKLE
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TBLSERTIFIKALARIM mdl)
        {
            repo.TAdd(mdl);
            return RedirectToAction("Index");
        }
        #endregion

        #region SERTİFİKA SİL
        public ActionResult SertifikaSil(int id)
        {
            TBLSERTIFIKALARIM sil = repo.Find(x => x.ID == id);
            repo.TDelete(sil);
            return RedirectToAction("Index");
        }
        #endregion
    }
}