using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace MyShop
{
    public partial class KhachHang : INotifyPropertyChanged, ICloneable
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

        public event PropertyChangedEventHandler PropertyChanged;
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
