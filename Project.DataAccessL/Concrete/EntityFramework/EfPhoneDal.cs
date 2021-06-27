using Project.DataAccessL.Abstract;
using Project.DataAccessL.DataAccess;
using Project.EnitityL.DTOs;
using Project.EnitityL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessL.Concrete.EntityFramework
{
    public class EfPhoneDal:EfEntityRepositoryBase<Phone,SellsPhoneContext>,IPhoneDal
    {
        public List<PhoneImgesDTO> GetPhoneImges()
        {
            using (SellsPhoneContext context=new SellsPhoneContext())
            {
                var result = from p in context.Phones
                             join c in context.PhoneImages
                             on p.Id equals c.PhoneId
                             select new PhoneImgesDTO
                             {
                                 Id = p.Id,
                                 PhoneModal = p.PhoneModal,
                                 PhoneParticular = p.PhoneParticular,
                                 Price = p.Price,
                                 Total = p.Total,
                                 ImageUrl = c.ImageURL
                             };
                return result.ToList();
            }
        }
        public List<FirstImageDTO> GetFirstImageDTOs()
        {
            using (SellsPhoneContext context=new SellsPhoneContext())
            {
                var result = from p in context.Phones
                             join c in context.PhoneImages
                             on p.Id equals c.PhoneId
                             select new FirstImageDTO
                             {
                                 ImageUrl = c.ImageURL
                             };
                return result.ToList();
            }
        }
        
    }
}
