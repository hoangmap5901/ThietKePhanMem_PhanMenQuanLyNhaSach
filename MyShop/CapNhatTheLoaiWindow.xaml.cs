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
    /// Interaction logic for CapNhatTheLoaiWindow.xaml
    /// </summary>
    public partial class CapNhatTheLoaiWindow : Window
    {
        public TheLoai CapNhatTheLoai { get; set; } = new TheLoai();
        public CapNhatTheLoaiWindow(TheLoai data)
        {
            InitializeComponent();

            CapNhatTheLoai.TheLoaiId = data.TheLoaiId;
            CapNhatTheLoai.Ten = data.Ten;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = CapNhatTheLoai;
        }

        private void CapNhatButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new MyShopDBContext();
            var theLoaiCapNhat = db.TheLoais.FirstOrDefault(u => u.TheLoaiId == CapNhatTheLoai.TheLoaiId);

            theLoaiCapNhat.Ten = CapNhatTheLoai.Ten;
            db.SaveChanges();

            MessageBox.Show($"Successfully updated TheLoai record in SQL Server with TheLoaiID = {theLoaiCapNhat.TheLoaiId}.");
            DialogResult = true;
        }
    }
}
