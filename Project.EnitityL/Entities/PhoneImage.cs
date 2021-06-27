using Project.EnitityL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.EnitityL.Entities
{
    public class PhoneImage:IEntity
    {
        public int Id { get; set; }
        public int PhoneId { get; set; }
        public string ImageURL { get; set; }
        public string  DeleteURL { get; set; }
        public Phone phone { get; set; }
    }
}
