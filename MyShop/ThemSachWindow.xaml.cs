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
    /// Interaction logic for ThemSachWindow.xaml
    /// </summary>
    public partial class ThemSachWindow : Window
    {
        public Sach NewSach { get; set; } = new Sach();
        public ThamSo ThayDoiQuyDinh { get; set; } = new ThamSo();
        FileInfo _selectedImage = null;
        public ThemSachWindow(ThamSo data)
        {
            InitializeComponent();

            ThayDoiQuyDinh.SoLuongSachNhapToiThieu = data.SoLuongSachNhapToiThieu;
            ThayDoiQuyDinh.SoLuongSachTonToiDaDeNhapSach = data.SoLuongSachTonToiDaDeNhapSach;
            ThayDoiQuyDinh.SoLuongSachTonToiThieuSauKhiBan = data.SoLuongSachTonToiThieuSauKhiBan;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = NewSach;

            var db = new MyShopDBContext();
            var theLoais = db.TheLoais.Where(u => u.TheLoaiId != 1).ToList();

            theLoaiSachComboBox.ItemsSource = theLoais;
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

        private void TheLoaiSachComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var theLoaiSach = theLoaiSachComboBox.SelectedItem as TheLoai;
            NewSach.TheLoaiId = theLoaiSach.TheLoaiId;

            var db = new MyShopDBContext();
            var theLoais = db.TheLoais.Where(u => u.TheLoaiId != 1).ToList();

            for (int i = 0; i < theLoais.Count; i++)
            {
                if (theLoais[i].TheLoaiId == NewSach.TheLoaiId)
                {
                    theLoaiSachComboBox.SelectedIndex = i;
                }
            }
        }

        private void ThemButton_Click(object sender, RoutedEventArgs e)
        {
            if (NewSach.SoLuong < 0)
            {
                MessageBox.Show("Số lượng sách nhập phải là số không âm.");
            }
            else if (NewSach.SoLuong < ThayDoiQuyDinh.SoLuongSachNhapToiThieu)
            {
                MessageBox.Show($"Số lượng sách nhập phải ít nhất là {ThayDoiQuyDinh.SoLuongSachNhapToiThieu}.");
            }
            else {
                var folder = AppDomain.CurrentDomain.BaseDirectory;
                string newPath = $"{folder}Images/Sach/{_selectedImage.Name}";

                if (!File.Exists(newPath))
                {
                    File.Copy(_selectedImage.FullName, newPath);
                }
                NewSach.ImagePath = $"Images/Sach/{_selectedImage.Name}";

                var db = new MyShopDBContext();
                var sachThem = new Sach()
                {
                    Ten = NewSach.Ten,
                    TacGia = NewSach.TacGia,
                    Gia = NewSach.Gia,
                    SoLuong = NewSach.SoLuong,
                    ImagePath = NewSach.ImagePath,
                    TheLoaiId = NewSach.TheLoaiId
                };

                db.Saches.Add(sachThem);
                db.SaveChanges();

                MessageBox.Show($"Successfully added new Sach record into SQL Server wit SachID = {sachThem.SachId}.");

                DialogResult = true;
            }
        }
    }
}
