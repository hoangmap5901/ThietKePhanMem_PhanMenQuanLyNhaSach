   M S B A M L   `   `   `  ����A  =MyShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyShopMyShop  5   	       MyShop.KhachHangWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:MyShop     5   	   -   5          �Name$  Khach_Hang_Window��5   	    � Title$ Khách Hàng Window��5	   	   $	��500��6#   $	��700��60    � 	Resources 5
      (   "MyShop.RelativeToAbsoluteConverter   absolute��%   &	          5   
   6,   5      .��5      �� .+�5   
   �� $��Quản Lí Khách Hàng��6   $
��Bold"�6.   $��25(�6@    �� Left$	 260��6N   
 �� Top$ 10��6`   $
��Left=�6p   $��Center=�6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��50��6.   $��	10,70,0,0q�6:   .+�5      �� -   5         ��Name$ themKhachHangButton��5       $��5q�6   $��Thêm��6=   $��80��6L   $��35��6W   5      �� 5      -   5        $ xoaKhachHangButton��5       $��5q�6   $
��Xóa��6<   $��80��6J   $��35��6U   $	 144��5   2   $ 18��6D   �� 5      -   5        $ capNhatKhachHangButton��5       $��5q�6   $��80��6@   $��35��6K   $��Cập nhật��6W   $	 245��5   6   $ 18��6H   5      �� 5   
   -   5        $��khachHangListView��5   `   $��Disabled=�6   $��10, 10, 0, 0q�6I   $ 10��6y   $	 129��6�   $	��200��6�   $	��436��6�   $��Center=�6�   $	��Top=�6�   ��5      �� 5      .R�5      �� $ Vertical=�6!   $	��150��68   $	��150��6D   .+�5      �� $��50��6!   $��50��6,   
��� ���$��3q�6M    �� CornerRadius$ 25��6a   ��5      �� 5   "    �� BitmapScalingMode$ HighQuality=�5    -   	 �� ImageSource	 5   -   �� 
 �� Path$
 	ImagePath� �� 	Converter# [  5    -    J� Effect 5"      3  -System.Windows.Media.Effects.DropShadowEffect  5#   "   5%      �� 5&      $ 
Horizontal=�6%   $��15,5,0,0q�6>   .+�5'      �� 
����  �$��20��6T   ��6(   �� $	
 Ten�6T   5(      5)      5*      ��5-      �� 5.      .R�5/      � 50       53        listViewContextMenu m� Icon��%X  &	       �� 54      .@�55      m� -   5        $
��Xóa��55       56      �� 57      $ HighQuality=�6$   $&�� Images/KhachHang/delete_icon.png��6R   59      m� 5:      -   5        $��Cập nhật��5:        5;      �� 5<      $ HighQuality=�6$   $$��Images/KhachHang/edit_icon.png��6R   5>      5?      5@      ��5B      �� 5C       �� 
TargetType" ��6   .�5D      ��  �� Property �@�ContextMenu �� Value# [ 5E      -   5        5H      5J      �� 5L   
   $$��Số Khách Hàng mỗi trang:��6   $	 504��64   $ 83��6F   $��Center=�6V   $	��Top=�6s   �� 5M   
   -	   5        $��rowsPerPageTextBox��5M      $��5,5,0,0q�6T   $	 473��6f   $	 120��6x   $	��188��6�   $��30��6�   $��Center=�6�   $	��Top=�6�   ��6,   �� *RowsPerPage+6�   �� 5N   
   -
   5        $��updateRowsPerPageButton��5N      $��80��60   $��34��6;   $��Cập nhật��6G   $	 527��6�   $	 174��6�   $��Center=�6�   $	��Top=�6�   �� 5P   
   $��Từ khóa tên:��6   $	 504��6(   $	 227��6:   $��Center=�6K   $	��Top=�6h   �� 5Q   
   -   5        $��keywordTextBox��5Q      $��5,5,0,0q�6A   $	��188��6S   $��30��6_   $	 473��6k   $	 256��6}   $��Center=�6�   $	��Top=�6�   ��6(   �� *	Keyword+6�   �� 5R   
   -   5        $��searchButton��5R   ;   $��Tìm kiếm��6   $��80��6$   $��35��6/   $	 527��6j   $	 299��6|   $��Center=�6�   $	��Top=�6�   �� 5T   
   -   5        $��pagingComboBox��5T   F   $	��150��6\   $��35��6h   $	 156��6t   $	 360��6�   $��Center=�6�   $	��Top=�6�   ��5U      �� 5V      .R�5W      �� $ 
Horizontal=�6!   .+�5X      ��  �� Padding$ 30,5,0,0q�6?   ��6$   �� $

 Page�6?   �� 5Y      $��/��6$   $��20��6-   $ 30,5,0,0q�69   �� 5Z      $ 30,5,0,0q�6E   ��6$   �� $
 
TotalPages�6E   5[      5\      5^      �� 5`   
   $ 
Horizontal=�6   $	 133��6.   $	 414��6@   $��Center=�6Q   $	��Top=�6n   .+�5a      �� $��Đang hiển thị ��6   
��� � �6.   �� 5b      $
��Bold"�6g   ��6   �� $
 NumberOfItemsCurrentPage1� �� ElementName$ Khach_Hang_Window��6g   �� 5c      $�� Khách Hàng  / ��6   
��� � �6/   �� 5d      $
��Bold"�6Y   ��6   �� $
 TotalItems1�$ Khach_Hang_Window��6Y   �� 5e      $�� Khách Hàng��6   
��� � �6+   5f      �� 5h   
   -   5        $��
nextButton��5h      $��80��6#   $��35��6.   $
��Next��6S   $	 339��6b   $	 360��6t   $��Center=�6�   $	��Top=�6�   �� 5j   
   -   5        $��previousButton��5j      $��80��6'   $��35��62   $ 43��6[   $	 360��6l   $��Previous��6}   $��Center=�6�   $	��Top=�6�   5l      5m      