using Project.EnitityL.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.EnitityL.Entities
{
    public class User:IEntity
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPasswordHash { get; set; }
        
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }

        public  string PhoneNumber { get; set; }

    }
}
