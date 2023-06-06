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
    /// Interaction logic for ThemTheLoaiWindow.xaml
    /// </summary>
    public partial class ThemTheLoaiWindow : Window
    {
        public TheLoai ThemTheLoai { get; set; } = new TheLoai();
        public ThemTheLoaiWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = ThemTheLoai;
        }

        private void ThemButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new MyShopDBContext();
            var theLoaiThem = new TheLoai()
            {
                Ten = ThemTheLoai.Ten
            };

            db.TheLoais.Add(theLoaiThem);
            db.SaveChanges();

            MessageBox.Show($"Successfully added new TheLoai record into SQL Server with TheLoaiID = {theLoaiThem.TheLoaiId}.");
            DialogResult = true;
        }
    }
}
