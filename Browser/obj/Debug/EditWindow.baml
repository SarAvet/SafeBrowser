   M S B A M L   `   `   `  ����B  >Browser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	        WpfApplication1.EditWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	   -   5          � Title$  
EditWindow��5   	   $	��300��6   $	��300��6)    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ NoResize=�6Z    � Icon$ Resources/Edit.ico��6�   $��14(�6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ urlName��5      $
��Left=�6#   $��23��6>   $��	24,49,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��238��6�   6�   �� 5   
   -   5        $ urlHref��5      $
��Left=�6#   $��23��6>   $��
24,130,0,0q�6J   $
 Wrap=�6^   $	��Top=�6r   $	��238��6�   6�   �� 5   
   -   5         ��Name$
 save��5      $��Сохранить��6   $
��Left=�63   $��
24,216,0,0q�6N   $	��Top=�6b   $��78��6z   $��25��6�   {�.  6�   �� 5   
   -   5        $ 	saveAndGo��5      $*��$Сохранить и перейти��6$   $
��Left=�6B   $��120,216,0,0q�6]   $	��Top=�6r   $	��142��6�   $��25                 ��6�   {�.  5   %   �� 5   
   -   5         ��Name$ label��5      $$��Название ссылки:��6   $
��Left=�6:   $��	24,18,0,0q�6U   $	��Top=�6h   $��26��6�   $	��133��6�   �� 5   
   -   5        $ label1��5      $��Адрес ссылки:��6    $
��Left=�68   $��	24,99,0,0q�6S   $	��Top=�6f   $��26��6~   $	��109��6�   �� 5   
   -   5        $ urlHrefError��5      $�� ��6&   $
��Left=�61   $��
24,158,0,0q�6L   $	��Top=�6`   	 J� RenderTransformOrigin$	 0.538,1.433&�6x   ���	#FFD817176�   5      5      