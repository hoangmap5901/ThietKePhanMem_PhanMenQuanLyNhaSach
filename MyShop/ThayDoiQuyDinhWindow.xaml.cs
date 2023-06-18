using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyShop
{
    /// <summary>
    /// Interaction logic for ThayDoiQuyDinhWindow.xaml
    /// </summary>
    public partial class ThayDoiQuyDinhWindow : Window
    {
        public ThamSo ThayDoiQuyDinh { get; set; } = new ThamSo();

        public ThayDoiQuyDinhWindow(ThamSo data)
        {
            InitializeComponent();

            ThayDoiQuyDinh.SoLuongSachNhapToiThieu = data.SoLuongSachNhapToiThieu;
            ThayDoiQuyDinh.SoLuongSachTonToiDaDeNhapSach = data.SoLuongSachTonToiDaDeNhapSach;
            ThayDoiQuyDinh.SoLuongSachTonToiThieuSauKhiBan = data.SoLuongSachTonToiThieuSauKhiBan;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = ThayDoiQuyDinh;
        }

        private void ThayDoiButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thay đổi quy định các tham số thành công.");

            DialogResult = true;
        }
    }
}
