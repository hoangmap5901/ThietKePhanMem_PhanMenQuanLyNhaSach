using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace MyShop
{
    public partial class TheLoai : INotifyPropertyChanged, ICloneable
    {
        public TheLoai()
        {
            Saches = new HashSet<Sach>();
        }

        public int TheLoaiId { get; set; }
        public string Ten { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
