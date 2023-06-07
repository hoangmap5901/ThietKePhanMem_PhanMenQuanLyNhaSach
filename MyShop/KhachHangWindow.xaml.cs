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
    /// Interaction logic for KhachHangWindow.xaml
    /// </summary>
    public partial class KhachHangWindow : Window
    {
        public int RowsPerPage { get => _rowsPerPage; set => _rowsPerPage = value; }
        public string Keyword { get; set; } = "";
        int _totalItems;
        int _numberOfItemsCurrentPage;
        int _currentPage;
        int _rowsPerPage = 2;
        int _totalPages;

        public static readonly DependencyProperty TotalItemsProperty =
          DependencyProperty.Register("TotalItems", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty NumberOfItemsCurrentPageProperty =
           DependencyProperty.Register("NumberOfItemsCurrentPage", typeof(int), typeof(Window), new PropertyMetadata(null));

        public int TotalItems
        {
            get { return (int)GetValue(TotalItemsProperty); }
            set { SetValue(TotalItemsProperty, value); }
        }

        public int NumberOfItemsCurrentPage
        {
            get { return (int)GetValue(NumberOfItemsCurrentPageProperty); }
            set { SetValue(NumberOfItemsCurrentPageProperty, value); }
        }

        public KhachHangWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rowsPerPageTextBox.DataContext = this;
            keywordTextBox.DataContext = this;

            _currentPage = 1;

            UpdateDataSource();
            UpdatePagingInfo();
            pagingComboBox.SelectedIndex = 0;
        }

        void UpdateDataSource()
        {
            var db = new MyShopDBContext();
            var khachHangs = db.KhachHangs.ToList();

            khachHangs.Where(khachHang => khachHang.Ten.Contains(Keyword));
            _totalItems = khachHangs.Count;
            TotalItems = _totalItems;

            khachHangs.Skip((_currentPage - 1) * RowsPerPage).Take(RowsPerPage);
            _numberOfItemsCurrentPage = khachHangs.Count;
            NumberOfItemsCurrentPage = _numberOfItemsCurrentPage;

            khachHangListView.ItemsSource = khachHangs;
        }

        void UpdatePagingInfo()
        {
            _totalPages = _totalItems / RowsPerPage + (_totalItems % RowsPerPage == 0 ? 0 : 1);

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

        private void AddKhachHangButton_Click(object sender, RoutedEventArgs e)
        {
            int pageIndex = pagingComboBox.SelectedIndex;
            var screen = new ThemKhachHangWindow();

            if (screen.ShowDialog() == true)
            {
                if (_numberOfItemsCurrentPage == RowsPerPage)
                {
                    pagingComboBox.SelectedIndex = pageIndex + 1;
                }
                else
                {
                    UpdateDataSource();
                }

                //UpdateDataSource();
                UpdatePagingInfo();
            }
        }

        private void DeleteSelectedKhachHang()
        {
            var db = new MyShopDBContext();

            KhachHang khachHangChon = khachHangListView.SelectedItem as KhachHang;
            var khachHangXoa = db.KhachHangs.FirstOrDefault(u => u.KhachHangId == khachHangChon.KhachHangId);

            db.KhachHangs.Remove(khachHangXoa);
            db.SaveChanges();

            MessageBox.Show($"Successfully deleted KhachHang record in SQL Server with TheLoaiID = {khachHangXoa.KhachHangId}.");
        }

        private void DeleteKhachHangButton_Click(object sender, RoutedEventArgs e)
        {
            int pageIndex = pagingComboBox.SelectedIndex;

            DeleteSelectedKhachHang();

            // && (_currentPage == pageIndex)
            if ((_numberOfItemsCurrentPage == 1) && (_currentPage > 1))
            {
                pagingComboBox.SelectedIndex = pageIndex - 1;
            }
            else
            {
                UpdateDataSource();
            }

            UpdatePagingInfo();
        }

        private void XoaMenu_Click(object sender, RoutedEventArgs e)
        {
            int pageIndex = pagingComboBox.SelectedIndex;

            DeleteSelectedKhachHang();

            // && (_currentPage == pageIndex)
            if ((_numberOfItemsCurrentPage == 1) && (_currentPage > 1))
            {
                pagingComboBox.SelectedIndex = pageIndex - 1;
            }
            else
            {
                UpdateDataSource();
            }

            UpdatePagingInfo();
        }

        private CapNhatKhachHangWindow UpdateSelectedKhachHang()
        {
            KhachHang khachHangChon = khachHangListView.SelectedItem as KhachHang;

            var screen = new CapNhatKhachHangWindow(khachHangChon);

            return screen;
        }

        private void UpdateKhachHangButton_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateSelectedKhachHang().ShowDialog() == true)
            {
                UpdateDataSource();
                UpdatePagingInfo();
            }
        }

        private void CapNhatMenu_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateSelectedKhachHang().ShowDialog() == true)
            {
                UpdateDataSource();
                UpdatePagingInfo();
            }
        }

        private void ListViewItem_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            KhachHang khachHangChon = khachHangListView.SelectedItem as KhachHang;

            string khachHangInfo = @$"
                                     Thông Tin Khách Hàng
            Khách hàng ID: {khachHangChon.KhachHangId}
            Tên: {khachHangChon.Ten}
            Số điện thoại: {khachHangChon.SoDienThoai}
            Địa chỉ: {khachHangChon.DiaChi}
            Email: {khachHangChon.Email}";

            MessageBox.Show(khachHangInfo);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            int i = pagingComboBox.SelectedIndex;
            if (i < (_totalPages - 1))
            {
                pagingComboBox.SelectedIndex = i + 1;
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            int i = pagingComboBox.SelectedIndex;
            if (i > 0)
            {
                pagingComboBox.SelectedIndex = i - 1;
            }
        }

        private void UpdateRowsPerPageButton_Click(object sender, RoutedEventArgs e)
        {
            //UpdateDataSource();
            pagingComboBox.SelectedIndex = 0;
            UpdatePagingInfo();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //UpdateDataSource();
            pagingComboBox.SelectedIndex = 0;
            UpdatePagingInfo();
            //_currentPage = 1;
        }
    }
}
