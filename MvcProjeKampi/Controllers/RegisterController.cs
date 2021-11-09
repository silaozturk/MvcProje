using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Register
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            string password = admin.AdminPassword;
            string result = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(password)));
            admin.AdminPassword = result;
            //admin.AdminRole = "A";
            adminManager.AdminAdd(admin);
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public ActionResult WriterIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterIndex(Writer writer)
        {
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            string password = writer.WriterPassword;
            string result = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(password)));
            writer.WriterPassword = result;
            //admin.AdminRole = "A";
            writerManager.WriterAdd(writer);
            return RedirectToAction("WriterLogin", "Login");
        }

    }
}