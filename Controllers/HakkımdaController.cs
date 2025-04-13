using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        GenericRepository<TBLHAKKIMDA> repo = new GenericRepository<TBLHAKKIMDA>();

        [HttpGet]
        public ActionResult Index()
        {
            var list = repo.List();
            return View(list);
        }
        [HttpPost]
        public ActionResult Index(List<TBLHAKKIMDA> hak)
        {
            foreach (var item in hak)
            {
                var guncel = repo.Find(x => x.ID == item.ID);
                guncel.MAIL = item.MAIL;
                guncel.AD = item.AD;
                guncel.SOYAD = item.SOYAD;
                guncel.ADRES = item.ADRES;
                guncel.TELEFON = item.TELEFON;
                guncel.ACIKLAMA = item.ACIKLAMA;
                guncel.RESIM = item.RESIM;
                repo.TUpdate(guncel);
            }

            return RedirectToAction("Index");
        }
    }
}