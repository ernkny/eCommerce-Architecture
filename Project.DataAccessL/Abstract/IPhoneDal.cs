using Project.DataAccessL.DataAccess;
using Project.EnitityL.DTOs;
using Project.EnitityL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessL.Abstract
{
    public interface IPhoneDal:IEntityRepository<Phone>
    {
        List<PhoneImgesDTO> GetPhoneImges();
        List<FirstImageDTO> GetFirstImageDTOs();
    }
}
