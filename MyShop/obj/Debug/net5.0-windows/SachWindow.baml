   M S B A M L   `   `   `  ����A  =MyShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyShopMyShop  5   	       MyShop.SachWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:MyShop     5   	   -   5          �Name$  Sach_Window��5   	    � Title$ Sách Window��5	   	   $	��650��6   $
��1200��6*    � 	Resources 5
      (   "MyShop.RelativeToAbsoluteConverter   absolute��%   &	          5   
   6,   5      .��5      ]� $
��True��6   .+�5   
   ��  �� Orientation$ Vertical=�6   $	��350��6,   
������$��Right=�6P   .+�5      �� $��Thông Tin Sách��6   $
��Bold"�6.   $��20(�6@   
���**��$��100, 10,0,5q�6a   �� 5      -   5         ��Name$ 	imagePath��5       �� BitmapScalingMode$ HighQuality=�5      $	��210��5      $	��200��6   ��5      ��  �� Path$ 	ImagePath� �� 	Converter# [   �� ElementName$ Sach_Window��5      �� 5      $��
Tên sách��6   $
��Bold"�6(   $��15(�6:   
���� ��$��15,5,0,0q�6\   �� 5      -   5        	 ��Name$	 
tenTextBox��5      $��0,5,0,0q�6c   $	��315��6t   ��6,   �� $ TenSach�$ Sach_Window��6t   �� 5      $��Thể loại sách��6   $
��Bold"�6-   $��15(�6?   
���� ��$��	15,20,0,0q�6a   �� 5      -   5        $	 theLoaiextBox��5      $��0,5,0,0q�6j   $	��315��6{   ��6/   �� $ TheLoaiSach�$ Sach_Window��6{   �� 5      $��
Tác giả��6   $
��Bold"�6'   $��15(�69   
���� ��$��	15,20,0,0q�6[   �� 5      -   5        $	 tacGiaTextBox��5      $��0,5,0,0q�6e   $	��315��6v   ��6/   �� $ TacGia�$ Sach_Window��6v   �� 5      $
��Giá��6   $
��Bold"�6#   $��15(�65   
���� ��$��	15,20,0,0q�6W   �� 5      $ 
Horizontal=�6   .+�5       �� -   5        $	 
giaTextBox��5       $��15,5,0,0q�6c   $	��100��6u   ��60   �� $	 Gia�$ Sach_Window��6u   �� 5!      $�� đồng��6   $��0,5,0,0q�6)   $	��315��6:   5"      �� 5$      $��Số lượng��6   $
��Bold"�6(   $��15(�6:   
���� ��$��	15,20,0,0q�6\   �� 5%      -   5        $	 soLuongTextBox��5%      $��0,5,0,0q�6g   $	��315��6x   ��60   �� $ SoLuong�$ Sach_Window��6x   5&      �� 5(   
   $ Vertical=�6   .+�5)      �� $��Quản Lí Sách��6   $
��Bold"�6,   $��25(�6>   $��
350,10,0,0q�6L   �� 5+      $ 
Horizontal=�6   $��50��62   $��	5, 20,0,0q�6>   $	��Top=�6Q   .+�5,      �� -   5        
 ��Name$
 themSachButton��5,   $   $��5q�6   $��Thêm��6<   $��80��6K   $��35��6V   5-      �� 5.      -	   5        $
 xoaSachButton��5.   $   $��5q�6   $
��Xóa��6;   $��80��6I   $��35��6T   5/      �� 50      -
   5        $
 capNhatSachButton��50   $   $��5q�6   $��80��6?   $��35��6J   $��Cập nhật��6V   51      �� 52      -   5        $
 timSachHetHangButton��52   $   $��5q�6   $	��122��6B   $��35��6N   $��Tìm sách hết hàng��6Z   53      54      �� 56      $ 
Horizontal=�6   $��0, 10, 0, 0q�62   .+�57      �� $��Thể loại sách:��6   $��5,5,0,0q�62   $��88��6C   �� 59      -   5        $��theLoaiSachComboBox��59   S   $	��250��6n   $��26��6z   $��Center=�6�   ��5:      �� 5;      .R�5<      ��  �� Padding$ 0,0,0,0q�6B   ��6(   �� $	 Ten�6B   5=      5?      5@      �� 5B      $ 
Horizontal=�6   $��15,5,0,0q�62   .+�5D      &   System.Windows.Controls.DataGrid  -   5          Name$ sachDataGrid��5D      $	��356��6^   $	��411��6k   $   HorizontalScrollBarVisibility$ Visible=�6w   "   VerticalScrollBarVisibility$ Visible=�5E         
IsReadOnly$
 True��69   �� 5G      $ Vertical=�6   $��0,0,0,0q�64   .+�5H      �� $��Số Sách mỗi trang:��6    $��	140,0,0,0q�6:   �� 5I      -   5         ��Name$ rowsPerPageTextBox��5I      $��5,5,0,0q�6b   $��5,15,0,0q�6t   $��52��6�   $��30��6�   ��6:   �� *RowsPerPage+6�   �� 5J      -   5        $
 updateRowsPerPageButton��5J      $��80��6>   $��30��6I   $��Cập nhật��6U   $��5,15,0,0q�6h   6z   �� 5L      $��Từ khóa tên sách:��6    $��
140,15,0,0q�69   �� 5M      -   5        $ keywordTextBox��5M      $��5,5,0,0q�6O   $��5,15,0,0q�6a   $	��230��6s   $��30��6   ��66   �� *	Keyword+6   �� 5N      -   5        $
 searchButton��5N   Y   $��Tìm kiếm��6   $��80��60   $��30��6;   $��5,15,0,0q�6G   6o   �� 5P      $%��Lọc sách theo khoảng giá:��6    $��
120,15,0,0q�6A   �� 5Q      $ 
Horizontal=�6!   $��50��6:   $��5,15,0,0q�6F   .+�5R      �� $��	Giá min:��6$   $��	30,15,0,0q�64   �� 5S      -   5        $ giaMinTextBox��5S   "   $��5,5,0,0q�6Q   $��5,0,0,0q�6c   $	��100��6t   $��30��6�   ��69   �� *GiaMin+6�   �� 5T      $��	Giá max:��6$   $��	50,15,0,0q�64   �� 5U      -   5        $ giaMaxTextBox��5U   "   $��5,5,0,0q�6Q   $��5,0,0,0q�6c   $	��100��6t   $��30��6�   ��69   �� *GiaMax+6�   5V      �� 5W      -   5        $
 priceFilterButton��5W   S   $��Lọc��6   $��80��6+   $��30��66   $��5,5,0,0q�6B   6n   5X      5Y      �� 5[      $ 
Horizontal=�6   $��0, 20, 0, 0q�62   .+�5\      �� -   5        $��previousButton��5\      $��80��6/   $��35��6:   $��Previous��6c   $��50, 0, 0, 0q�6v   �� 5^      -   5        $��pagingComboBox��5^   N   $	��150��6d   $��35��6p   $��center=�5_      $��Center=�64   $��
20,0, 0, 0q�6O   ��5`      �� 5a      .R�5b      �� $ 
Horizontal=�6)   .+�5c   "   �� $ 30,5,0,0q�6G   ��6,   �� $
 Page�6G   �� 5d   "   $��/��6,   $��20��65   $ 30,5,0,0q�6A   �� 5e   "   $ 30,5,0,0q�6M   ��6,   �� $ 
TotalPages�6M   5f      5g      5i      �� 5k      -   5        $��
nextButton��5k      $��80��6+   $��35��66   $
��Next��6[   $��20, 0, 0, 0q�6j   5l      �� 5n      $ 
Horizontal=�6   $��150, 15, 0, 0q�62   .+�5o      �� $��Đang hiển thị ��6   
��� ���$
��Bold"�6F   �� 5p      $
��Bold"�6e   ��6   �� $ NumberOfItemsCurrentPage2�$ Sach_Window��6e   �� 5q      $��	 Sách / ��6   
��� ���$
��Bold"�6@   �� 5r      $
��Bold"�6W   ��6   �� $ TotalItems2�$ Sach_Window��6W   �� 5s      $�� Sách��6   
��� ���$
��Bold"�6=   5t      5u      5v      5w      