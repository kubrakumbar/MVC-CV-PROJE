using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class IletisimController : Controller
    {
        GenericRepository<TBLILETISIM> repo = new GenericRepository<TBLILETISIM>();
        // GET: Iletisim

        #region LİSTELEME
        public ActionResult Index()
        {
            
            return View(repo.List());
        }
        #endregion
    }
}