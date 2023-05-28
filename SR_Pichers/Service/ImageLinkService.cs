using SR_Pichers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_Pichers.Service
{
    internal class ImageLinkService
    {
        public List<ImageLink> liastAll()
        {
            using(ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.imageLink.ToList();
            }
        }
        public ImageLink Add(ImageLink image)
        {
            using(var db = new ApplicationDbContext())
            {
                db.imageLink.Add(image);
                db.SaveChanges();
                return image;
            }
        }
    }
}
