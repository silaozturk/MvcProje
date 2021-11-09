using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterAboutController : Controller
    {
        // GET: WriteAbout
        AboutManager aboutmanager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutvalues = aboutmanager.GetList();
            return View(aboutvalues);
        }
    }
}