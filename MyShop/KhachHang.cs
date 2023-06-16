using System;
using System.Collections.Generic;

#nullable disable

namespace MyShop
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public int KhachHangId { get; set; }
        public string Ten { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
