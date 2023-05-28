using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_Pichers.Model
{
    internal class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public byte[] Data { get; set; }
    }
}
