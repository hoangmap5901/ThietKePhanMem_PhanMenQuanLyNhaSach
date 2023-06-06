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
    /// Interaction logic for TheLoaiSachWindow.xaml
    /// </summary>
    public partial class TheLoaiSachWindow : Window
    {
        public TheLoaiSachWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new MyShopDBContext();
            var theLoais = db.TheLoais.ToList();

            theLoaiDataGrid.ItemsSource = theLoais;
            theLoaiDataGrid.Columns[2].MaxWidth = 0;
        }

        private void ThemTheLoaiButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ThemTheLoaiWindow();
            if (screen.ShowDialog() == true)
            {
                var db = new MyShopDBContext();
                var theLoais = db.TheLoais.ToList();

                theLoaiDataGrid.ItemsSource = theLoais;
                theLoaiDataGrid.Columns[2].MaxWidth = 0;
            }
        }

        private void XoaTheLoaiButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new MyShopDBContext();

            TheLoai theLoaiChon = theLoaiDataGrid.SelectedItem as TheLoai;
            var theLoaiXoa = db.TheLoais.FirstOrDefault(u => u.TheLoaiId == theLoaiChon.TheLoaiId);

            db.TheLoais.Remove(theLoaiXoa);
            db.SaveChanges();

            MessageBox.Show($"Successfully deleted TheLoai record in SQL Server with TheLoaiID = {theLoaiXoa.TheLoaiId}.");

            var theLoais = db.TheLoais.ToList();

            theLoaiDataGrid.ItemsSource = theLoais;
            theLoaiDataGrid.Columns[2].MaxWidth = 0;
        }

        private void CapNhatTheLoaiButton_Click(object sender, RoutedEventArgs e)
        {
 
            TheLoai theLoaiChon = theLoaiDataGrid.SelectedItem as TheLoai;


            var screen = new CapNhatTheLoaiWindow(theLoaiChon);

            if (screen.ShowDialog() == true)  
            {
                var db = new MyShopDBContext();
                var theLoais = db.TheLoais.ToList();

                theLoaiDataGrid.ItemsSource = theLoais;
                theLoaiDataGrid.Columns[2].MaxWidth = 0;
            }   
        }
    }
}
