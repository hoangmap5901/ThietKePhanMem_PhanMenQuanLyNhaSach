using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.IO;

namespace MyShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ThamSo ThayDoiQuyDinh { get; set; } = new ThamSo();

        public static readonly DependencyProperty UserNameLoginWelcomeProperty =
  DependencyProperty.Register("UserNameLoginWelcome", typeof(string), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty TongSachProperty =
        DependencyProperty.Register("TongSach", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty SoLuongDonHangProperty =
       DependencyProperty.Register("SoLuongDonHangMoi", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty ImagePath1Property =
         DependencyProperty.Register("ImagePath1", typeof(string), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty ImagePath2Property =
         DependencyProperty.Register("ImagePath2", typeof(string), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty ImagePath3Property =
         DependencyProperty.Register("ImagePath3", typeof(string), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty ImagePath4Property =
         DependencyProperty.Register("ImagePath4", typeof(string), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty ImagePath5Property =
         DependencyProperty.Register("ImagePath5", typeof(string), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty SoLuong1Property =
     DependencyProperty.Register("SoLuong1", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty SoLuong2Property =
    DependencyProperty.Register("SoLuong2", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty SoLuong3Property =
    DependencyProperty.Register("SoLuong3", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty SoLuong4Property =
    DependencyProperty.Register("SoLuong4", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty SoLuong5Property =
    DependencyProperty.Register("SoLuong5", typeof(int), typeof(Window), new PropertyMetadata(null));
        public string UserNameLoginWelcome
        {
            get { return (string)GetValue(UserNameLoginWelcomeProperty); }
            set { SetValue(UserNameLoginWelcomeProperty, value); }
        }

        public int TongSach
        {
            get { return (int)GetValue(TongSachProperty); }
            set { SetValue(TongSachProperty, value); }
        }

        public int SoLuongDonHangMoi
        {
            get { return (int)GetValue(SoLuongDonHangProperty); }
            set { SetValue(SoLuongDonHangProperty, value); }
        }

        public string ImagePath1
        {
            get { return (string)GetValue(ImagePath1Property); }
            set { SetValue(ImagePath1Property, value); }
        }

        public string ImagePath2
        {
            get { return (string)GetValue(ImagePath2Property); }
            set { SetValue(ImagePath2Property, value); }
        }

        public string ImagePath3
        {
            get { return (string)GetValue(ImagePath3Property); }
            set { SetValue(ImagePath3Property, value); }
        }

        public string ImagePath4
        {
            get { return (string)GetValue(ImagePath4Property); }
            set { SetValue(ImagePath4Property, value); }
        }

        public string ImagePath5
        {
            get { return (string)GetValue(ImagePath5Property); }
            set { SetValue(ImagePath5Property, value); }
        }

        public int SoLuong1
        {
            get { return (int)GetValue(SoLuong1Property); }
            set { SetValue(SoLuong1Property, value); }
        }

        public int SoLuong2
        {
            get { return (int)GetValue(SoLuong2Property); }
            set { SetValue(SoLuong2Property, value); }
        }

        public int SoLuong3
        {
            get { return (int)GetValue(SoLuong3Property); }
            set { SetValue(SoLuong3Property, value); }
        }

        public int SoLuong4
        {
            get { return (int)GetValue(SoLuong4Property); }
            set { SetValue(SoLuong4Property, value); }
        }

        public int SoLuong5
        {
            get { return (int)GetValue(SoLuong5Property); }
            set { SetValue(SoLuong5Property, value); }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var screen = new DangNhapWindow();
            if (screen.ShowDialog() == true)
            {
                UserNameLoginWelcome = screen._usernameLoginWelcome;
                this.Show();
                ThayDoiQuyDinh.SoLuongSachNhapToiThieu = 150;
                ThayDoiQuyDinh.SoLuongSachTonToiDaDeNhapSach = 300;
                ThayDoiQuyDinh.SoLuongSachTonToiThieuSauKhiBan = 20;
            }
        }

        private void ImportExcelButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();

            if (screen.ShowDialog() == true)
            {
                var db = new MyShopDBContext();

                string filename = screen.FileName;
                var document = SpreadsheetDocument.Open(filename, false);
                var workbookPart = document.WorkbookPart!;
                var sheets = workbookPart.Workbook.Descendants<Sheet>()!;

                // Thể loại
                var theLoaiSheet = sheets.FirstOrDefault(s => s.Name == "TheLoai")!;
                var worksheetPart = (WorksheetPart)workbookPart.GetPartById(theLoaiSheet.Id!)!;
                var cells = worksheetPart.Worksheet.Descendants<Cell>()!;
                int row = 3;
                Cell idCell;

                do
                {
                    idCell = cells.FirstOrDefault(
                        c => c?.CellReference == $"B{row}");

                    if (idCell?.InnerText.Length > 0)
                    {
                        Cell tenCell = cells.FirstOrDefault(c => c?.CellReference == $"C{row}");
                        string tenId = tenCell!.InnerText;

                        var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault()!;
                        string ten = stringTable.SharedStringTable.ElementAt(int.Parse(tenId)).InnerText;

                        var theLoai = new TheLoai()
                        {
                            Ten = ten
                        };
                        db.TheLoais.Add(theLoai);
                    }

                    row++;
                } while (idCell?.InnerText.Length > 0);
                db.SaveChanges();

                // Sách
                var sachSheet = sheets.FirstOrDefault(s => s.Name == "Sach")!;
                worksheetPart = (WorksheetPart)workbookPart.GetPartById(sachSheet.Id!)!;
                cells = worksheetPart.Worksheet.Descendants<Cell>()!;
                row = 3;

                do
                {
                    idCell = cells.FirstOrDefault(
                        c => c?.CellReference == $"B{row}");

                    if (idCell?.InnerText.Length > 0)
                    {
                        string theLoaiID = cells.FirstOrDefault(c => c?.CellReference == $"C{row}").InnerText;
                        Cell tenCell = cells.FirstOrDefault(c => c?.CellReference == $"D{row}");
                        string tenId = tenCell!.InnerText;
                        string soLuong = cells.FirstOrDefault(c => c?.CellReference == $"E{row}").InnerText;
                        string gia = cells.FirstOrDefault(c => c?.CellReference == $"F{row}").InnerText;
                        Cell tacGiaCell = cells.FirstOrDefault(c => c?.CellReference == $"G{row}");
                        string tacGiaId = tacGiaCell!.InnerText;
                        Cell imagePathCell = cells.FirstOrDefault(c => c?.CellReference == $"H{row}");
                        string imagePathId = imagePathCell!.InnerText;

                        var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault()!;
                        string ten = stringTable.SharedStringTable.ElementAt(int.Parse(tenId)).InnerText;
                        string tacGia = stringTable.SharedStringTable.ElementAt(int.Parse(tacGiaId)).InnerText;
                        string imagePath = stringTable.SharedStringTable.ElementAt(int.Parse(imagePathId)).InnerText;

                        var sach = new Sach()
                        {
                            TheLoaiId = int.Parse(theLoaiID),
                            Ten = ten,
                            SoLuong = int.Parse(soLuong),
                            Gia = int.Parse(gia),
                            TacGia = tacGia,
                            ImagePath = imagePath
                        };
                        db.Saches.Add(sach);
                    }

                    row++;
                } while (idCell?.InnerText.Length > 0);
                db.SaveChanges();

                // Khách hàng
                var khachHangSheet = sheets.FirstOrDefault(s => s.Name == "KhachHang")!;
                worksheetPart = (WorksheetPart)workbookPart.GetPartById(khachHangSheet.Id!)!;
                cells = worksheetPart.Worksheet.Descendants<Cell>()!;
                row = 3;

                do
                {
                    idCell = cells.FirstOrDefault(
                        c => c?.CellReference == $"B{row}");

                    if (idCell?.InnerText.Length > 0)
                    {
                        Cell tenCell = cells.FirstOrDefault(c => c?.CellReference == $"C{row}");
                        string tenId = tenCell!.InnerText;
                        string soDienThoai = cells.FirstOrDefault(c => c?.CellReference == $"D{row}").InnerText;
                        Cell diaChiCell = cells.FirstOrDefault(c => c?.CellReference == $"E{row}");
                        string diaChiId = diaChiCell!.InnerText;
                        Cell emailCell = cells.FirstOrDefault(c => c?.CellReference == $"F{row}");
                        string emailId = emailCell!.InnerText;
                        Cell imagePathCell = cells.FirstOrDefault(c => c?.CellReference == $"G{row}");
                        string imagePathId = imagePathCell!.InnerText;

                        var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault()!;
                        string ten = stringTable.SharedStringTable.ElementAt(int.Parse(tenId)).InnerText;
                        string diaChi = stringTable.SharedStringTable.ElementAt(int.Parse(diaChiId)).InnerText;
                        string email = stringTable.SharedStringTable.ElementAt(int.Parse(emailId)).InnerText;
                        string imagePath = stringTable.SharedStringTable.ElementAt(int.Parse(imagePathId)).InnerText;

                        var khachHang = new KhachHang()
                        {
                            Ten = ten,
                            SoDienThoai = soDienThoai,
                            DiaChi = diaChi,
                            Email = email,
                            ImagePath = imagePath

                        };
                        db.KhachHangs.Add(khachHang);
                    }

                    row++;
                } while (idCell?.InnerText.Length > 0);
                db.SaveChanges();

                // Trạng thái đơn hàng
                var trangThaiDonHangSheet = sheets.FirstOrDefault(s => s.Name == "TrangThaiDonHang")!;
                worksheetPart = (WorksheetPart)workbookPart.GetPartById(trangThaiDonHangSheet.Id!)!;
                cells = worksheetPart.Worksheet.Descendants<Cell>()!;
                row = 3;

                do
                {
                    idCell = cells.FirstOrDefault(
                        c => c?.CellReference == $"B{row}");

                    if (idCell?.InnerText.Length > 0)
                    {
                        Cell trangThaiCell = cells.FirstOrDefault(c => c?.CellReference == $"C{row}");
                        string trangThaiId = trangThaiCell!.InnerText;
                        Cell moTaCell = cells.FirstOrDefault(c => c?.CellReference == $"D{row}");
                        string moTaId = moTaCell!.InnerText;
                        Cell chuHienThiCell = cells.FirstOrDefault(c => c?.CellReference == $"E{row}");
                        string chuHienThiId = chuHienThiCell!.InnerText;

                        var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault()!;
                        string trangThai = stringTable.SharedStringTable.ElementAt(int.Parse(trangThaiId)).InnerText;
                        string moTa = stringTable.SharedStringTable.ElementAt(int.Parse(moTaId)).InnerText;
                        string chuHienThi = stringTable.SharedStringTable.ElementAt(int.Parse(chuHienThiId)).InnerText;

                        var trangThaiDonHang = new TrangThaiDonHang()
                        {
                            TrangThai = trangThai,
                            MoTa = moTa,
                            ChuHienThi = chuHienThi

                        };
                        db.TrangThaiDonHangs.Add(trangThaiDonHang);
                    }

                    row++;
                } while (idCell?.InnerText.Length > 0);
                db.SaveChanges();

                MessageBox.Show("Successfully imported TheLoai, Sach, KhachHang, TrangThaiDonHang data from Excel into SQL Server.");
            }
        }

        private void QuanLiTheLoaiSachButton_Click(object sender, RoutedEventArgs e)
        {
            var theLoaiScreen = new TheLoaiSachWindow();
            theLoaiScreen.Show();
        }

        private void QuanLiSachButton_Click(object sender, RoutedEventArgs e)
        {
            var sachScreen = new SachWindow();
            sachScreen.Show();
        }

        private void QuanLiDonHangButton_Click(object sender, RoutedEventArgs e)
        {
            var donHangScreen = new DonHangWindow(ThayDoiQuyDinh);
            donHangScreen.Show();
        }

        private void QuanLiKhachHangButton_Click(object sender, RoutedEventArgs e)
        {
            var khachHangScreen = new KhachHangWindow();
            khachHangScreen.Show();
        }

        private void BaoCaoButton_Click(object sender, RoutedEventArgs e)
        {
            var baoCaoScreen = new BaoCaoWindow();
            baoCaoScreen.Show();
        }

        private void ThayDoiQuyDinhButton_Click(object sender, RoutedEventArgs e)
        {
            var thayDoiQuyDinhScreen = new ThayDoiQuyDinhWindow(ThayDoiQuyDinh);
            if (thayDoiQuyDinhScreen.ShowDialog() == true)
            {
                var thayDoiQuyDinhCapNhat = (ThamSo)thayDoiQuyDinhScreen.ThayDoiQuyDinh.Clone();

                ThayDoiQuyDinh.SoLuongSachNhapToiThieu = thayDoiQuyDinhCapNhat.SoLuongSachNhapToiThieu;
                ThayDoiQuyDinh.SoLuongSachTonToiDaDeNhapSach = thayDoiQuyDinhCapNhat.SoLuongSachTonToiDaDeNhapSach;
                ThayDoiQuyDinh.SoLuongSachTonToiThieuSauKhiBan = thayDoiQuyDinhCapNhat.SoLuongSachTonToiThieuSauKhiBan;
            }
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new MyShopDBContext();

            var saches = db.Saches.ToList();
            TongSach = saches.Count();
            tongSachTextBox1.Visibility = Visibility.Visible;
            tongSachTextBox2.Visibility = Visibility.Visible;

            var dateNow = DateTime.Now;
            var donHangMoi = db.DonHangs.Where(u => u.NgayTao.Value.Month == dateNow.Month && u.NgayTao.Value.Year == dateNow.Year).ToList();
            SoLuongDonHangMoi = donHangMoi.Count();
            donHangMoiTextBox1.Visibility = Visibility.Visible;
            donHangMoiTextBox2.Visibility = Visibility.Visible;

            topNamSachSapHetHangextBox.Visibility = Visibility.Visible;
            var sachesTopNamSapHetHang = db.Saches.OrderBy(u => u.SoLuong).ToList();
            for (int i = 0; i < 5; i++)
            {
                switch(i)
                {
                    case 0:
                        ImagePath1 = sachesTopNamSapHetHang[i].ImagePath;
                        SoLuong1 = (int)sachesTopNamSapHetHang[i].SoLuong;
                        soThuTu1TextBox.Visibility = Visibility.Visible;
                        imagePath1Box.Visibility = Visibility.Visible;
                        soLuong1TextBox.Visibility = Visibility.Visible;
                        cuon1TextBox.Visibility = Visibility.Visible;
                        break;
                    case 1:
                        ImagePath2 = sachesTopNamSapHetHang[i].ImagePath;
                        SoLuong2 = (int)sachesTopNamSapHetHang[i].SoLuong;
                        soThuTu2TextBox.Visibility = Visibility.Visible;
                        imagePath2Box.Visibility = Visibility.Visible;
                        soLuong2TextBox.Visibility = Visibility.Visible;
                        cuon2TextBox.Visibility = Visibility.Visible;
                        break;
                    case 2:
                        ImagePath3 = sachesTopNamSapHetHang[i].ImagePath;
                        SoLuong3 = (int)sachesTopNamSapHetHang[i].SoLuong;
                        soThuTu3TextBox.Visibility = Visibility.Visible;
                        imagePath3Box.Visibility = Visibility.Visible;
                        soLuong3TextBox.Visibility = Visibility.Visible;
                        cuon3TextBox.Visibility = Visibility.Visible;
                        break;
                    case 3:
                        ImagePath4 = sachesTopNamSapHetHang[i].ImagePath;
                        SoLuong4 = (int)sachesTopNamSapHetHang[i].SoLuong;
                        soThuTu4TextBox.Visibility = Visibility.Visible;
                        imagePath4Box.Visibility = Visibility.Visible;
                        soLuong4TextBox.Visibility = Visibility.Visible;
                        cuon4TextBox.Visibility = Visibility.Visible;
                        break;
                    case 4:
                        ImagePath5 = sachesTopNamSapHetHang[i].ImagePath;
                        SoLuong5 = (int)sachesTopNamSapHetHang[i].SoLuong;
                        soThuTu5TextBox.Visibility = Visibility.Visible;
                        imagePath5Box.Visibility = Visibility.Visible;
                        soLuong5TextBox.Visibility = Visibility.Visible;
                        cuon5TextBox.Visibility = Visibility.Visible;
                        break;
                    default:
                        break;
                }
            }
        }


    }
}
