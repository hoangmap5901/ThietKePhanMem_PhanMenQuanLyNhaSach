using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for TaoDonHangWindow.xaml
    /// </summary>
    public partial class TaoDonHangWindow : Window
    {
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        int _soLuong = 0;
        public DonHang NewDonHang { get; set; } = new DonHang();
        List<ChiTietDonHang> _chiTietDonHangs = new List<ChiTietDonHang>();

        public static readonly DependencyProperty TongProperty =
       DependencyProperty.Register("Tong", typeof(int), typeof(Window), new PropertyMetadata(null));

        public int Tong
        {
            get { return (int)GetValue(TongProperty); }
            set { SetValue(TongProperty, value); }
        }

        public TaoDonHangWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = NewDonHang;
            soLuongTextBox.DataContext = this;

            var db = new MyShopDBContext();

            var khachHangs = db.KhachHangs.ToList();
            khachHangComboBox.ItemsSource = khachHangs;

            var trangThaiDonHangs = db.TrangThaiDonHangs.ToList();
            trangThaiDonHangComboBox.ItemsSource = trangThaiDonHangs;

            var saches = db.Saches.ToList();
            sachDonHangComboBox.ItemsSource = saches;
        }

        private void khachHangComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var khachHangChon = khachHangComboBox.SelectedItem as KhachHang;
            NewDonHang.KhachHangId = khachHangChon.KhachHangId;
        }

        private void trangThaiDonHangComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var trangThaiDonHangChon = trangThaiDonHangComboBox.SelectedItem as TrangThaiDonHang;
            NewDonHang.TrangThaiDonHangId = trangThaiDonHangChon.TrangThaiDonHangId;
        }

        private void ThemSachButton_Click(object sender, RoutedEventArgs e)
        {
            var sachChon = sachDonHangComboBox.SelectedItem as Sach;

            if (SoLuong > sachChon.SoLuong)
            {
                MessageBox.Show($"Sách {sachChon.Ten} không đủ số lượng để thêm vào đơn hàng.");
            }
            else
            {
                _chiTietDonHangs.Add(new ChiTietDonHang()
                {
                    SachId = sachChon.SachId,
                    Gia = sachChon.Gia,
                    SoLuong = SoLuong
                });

                sachDataGrid.ItemsSource = _chiTietDonHangs;

                Tong = 0;

                for (int i = 0; i < _chiTietDonHangs.Count; i++)
                {
                    Tong += (int)_chiTietDonHangs[i].Gia * (int)_chiTietDonHangs[i].SoLuong;
                }
            }
        }

        private void TaoButton_Click(object sender, RoutedEventArgs e)
        {
            if (ngayTaoDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Chưa chọn ngày tạo.");
            }
            else
            {
                var db = new MyShopDBContext();
                var donHangThem = new DonHang()
                {
                    KhachHangId = NewDonHang.KhachHangId,
                    TrangThaiDonHangId = NewDonHang.TrangThaiDonHangId,
                    Tong = Tong,
                    NgayTao = ngayTaoDatePicker.SelectedDate.Value.Date
                };

                db.DonHangs.Add(donHangThem);
                db.SaveChanges();

                MessageBox.Show($"Successfully added new DonHang record into SQL Server with DonHangID = {donHangThem.DonHangId}.");

                string messageThemChiTietDonHang = "";
                for (int i = 0; i < _chiTietDonHangs.Count; i++)
                {
                    var chiTietDonHangThem = new ChiTietDonHang()
                    {
                        DonHangId = donHangThem.DonHangId,
                        SachId = _chiTietDonHangs[i].SachId,
                        Gia = _chiTietDonHangs[i].Gia,
                        SoLuong = _chiTietDonHangs[i].SoLuong,
                        Tong = _chiTietDonHangs[i].Gia * _chiTietDonHangs[i].SoLuong
                    };

                    db.ChiTietDonHangs.Add(chiTietDonHangThem);
                    db.SaveChanges();

                   messageThemChiTietDonHang += $"Successfully added new ChiTietDonHang record into SQL Server with chiTietDonHangID = {chiTietDonHangThem.DonHangId}.\n";
                }

                MessageBox.Show(messageThemChiTietDonHang);

                for (int i = 0; i < _chiTietDonHangs.Count; i++)
                {
                    var sachXoa = db.Saches.FirstOrDefault(u => u.SachId == _chiTietDonHangs[i].SachId);
                    sachXoa.SoLuong = sachXoa.SoLuong - _chiTietDonHangs[i].SoLuong;
                    db.SaveChanges();
                }

                DialogResult = true;
            }
        }
    }
}
