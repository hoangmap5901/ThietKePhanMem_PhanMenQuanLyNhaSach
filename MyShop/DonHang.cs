using System;
using System.Collections.Generic;

#nullable disable

namespace MyShop
{
    public partial class DonHang
    {
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        public int DonHangId { get; set; }
        public int? KhachHangId { get; set; }
        public int? TrangThaiDonHangId { get; set; }
        public int? Tong { get; set; }
        public DateTime? NgayTao { get; set; }

        public virtual KhachHang KhachHang { get; set; }
        public virtual TrangThaiDonHang TrangThaiDonHang { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
