   M S B A M L   `   `   `  ����A  =MyShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyShopMyShop  5   	       MyShop.DonHangWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:MyShop     5   	   -   5          �Name$  Don_Hang_Window��5   	    � Title$ Đơn Hàng Window��5	   	   $	��600��6!   $
��1200��6.   .��5
      ]� $
��True��6   .+�5   
   ��  �� Orientation$ Vertical=�6   $	��500��6,   
�������$��Right=�6J   .+�5      �� $��Chi Tiết Đơn Hàng��6   $
��Bold"�61   $��20(�6C   
����  �$��170, 10,0,5q�6c   �� 5      $ 
Horizontal=�6   .+�5      �� $��ID Đơn hàng��6   $
��Bold"�6/   $��15(�6A   
��� � �$��15,5,0,0q�6b   �� 5      -   5         ��Name$ idDonHangTextBox��5      $��20,7,0,0q�6s   $	��200��6�   ��66   ��  �� Path$ 	DonHangID� �� ElementName$ Don_Hang_Window��6�   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Trạng thái đơn hàng��6   $
��Bold"�67   $��15(�6I   
��� � �$��	15,10,0,0q�6j   �� 5      -   5        $ trangThaiDonHangTextBox1��5      $��	20,10,0,0q�6{   ��6>   �� $ 	TrangThai�$ Don_Hang_Window��6{   �� 5      $	�� - ��6   $��0,15,0,0q�6'   �� 5      -   5        $ trangThaiDonHangTextBox2��5      $��0,10,0,0q�6v   ��6>   �� $
 MoTa�$ Don_Hang_Window��6v   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��ID khách hàng��6   $
��Bold"�61   $��15(�6C   
��� � �$��15,5,0,0q�6d   �� 5      -   5        $ idKhachHangTextBox��5      $��20,5,0,0q�6w   $	��200��6�   ��68   �� $ KhachHangID�$ Don_Hang_Window��6�   5      �� 5      $ 
Horizontal=�6   .+�5       �� $
��Tên��6   $
��Bold"�6'   $��15(�69   
��� � �$��	15,10,0,0q�6Z   �� 5!      -   5        $ 
tenTextBox��5!      $��	20,10,0,0q�6g   $	��200��6z   ��60   �� $	 Ten�$ Don_Hang_Window��6z   5"      �� 5$      $ 
Horizontal=�6   .+�5%      �� $��Số diện thoại��6   $
��Bold"�61   $��15(�6C   
��� � �$��	15,10,0,0q�6d   �� 5&      -   5        $ soDienThoaiTextBox��5&      $��	20,10,0,0q�6w   $	��200��6�   ��68   �� $ SoDienThoai�$ Don_Hang_Window��6�   5'      �� 5)      $ 
Horizontal=�6   .+�5*      �� $��Địa chỉ��6   $
��Bold"�6+   $��15(�6=   
��� � �$��	15,10,0,0q�6^   �� 5+      -   5        $ diaChiTextBox��5+      $��	20,10,0,0q�6m   $	��200��6�   ��63   �� $ DiaChi�$ Don_Hang_Window��6�   5,      �� 5.      $ 
Horizontal=�6   .+�5/      �� $��Email��6   $
��Bold"�6)   $��15(�6;   
��� � �$��	15,10,0,0q�6\   �� 50      -	   5        $ emailTextBox��50      $��	20,10,0,0q�6k   $	��200��6~   ��62   �� $ Email�$ Don_Hang_Window��6~   51      �� 53      $��Danh sách sách��6   $
��Bold"�6.   $��15(�6@   
��� � �$��
15,10,0,10q�6a   &   System.Windows.Controls.DataGrid  55      -
   5          Name$ sachDataGrid��55      $	��231��6-   $	��412��6:   $   HorizontalScrollBarVisibility$ Visible=�6F   "   VerticalScrollBarVisibility$ Visible=�56      	   
IsReadOnly$
	 True��69   �� 58      $ 
Horizontal=�6   .+�59      �� $��Tổng:��6   $
��Bold"�6)   $��15(�6;   
��� E��$��
15,20,0,10q�6`   �� 5:      -   5        $ tongTextBox��5:      $
��Bold"�6j   $��	20,25,0,0q�6|   $	��150��6�   ��61   �� $ Tong1�$ Don_Hang_Window��6�   �� 5;      $�� đồng��6   $
��Bold"�6)   $��15(�6;   $��	0,20,0,10q�6I   5<      5=      �� 5?   
   $ Vertical=�6   .+�5@      �� $��Quản Lí Đơn Hàng��6   $
