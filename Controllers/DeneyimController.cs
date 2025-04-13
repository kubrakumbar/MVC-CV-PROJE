using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository(); //artık epository katmanından örnek alırız

        
        #region DENEYİM LİSTELEME
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        #endregion

        #region DENEYİM EKLE
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TBLDENEYIMLER p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        #endregion

        #region DENEYİM SİL
        public ActionResult DeneyimSil(int id)
        {
            TBLDENEYIMLER t = repo.Find(x => x.ID == id); //find metotu ile , koşul ile
            //TBLDENEYIMLER t = repo.TGet(id);//tget metotu ile , id ile
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        #endregion

        #region DENEYİM GĞNCELLE
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            //TBLDENEYIMLER t = repo.TGet(id); tget metotu, id ile
            TBLDENEYIMLER t = repo.Find(x => x.ID == id); //fin metotu, şarta göre
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TBLDENEYIMLER mdl)
        {
            TBLDENEYIMLER t = repo.Find(x => x.ID == mdl.ID);
            t.BASLIK = mdl.BASLIK;
            t.ALTBASLIK = mdl.ALTBASLIK;
            t.ACIKLAMA = mdl.ACIKLAMA;
            t.TARIH = mdl.TARIH;
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
     

        #endregion

    }
}