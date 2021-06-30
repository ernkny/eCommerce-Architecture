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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            PhoneManager phoneManager = new PhoneManager(new EfPhoneDal());

            var result = phoneManager.GetAll();
            return View(result);
        }
        public ActionResult PhoneDetail(int id)
        {
            PhotoImagesManager photomanager = new PhotoImagesManager(new EfPhoneImagesDal());

            PhoneManager phonemanager = new PhoneManager(new EfPhoneDal());
            ViewModel vm = new ViewModel();

             vm.Phone= phonemanager.GetAll().Where(p=>p.Id== id);
            vm.PhoneImage = photomanager.GetAll().Where(p => p.PhoneId == id);


            return View(vm);
        }
    }
}