   M S B A M L   `   `   `  ����A  =MyShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyShopMyShop  5   	   !    MyShop.ThayDoiQuyDinhWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:MyShop     5   	   -   5          � Title$$  Thay Đổi Quy Định Window��5   	   $	��450��6*   $	��680��67    � 	Resources 5	      (   "MyShop.RelativeToAbsoluteConverter   absolute��%   &	          5
   
   6,   5      .��5      �� .+�5   
   �� $/��)Nhập Thông Tin Thay Đổi Quy Định��6   $
��Bold"�6<   $��25(�6N    �� Left$	 131��6\   
 �� Top$ 51��6n   �� 5   
   $.��(Số lượng sách nhập tối thiểu��6   $	 110��68   $	 151��6J   �� 5   
   -   5         ��Name$$ soLuongSachNhapToiThieuTextBox��5      $��5,0,0,0q�6u   $	 348��6�   $	 149��6�   $	��312��6�   $
��Left=�6�   $��Center=�6�   ��6:   ��  �� Path$ SoLuongSachNhapToiThieu�6�   �� 5   
   $<��6Số lượng sách tồn tối đa để nhập sách��6   $	 110��6A   $	 215��6S   �� 5   
   -   5        $* $soLuongSachTonToiDaDeNhapSachTextBox��5      $��5,0,0,0q�6�   $	 348��6�   $	 213��6�   $	��312��6�   $
��Left=�6�   $��Center=�6�   ��6@   �� $# SoLuongSachTonToiDaDeNhapSach�6�   �� 5   
   $:��4Số lượng sách tồn tối thiểu sau khi bán��6   $	 110��6C   $	 279��6U   �� 5   
   -   5        $, &soLuongSachTonToiThieuSauKhiBanTextBox��5      $��5,0,0,0q�6�   $	 348��6�   $	 277��6�   $	��312��6�   $
��Left=�6�   $��Center=�6�   ��6B   �� $% SoLuongSachTonToiThieuSauKhiBan�6�   �� 5   
   -   5         ��Name$ thayDoiButton��5       �� 	IsDefault$
 True��6(   $��Thay đổi��69   $
��Left=�6h   $	��Top=�6�   $	 242��6�   $	 342��6�   $��27��6�   $��60��6�   �� 5   
   -   5        $ 
dongButton��5       �� IsCancel$
 True��6%   $��Đóng��65   $
��Left=�6D   $	��Top=�6_   $	 406��6w   $	 342��6�   $��27��6�   $��60��6�   5      5      