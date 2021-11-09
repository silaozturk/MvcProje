﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writermanager = new WriterManager(new EfWriterDal());
        WriterValidator writervalidator = new WriterValidator();

        // GET: Writer
        public ActionResult Index()
        {
            var Writervalues = writermanager.GetList();
            return View(Writervalues);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            ValidationResult results = writervalidator.Validate(p);
            if (results.IsValid)
            {
                SHA512 sha512 = new SHA512CryptoServiceProvider();
                string password = p.WriterPassword;
                string result = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(password)));
                p.WriterPassword = result;

                writermanager.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {

            var wrietrvalue = writermanager.GetByID(id);
            return View(wrietrvalue);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult results = writervalidator.Validate(p);
            if (results.IsValid)
            {
                //SHA512 sha512 = new SHA512CryptoServiceProvider();
                //string password = p.WriterPassword;
                //string result = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(password)));
                //p.WriterPassword = result;
                writermanager.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}