��Bold"�60   $��25(�6B   $��
200,10,0,0q�6P   �� 5B      $ 
Horizontal=�6   $��50��62   $��	5, 20,0,0q�6>   $	��Top=�6Q   .+�5C      �� -   5        
 ��Name$
 taoDonHanghButton��5C   $   $��5q�6   $��Tạo��6?   $��80��6M   $��35��6X   5D      �� 5E      -   5        $
 xoaDonHangButton��5E   $   $��5q�6   $
��Xóa��6>   $��80��6L   $��35��6W   5F      �� 5G      -   5        $
 capNhatDonHangButton��5G   $   $��5q�6   $��80��6B   $��35��6M   $��Cập nhật��6Y   5H      5I      �� 5L      $ 
Horizontal=�6   $��15,5,0,0q�62   .+�5N        -   5        $ donHangDataGrid��5N      $	��356��6h   $	��411��6u   $ Visible=�6�   $ Visible=�5O      $
	 True��69   �� 5Q      $ Vertical=�6   $��0,0,0,0q�64   .+�5S      �� $��Tìm kiếm đon hàng:��6    $��	60,15,0,0q�6:   �� 5U      $��Từ ngày:��6    $��	30,15,0,0q�60   (  "System.Windows.Controls.DatePicker  5V      -   5        $��tuNgayDatePicker��5V   !   $��30q�69   $	��175��6E   6S   �� 5W      $��Đến ngày:��6    $��	30,15,0,0q�61     5X      -   5        $��denNgayDatePicker��5X   !   $��30q�6:   6H   �� 5Z      -   5        $
 timKiemButton��5Z   X   $��Tìm kiếm��6   $��80��60   $��30��6;   $��5,5,0,0q�6G   6o   5[      5\      �� 5^      $ 
Horizontal=�6   $��0, 20, 0, 0q�62   .+�5_      �� -   5        $��previousButton��5_      $��80��6/   $��35��6:   $��Previous��6c   $��50, 0, 0, 0q�6v   �� 5a      -   5        $��pagingComboBox��5a   N   $	��150��6d   $��35��6p   $��center=�5b      $��Center=�64   $��
20,0, 0, 0q�6O   ��5c      �� 5d      .R�5e      �� $ 
Horizontal=�6)   .+�5f   "   ��  �� Padding$ 30,5,0,0q�6G   ��6,   �� $
 Page�6G   �� 5g   "   $��/��6,   $��20��65   $ 30,5,0,0q�6A   �� 5h   "   $ 30,5,0,0q�6M   ��6,   �� $ 
TotalPages�6M   5i      5j      5l      �� 5n      -   5        $��
nextButton��5n      $��80��6+   $��35��66   $
��Next��6[   $��20, 0, 0, 0q�6j   5o      �� 5q      $ 
Horizontal=�6   $��120, 15, 0, 0q�62   .+�5r      �� $��Đang hiển thị ��6   
��� ���$
��Bold"�6F   �� 5s      $
��Bold"�6i   ��6   �� $ NumberOfItemsCurrentPage3�$ Don_Hang_Window��6i   �� 5t      $�� Đơn hàng / ��6   
��� ���$
��Bold"�6D   �� 5u      $
��Bold"�6[   ��6   �� $ TotalItems3�$ Don_Hang_Window��6[   �� 5v      $�� Đơn hàng��6   
��� ���$
��Bold"�6A   5w      5x      5y      5z      