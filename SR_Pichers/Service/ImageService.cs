using SR_Pichers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_Pichers.Service
{
    internal class ImageService
    {
        public List<Image> ListAll()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.image.ToList();
            }
        }
        public Image Add(Image image)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                db.image.Add(image);
                db.SaveChanges();
                return image;
            }
        }
    }
}
