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
            if (baoCaoDoanhThuTabItem.IsSelected)
            {
                thangBaoCaoDoanhThuTextBox.DataContext = this;
                namBaoCaoDoanhThuTextBox.DataContext = this;

                var db = new MyShopDBContext();
                var donHangs = db.DonHangs.ToList();

                donHangs = donHangs.OrderBy(u => u.NgayTao.Value.Year).ThenBy(u => u.NgayTao.Value.Month).ToList();

                var doanhThuSeries = new List<int>();

                for (int i = 0; i < donHangs.Count; i++)
                {
                    doanhThuSeries.Add((int)donHangs[i].Tong);
                }

                doanhThuChart.Series.Add(new LineSeries()
                {
                    Title = "Doanh thu tháng",
                    Values = new ChartValues<int>(doanhThuSeries),
                    Stroke = Brushes.Green,
                    StrokeThickness = 2,
                    Fill = new SolidColorBrush(Colors.Orange)
                });

                var dateAxisXDoanhThuChart = new List<string>();

                for (int i = 0; i < donHangs.Count; i++)
                {
                    dateAxisXDoanhThuChart.Add($"{donHangs[i].NgayTao.Value.Month}/{donHangs[i].NgayTao.Value.Year}");
                }

                doanhThuChart.AxisX.Add(new Axis()
                {
                    Labels = new List<string>(dateAxisXDoanhThuChart)
                });

                var sanPhamsBanChay = db.ChiTietDonHangs
                    .GroupBy(x => x.SachId)
                    .Select(u => new { 
                        
                    })
            }

           

        }
    }
}

