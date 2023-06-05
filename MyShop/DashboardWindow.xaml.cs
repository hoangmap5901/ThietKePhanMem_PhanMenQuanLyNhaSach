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
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public static readonly DependencyProperty UserNameLoginWelcomeProperty =
   DependencyProperty.Register("UserNameLoginWelcome", typeof(string), typeof(Window), new PropertyMetadata(null));

        public string UserNameLoginWelcome
        {
            get { return (string)GetValue(UserNameLoginWelcomeProperty); }
            set { SetValue(UserNameLoginWelcomeProperty, value); }
        }

        public DashboardWindow(string username)
        {
            InitializeComponent();

            UserNameLoginWelcome = username;
        }

        private void ImportExcelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QuanLiLoaiSachButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QuanLiSachButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QuanLiDonHangButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QuanLiKhachHangButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BaoCaoButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
