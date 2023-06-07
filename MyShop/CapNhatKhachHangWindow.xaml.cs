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
    /// Interaction logic for CapNhatKhachHangWindow.xaml
    /// </summary>
    public partial class CapNhatKhachHangWindow : Window
    {
        public KhachHang CapNhatKhachHang { get; set; } = new KhachHang();
        bool _daChonHinhTrongChonHinhButton = false;
        FileInfo _selectedImage = null;

        public CapNhatKhachHangWindow(KhachHang data)
        {
            InitializeComponent();

            CapNhatKhachHang.KhachHangId = data.KhachHangId;
            CapNhatKhachHang.Ten = data.Ten;
            CapNhatKhachHang.SoDienThoai = data.SoDienThoai;
            CapNhatKhachHang.DiaChi = data.DiaChi;
            CapNhatKhachHang.Email = data.Email;
            CapNhatKhachHang.ImagePath = data.ImagePath;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = CapNhatKhachHang;
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

        private void CapNhatButton_Click(object sender, RoutedEventArgs e)
        {

            if (_daChonHinhTrongChonHinhButton == true)
            {
                var folder = AppDomain.CurrentDomain.BaseDirectory;
                string newPath = $"{folder}Images/KhachHang/{_selectedImage.Name}";

                if (!File.Exists(newPath))
                {
                    File.Copy(_selectedImage.FullName, newPath);
                }

                CapNhatKhachHang.ImagePath = $"Images/KhachHang/{_selectedImage.Name}";

                var db = new MyShopDBContext();
                var khachHangCapNhat = db.KhachHangs.FirstOrDefault(u => u.KhachHangId == CapNhatKhachHang.KhachHangId);

                khachHangCapNhat.Ten = CapNhatKhachHang.Ten;
                khachHangCapNhat.SoDienThoai = CapNhatKhachHang.SoDienThoai;
                khachHangCapNhat.DiaChi = CapNhatKhachHang.DiaChi;
                khachHangCapNhat.Email = CapNhatKhachHang.Email;
                khachHangCapNhat.ImagePath = CapNhatKhachHang.ImagePath;
                db.SaveChanges();

                MessageBox.Show($"Successfully updated KhachHang record in SQL Server with TheLoaiID = {khachHangCapNhat.KhachHangId}.");
            }
          
            DialogResult = true;
        }
    }
}
