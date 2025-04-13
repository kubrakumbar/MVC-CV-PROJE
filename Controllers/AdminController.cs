using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        GenericRepository<TBLADMIN> repo = new GenericRepository<TBLADMIN>();
        // GET: Admin
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(TBLADMIN admn)
        {
            repo.TAdd(admn);
            return RedirectToAction("Index","Admin");
        }
        public ActionResult AdminSil(int id)
        {
            TBLADMIN sil = repo.Find(x => x.ID == id);
            repo.TDelete(sil);
            return RedirectToAction("Index", "Admin");
        }
        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            TBLADMIN sil = repo.Find(x => x.ID == id);
            return View(sil);
        }
        [HttpPost]
        public ActionResult AdminDuzenle(TBLADMIN admn)
        {
            TBLADMIN dznle = repo.Find(x => x.ID == admn.ID);
            dznle.KULLANICIADI = admn.KULLANICIADI;
            dznle.SIFRE = admn.SIFRE;
            repo.TUpdate(dznle);
            return RedirectToAction("Index");
        }

    }
}