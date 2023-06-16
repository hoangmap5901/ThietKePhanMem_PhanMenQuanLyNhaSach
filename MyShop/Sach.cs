using System;
using System.Collections.Generic;

#nullable disable

namespace MyShop
{
    public partial class Sach
    {
        public Sach()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        public int SachId { get; set; }
        public int? TheLoaiId { get; set; }
        public string Ten { get; set; }
        public int? SoLuong { get; set; }
        public int? Gia { get; set; }
        public string TacGia { get; set; }
        public string ImagePath { get; set; }

        public virtual TheLoai TheLoai { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
