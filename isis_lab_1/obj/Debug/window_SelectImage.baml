   M S B A M L   `   `   `  ����E  Aisis_lab_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:isis_lab_1
isis_lab_1  5   	   #    isis_lab_1.window_SelectImage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:isis_lab_1     5   	     � Title$  window_SelectImage��5   	   $
��auto��6$   $
��auto��61   $	��600��5	      $	��400��6   .��5
      �  � RowDefinitions 5   
   �� 5      $
��0.2* �6   6,   �� 5      6   �� 5      $
��0.2* �6   6,    � ColumnDefinitions 5   
   �� 5      $
��0.2* �6   6.   �� 5      6!   �� 5      $
��0.2* �6   6.   .+�5   
   � $��1��6   $��1��6    5      �� 5      6"   �� 5      $
��0.1* �6    60   .+�5      �� -   5        $��listView_images��5      $��Disabled=�6.   $��Center=�6d    %� IsVirtualizing .  ��5      �� 5      .R�5      �  � Orientation$ 
Horizontal=�6$   $��Center=�6=   6\   5       ��5"      �� 5#      .R�5$      �� $	��200��6    ��5%      �� 5&   "    �� Path$ 	PhotoPath�6*   5'   #   5)      5*      5,      � 5.      $��1��6    5/      �� 50      6)   �� 51      6)   �� 52      6)   .+�54      �� -   5        $��btn_Save��54   -   $��Сохранить��6   $��5q�6T   6a   �� 55      -   5        $��
btn_Cancel��55   ,   $��Отменить��6   $��1��6W   $��5q�6g   6t   �� 56      -   5        $��btn_Load��56   -   $��Загрузить��6   $��2��6T   $��5q�6d   6q   57      58      59      5:      