using System;
using System.Collections.Generic;

#nullable disable

namespace MyShop
{
    public partial class TheLoai
    {
        public TheLoai()
        {
            Saches = new HashSet<Sach>();
        }

        public int TheLoaiId { get; set; }
        public string Ten { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
