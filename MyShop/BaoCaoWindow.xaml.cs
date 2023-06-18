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

        public string ThangBaoCaoSach { get; set; } = "";
        public string NamBaoCaoSach { get; set; } = "";
        public BaoCaoWindow()
        {
            InitializeComponent();
        }


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (baoCaoDoanhThuSachTabItem.IsSelected)
            {
                doanhThuSachLineChart.Series.Clear();
                doanhThuSachLineChart.AxisX.Clear();







                // ---------------



                if ((NamBaoCaoDoanhThu != "") || (ThangBaoCaoDoanhThu != "" && NamBaoCaoDoanhThu != ""))
                {
                    var db = new MyShopDBContext();

                    int thangBaoCaoDoanhThu = 0;
                    int namBaoCaoDoanhThu = 0;
                    if (ThangBaoCaoDoanhThu != "")
                    {
                        thangBaoCaoDoanhThu = int.Parse(ThangBaoCaoDoanhThu);
                    }
                    if (NamBaoCaoDoanhThu != "")
                    {
                        namBaoCaoDoanhThu = int.Parse(NamBaoCaoDoanhThu);
                    }

                    var donHangs = db.DonHangs.ToList();
                    var chiTietDonHangs = db.ChiTietDonHangs.ToList();

                    if (ThangBaoCaoDoanhThu != "" && NamBaoCaoDoanhThu != "")
                    {

                        donHangs = donHangs.Where(u => u.NgayTao.Value.Month == thangBaoCaoDoanhThu && u.NgayTao.Value.Year == namBaoCaoDoanhThu).ToList();
                        donHangs = donHangs.OrderBy(u => u.NgayTao.Value.Year).ThenBy(u => u.NgayTao.Value.Month).ThenBy(u => u.NgayTao.Value.Day).ToList();

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
                            StrokeDashArray = new DoubleCollection { 2 }
                        });

                        var dateAxisXDoanhThuChart = new List<string>();

                        for (int i = 0; i < donHangs.Count; i++)
                        {
                            dateAxisXDoanhThuChart.Add($"{donHangs[i].NgayTao.Value.Day}/{donHangs[i].NgayTao.Value.Month}/{donHangs[i].NgayTao.Value.Year}");
                        }

                        doanhThuSachLineChart.AxisX.Add(new Axis()
                        {
                            Labels = new List<string>(dateAxisXDoanhThuChart)
                        });

                        var donHangs1 = db.DonHangs.Where(u => u.NgayTao.Value.Month == thangBaoCaoDoanhThu && u.NgayTao.Value.Year == namBaoCaoDoanhThu).Select(u => u.DonHangId).ToList();

                        var chiTietDonHangBaoCao = new List<ChiTietDonHang>();
                        for (int i = 0; i < chiTietDonHangs.Count; i++)
                        {
                            if (donHangs1.Contains((int)chiTietDonHangs[i].DonHangId))
                            {
                                chiTietDonHangBaoCao.Add(chiTietDonHangs[i]);
                            }
                        }

                        var chiTietSaches = chiTietDonHangBaoCao
                                                                .GroupBy(x => x.SachId)
                                                                .Select(u => new
                                                                {
                                                                    SachId = u.Key,
                                                                    soLuong = u.Sum(v => v.SoLuong)
                                                                }).OrderByDescending(y => y.soLuong);
                        

                        var tenSaches = new List<string>();
                        var soLuongBanSaches = new List<int>();

                        foreach (var i in chiTietSaches)
                        {
                            if (tenSaches.Count == 3)
                            {
                                break;
                            }
                            var sach = db.Saches.FirstOrDefault(u => u.SachId == i.SachId);
                            tenSaches.Add(sach.Ten);
                            soLuongBanSaches.Add((int)i.soLuong);
                        }


                        for (int i = 0; i < tenSaches.Count; i++)
                        {
                            doanhThuSachLineChart.Series.Add(new ColumnSeries()
                            {
                                DataLabels = true,
                                Title = tenSaches[i],
                                Values = new ChartValues<int>() { soLuongBanSaches[i] },
                            });
                        }


                    }

                    else if (NamBaoCaoDoanhThu != "")
                    {
                        donHangs = donHangs.Where(u => u.NgayTao.Value.Year == namBaoCaoDoanhThu).ToList();
                        donHangs = donHangs.OrderBy(u => u.NgayTao.Value.Year).ThenBy(u => u.NgayTao.Value.Month).ThenBy(u => u.NgayTao.Value.Day).ToList();

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
                            StrokeDashArray = new DoubleCollection { 2 }
                        });

                        var dateAxisXDoanhThuChart = new List<string>();

                        for (int i = 0; i < donHangs.Count; i++)
                        {
                            dateAxisXDoanhThuChart.Add($"{donHangs[i].NgayTao.Value.Day}/{donHangs[i].NgayTao.Value.Month}/{donHangs[i].NgayTao.Value.Year}");
                        }

                        doanhThuSachLineChart.AxisX.Add(new Axis()
                        {
                            Labels = new List<string>(dateAxisXDoanhThuChart)
                        });

                        var donHangs1 = db.DonHangs.Where(u => u.NgayTao.Value.Year == namBaoCaoDoanhThu).Select(u => u.DonHangId).ToList();

                        var chiTietDonHangBaoCao = new List<ChiTietDonHang>();
                        for (int i = 0; i < chiTietDonHangs.Count; i++)
                        {
                            if (donHangs1.Contains((int)chiTietDonHangs[i].DonHangId))
                            {
                                chiTietDonHangBaoCao.Add(chiTietDonHangs[i]);
                            }
                        }

                        var chiTietSaches = chiTietDonHangBaoCao
                                                                .GroupBy(x => x.SachId)
                                                                .Select(u => new
                                                                {
                                                                    SachId = u.Key,
                                                                    soLuong = u.Sum(v => v.SoLuong)
                                                                }).OrderByDescending(y => y.soLuong);


                        var tenSaches = new List<string>();
                        var soLuongBanSaches = new List<int>();

                        foreach (var i in chiTietSaches)
                        {
                            if (tenSaches.Count == 3)
                            {
                                break;
                            }
                            var sach = db.Saches.FirstOrDefault(u => u.SachId == i.SachId);
                            tenSaches.Add(sach.Ten);
                            soLuongBanSaches.Add((int)i.soLuong);
                        }


                        for (int i = 0; i < tenSaches.Count; i++)
                        {
                            doanhThuSachLineChart.Series.Add(new ColumnSeries()
                            {
                                DataLabels = true,
                                Title = tenSaches[i],
                                Values = new ChartValues<int>() { soLuongBanSaches[i] },
                            });
                        }

                    }





                }
            }

            else if (baoCaoSoLuongSachTabItem.IsSelected)
            {
                soLuongSachPieChart.Series.Clear();

                if ((NamBaoCaoSach != "") || (ThangBaoCaoSach != "" && NamBaoCaoSach != ""))
                {
                    var db = new MyShopDBContext();

                    int thangBaoCaoSach = 0;
                    int namBaoCaoSach = 0;
                    if (ThangBaoCaoSach != "")
                    {
                        thangBaoCaoSach = int.Parse(ThangBaoCaoSach);
                    }
                    if (NamBaoCaoSach != "")
                    {
                        namBaoCaoSach = int.Parse(NamBaoCaoSach);
                    }


                    var chiTietDonHangs = db.ChiTietDonHangs.ToList();
                    


                    if (ThangBaoCaoSach != "" && NamBaoCaoSach != "")
                    {

                        var donHangs = db.DonHangs.Where(u => u.NgayTao.Value.Month == thangBaoCaoSach && u.NgayTao.Value.Year == namBaoCaoSach).Select(u => u.DonHangId).ToList();

                        var chiTietDonHangBaoCao = new List<ChiTietDonHang>();
                        for (int i = 0; i < chiTietDonHangs.Count; i++)
                        {
                            if (donHangs.Contains((int)chiTietDonHangs[i].DonHangId))
                            {
                                chiTietDonHangBaoCao.Add(chiTietDonHangs[i]);
                            }
                        }

                        var chiTietSaches = chiTietDonHangBaoCao
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

                    else if (NamBaoCaoSach != "")
                    {
                        var donHangs = db.DonHangs.Where(u => u.NgayTao.Value.Year == namBaoCaoSach).Select(u => u.DonHangId).ToList();

                        var chiTietDonHangBaoCao = new List<ChiTietDonHang>();
                        for (int i = 0; i < chiTietDonHangs.Count; i++)
                        {
                            if (donHangs.Contains((int)chiTietDonHangs[i].DonHangId))
                            {
                                chiTietDonHangBaoCao.Add(chiTietDonHangs[i]);
                            }
                        }

                        var chiTietSaches = chiTietDonHangBaoCao
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


            }



        }

        private void BaoCaoDoanhThuButton_Click(object sender, RoutedEventArgs e)
        {
            ThangBaoCaoDoanhThu = thangBaoCaoDoanhThuTextBox.Text;
            NamBaoCaoDoanhThu = namBaoCaoDoanhThuTextBox.Text;
            doanhThuSachLineChart.Series.Clear();
            doanhThuSachLineChart.AxisX.Clear();
            soLuongSachPieChart.Series.Clear();
            baoCaoTabControl.SelectedIndex = 1;
            baoCaoTabControl.SelectedIndex = 0;
        }

        private void BaoCaoSoLuongSachButton_Click(object sender, RoutedEventArgs e)
        {
            ThangBaoCaoSach = thangBaoCaoSoLuongSachTextBox.Text;
            NamBaoCaoSach = namBaoCaoSoLuongSachTextBox.Text;
            doanhThuSachLineChart.Series.Clear();
            doanhThuSachLineChart.AxisX.Clear();
            soLuongSachPieChart.Series.Clear();
            baoCaoTabControl.SelectedIndex = 0;
            baoCaoTabControl.SelectedIndex = 1;
        }


    }
}

