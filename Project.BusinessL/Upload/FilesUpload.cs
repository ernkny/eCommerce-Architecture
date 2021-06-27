using Project.EnitityL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Project.BusinessL.Upload
{
    public class FilesUpload
    {

        
        
        public List<PhoneImage> SaveAllFiles(List<HttpPostedFileBase> files,int id)
        {
            List<PhoneImage> phones = new List<PhoneImage>(); 
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var extensiton = Path.GetExtension(file.FileName);
                    if (extensiton == ".JPG" || extensiton == ".png" || extensiton == ".jpg" || extensiton == ".PNG")
                    {
                        PhoneImage phnimage = new PhoneImage();
                        string guid = Guid.NewGuid().ToString();

                        string pathway = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"), Path.GetFileName(guid + extensiton));
                        file.SaveAs(pathway);
                        string pathImage = "/Images/" + guid + extensiton;
                        phnimage.PhoneId = id;
                        phnimage.ImageURL = pathImage;
                        phnimage.DeleteURL = pathway;
                        phones.Add(phnimage);
                            
                    }
                    else
                    {
                      
                        return null;
                    }

                }
                else
                {
                    return null;
                }
                
            }
            
            return phones;
        }

    
    }
}
