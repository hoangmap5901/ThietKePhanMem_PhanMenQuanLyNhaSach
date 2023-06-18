using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop
{
    public class ThamSo : INotifyPropertyChanged, ICloneable
    {

        public int SoLuongSachNhapToiThieu { get; set; }
        public int SoLuongSachTonToiDaDeNhapSach { get; set; }

        public int SoLuongSachTonToiThieuSauKhiBan { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
