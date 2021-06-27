using Project.EnitityL.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Project.EnitityL.Entities
{
    public class Phone:IEntity
    {
        
        public int Id { get; set; }
        public string PhoneModal { get; set; }
        [AllowHtml]
        public string PhoneParticular { get; set; }
        public int  Total { get; set; }
        public int Price { get; set; }
        public List<PhoneImage> phoneImages { get; set; }
        public string ImageUrl { get; set; }
        public string Keywords { get; set; }
        public Nullable< DateTime> Tarih { get; set; }
    }
}
