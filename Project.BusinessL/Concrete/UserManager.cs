using Project.DataAccessL.Abstract;
using Project.EnitityL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessL.Concrete
{
    public class UserManager
    {
        IUserDal _userdal;
        public UserManager(IUserDal userDal)
        {
            _userdal = userDal;
        }

        public string AddNewUser(User user,string pswrepeat)
        {
            if (false!=string.IsNullOrEmpty(user.UserName)&& string.IsNullOrEmpty(user.UserPasswordHash)&& string.IsNullOrEmpty(user.PhoneNumber.ToString())
                && string.IsNullOrEmpty(user.Email)&& string.IsNullOrEmpty(user.FullName))
            {
                return "Lütfen bütün alanları doldurunuz";
            }
            else if (pswrepeat!=user.UserPasswordHash)
            {
                return "Şifreler uyuşmamaktadır";
            }
            else if(_userdal.GetAll().Find(u=>u.Email==user.Email)!=null )
            {
                return "Email Mevcut";
            }
            else if ( _userdal.GetAll().Find(u => u.UserName == user.UserName) != null)
            {
                return "Kullanıcı Adı Mevcut";
            }
            else if(user.UserPasswordHash.Length<6 && user.UserPasswordHash.Length>20==false)
            {
                return "Lütfen Şifrenizi 6 Karakter ile 20 Karakter Arasında Giriniz";
            }
            else
            {
               
                    MD5 md5 = new MD5CryptoServiceProvider();
                    md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(user.UserPasswordHash));
                    byte[] sonuc = md5.Hash;
                    StringBuilder strBuilder = new StringBuilder();
                    for (int i = 0; i < sonuc.Length; i++)
                    {
                        strBuilder.Append(sonuc[i].ToString("x4"));
                    }
                    user.UserPasswordHash = strBuilder.ToString();
                _userdal.Add(user);
                return "Kullanıcı oluşturuldu";
                
            }
            
        }

    }
}
