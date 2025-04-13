using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TBLEGITIMLERIM> repo = new GenericRepository<TBLEGITIMLERIM>();

        #region EGİTİM LİSTELEME

       //[Authorize] //bu şekilde tanımlanan sayfaya erişilemez.
        public ActionResult Index()
        {
            return View(repo.List());
        }
        #endregion

        #region EĞİTİM EKLE
        [HttpGet]
        public ActionResult EgitimEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TBLEGITIMLERIM e)
        {
            if (!ModelState.IsValid) //eğer modelin durum geçerliliği sağlanmadıysa
            {
                return View("EgitimEkle");
            }
            repo.TAdd(e);
            return RedirectToAction("Index");
        }
        #endregion

        #region EĞİTİM SİLME
        public ActionResult EgitimSil(int id)
        {
            TBLEGITIMLERIM sil = repo.Find(x => x.ID == id);
            repo.TDelete(sil);
            return RedirectToAction("Index");
        }
        #endregion

        #region EĞİTİM GÜNCELLEME
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            TBLEGITIMLERIM e = repo.Find(x => x.ID == id);
            return View(e);
        }
        [HttpPost]
        public ActionResult EgitimGetir(TBLEGITIMLERIM mdl)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimGetir");
            }
            TBLEGITIMLERIM gncl = repo.Find(x => x.ID == mdl.ID);
            gncl.BASLIK = mdl.BASLIK;
            gncl.ALTBASLIK = mdl.ALTBASLIK;
            gncl.ALTBASLIK2 = mdl.ALTBASLIK2;
            gncl.GNO = mdl.GNO;
            gncl.TARIH = mdl.TARIH;
            repo.TUpdate(gncl);

            return RedirectToAction("Index");
        }

        #endregion
    }
}