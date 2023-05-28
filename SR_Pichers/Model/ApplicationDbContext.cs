using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_Pichers.Model
{
    internal class ApplicationDbContext : DbContext
    {
      public DbSet<Image> image { get; set; }
      public DbSet<ImageLink> imageLink { get; set; }

      public  ApplicationDbContext() : base("DefaultConnection")
        {

        }
    }
}
