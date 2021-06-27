using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.EnitityL.Entities
{
    public class ViewModel
    {
        public IEnumerable<Phone> Phone { get; set; }
        public IEnumerable<PhoneImage> PhoneImage { get; set; }

    }
}
