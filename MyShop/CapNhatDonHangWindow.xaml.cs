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
    /// Interaction logic for CapNhatDonHangWindow.xaml
    /// </summary>
    public partial class CapNhatDonHangWindow : Window
    {
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        int _soLuong = 0;
        int _soLuongChiTietDonHangPrev = 0;
        List<int> _soLuongSachChiTietDonHangPrev = new List<int>();
        public DonHang CapNhatDonHang { get; set; } = new DonHang();
        List<Sach> _sachesThem = new List<Sach>();
        List<ChiTietDonHang> _chiTietDonHangs = new List<ChiTietDonHang>();

        public static readonly DependencyProperty TongProperty =
       DependencyProperty.Register("Tong3", typeof(int), typeof(Window), new PropertyMetadata(null));

        public int Tong3
        {
            get { return (int)GetValue(TongProperty); }
            set { SetValue(TongProperty, value); }
        }

        public CapNhatDonHangWindow(DonHang data)
        {
            InitializeComponent();

            CapNhatDonHang.DonHangId = data.DonHangId;
            CapNhatDonHang.KhachHangId = data.KhachHangId;
            CapNhatDonHang.TrangThaiDonHangId = data.TrangThaiDonHangId;
            CapNhatDonHang.Tong = data.Tong;
            CapNhatDonHang.NgayTao = data.NgayTao;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = CapNhatDonHang;
            soLuongTextBox.DataContext = this;

            var db = new MyShopDBContext();

            var khachHangs = db.KhachHangs.ToList();
            khachHangComboBox.ItemsSource = khachHangs;
            for (int i = 0; i < khachHangs.Count; i++)
            {
                if (khachHangs[i].KhachHangId == CapNhatDonHang.KhachHangId)
                {
                    khachHangComboBox.SelectedIndex = i;
                }
            }

            var trangThaiDonHangs = db.TrangThaiDonHangs.ToList();
            trangThaiDonHangComboBox.ItemsSource = trangThaiDonHangs;
            for (int i = 0; i < trangThaiDonHangs.Count; i++)
            {
                if (trangThaiDonHangs[i].TrangThaiDonHangId == CapNhatDonHang.TrangThaiDonHangId)
                {
                    trangThaiDonHangComboBox.SelectedIndex = i;
                }
            }

            ngayTaoDatePicker.SelectedDate = CapNhatDonHang.NgayTao;

            var saches = db.Saches.ToList();
            sachDonHangComboBox.ItemsSource = saches;

            var chiTietDonHang = db.ChiTietDonHangs.Where(u => u.DonHangId == CapNhatDonHang.DonHangId).ToList();
            Tong3 = 0;
            for (int i = 0; i < chiTietDonHang.Count; i++)
            {
                Tong3 += (int)chiTietDonHang[i].Tong;
            }

            var sachesDonHang = new List<Sach>();
            for (int i = 0; i < chiTietDonHang.Count; i++)
            {
                var sachDonHang = db.Saches.FirstOrDefault(u => u.SachId == chiTietDonHang[i].SachId);
                sachesDonHang.Add(sachDonHang);
                sachesDonHang[i].SoLuong = chiTietDonHang[i].SoLuong;
            }
            sachDataGrid.ItemsSource = sachesDonHang.ToList();

            for (int i = 0; i < chiTietDonHang.Count; i++)
            {
                _chiTietDonHangs.Add(new ChiTietDonHang()
                {
                    ChiTietDonHangId = chiTietDonHang[i].ChiTietDonHangId,
                    DonHangId = chiTietDonHang[i].DonHangId,
                    SachId = chiTietDonHang[i].SachId,
                    Gia = chiTietDonHang[i].Gia,
                    SoLuong = chiTietDonHang[i].SoLuong,
                    Tong = chiTietDonHang[i].Tong
                });
                _soLuongSachChiTietDonHangPrev.Add((int)chiTietDonHang[i].SoLuong);
            }

            _soLuongChiTietDonHangPrev = chiTietDonHang.Count;

            for (int i = 0; i < sachesDonHang.Count; i++)
            {
                _sachesThem.Add(new Sach()
                {
                    SachId = sachesDonHang[i].SachId,
                    TheLoaiId = sachesDonHang[i].TheLoaiId,
                    Ten = sachesDonHang[i].Ten,
                    Gia = sachesDonHang[i].Gia,
                    SoLuong = sachesDonHang[i].SoLuong,
                    TacGia = sachesDonHang[i].TacGia,
                    ImagePath = sachesDonHang[i].ImagePath
                });
            }
        }

        private void khachHangComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var khachHangChon = khachHangComboBox.SelectedItem as KhachHang;
            CapNhatDonHang.KhachHangId = khachHangChon.KhachHangId;
        }

        private void trangThaiDonHangComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var trangThaiDonHangChon = trangThaiDonHangComboBox.SelectedItem as TrangThaiDonHang;
            CapNhatDonHang.TrangThaiDonHangId = trangThaiDonHangChon.TrangThaiDonHangId;
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
                    SoLuong = SoLuong,
                    Tong = sachChon.Gia * SoLuong
                });

                _sachesThem.Add(new Sach()
                {
                    SachId = sachChon.SachId,
                    TheLoaiId = sachChon.TheLoaiId,
                    Ten = sachChon.Ten,
                    Gia = sachChon.Gia,
                    SoLuong = SoLuong,
                    TacGia = sachChon.TacGia,
                    ImagePath = sachChon.ImagePath
                });

                sachDataGrid.ItemsSource = _sachesThem.ToList();

                Tong3 = 0;

                for (int i = 0; i < _chiTietDonHangs.Count; i++)
                {
                    Tong3 += (int)_chiTietDonHangs[i].Tong;
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
                var donHangCapNhat = db.DonHangs.FirstOrDefault(u => u.DonHangId == CapNhatDonHang.DonHangId);

                donHangCapNhat.KhachHangId = CapNhatDonHang.KhachHangId;
                donHangCapNhat.TrangThaiDonHangId = CapNhatDonHang.TrangThaiDonHangId;
                donHangCapNhat.Tong = Tong3;
                donHangCapNhat.NgayTao = ngayTaoDatePicker.SelectedDate.Value.Date;

                db.SaveChanges();
                MessageBox.Show($"Successfully updated DonHang record in SQL Server with DonHangID = {donHangCapNhat.DonHangId}.");

                for (int i = _soLuongChiTietDonHangPrev; i < _chiTietDonHangs.Count; i++)
                {
                    var chiTietDonHangThem = new ChiTietDonHang()
                    {
                        DonHangId = donHangCapNhat.DonHangId,
                        SachId = _chiTietDonHangs[i].SachId,
                        Gia = _chiTietDonHangs[i].Gia,
                        SoLuong = _chiTietDonHangs[i].SoLuong,
                        Tong = _chiTietDonHangs[i].Tong
                    };

                    db.ChiTietDonHangs.Add(chiTietDonHangThem);
                    db.SaveChanges();
                }

                MessageBox.Show($"Successfully added {_chiTietDonHangs.Count - _soLuongChiTietDonHangPrev} new ChiTietDonHang records into SQL Server.");

                string messageGiamSoLuongSachBan = "";
                for (int i = _soLuongChiTietDonHangPrev; i < _chiTietDonHangs.Count; i++)
                {
                    var sachBan = db.Saches.FirstOrDefault(u => u.SachId == _chiTietDonHangs[i].SachId);
                    sachBan.SoLuong = sachBan.SoLuong - _chiTietDonHangs[i].SoLuong;
                    db.SaveChanges();

                    messageGiamSoLuongSachBan += $"Successfully reduced {_chiTietDonHangs[i].SoLuong} so luong of Sach record in SQL Server with sachID = {_chiTietDonHangs[i].SachId}.\n";
                }
                MessageBox.Show(messageGiamSoLuongSachBan);

                DialogResult = true;
            }
        }
    }
}
