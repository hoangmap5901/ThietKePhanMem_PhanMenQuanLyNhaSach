   M S B A M L   `   `   `  ����A  =MyShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyShopMyShop  5   	   #    MyShop.CapNhatKhachHangWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:MyShop     5   	   -   5          � Title$&   Cập Nhật Khách Hàng Window��5   	   $	��700��6,   $	��680��69    � 	Resources 5	      (   "MyShop.RelativeToAbsoluteConverter   absolute��%   &	          5
   
   6,   5      .��5      �� .+�5   
   �� $1��+Nhập Thông Tin Cập Nhật Khách Hàng��6   $
��Bold"�6>   $��25(�6P    �� Left$	 112��6^   
 �� Top$ 48��6p   �� 5   
   $
��Tên��6   $	 110��6   $	 151��61   �� 5   
   -   5         ��Name$ 
tenTextBox��5      $��5,0,0,0q�6@   $	 244��6R   $	 149��6d   $	��312��6u   ��6&   ��  �� Path$	 Ten�6u   �� 5   
   $��Email��6   $	 110��6!   $	 215��63   �� 5   
   -   5        $ emailTextBox��5      $��5,0,0,0q�6D   $	 244��6V   $	 213��6h   $	��312��6y   ��6(   �� $ Email�6y   �� 5   
   $��Địa chỉ��6   $	 110��6#   $	 279��65   �� 5   
   -   5        $ diaChiTextBox��5      $��5,0,0,0q�6F   $	 244��6X   $	 277��6j   $	��312��6{   ��6)   �� $ DiaChi�6{   �� 5   
   $��Số điện thoại��6   $	 110��6)   $	 351��6;   �� 5   
   -   5        $ soDienThoaiTextBox��5      $��5,0,0,0q�6P   $	 244��6b   $	 349��6t   $	��312��6�   ��6.   �� $ SoDienThoai�6�   �� 5   
   $��Hình avatar��6   $	 116��6'   $	 468��69   �� 5   
   -   5         ��Name$ 	imagePath��5       �� BitmapScalingMode$ HighQuality=�5      $	��152��5       $	 244��6   $	��156��6/   $	 400��6;   ��5      �� $ 	ImagePath� �� 	Converter# [  5    ;   �� 5!   
   -   5        	 ��Name$	 chonHinhButton��5!      $��Chọn hình...��6)   $��Center=�6]   $��Center=�6z   $	 486��6�   $	 465��6�   $��70��6�   $��27��6�   �� 5#   
   -   5        $	 capNhatButton��5#      
 �� 	IsDefault$

 True��6(   $��Cập nhật��69   $��Center=�6h   $��Center=�6�   $	 249��6�   $	 601��6�   $��27��6�   $��60��6�   �� 5$   
   -	   5        $	 
dongButton��5$       �� IsCancel$
 True��6%   $��Đóng��65   $��Center=�6D   $��Center=�6a   $	 413��6|   $	 601��6�   $��27��6�   $��60��6�   5%      5&      