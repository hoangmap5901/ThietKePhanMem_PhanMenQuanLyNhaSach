using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for CapNhatSachWindow.xaml
    /// </summary>
    public partial class CapNhatSachWindow : Window
    {
        public Sach CapNhatSach { get; set; } = new Sach();
        public ThamSo ThayDoiQuyDinh { get; set; } = new ThamSo();
        public int SoLuongSachNhap { get => _soLuongSachNhap; set => _soLuongSachNhap = value; }
        bool _daChonHinhTrongChonHinhButton = false;
        FileInfo _selectedImage = null;
        int _soLuongSachNhap = 0;
        public static readonly DependencyProperty SoLuongTonProperty =
        DependencyProperty.Register("SoLuongTon", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty SoLuongMoiProperty =
       DependencyProperty.Register("SoLuongMoi", typeof(int), typeof(Window), new PropertyMetadata(null));

        public int SoLuongTon
        {
            get { return (int)GetValue(SoLuongTonProperty); }
            set { SetValue(SoLuongTonProperty, value); }
        }
        public int SoLuongMoi
        {
            get { return (int)GetValue(SoLuongMoiProperty); }
            set { SetValue(SoLuongMoiProperty, value); }
        }
        public CapNhatSachWindow(Sach sachData, ThamSo thamSodata)
        {
            InitializeComponent();

            CapNhatSach.SachId = sachData.SachId;
            CapNhatSach.Ten = sachData.Ten;
            CapNhatSach.TacGia = sachData.TacGia;
            CapNhatSach.Gia = sachData.Gia;
            CapNhatSach.SoLuong = sachData.SoLuong;
            CapNhatSach.ImagePath = sachData.ImagePath;
            CapNhatSach.TheLoaiId = sachData.TheLoaiId;

            ThayDoiQuyDinh.SoLuongSachNhapToiThieu = thamSodata.SoLuongSachNhapToiThieu;
            ThayDoiQuyDinh.SoLuongSachTonToiDaDeNhapSach = thamSodata.SoLuongSachTonToiDaDeNhapSach;
            ThayDoiQuyDinh.SoLuongSachTonToiThieuSauKhiBan = thamSodata.SoLuongSachTonToiThieuSauKhiBan;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = CapNhatSach;
            soLuongTextBox.DataContext = this;

            var db = new MyShopDBContext();
            var theLoais = db.TheLoais.Where(u => u.TheLoaiId != 1).ToList();

            theLoaiSachComboBox.ItemsSource = theLoais;

            for (int i = 0; i < theLoais.Count; i++)
            {
                if (theLoais[i].TheLoaiId == CapNhatSach.TheLoaiId)
                {
                    theLoaiSachComboBox.SelectedIndex = i;
                }
            }

            SoLuongTon = (int)CapNhatSach.SoLuong;
            SoLuongMoi = (int)CapNhatSach.SoLuong;
        }

        private void ChonHinhButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();

            if (screen.ShowDialog() == true)
            {
                _selectedImage = new FileInfo(screen.FileName);

                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(screen.FileName, UriKind.Absolute);
                bitmap.EndInit();
                imagePath.Source = bitmap;

                _daChonHinhTrongChonHinhButton = true;
            }
        }

        private void TheLoaiSachComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var theLoaiSach = theLoaiSachComboBox.SelectedItem as TheLoai;
            CapNhatSach.TheLoaiId = theLoaiSach.TheLoaiId;

            var db = new MyShopDBContext();
            var theLoais = db.TheLoais.Where(u => u.TheLoaiId != 1).ToList();

            for (int i = 0; i < theLoais.Count; i++)
            {
                if (theLoais[i].TheLoaiId == CapNhatSach.TheLoaiId)
                {
                    theLoaiSachComboBox.SelectedIndex = i;
                }
            }
        }


        private void NhapSachButton_Click(object sender, RoutedEventArgs e)
        {
            if (SoLuongSachNhap < 0)
            {
                MessageBox.Show("Số lượng sách nhập phải là số không âm.");
            }
            else
            {
                if (SoLuongSachNhap >= ThayDoiQuyDinh.SoLuongSachNhapToiThieu && CapNhatSach.SoLuong <= ThayDoiQuyDinh.SoLuongSachTonToiDaDeNhapSach)
                {
                    SoLuongMoi = SoLuongTon + SoLuongSachNhap;
                }
                else
                {
                    if (SoLuongSachNhap < ThayDoiQuyDinh.SoLuongSachNhapToiThieu)
                    {
                        MessageBox.Show($"Số lượng sách nhập phải ít nhất là {ThayDoiQuyDinh.SoLuongSachNhapToiThieu}.");
                    }

                    if (CapNhatSach.SoLuong > ThayDoiQuyDinh.SoLuongSachTonToiDaDeNhapSach)
                    {
                        MessageBox.Show($"Đầu sách nhập phải có lượng tồn ít hơn hoặc bằng {ThayDoiQuyDinh.SoLuongSachTonToiDaDeNhapSach}.");
                    }
                }
            }
        }

        private void CapNhatButton_Click(object sender, RoutedEventArgs e)
        {
            if (_daChonHinhTrongChonHinhButton == true)
            {
                var folder = AppDomain.CurrentDomain.BaseDirectory;
                string newPath = $"{folder}Images/Sach/{_selectedImage.Name}";

                if (!File.Exists(newPath))
                {
                    File.Copy(_selectedImage.FullName, newPath);
                }

                CapNhatSach.ImagePath = $"Images/Sach/{_selectedImage.Name}";
            }

                var db = new MyShopDBContext();
                var sachCapNhat = db.Saches.FirstOrDefault(u => u.SachId == CapNhatSach.SachId);

                sachCapNhat.Ten = CapNhatSach.Ten;
                sachCapNhat.TacGia = CapNhatSach.TacGia;
                sachCapNhat.Gia = CapNhatSach.Gia;
                sachCapNhat.SoLuong = SoLuongMoi;
                sachCapNhat.ImagePath = CapNhatSach.ImagePath;
                sachCapNhat.TheLoaiId = CapNhatSach.TheLoaiId;

                db.SaveChanges();

                MessageBox.Show($"Successfully updated Sach record in SQL Server with SachID = {sachCapNhat.SachId}.");


            DialogResult = true;
        }
    }
}
