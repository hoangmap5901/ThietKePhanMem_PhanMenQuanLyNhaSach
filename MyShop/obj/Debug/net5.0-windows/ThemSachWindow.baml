   M S B A M L   `   `   `  ����A  =MyShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyShopMyShop  5   	       MyShop.ThemSachWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:MyShop     5   	   -   5          � Title$  Thêm Sách Window��5   	   $	��800��6"   $	��680��6/    � 	Resources 5	      (   "MyShop.RelativeToAbsoluteConverter   absolute��%   &	          5
   
   6,   5      .��5      �� .+�5   
   �� $#��Nhập Thông Tin Thêm Sách��6   $
��Bold"�64   $��25(�6F    �� Left$	 181��6T   
 �� Top$ 24��6f   �� 5   
   $
��Tên��6   $	 110��6   $	 151��61   �� 5   
   -   5         ��Name$ 
tenTextBox��5      $��5,0,0,0q�6@   $	 244��6R   $	 149��6d   $	��312��6u   ��6&   ��  �� Path$	 Ten�6u   �� 5   
   $��Thể loại sách��6   $	 110��6)   $	 213��6;   �� 5   
   -   5        $��theLoaiSachComboBox��5   K   $	��300��6f   $��25��6r   $	 250��6~   $	 213��6�   $��center=�6�   $��Center=�6�   ��5      �� 5      .R�5      ��  �� Padding$ 0,0,0,0q�6:   ��6    �� $	 Ten�6:   5      5      �� 5   
   $��
Tác giả��6   $	 110��6#   $	 283��65   �� 5   
   -   5        $ tacGiaTextBox��5      $��5,0,0,0q�6F   $	 244��6X   $	 281��6j   $	��312��6{   ��6)   �� $ TacGia�6{   �� 5   
   $
��Giá��6   $	 110��6   $	 347��61   �� 5   
   -   5        $ 
giaTextBox��5      $��5,0,0,0q�6@   $	 244��6R   $	 345��6d   $	��312��6u   ��6&   �� $	 Gia�6u   �� 5!   
   $��Số lượng��6   $	 110��6$   $	 419��66   �� 5"   
   -   5        $ soLuongTextBox��5"      $��5,0,0,0q�6H   $	 244��6Z   $	 417��6l   $	��312��6}   ��6*   �� $ SoLuong�6}   �� 5$   
   $��Hình bìa sách��6   $	 116��6)   $	 536��6;   �� 5%   
   -   5         ��Name$ 	imagePath��5%       �� BitmapScalingMode$ HighQuality=�5(      $	��152��5)      $	 244��6   $	��156��6/   $	 468��6;   ��5'      �� $ 	ImagePath�	 �� 	Converter#	 [  5)   ;   �� 5*   
   -   5        
 ��Name$
 chonHinhButton��5*      $��Chọn hình...��6)   $	 486��6]   $	 533��6o   $��70��6�   $��27��6�   �� 5,   
   -	   5        $
 
themButton��5,       �� 	IsDefault$
 True��6%   $��Thêm��66   $	 249��6^   $	 669��6p   $��27��6�   $��50��6�   �� 5-   
   -
   5        $
 
dongButton��5-       �� IsCancel$
 True��6%   $��Đóng��65   $	 413��6D   $	 669��6V   $��27��6g   $��50��6s   5.      5/      