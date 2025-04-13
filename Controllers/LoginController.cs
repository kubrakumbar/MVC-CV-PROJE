using MVC_CV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_CV.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //Doğrulama işlemi başarılı olduğunda kullanıcının tarayıcısına bir kimlik doğrulama çerezi (authentication cookie) gönderilir ve kullanıcı bu çerez sayesinde web uygulamasına erişebilir.
        [HttpPost]
        public ActionResult Index(TBLADMIN a)
        {
            DB_MVC_CVEntities db = new DB_MVC_CVEntities();
            var bilgi = db.TBLADMIN.FirstOrDefault(x => x.KULLANICIADI == a.KULLANICIADI && x.SIFRE == a.SIFRE);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KULLANICIADI, false);//Kimlik doğrulama işlemi başarılı olduğunda, kullanıcının tarayıcısına bir authentication cookie gönderilir.
                Session["KullaniciAdi"] = bilgi.KULLANICIADI.ToString();
                return RedirectToAction("Index", "Deneyim");

            }
            else
            {
                return RedirectToAction("Index", "Logın");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();//oturum verilerini yok eder
            return RedirectToAction("Index","Login");
        }
    }
}