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
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        bool _daChonHinhTrongChonHinhButton = false;
        FileInfo _selectedImage = null;
        int _soLuong;
        public static readonly DependencyProperty SoLuongCuProperty =
        DependencyProperty.Register("SoLuongCu", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty SoLuongMoiProperty =
       DependencyProperty.Register("SoLuongMoi", typeof(int), typeof(Window), new PropertyMetadata(null));

        public int SoLuongCu
        {
            get { return (int)GetValue(SoLuongCuProperty); }
            set { SetValue(SoLuongCuProperty, value); }
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

            MessageBox.Show(ThayDoiQuyDinh.SoLuongSachNhapToiThieu.ToString());
            MessageBox.Show(ThayDoiQuyDinh.SoLuongSachTonToiDaDeNhapSach.ToString());
            MessageBox.Show(ThayDoiQuyDinh.SoLuongSachTonToiThieuSauKhiBan.ToString());

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

            SoLuongCu = (int)CapNhatSach.SoLuong;
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
