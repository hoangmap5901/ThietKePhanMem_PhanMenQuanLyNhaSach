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
        int _rowsPerPage = 1;
        bool _timKiemClick = false;

        public static readonly DependencyProperty TotalItemsProperty =
         DependencyProperty.Register("TotalItems3", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty NumberOfItemsCurrentPageProperty =
           DependencyProperty.Register("NumberOfItemsCurrentPage3", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty DonHangIDProperty =
         DependencyProperty.Register("DonHangID", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty TrangThaiProperty =
           DependencyProperty.Register("TrangThai", typeof(string), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty MoTaProperty =
          DependencyProperty.Register("MoTa", typeof(string), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty KhachHangIDProperty =
        DependencyProperty.Register("KhachHangID", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty TenProperty =
         DependencyProperty.Register("Ten", typeof(string), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty SoDienThoaiProperty =
         DependencyProperty.Register("SoDienThoai", typeof(string), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty DiaChiProperty =
         DependencyProperty.Register("DiaChi", typeof(string), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty EmailProperty =
        DependencyProperty.Register("Email", typeof(string), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty TongProperty =
       DependencyProperty.Register("Tong1", typeof(int), typeof(Window), new PropertyMetadata(null));

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

        public int DonHangID
        {
            get { return (int)GetValue(DonHangIDProperty); }
            set { SetValue(DonHangIDProperty, value); }
        }

        public string TrangThai
        {
            get { return (string)GetValue(TrangThaiProperty); }
            set { SetValue(TrangThaiProperty, value); }
        }

        public string MoTa
        {
            get { return (string)GetValue(MoTaProperty); }
            set { SetValue(MoTaProperty, value); }
        }

        public int KhachHangID
        {
            get { return (int)GetValue(KhachHangIDProperty); }
            set { SetValue(KhachHangIDProperty, value); }
        }

        public string Ten
        {
            get { return (string)GetValue(TenProperty); }
            set { SetValue(TenProperty, value); }
        }

        public string SoDienThoai
        {
            get { return (string)GetValue(SoDienThoaiProperty); }
            set { SetValue(SoDienThoaiProperty, value); }
        }

        public string DiaChi
        {
            get { return (string)GetValue(DiaChiProperty); }
            set { SetValue(DiaChiProperty, value); }
        }

        public string Email
        {
            get { return (string)GetValue(EmailProperty); }
            set { SetValue(EmailProperty, value); }
        }

        public int Tong1
        {
            get { return (int)GetValue(TongProperty); }
            set { SetValue(TongProperty, value); }
        }
        public DonHangWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            _totalItems = 0;
            _numberOfItemsCurrentPage = 0;

            UpdateDataSource();
            UpdatePagingInfo();
            pagingComboBox.SelectedIndex = 0;
        }

        void UpdateDataSource(bool timKiemClick = false)
        {
            var db = new MyShopDBContext();
            var donHangs = db.DonHangs.ToList();

            if (timKiemClick == true)
            {
                var tuNgay = tuNgayDatePicker.SelectedDate.Value.Date;
                var denNgay = denNgayDatePicker.SelectedDate.Value.Date;

                donHangs = donHangs
                              .Where(u => DateTime.Compare(tuNgay, u.NgayTao ?? DateTime.Now) <= 0 && DateTime.Compare(u.NgayTao ?? DateTime.Now, denNgay) <= 0)
                              .ToList();
            }

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
                if (_timKiemClick == true)
                {
                    UpdateDataSource(true);
                }
                else
                {
                    UpdateDataSource();
                }
            }
        }

        private void TaoDonHangButton_Click(object sender, RoutedEventArgs e)
        {
            int pageIndex = pagingComboBox.SelectedIndex;
            var screen = new TaoDonHangWindow();
            int numberOfItemsCurrentPagePrev = _numberOfItemsCurrentPage;

            if (screen.ShowDialog() == true)
            {
                UpdateDataSource();
                UpdatePagingInfo();
                if (numberOfItemsCurrentPagePrev == _rowsPerPage)
                {
                    pagingComboBox.SelectedIndex = pageIndex + 1;
                }
            }
        }

        private void XoaDonHangButton_Click(object sender, RoutedEventArgs e)
        {
            int pageIndex = pagingComboBox.SelectedIndex;
            int numberOfItemsCurrentPagePrev = _numberOfItemsCurrentPage;

            var db = new MyShopDBContext();

            DonHang donHangChon = donHangDataGrid.SelectedItem as DonHang;
            var donHangXoa = db.DonHangs.FirstOrDefault(u => u.DonHangId == donHangChon.DonHangId);

            db.DonHangs.Remove(donHangXoa);
            db.SaveChanges();

            MessageBox.Show($"Successfully deleted DonHang record in SQL Server with DonHangID = {donHangXoa.DonHangId}.");

            // && (_currentPage == pageIndex)
            UpdateDataSource();

            UpdatePagingInfo();
            pagingComboBox.SelectedIndex = pageIndex;
            if ((numberOfItemsCurrentPagePrev == 1) && (_currentPage > 1))
            {
                pagingComboBox.SelectedIndex = pageIndex - 1;
            }
        }

        private void CapNhatDonHangButton_Click(object sender, RoutedEventArgs e)
        {
            int pageIndex = pagingComboBox.SelectedIndex;
            DonHang donHangChon = donHangDataGrid.SelectedItem as DonHang;

            var screen = new CapNhatDonHangWindow(donHangChon);

            if (screen.ShowDialog() == true)
            {
                UpdateDataSource();
                UpdatePagingInfo();
                pagingComboBox.SelectedIndex = pageIndex;
            }
        }

        private void DonHangDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (donHangDataGrid.SelectedItem != null)
            {
                var db = new MyShopDBContext();
                DonHang donHangChon = donHangDataGrid.SelectedItem as DonHang;


                TrangThai = db.TrangThaiDonHangs.Where(u => u.TrangThaiDonHangId == donHangChon.TrangThaiDonHangId).Select(u => u.TrangThai).SingleOrDefault();
                MoTa = db.TrangThaiDonHangs.Where(u => u.TrangThaiDonHangId == donHangChon.TrangThaiDonHangId).Select(u => u.MoTa).SingleOrDefault();

                KhachHangID = db.KhachHangs.Where(u => u.KhachHangId == donHangChon.KhachHangId).Select(u => u.KhachHangId).SingleOrDefault();
                Ten = db.KhachHangs.Where(u => u.KhachHangId == donHangChon.KhachHangId).Select(u => u.Ten).SingleOrDefault();
                SoDienThoai = db.KhachHangs.Where(u => u.KhachHangId == donHangChon.KhachHangId).Select(u => u.SoDienThoai).SingleOrDefault();
                DiaChi = db.KhachHangs.Where(u => u.KhachHangId == donHangChon.KhachHangId).Select(u => u.DiaChi).SingleOrDefault();
                Email = db.KhachHangs.Where(u => u.KhachHangId == donHangChon.KhachHangId).Select(u => u.Email).SingleOrDefault();

                var chiTietDonHang = db.ChiTietDonHangs.Where(u => u.DonHangId == donHangChon.DonHangId).ToList();

                Tong1 = 0;
                for (int i = 0; i < chiTietDonHang.Count; i++)
                {
                    Tong1 += (int)chiTietDonHang[i].Tong;
                }

                var sachesDonHang = new List<Sach>();
                for (int i = 0; i < chiTietDonHang.Count; i++)
                {
                    var sachDonHang = db.Saches.FirstOrDefault(u => u.SachId == chiTietDonHang[i].SachId);
                    sachesDonHang.Add(sachDonHang);
                    sachesDonHang[i].SoLuong = chiTietDonHang[i].SoLuong;
                }

                sachDataGrid.ItemsSource = sachesDonHang.ToList();
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            int i = pagingComboBox.SelectedIndex;
            if (i > 0)
            {
                donHangDataGrid.SelectedItem = null;
                pagingComboBox.SelectedIndex = i - 1;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            int i = pagingComboBox.SelectedIndex;
            if (i < (_totalPages - 1))
            {
                donHangDataGrid.SelectedItem = null;
                pagingComboBox.SelectedIndex = i + 1;
            }
        }

        private void TimKiemButton_Click(object sender, RoutedEventArgs e)
        {
            _timKiemClick = true;
            UpdateDataSource(true);
            UpdatePagingInfo();
            pagingComboBox.SelectedIndex = 0;
            _timKiemClick = false;
        }
    }
}
