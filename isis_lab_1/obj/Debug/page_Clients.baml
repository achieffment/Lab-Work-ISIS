   M S B A M L   `   `   `  ����E  Aisis_lab_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:isis_lab_1
isis_lab_1  5          isis_lab_1.page_Clients   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:isis_lab_1     5      -   5        $
��auto��5      $
��auto��6     N� Title$  Страница 1��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5         AutoGenerateColumns .     
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6S   $��0��6c      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ID+6J     5      $ 	FirstName��6%    68   �� *	FirstName+6X     5      $ LastName��6%    67   �� *
LastName+6V     5      $ 
Patronymic��6%    69   �� *
Patronymic+6Z     5      $ Birthday��6%    67   �� *
Birthday+6V     5      $ RegistrationDate��6%    6?   �� *RegistrationDate+6f     5      $ Email��6%    64   �� *Email+6P     5      $ Phone��6%    64   �� *Phone+6P     5      $ 
GenderCode��6%    69   �� *
GenderCode+6Z     5      $ 	PhotoPath��6%    68   �� *	PhotoPath+6X   4  .System.Windows.Controls.DataGridTemplateColumn  5      	   CellTemplate	 5      �� 5      .R�5      �� $��btnEdit��64   -   5        $
��Edit��5   %   6[   5       5"      5$      �� 5%   
   -   5        $��addBtn��5%      $	��Add��6   $��1��6-   $��15q�6:   $
��Left=�6F   $��Center=�6a   6�   �� 5&   
   -   5        $��rmvBtn��5&   "   $��Remove��6   $��1��60   $��15q�6=   $��Right=�6I   $��Center=�6e   6�   5'      5(      