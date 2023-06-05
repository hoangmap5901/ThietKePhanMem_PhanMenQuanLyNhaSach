﻿using DocumentFormat.OpenXml.Packaging;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var curDir = AppDomain.CurrentDomain.BaseDirectory;
            var importExcelDir = Path.GetFullPath(Path.Combine(curDir, @"..\..\..\..\"));
            string importExcelFile = $"{importExcelDir}MyShopDataImportDataBase.xlsx";

            var document = SpreadsheetDocument.Open(importExcelFile, false);
            var workbookPart = document.WorkbookPart!;
            var sheets = workbookPart.Workbook.Descendants<Sheet>()!;

            var db = new MyShopDBContext();

            var taiKhoanSheet = sheets.FirstOrDefault(s => s.Name == "TaiKhoan")!;
            var worksheetPart = (WorksheetPart)workbookPart.GetPartById(taiKhoanSheet.Id!)!;
            var cells = worksheetPart.Worksheet.Descendants<Cell>()!;
            int row = 3;
            Cell idCell;

            do
            {
                idCell = cells.FirstOrDefault(
                    c => c?.CellReference == $"B{row}");

                if (idCell?.InnerText.Length > 0)
                {
                    Cell tenDangNhapCell = cells.FirstOrDefault(c => c?.CellReference == $"C{row}");
                    string tenDangNhapId = tenDangNhapCell!.InnerText;
                    Cell matKhauCell = cells.FirstOrDefault(c => c?.CellReference == $"D{row}");
                    string matKhauId = matKhauCell!.InnerText;
                    Cell vaiTroCell = cells.FirstOrDefault(c => c?.CellReference == $"E{row}");
                    string vaiTroId = vaiTroCell!.InnerText;

                    var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault()!;
                    string tenDangNhap = stringTable.SharedStringTable.ElementAt(int.Parse(tenDangNhapId)).InnerText;
                    string matKhau = stringTable.SharedStringTable.ElementAt(int.Parse(matKhauId)).InnerText;
                    string vaiTro = stringTable.SharedStringTable.ElementAt(int.Parse(vaiTroId)).InnerText;

                    var taiKhoan = new TaiKhoan()
                    {
                        TenDangNhap = tenDangNhap,
                        MatKhau = matKhau,
                        VaiTro = vaiTro
                    };
                    db.TaiKhoans.Add(taiKhoan);
                }

                row++;
            } while (idCell?.InnerText.Length > 0);
            db.SaveChanges();

            MessageBox.Show("Imported TaiKhoan data from Excel into SQL Server successfully.");
        }

        //private void ImportExcelButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var screen = new OpenFileDialog();

        //    if (screen.ShowDialog() == true)
        //    {
        //        var db = new MyShopDBContext();

        //        string filename = screen.FileName;
        //        var document = SpreadsheetDocument.Open(filename, false);
        //        var workbookPart = document.WorkbookPart!;
        //        var sheets = workbookPart.Workbook.Descendants<Sheet>()!;

        //        // Thể loại
        //        var theLoaiSheet = sheets.FirstOrDefault(s => s.Name == "TheLoai")!;
        //        var worksheetPart = (WorksheetPart)workbookPart.GetPartById(theLoaiSheet.Id!)!;
        //        var cells = worksheetPart.Worksheet.Descendants<Cell>()!;
        //        int row = 3;
        //        Cell idCell;

        //        do
        //        {
        //            idCell = cells.FirstOrDefault(
        //                c => c?.CellReference == $"B{row}");

        //            if (idCell?.InnerText.Length > 0)
        //            {
        //                Cell tenCell = cells.FirstOrDefault(c => c?.CellReference == $"C{row}");
        //                string tenId = tenCell!.InnerText;

        //                var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault()!;
        //                string ten = stringTable.SharedStringTable.ElementAt(int.Parse(tenId)).InnerText;

        //                var theLoai = new TheLoai()
        //                {
        //                    Ten = ten
        //                };
        //                db.TheLoais.Add(theLoai);
        //            }

        //            row++;
        //        } while (idCell?.InnerText.Length > 0);
        //        db.SaveChanges();

        //        // Sách
        //        var sachSheet = sheets.FirstOrDefault(s => s.Name == "Sach")!;
        //        worksheetPart = (WorksheetPart)workbookPart.GetPartById(sachSheet.Id!)!;
        //        cells = worksheetPart.Worksheet.Descendants<Cell>()!;
        //        row = 3;

        //        do
        //        {
        //            idCell = cells.FirstOrDefault(
        //                c => c?.CellReference == $"B{row}");

        //            if (idCell?.InnerText.Length > 0)
        //            {
        //                string theLoaiID = cells.FirstOrDefault(c => c?.CellReference == $"C{row}").InnerText;
        //                Cell tenCell = cells.FirstOrDefault(c => c?.CellReference == $"D{row}");
        //                string tenId = tenCell!.InnerText;
        //                string soLuong = cells.FirstOrDefault(c => c?.CellReference == $"E{row}").InnerText;
        //                string gia = cells.FirstOrDefault(c => c?.CellReference == $"F{row}").InnerText;
        //                Cell tacGiaCell = cells.FirstOrDefault(c => c?.CellReference == $"G{row}");
        //                string tacGiaId = tacGiaCell!.InnerText;
        //                Cell imagePathCell = cells.FirstOrDefault(c => c?.CellReference == $"H{row}");
        //                string imagePathId = imagePathCell!.InnerText;

        //                var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault()!;
        //                string ten = stringTable.SharedStringTable.ElementAt(int.Parse(tenId)).InnerText;
        //                string tacGia = stringTable.SharedStringTable.ElementAt(int.Parse(tacGiaId)).InnerText;
        //                string imagePath = stringTable.SharedStringTable.ElementAt(int.Parse(imagePathId)).InnerText;

        //                var sach = new Sach()
        //                {
        //                    TheLoaiId = int.Parse(theLoaiID),
        //                    Ten = ten,
        //                    SoLuong = int.Parse(soLuong),
        //                    Gia = int.Parse(gia),
        //                    TacGia = tacGia,
        //                    ImagePath = imagePath
        //                };
        //                db.Saches.Add(sach);
        //            }

        //            row++;
        //        } while (idCell?.InnerText.Length > 0);
        //        db.SaveChanges();

        //        // Khách hàng
        //        var khachHangSheet = sheets.FirstOrDefault(s => s.Name == "KhachHang")!;
        //        worksheetPart = (WorksheetPart)workbookPart.GetPartById(khachHangSheet.Id!)!;
        //        cells = worksheetPart.Worksheet.Descendants<Cell>()!;
        //        row = 3;

        //        do
        //        {
        //            idCell = cells.FirstOrDefault(
        //                c => c?.CellReference == $"B{row}");

        //            if (idCell?.InnerText.Length > 0)
        //            {
        //                Cell tenCell = cells.FirstOrDefault(c => c?.CellReference == $"C{row}");
        //                string tenId = tenCell!.InnerText;
        //                string soDienThoai = cells.FirstOrDefault(c => c?.CellReference == $"D{row}").InnerText;
        //                Cell diaChiCell = cells.FirstOrDefault(c => c?.CellReference == $"E{row}");
        //                string diaChiId = diaChiCell!.InnerText;
        //                Cell emailCell = cells.FirstOrDefault(c => c?.CellReference == $"F{row}");
        //                string emailId = emailCell!.InnerText;
        //                Cell imagePathCell = cells.FirstOrDefault(c => c?.CellReference == $"G{row}");
        //                string imagePathId = imagePathCell!.InnerText;

        //                var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault()!;
        //                string ten = stringTable.SharedStringTable.ElementAt(int.Parse(tenId)).InnerText;
        //                string diaChi = stringTable.SharedStringTable.ElementAt(int.Parse(diaChiId)).InnerText;
        //                string email = stringTable.SharedStringTable.ElementAt(int.Parse(emailId)).InnerText;
        //                string imagePath = stringTable.SharedStringTable.ElementAt(int.Parse(imagePathId)).InnerText;

        //                var khachHang = new KhachHang()
        //                {
        //                    Ten = ten,
        //                    SoDienThoai = soDienThoai,
        //                    DiaChi = diaChi,
        //                    Email = email,
        //                    ImagePath = imagePath

        //                };
        //                db.KhachHangs.Add(khachHang);
        //            }

        //            row++;
        //        } while (idCell?.InnerText.Length > 0);
        //        db.SaveChanges();

        //        // Trạng thái đơn hàng
        //        var trangThaiDonHangSheet = sheets.FirstOrDefault(s => s.Name == "TrangThaiDonHang")!;
        //        worksheetPart = (WorksheetPart)workbookPart.GetPartById(trangThaiDonHangSheet.Id!)!;
        //        cells = worksheetPart.Worksheet.Descendants<Cell>()!;
        //        row = 3;

        //        do
        //        {
        //            idCell = cells.FirstOrDefault(
        //                c => c?.CellReference == $"B{row}");

        //            if (idCell?.InnerText.Length > 0)
        //            {
        //                Cell trangThaiCell = cells.FirstOrDefault(c => c?.CellReference == $"C{row}");
        //                string trangThaiId = trangThaiCell!.InnerText;
        //                Cell moTaCell = cells.FirstOrDefault(c => c?.CellReference == $"D{row}");
        //                string moTaId = moTaCell!.InnerText;
        //                Cell chuHienThiCell = cells.FirstOrDefault(c => c?.CellReference == $"E{row}");
        //                string chuHienThiId = chuHienThiCell!.InnerText;

        //                var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault()!;
        //                string trangThai = stringTable.SharedStringTable.ElementAt(int.Parse(trangThaiId)).InnerText;
        //                string moTa = stringTable.SharedStringTable.ElementAt(int.Parse(moTaId)).InnerText;
        //                string chuHienThi = stringTable.SharedStringTable.ElementAt(int.Parse(chuHienThiId)).InnerText;

        //                var trangThaiDonHang = new TrangThaiDonHang()
        //                {
        //                    TrangThai = trangThai,
        //                    MoTa = moTa,
        //                    ChuHienThi = chuHienThi

        //                };
        //                db.TrangThaiDonHangs.Add(trangThaiDonHang);
        //            }

        //            row++;
        //        } while (idCell?.InnerText.Length > 0);
        //        db.SaveChanges();

        //        // Tài khoản
        //        var taiKhoanSheet = sheets.FirstOrDefault(s => s.Name == "TaiKhoan")!;
        //        worksheetPart = (WorksheetPart)workbookPart.GetPartById(taiKhoanSheet.Id!)!;
        //        cells = worksheetPart.Worksheet.Descendants<Cell>()!;
        //        row = 3;

        //        do
        //        {
        //            idCell = cells.FirstOrDefault(
        //                c => c?.CellReference == $"B{row}");

        //            if (idCell?.InnerText.Length > 0)
        //            {
        //                Cell tenDangNhapCell = cells.FirstOrDefault(c => c?.CellReference == $"C{row}");
        //                string tenDangNhapId = tenDangNhapCell!.InnerText;
        //                Cell matKhauCell = cells.FirstOrDefault(c => c?.CellReference == $"D{row}");
        //                string matKhauId = matKhauCell!.InnerText;
        //                Cell vaiTroCell = cells.FirstOrDefault(c => c?.CellReference == $"E{row}");
        //                string vaiTroId = vaiTroCell!.InnerText;

        //                var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault()!;
        //                string tenDangNhap = stringTable.SharedStringTable.ElementAt(int.Parse(tenDangNhapId)).InnerText;
        //                string matKhau = stringTable.SharedStringTable.ElementAt(int.Parse(matKhauId)).InnerText;
        //                string vaiTro = stringTable.SharedStringTable.ElementAt(int.Parse(vaiTroId)).InnerText;

        //                var taiKhoan = new TaiKhoan()
        //                {
        //                    TenDangNhap = tenDangNhap,
        //                    MatKhau = matKhau,
        //                    VaiTro = vaiTro
        //                };
        //                db.TaiKhoans.Add(taiKhoan);
        //            }

        //            row++;
        //        } while (idCell?.InnerText.Length > 0);
        //        db.SaveChanges();

        //        MessageBox.Show("Imported data from Excel into SQL Server successfully.");
        //    }
        //}

        private void DangNhapButton_Click(object sender, RoutedEventArgs e)
        {
            string usernameInput = usernameTextBox.Text;
            string passwordInput = dangNhapPasswordPasswordBox.Password.ToString();

            var db = new MyShopDBContext();

            var danhSachTenDangNhap = db.TaiKhoans.Select(u => u.TenDangNhap).ToList();
            var danhSachMatKhau = db.TaiKhoans.Select(u => u.MatKhau).ToList();

            if (danhSachTenDangNhap.Contains(usernameInput) == false)
            {
                MessageBox.Show($"Không tìm thấy username {usernameInput} trong cơ sở dữ liệu.");
            }
            else
            {
                int chiMucTenDangNhap = danhSachTenDangNhap.IndexOf(usernameInput);
                if (passwordInput == danhSachMatKhau[chiMucTenDangNhap])
                {
                    MessageBox.Show("Đăng nhập thành công.");
                    var screen = new DashboardWindow(usernameInput);
                    screen.Show();
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu.");
                }
            }
        }

    }
}
