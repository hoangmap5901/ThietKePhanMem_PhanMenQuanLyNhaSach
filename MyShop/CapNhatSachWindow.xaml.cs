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
        bool _daChonHinhTrongChonHinhButton = false;
        FileInfo _selectedImage = null;

        public CapNhatSachWindow(Sach data)
        {
            InitializeComponent();

            CapNhatSach.SachId = data.SachId;
            CapNhatSach.Ten = data.Ten;
            CapNhatSach.TacGia = data.TacGia;
            CapNhatSach.Gia = data.Gia;
            CapNhatSach.SoLuong = data.SoLuong;
            CapNhatSach.ImagePath = data.ImagePath;
            CapNhatSach.TheLoaiId = data.TheLoaiId;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = CapNhatSach;

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

                var db = new MyShopDBContext();
                var sachCapNhat = db.Saches.FirstOrDefault(u => u.SachId == CapNhatSach.SachId);

                sachCapNhat.Ten = CapNhatSach.Ten;
                sachCapNhat.TacGia = CapNhatSach.TacGia;
                sachCapNhat.Gia = CapNhatSach.Gia;
                sachCapNhat.SoLuong = CapNhatSach.SoLuong;
                sachCapNhat.ImagePath = CapNhatSach.ImagePath;
                sachCapNhat.TheLoaiId = CapNhatSach.TheLoaiId;

                db.SaveChanges();

                MessageBox.Show($"Successfully updated Sach record in SQL Server with SachID = {sachCapNhat.SachId}.");
            }

            DialogResult = true;
        }
    }
}
