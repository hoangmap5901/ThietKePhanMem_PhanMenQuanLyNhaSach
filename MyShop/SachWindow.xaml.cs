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
    /// Interaction logic for SachWindow.xaml
    /// </summary>
    public partial class SachWindow : Window
    {
        public int RowsPerPage { get => _rowsPerPage; set => _rowsPerPage = value; }
        public string Keyword { get; set; } = "";
        public string GiaMin { get; set; } = "";
        public string GiaMax { get; set; } = "";
        int _theLoaiSachIDComboBox;
        int _theLoaiSachSelectedIndexComboBox;
        int _totalItems;
        int _numberOfItemsCurrentPage;
        int _currentPage;
        int _rowsPerPage = 12;
        int _totalPages;
        bool _timSachHetHanClick = false;
        public ThamSo ThayDoiQuyDinh { get; set; } = new ThamSo();

        public static readonly DependencyProperty TotalItemsProperty =
          DependencyProperty.Register("TotalItems2", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty NumberOfItemsCurrentPageProperty =
           DependencyProperty.Register("NumberOfItemsCurrentPage2", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty ImagePathProperty =
          DependencyProperty.Register("ImagePath", typeof(string), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty TenSachProperty =
           DependencyProperty.Register("TenSach", typeof(string), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty TheLoaiSachProperty =
          DependencyProperty.Register("TheLoaiSach", typeof(string), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty TacGiaProperty =
           DependencyProperty.Register("TacGia", typeof(string), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty GiaProperty =
          DependencyProperty.Register("Gia", typeof(int), typeof(Window), new PropertyMetadata(null));

        public static readonly DependencyProperty SoLuongProperty =
        DependencyProperty.Register("SoLuong", typeof(int), typeof(Window), new PropertyMetadata(null));

        public int TotalItems2
        {
            get { return (int)GetValue(TotalItemsProperty); }
            set { SetValue(TotalItemsProperty, value); }
        }

        public int NumberOfItemsCurrentPage2
        {
            get { return (int)GetValue(NumberOfItemsCurrentPageProperty); }
            set { SetValue(NumberOfItemsCurrentPageProperty, value); }
        }

        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        public string TenSach
        {
            get { return (string)GetValue(TenSachProperty); }
            set { SetValue(TenSachProperty, value); }
        }

        public string TheLoaiSach
        {
            get { return (string)GetValue(TheLoaiSachProperty); }
            set { SetValue(TheLoaiSachProperty, value); }
        }

        public string TacGia
        {
            get { return (string)GetValue(TacGiaProperty); }
            set { SetValue(TacGiaProperty, value); }
        }

        public int Gia
        {
            get { return (int)GetValue(GiaProperty); }
            set { SetValue(GiaProperty, value); }
        }

        public int SoLuong
        {
            get { return (int)GetValue(SoLuongProperty); }
            set { SetValue(SoLuongProperty, value); }
        }

        public SachWindow(ThamSo data)
        {
            InitializeComponent();

            ThayDoiQuyDinh.SoLuongSachNhapToiThieu = data.SoLuongSachNhapToiThieu;
            ThayDoiQuyDinh.SoLuongSachTonToiDaDeNhapSach = data.SoLuongSachTonToiDaDeNhapSach;
            ThayDoiQuyDinh.SoLuongSachTonToiThieuSauKhiBan = data.SoLuongSachTonToiThieuSauKhiBan;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rowsPerPageTextBox.DataContext = this;
            keywordTextBox.DataContext = this;
            giaMinTextBox.DataContext = this;
            giaMaxTextBox.DataContext = this;

            _currentPage = 1;

            var db = new MyShopDBContext();
            var theLoais = db.TheLoais.ToList();
            theLoaiSachComboBox.ItemsSource = theLoais;

            theLoaiSachComboBox.SelectedIndex = 0;
            //_theLoaiSachIDComboBox = 1;
            //_theLoaiSachSelectedIndexComboBox = 0;

            UpdateDataSource();
            UpdatePagingInfo();
            pagingComboBox.SelectedIndex = 0;
        }

        void UpdateDataSource(bool timSachSapHetHang = false)
        {
            //theLoaiSachComboBox.SelectedIndex = _theLoaiSachSelectedIndexComboBox;
            var db = new MyShopDBContext();
            var saches = db.Saches.ToList();

            if (_theLoaiSachSelectedIndexComboBox != 0)
            {
                saches = saches.Where(sach => sach.TheLoaiId == _theLoaiSachIDComboBox).ToList();
            }


            if (timSachSapHetHang == true)
            {
                saches = saches.Where(sach => sach.SoLuong < 5).ToList();
            }

            saches = saches.Where(sach => sach.Ten.Contains(Keyword)).ToList();

            if (GiaMin != "" && GiaMax != "")
            {
                int giaMin = int.Parse(GiaMin);
                int giaMax = int.Parse(GiaMax);
                saches = saches.Where(sach => sach.Gia >= giaMin && sach.Gia <= giaMax).ToList();
            }

            _totalItems = saches.Count();
            TotalItems2 = _totalItems;


            var sachesRowsPerPage = saches.Skip((_currentPage - 1) * RowsPerPage).Take(RowsPerPage);
            _numberOfItemsCurrentPage = sachesRowsPerPage.Count();
            NumberOfItemsCurrentPage2 = _numberOfItemsCurrentPage;

            sachDataGrid.ItemsSource = sachesRowsPerPage;
        }

        void UpdatePagingInfo()
        {
            _totalPages = _totalItems / RowsPerPage + (_totalItems % RowsPerPage == 0 ? 0 : 1);

            var pagingInfo = new PagingInfo(_totalPages);

            pagingComboBox.ItemsSource = pagingInfo.Items;
        }

        private void TheLoaiSachComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var theLoaiSach = theLoaiSachComboBox.SelectedItem as TheLoai;
            _theLoaiSachIDComboBox = theLoaiSach.TheLoaiId;

            var db = new MyShopDBContext();
            var theLoais = db.TheLoais.ToList();

            for (int i = 0; i < theLoais.Count; i++)
            {
                if (theLoais[i].TheLoaiId == _theLoaiSachIDComboBox)
                {
                    _theLoaiSachSelectedIndexComboBox = i;
                    break;
                    //UpdatePagingInfo();
                    //pagingComboBox.SelectedIndex = 0;
                }
            }

            UpdateDataSource();
            UpdatePagingInfo();
            pagingComboBox.SelectedIndex = 0;
        }

        private void PagingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = pagingComboBox.SelectedIndex;

            if (i >= 0)
            {
                _currentPage = i + 1;
                if (_timSachHetHanClick == true)
                {
                    UpdateDataSource(true);
                }
                else
                {
                    UpdateDataSource();
                }
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sachDataGrid.SelectedItem != null)
            {
                Sach sachChon = sachDataGrid.SelectedItem as Sach;

                ImagePath = sachChon.ImagePath;
                TenSach = sachChon.Ten;
                TacGia = sachChon.TacGia;
                Gia = (int)sachChon.Gia;
                SoLuong = (int)sachChon.SoLuong;

                var db = new MyShopDBContext();
                TheLoaiSach = db.TheLoais.Where(u => u.TheLoaiId == sachChon.TheLoaiId).Select(u => u.Ten).SingleOrDefault();
            }
        }

        private void ThemSachButton_Click(object sender, RoutedEventArgs e)
        {
            int pageIndex = pagingComboBox.SelectedIndex;
            var screen = new ThemSachWindow();
            int numberOfItemsCurrentPagePrev = _numberOfItemsCurrentPage;

            if (screen.ShowDialog() == true)
            {
                UpdateDataSource();
                UpdatePagingInfo();
                if (numberOfItemsCurrentPagePrev == RowsPerPage)
                {
                    pagingComboBox.SelectedIndex = pageIndex + 1;
                }
            }
        }

        private void XoaSachButton_Click(object sender, RoutedEventArgs e)
        {
            int pageIndex = pagingComboBox.SelectedIndex;
            int numberOfItemsCurrentPagePrev = _numberOfItemsCurrentPage;

            var db = new MyShopDBContext();

            Sach sachChon = sachDataGrid.SelectedItem as Sach;
            var sachXoa = db.Saches.FirstOrDefault(u => u.SachId == sachChon.SachId);

            db.Saches.Remove(sachXoa);
            db.SaveChanges();

            MessageBox.Show($"Successfully deleted Sach record in SQL Server with SachID = {sachXoa.SachId}.");

            // && (_currentPage == pageIndex)
            UpdateDataSource();

            UpdatePagingInfo();
            pagingComboBox.SelectedIndex = pageIndex;
            if ((numberOfItemsCurrentPagePrev == 1) && (_currentPage > 1))
            {
                pagingComboBox.SelectedIndex = pageIndex - 1;
            }
        }

        private void CapNhatSachButton_Click(object sender, RoutedEventArgs e)
        {
            int pageIndex = pagingComboBox.SelectedIndex;

            Sach sachChon = sachDataGrid.SelectedItem as Sach;

            var screen = new CapNhatSachWindow(sachChon, ThayDoiQuyDinh);

            if (screen.ShowDialog() == true)
            {
                UpdateDataSource();
                UpdatePagingInfo();
                pagingComboBox.SelectedIndex = pageIndex;
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            int i = pagingComboBox.SelectedIndex;
            if (i > 0)
            {
                sachDataGrid.SelectedItem = null;
                pagingComboBox.SelectedIndex = i - 1;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            int i = pagingComboBox.SelectedIndex;
            if (i < (_totalPages - 1))
            {
                sachDataGrid.SelectedItem = null;
                pagingComboBox.SelectedIndex = i + 1;
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
        }

        private void FilterPriceButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataSource();
            UpdatePagingInfo();
            pagingComboBox.SelectedIndex = 0;
        }

        private void TimSachHetHanButton_Click(object sender, RoutedEventArgs e)
        {
            _timSachHetHanClick = true;
            UpdateDataSource(true);
            UpdatePagingInfo();
            pagingComboBox.SelectedIndex = 0;
            _timSachHetHanClick = false;
        }
    }
}
