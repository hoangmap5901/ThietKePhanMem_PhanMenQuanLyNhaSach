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
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace MyShop
{
    /// <summary>
    /// Interaction logic for DangNhapWindow.xaml
    /// </summary>
    public partial class DangNhapWindow : Window
    {
        public string _usernameLoginWelcome = "";

        public DangNhapWindow()
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

            MessageBox.Show("Successfully imported TaiKhoan data from Excel into SQL Server.");
        }

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
                    _usernameLoginWelcome = usernameInput;
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu.");
                }
            }
        }

      
    }
}
