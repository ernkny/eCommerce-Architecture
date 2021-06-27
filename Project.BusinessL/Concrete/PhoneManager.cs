
using Project.DataAccessL.Abstract;
using Project.EnitityL.DTOs;
using Project.EnitityL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessL.Concrete
{
    public class PhoneManager 
    {
        IPhoneDal _phoneDal;
        public PhoneManager(IPhoneDal phoneDal)
        {
            _phoneDal = phoneDal;
        }
        public void add(Phone phone)
        {
            _phoneDal.Add(phone);
        }

        public List<Phone> GetAll()
        {
            return _phoneDal.GetAll();
        }
        public List<PhoneImgesDTO> GetImages(int id)
        {
            var result = _phoneDal.GetPhoneImges().Where(p => p.Id == id).ToList();
            return result;
        }
     
        public List<FirstImageDTO> firstImageDTOs()
        {
            var result = _phoneDal.GetFirstImageDTOs();
            return result;
        }
        public void AddImageUrl(Phone phone)
        {
             _phoneDal.Update(phone);
        }
        public void DeleteItem(int id)
        {
            var result = _phoneDal.Get(p=>p.Id==id);
            _phoneDal.Delete(result);
           
        }
        public Phone Get(int id)
        {
            var result = _phoneDal.Get(p=>p.Id==id);
            return result;
        }
    }
}
