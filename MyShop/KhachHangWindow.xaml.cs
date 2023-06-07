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

            var khachHangsKeyword = khachHangs.Where(khachHang => khachHang.Ten.Contains(Keyword));
            _totalItems = khachHangsKeyword.Count();
            TotalItems = _totalItems;

            var khachHangsRowsPerPage = khachHangsKeyword.Skip((_currentPage - 1) * RowsPerPage).Take(RowsPerPage);
            _numberOfItemsCurrentPage = khachHangsRowsPerPage.Count();
            NumberOfItemsCurrentPage = _numberOfItemsCurrentPage;

            khachHangListView.ItemsSource = khachHangsRowsPerPage;
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

        private void ThemKhachHangButton_Click(object sender, RoutedEventArgs e)
        {
            int pageIndex = pagingComboBox.SelectedIndex;
            var screen = new ThemKhachHangWindow();
            int numberOfItemsCurrentPagePrev = _numberOfItemsCurrentPage;

            if (screen.ShowDialog() == true)
            {
                UpdateDataSource();
                //UpdateDataSource();
                UpdatePagingInfo();
                if (numberOfItemsCurrentPagePrev == RowsPerPage)
                {
                    pagingComboBox.SelectedIndex = pageIndex + 1;
                }
            }
        }

        private void DeleteSelectedKhachHang()
        {
            var db = new MyShopDBContext();

            KhachHang khachHangChon = khachHangListView.SelectedItem as KhachHang;
            var khachHangXoa = db.KhachHangs.FirstOrDefault(u => u.KhachHangId == khachHangChon.KhachHangId);

            db.KhachHangs.Remove(khachHangXoa);
            db.SaveChanges();

            MessageBox.Show($"Successfully deleted KhachHang record in SQL Server with KhachHangID = {khachHangXoa.KhachHangId}.");
        }

        private void XoaKhachHangButton_Click(object sender, RoutedEventArgs e)
        {
            int pageIndex = pagingComboBox.SelectedIndex;
            int numberOfItemsCurrentPagePrev = _numberOfItemsCurrentPage;

            DeleteSelectedKhachHang();

            // && (_currentPage == pageIndex)
            UpdateDataSource();

            UpdatePagingInfo();
            pagingComboBox.SelectedIndex = pageIndex;
            if ((numberOfItemsCurrentPagePrev == 1) && (_currentPage > 1))
            {
                pagingComboBox.SelectedIndex = pageIndex - 1;
            }
        }

        private void XoaMenu_Click(object sender, RoutedEventArgs e)
        {
            int pageIndex = pagingComboBox.SelectedIndex;
            int numberOfItemsCurrentPagePrev = _numberOfItemsCurrentPage;

            DeleteSelectedKhachHang();

            // && (_currentPage == pageIndex)
            UpdateDataSource();

            UpdatePagingInfo();
            pagingComboBox.SelectedIndex = pageIndex;
            if ((numberOfItemsCurrentPagePrev == 1) && (_currentPage > 1))
            {
                pagingComboBox.SelectedIndex = pageIndex - 1;
            }
        }

        private CapNhatKhachHangWindow UpdateSelectedKhachHang()
        {
            KhachHang khachHangChon = khachHangListView.SelectedItem as KhachHang;

            var screen = new CapNhatKhachHangWindow(khachHangChon);

            return screen;
        }

        private void CapNhatKhachHangButton_Click(object sender, RoutedEventArgs e)
        {
            int pageIndex = pagingComboBox.SelectedIndex;

            if (UpdateSelectedKhachHang().ShowDialog() == true)
            {
                UpdateDataSource();
                UpdatePagingInfo();
                pagingComboBox.SelectedIndex = pageIndex;
            }
        }

        private void CapNhatMenu_Click(object sender, RoutedEventArgs e)
        {
            int pageIndex = pagingComboBox.SelectedIndex;

            if (UpdateSelectedKhachHang().ShowDialog() == true)
            {
                UpdateDataSource();
                UpdatePagingInfo();
                pagingComboBox.SelectedIndex = pageIndex;
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
            UpdateDataSource();
            UpdatePagingInfo();
            pagingComboBox.SelectedIndex = 0;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataSource();
            UpdatePagingInfo();
            pagingComboBox.SelectedIndex = 0;
            //_currentPage = 1;
        }
    }
}
