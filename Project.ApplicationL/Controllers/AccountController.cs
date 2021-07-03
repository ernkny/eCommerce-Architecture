using Project.BusinessL.Concrete;
using Project.DataAccessL.Concrete.EntityFramework;
using Project.EnitityL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.ApplicationL.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SingUp()
        {
            return View();

        }
        [HttpPost]
        public ActionResult SingUp(User user,string pswrepeat)
        {
            UserManager usermanager = new UserManager(new EfUserDal());
            var result=usermanager.AddNewUser(user, pswrepeat);
            ViewBag.Message = result;
            return View();

        }
    }
}