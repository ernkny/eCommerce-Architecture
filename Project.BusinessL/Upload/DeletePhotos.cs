using Project.BusinessL.Concrete;
using Project.DataAccessL.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessL.Upload
{
    public class DeletePhotos
    {
        private int _id;
        public DeletePhotos()
        {

        }
        public DeletePhotos(int id)
        {
            _id = id;
            DeleteAllUrl();

        }

        public void DeleteAllUrl()
        {
            PhotoImagesManager photoImages = new PhotoImagesManager(new EfPhoneImagesDal());

            var result = photoImages.GetAll().Where(c => c.PhoneId == _id);
            foreach (var item in result)
            {
                string deleteurl = item.DeleteURL;
                System.IO.File.Delete(deleteurl);

            }
        }


    }
}
