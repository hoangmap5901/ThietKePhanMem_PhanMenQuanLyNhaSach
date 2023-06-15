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
    /// Interaction logic for DonHangWindow.xaml
    /// </summary>
    public partial class DonHangWindow : Window
    {
        int _totalItems;
        int _numberOfItemsCurrentPage;
        int _currentPage;
        int _totalPages;
        int _rowsPerPage = 5;

        public static readonly DependencyProperty TotalItemsProperty =
         DependencyProperty.Register("TotalItems3", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty NumberOfItemsCurrentPageProperty =
           DependencyProperty.Register("NumberOfItemsCurrentPage3", typeof(int), typeof(Window), new PropertyMetadata(null));

        public int TotalItems3
        {
            get { return (int)GetValue(TotalItemsProperty); }
            set { SetValue(TotalItemsProperty, value); }
        }

        public int NumberOfItemsCurrentPage3
        {
            get { return (int)GetValue(NumberOfItemsCurrentPageProperty); }
            set { SetValue(NumberOfItemsCurrentPageProperty, value); }
        }
        public DonHangWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;

            UpdateDataSource();
            UpdatePagingInfo();
            pagingComboBox.SelectedIndex = 0;
        }

        void UpdateDataSource()
        {
            var db = new MyShopDBContext();
            var donHangs = db.DonHangs.ToList();

            _totalItems = donHangs.Count();
            TotalItems3 = _totalItems;

            var donHangsCurrentPage = donHangs.Skip((_currentPage - 1) * _rowsPerPage).Take(_rowsPerPage);
            _numberOfItemsCurrentPage = donHangsCurrentPage.Count();
            NumberOfItemsCurrentPage3 = _numberOfItemsCurrentPage;

            donHangDataGrid.ItemsSource = donHangsCurrentPage;
        }

        void UpdatePagingInfo()
        {
            _totalPages = _totalItems / _rowsPerPage + (_totalItems % _rowsPerPage == 0 ? 0 : 1);

            var pagingInfo = new PagingInfo(_totalPages);

            pagingComboBox.ItemsSource = pagingInfo.Items;
        }

        private void PagingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = pagingComboBox.SelectedIndex;

            if (i >= 0)
            {
                _currentPage = i + 1;
                UpdateDataSource();
            }
        }

        private void TaoDonHangButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void XoaDonHangButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CapNhatDonHangButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SachDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DonHangDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            int i = pagingComboBox.SelectedIndex;
            if (i > 0)
            {
                pagingComboBox.SelectedIndex = i - 1;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            int i = pagingComboBox.SelectedIndex;
            if (i < (_totalPages - 1))
            {
                pagingComboBox.SelectedIndex = i + 1;
            }
        }

        private void timKiemButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
