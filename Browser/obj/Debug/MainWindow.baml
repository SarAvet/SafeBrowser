   M S B A M L   `   `   `  ����B  >Browser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	        WpfApplication1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	   -   5          � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � WindowState$ 	Maximized=�65    � WindowStyle$
 None=�6M   $��14(�6y   .��5	      � -   5         �Name$
 grid��5	      |�.  � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   (  "System.Windows.Controls.WebBrowser  -   5          Name$ browser��5      $��0,36,0,0q�6&   |�. 68   a� 5   
   -   5         a�Name$ toolBarPanel��5      ���	#FFCFCECE$��	0,0,0,289q�6D   .+�5      c� -   5         c�Name$ toolBar��5      $��36��6'   ���	#FFC9C9C9.@�5      �� -   5         ��Name$ goBack��5      $	��Top=�6*   $��46��6B   	 � Cursor$
	 Hand��6c   $��27��6q   
 � ToolTip$
 
Назад��6}   ��5      �� 5       j� Stretch$ Uniform=�6%    j� TileMode$ FlipX=�67    �� ImageSource$ Resources/GoBack.png��6H   5      �� 5      -   5        $ 	goForward��5      $�� ��6,   $��27��67   $	��Top=�6C   $��49��6[   $
	 Hand��6|   $
 Вперед��6�   ��5      �� 5      $ Resources/GoForward.png��6%   $ Uniform=�6K   5      �� 5      -   5        $ refresh��5      $�� ��6*   $!��25                         ��65   $	��Top=�5       J� RenderTransformOrigin$ 0.999,0.435&�64   $��31��6X   $
��20,0q�6c   {�.  $
	 Hand��6�   $
 Обновить��6�   ��5      �� 5      $ Resources/Refresh.png��6%   $ Uniform=�6I   5       5"      5#      5$      5%      