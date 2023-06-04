using System;
using System.Collections.Generic;

#nullable disable

namespace MyShop
{
    public partial class TrangThaiDonHang
    {
        public TrangThaiDonHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public int TrangThaiDonHangId { get; set; }
        public string TrangThai { get; set; }
        public string MoTa { get; set; }
        public string ChuHienThi { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
