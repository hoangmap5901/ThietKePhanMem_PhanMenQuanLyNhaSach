using System;
using System.Collections.Generic;

#nullable disable

namespace MyShop
{
    public partial class ChiTietDonHang
    {
        public int ChiTietDonHangId { get; set; }
        public int? DonHangId { get; set; }
        public int? SachId { get; set; }
        public int? Gia { get; set; }
        public int? SoLuong { get; set; }
        public int? Tong { get; set; }

        public virtual DonHang DonHang { get; set; }
        public virtual Sach Sach { get; set; }
    }
}
