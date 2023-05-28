using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_Pichers.Model
{
    //ссылка накартинку
    internal class ImageLink
    {
        public int Id { get; set; }
        public string FileName { get; set; }

        public override string ToString()
        {
            return FileName;
        }
    }
}
