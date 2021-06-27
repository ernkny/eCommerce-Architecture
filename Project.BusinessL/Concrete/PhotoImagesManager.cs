using Project.DataAccessL.Abstract;
using Project.EnitityL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessL.Concrete
{
    public  class PhotoImagesManager
    {
        IPhoneImagesDal _phoneImagesDal;
        public PhotoImagesManager(IPhoneImagesDal phoneImagesDal)
        {
            _phoneImagesDal = phoneImagesDal;
        }
        public void Add(PhoneImage phoneImage)
        {
            _phoneImagesDal.Add(phoneImage);
        }
        public List<PhoneImage> GetAll()
        {
            var result=_phoneImagesDal.GetAll().ToList();
            return result;
        }
        public void DeletePhoto(int id)
        {
            var result = _phoneImagesDal.GetAll().Where(c => c.PhoneId == id);
            foreach (var item in result)
            {
                _phoneImagesDal.Delete(item);
            }
        }
        
    }
}
