using ITBedrijf.DataAccess;
using ITBedrijf.Models;
using ITBedrijf.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITBedrijf.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            ViewBag.Register = DARegister.GetRegisters();
            return View();
        }
        [HttpGet]
        public ActionResult NewRegister()
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult NewRegister(PMRegister register, DateTime? PurchaseTime, DateTime? ExpireTime)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");

            if (ModelState.IsValid)
            {
                if (register.PurchaseDate >= register.ExpireDate) return View(register);
                register.PurchaseDate = new DateTime(register.PurchaseDate.Year, register.PurchaseDate.Month, register.PurchaseDate.Day, PurchaseTime.Value.Hour, PurchaseTime.Value.Minute, 0);
                register.ExpireDate = new DateTime(register.ExpireDate.Year, register.ExpireDate.Month, register.ExpireDate.Day, ExpireTime.Value.Hour, ExpireTime.Value.Minute, 0);
                DARegister.InsertRegister(register);
                return RedirectToAction("Index");
            }
            return View(register);
        }

        [HttpGet]
        public ActionResult Log(int id)
        {
            ViewBag.Log = DALog.GetLogsById(id);
            return View();
        }

        [HttpGet]
        public ActionResult Logs()
        {
            ViewBag.Log = DALog.GetErrorlog();
            return View();
        }
    }
}