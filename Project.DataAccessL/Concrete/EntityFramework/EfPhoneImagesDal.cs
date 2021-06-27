using Project.DataAccessL.Abstract;
using Project.DataAccessL.DataAccess;
using Project.EnitityL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessL.Concrete.EntityFramework
{
    public class EfPhoneImagesDal : EfEntityRepositoryBase<PhoneImage, SellsPhoneContext>, IPhoneImagesDal
    {
        
    }
}
