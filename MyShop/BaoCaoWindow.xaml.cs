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
using LiveCharts;
using LiveCharts.Wpf;


namespace MyShop
{
    /// <summary>
    /// Interaction logic for BaoCaoWindow.xaml
    /// </summary>
    public partial class BaoCaoWindow : Window
    {
        public string ThangBaoCaoDoanhThu { get; set; } = "";
        public string NamBaoCaoDoanhThu { get; set; } = "";
        public BaoCaoWindow()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (baoCaoDoanhThuSachTabItem.IsSelected)
            {
                thangBaoCaoDoanhThuTextBox.DataContext = this;
                namBaoCaoDoanhThuTextBox.DataContext = this;

                var db = new MyShopDBContext();
                var donHangs = db.DonHangs.ToList();

                donHangs = donHangs.OrderBy(u => u.NgayTao.Value.Year).ThenBy(u => u.NgayTao.Value.Month).ToList();

                var doanhThuSachSeries = new List<int>();

                for (int i = 0; i < donHangs.Count; i++)
                {
                    doanhThuSachSeries.Add((int)donHangs[i].Tong);
                }

                doanhThuSachLineChart.Series.Add(new LineSeries()
                {
                    Title = "Doanh thu sách",
                    Values = new ChartValues<int>(doanhThuSachSeries),
                    Stroke = Brushes.Green,
                    Fill = new SolidColorBrush(Colors.Orange),
                    StrokeDashArray = new DoubleCollection {2}
                });

                var dateAxisXDoanhThuChart = new List<string>();

                for (int i = 0; i < donHangs.Count; i++)
                {
                    dateAxisXDoanhThuChart.Add($"{donHangs[i].NgayTao.Value.Month}/{donHangs[i].NgayTao.Value.Year}");
                }

                doanhThuSachLineChart.AxisX.Add(new Axis()
                {
                    Labels = new List<string>(dateAxisXDoanhThuChart)
                });

                // ---------------

                var chiTietSachesBanChay = db.ChiTietDonHangs
                    .GroupBy(x => x.SachId)
                    .Select(u => new
                    {
                        SachId = u.Key,
                        soLuong = u.Sum(v => v.SoLuong)
                    });

                chiTietSachesBanChay = chiTietSachesBanChay.OrderByDescending(u => u.soLuong);

                var tenSachesBanChay = new List<string>();
                var soLuongSachBanChaySeries = new List<int>();

                foreach (var i in chiTietSachesBanChay)
                {
                    if (tenSachesBanChay.Count == 3)
                    {
                        break;
                    }
                    var sach = db.Saches.FirstOrDefault(u => u.SachId == i.SachId);
                    tenSachesBanChay.Add(sach.Ten);
                    soLuongSachBanChaySeries.Add((int)i.soLuong);
                }

                //doanhThuSachLineChart.Series.Add(new ColumnSeries()
                //{
                //    Title = "Sách bán chạy",
                //    Values = new ChartValues<int>(soLuongSachBanChaySeries),
                //    Stroke = Brushes.Yellow,
                //    StrokeThickness = 2,
                //    Fill = new SolidColorBrush(Colors.Purple)
                //});

                //for (int i = 0; i < tenSachesBanChay.Count; i++)
                //{
                //    soLuongSachPieChart.Series.Add(new ColumnSeries()
                //    {
                //        DataLabels = true,
                //        Title = tenSachesBanChay[i],
                //        Values = new ChartValues<int>() { soLuongSachBanChaySeries[i] },
                //    });
                //}

                doanhThuSachLineChart.Series.Add(new LineSeries()
                {
                    Title = "Doanh thu sách",
                    Values = new ChartValues<int>(doanhThuSachSeries),
                    Stroke = Brushes.Green,
                    Fill = new SolidColorBrush(Colors.Orange),
                    StrokeDashArray = new DoubleCollection { 2 }
                });

            }

            else if (baoCaoSoLuongSachTabItem.IsSelected)
            {
                var db = new MyShopDBContext();

                var chiTietSaches = db.ChiTietDonHangs
                  .GroupBy(x => x.SachId)
                  .Select(u => new
                  {
                      SachId = u.Key,
                      soLuong = u.Sum(v => v.SoLuong)
                  });

                var tenSaches = new List<string>();
                var soLuongBanSaches = new List<int>();
 
                foreach (var i in chiTietSaches)
                {
                    var sach = db.Saches.FirstOrDefault(u => u.SachId == i.SachId);
                    tenSaches.Add(sach.Ten);
                    soLuongBanSaches.Add((int)i.soLuong);
                }

                for (int i = 0; i < tenSaches.Count; i++)
                {
                    soLuongSachPieChart.Series.Add(new PieSeries()
                    {
                        DataLabels = true,
                        Title = tenSaches[i],
                        Values = new ChartValues<int>() { soLuongBanSaches[i] },
                        LabelPoint = point => $"{point.Y} - {point.Participation:P1}"
                    });
                }
            }

           

        }

        private void BaoCaoDoanhThuButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BaoCaoSoLuongSachButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

