   M S B A M L   `   `   `  ����D  @WhiteBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WhiteBook	WhiteBook  5   	       WhiteBook.Register_Window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WhiteBook     5   	     � Title$  Register_Window��5   	   $	��450��6!   $	��800��6.    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5
         WindowBackgroundBrush �� ImageSource  ButtonStyle �� 
TargetType �� Property �� Value �� Triggers P� Property	 P� Value��%s  &	        &	 E     �� 5   
   $1 +D:\WPF\WhiteBook\WhiteBook\resources\rm.jpg��63   �� 5   
   " ��6$   .�5      ��  � �� �	#FF006AC16+   �� 5       � ��
 �����6+   �� 5       � ��
 �   �6,   �� 5       � ��$ 2q�60   �� 5       � ��$ 20(�6)   �� 5       � ��$ Segoe UI)�6+   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69    5      P� 5       �@J�IsMouseOver	 . . �5      ��  � �� �	#FF008CFF63   5      P� 5       � ��	 . . �5      ��  � ��
 �   �63   5      5      5      .��5       � #��[  6   
 � RowDefinitions
 5!   
   �� 5"      $��50 �6   �� 5#      $��50 �6   �� 5$      $	��280 �6   �� 5%      $��* �6   .+�5'   
   �� $��5q�6   $��0��6   $��0��6,   $��Your White Book��6<   $��35(�6S   $��Center=�6a   $��Brush Script MT)�6~   �� 5)   
   $��1��6   $��1q�6   
���   � �� Padding$ 10q�6F   
����iA�._�5*      �� $��Please Register��6   $��Center=�6/   $��Center=�6L   $��23(�5+      $
��Bold"�6   $��Italic$�60   
�������6C   5,      �� 5.   
   $��2��6   $��Center=�6"   $��Center=�6=   $	��267��6Z   .+�50      �� $��	Username:��6   $��16(�6)   $��5q�67   �� 51      -   5         ��Name$ usernameTextBox��51      $��14(�6/   $��5q�6=   �� 52      $��Code:��6   $��16(�6%   $��5q�63   �� 54      $��5q�6,   $��14(�67   ��6   �� *Code+67   �� 55      -   5        $��Register��55      $	��100��6E   $��10q�6Q   
����d�#��[ 6y   �� 56      -   5        $
��Back��56      $��83��6=   $��10q�6H   
������#��[ 6j   $��35��6�   57      �� 59   
   $��3��6   $��Center=�6!   $��Center=�6>   $��30(�6Y   $��
Halamadrid��5:      $��Brush Script MT)�6&   5;      5=      