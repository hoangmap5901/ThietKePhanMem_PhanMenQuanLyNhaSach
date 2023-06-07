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
    /// Interaction logic for ThemKhachHangWindow.xaml
    /// </summary>
    public partial class ThemKhachHangWindow : Window
    {

        public KhachHang NewKhachHang { get; set; } = new KhachHang();
        FileInfo _selectedImage = null;
        public ThemKhachHangWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = NewKhachHang;
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
            }
        }

        private void ThemButton_Click(object sender, RoutedEventArgs e)
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            string newPath = $"{folder}Images/KhachHang/{_selectedImage.Name}";

            if (!File.Exists(newPath))
            {
                File.Copy(_selectedImage.FullName, newPath);
            }
            NewKhachHang.ImagePath = $"Images/KhachHang/{_selectedImage.Name}";

            var db = new MyShopDBContext();
            var khachHangThem = new KhachHang()
            {
                Ten = NewKhachHang.Ten,
                SoDienThoai = NewKhachHang.SoDienThoai,
                DiaChi = NewKhachHang.DiaChi,
                Email = NewKhachHang.Email,
                ImagePath = NewKhachHang.ImagePath
            };

            db.KhachHangs.Add(khachHangThem);
            db.SaveChanges();

            MessageBox.Show($"Successfully added new KhachHang record into SQL Server with KhachHangID = {khachHangThem.KhachHangId}.");

            DialogResult = true;
        }
    }
}
