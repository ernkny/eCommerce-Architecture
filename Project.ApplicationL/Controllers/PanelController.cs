using Project.BusinessL.Concrete;
using Project.BusinessL.Upload;
using Project.DataAccessL.Concrete.EntityFramework;
using Project.DataAccessL.DataAccess.CreateTable;
using Project.EnitityL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.ApplicationL.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        public  ActionResult Index()
        {
            return View();
        }
        public ActionResult Phone()
        {
            PhoneManager phoneManager = new PhoneManager(new EfPhoneDal());

            var result = phoneManager.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddProductPhone()
        {

            return View();
        }

        
        [HttpPost]
        public ActionResult AddProductPhone(Phone phone, List<HttpPostedFileBase> files)
        {
            PhoneManager phoneManager = new PhoneManager(new EfPhoneDal());
            PhotoImagesManager photoManager = new PhotoImagesManager(new EfPhoneImagesDal());

            phoneManager.add(phone);
            int id = phoneManager.GetAll().Select(p => p.Id).Last();
            FilesUpload filesUpload = new FilesUpload();
            var result = filesUpload.SaveAllFiles(files, id);
            foreach (var item in result)
            {
                photoManager.Add(item);
            }
            var imges = phoneManager.GetImages(id).First();
            phone.ImageUrl = imges.ImageUrl;
            phoneManager.AddImageUrl(phone);
            return RedirectToAction("Phone");
        }

        public ActionResult GetPhotosPhone(int id)
        {
            PhoneManager phoneManager = new PhoneManager(new EfPhoneDal());
            var result = phoneManager.GetImages(id);
            return View(result);
        }
        public ActionResult DeletePhone(int id)
        {
            PhoneManager phoneManager = new PhoneManager(new EfPhoneDal());
            PhotoImagesManager ımagesManager = new PhotoImagesManager(new EfPhoneImagesDal());
            DeletePhotos deletephotos = new DeletePhotos(id);
            ımagesManager.DeletePhoto(id);
            phoneManager.DeleteItem(id);

            return RedirectToAction("Phone");
        }
        [HttpGet]
        public ActionResult UpdatePhone(int id)
        {
            ViewModel vm = new ViewModel();
            PhoneManager phoneManager = new PhoneManager(new EfPhoneDal());
            PhotoImagesManager photoManager = new PhotoImagesManager(new EfPhoneImagesDal());
            vm.Phone = phoneManager.GetAll().Where(p => p.Id == id);
            vm.PhoneImage = photoManager.GetAll().Where(p => p.PhoneId == id);


            return View(vm);
        }
        [HttpPost]
        public ActionResult Create()
        {
            EFCreateTable crt = new EFCreateTable();
            crt.CreateTable();

            return RedirectToAction("Index");
        }
    }
}