   M S B A M L   `   `   `  ���� D  @WhiteBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WhiteBook	WhiteBook  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem     WhiteBook.Window_1   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:WhiteBook     9system&clr-namespace:System;assembly=mscorlib       � Title$  Window_1��$	��450��$	��800�� � WindowStartupLocation$ CenterScreen=� � 	Resources    TurnoffBrush �� ImageSource 
 Brush2 	 Brush 
 Brush1  RealmadridBrush  	ExitBrush  	BackBrush  RoundButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName �� ScaleX �� ScaleY  	ListStyle �� Triggers��%\  &	        &	 A     &	 }     &	 �     &	 �     &	 1    &	 u    &	 �    &	 �    '�� t    '�� �    �� $; 5D:\WPF\WhiteBook\WhiteBook\resources\关闭按钮.jpg���� $6 0D:\WPF\WhiteBook\WhiteBook\resources\皇马1.jpg���� $; 5D:\WPF\WhiteBook\WhiteBook\resources\设置按钮.jpg���� $6 0D:\WPF\WhiteBook\WhiteBook\resources\皇马8.jpg���� $1 +D:\WPF\WhiteBook\WhiteBook\resources\rm.jpg���� $> 8D:\WPF\WhiteBook\WhiteBook\resources\退出按钮(1).jpg���� $3 -D:\WPF\WhiteBook\WhiteBook\resources\back.jpg���� " ��.���  � ��$ 50����  � ��$ 50����  � ��
 �������  � ��$ 0q���  � ��$ Center=���  � ��$ Center=���  � ��$
 Bold"���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$	 25��._��� $��Center=�$��Center=�
 P�  �@J�IsMouseOver . . ��� $ border�� � ��
 ��  �P�  � �� . . ���  � z� �� $	 0.8Q�$	 0.8Q���  �@J�RenderTransformOrigin$ 0.5,0.5&��� " ��.���  � �� �	#FFF4F4F5��  � �� �#333333��  � �� �	#FFCCCCCC��  � ��$ 0q���  � ��$ 2q���  � ��$ 
ExtraLight"���  � ��$ Brush Script MT)���  � ��$ 20(��� " ��.���  � ��$ 5q���  � ��$ 10q���  � �� �#DDDDDD��  � ��$ 1q���  � ��$ Stretch=���  � ��
 ����  P�  �@J�IsMouseOver . . ���  � �� �#E5E5E5P�  �@��
IsSelected . . ���  � �� �#CCCCFF��  � �� �#5555FF��  � ��
 ������� " ��.���  � �� �#FFDDDD.���� -    ��Name$ mainTabControl��.@��� -    ��Name$ mainTab��.���  � ColumnDefinitions �� $��50 ��� $��5 ��� $��177.667 ��� $��* �.+��� $��0��$��3������ $2 ,D:\WPF\WhiteBook\WhiteBook\resources\cr7.jpg��.+��� ���	#00000080$	 15��$��10q� �� Padding$ 10q����#FFFFFF$��1q� J� Opacity$	 0.8Q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ Black��   	Direction$	 320Q�   ShadowDepth$ 5Q�   
BlurRadius$ 10Q�   Opacity$	 0.5Q�._��� $��Center=�$��15(�
�������$
��Bold"����� *CurrentDateTime+ �� StringFormat$ {0:yyyy-MM-dd HH:mm:ss}���� -    ��Name$ Search��$��Search ��#��[ $	��100��$��17(�$
��Bold"�#��[ �� -   $��New         ��$��30q�#��[ #��[ $	��100��
���   �$
��Bold"�$��17(��� -   $ 
HideBotton��$��49��$��64��$y�Hidden=�#��[ $
��Hide��$��15(�$��DemiBold"�#��[ �� -   $ 
ExitButton��$��40��#��[ $y�Hidden=�#��[ �� -   $ TurnoffButton��$��40��#��[ $��10(�$y�Hidden=�#��[  �� -   #��[ #��[ $��41��$��43���� $��3��$��10,10,10,10q����� $6 0D:\WPF\WhiteBook\WhiteBook\resources\皇马0.jpg��.+�� .+��� $��Disabled=�$��Disabled=�.���� -	    ��Name$ entriesListView��#��[ $y�Hidden=� �� View �� .P���   �� Width$	  100��! �� HeaderTemplate! �� .R��� $
��Date��$
��Bold"�$��18(�
���   �" �� CellTemplate" �� .R��� $��14(�
���   �$��Calibri)����� *Date+�� $	  100��! �� .R��� $��Title��$
��Bold"�$��18(�
���W�.�" �� .R��� $��12(�
���   �$��Calibri)����� *Title+�� $	  100��! �� .R��� $
��Mood��$
��Bold"�$��18(�
��� E��" �� .R��� $��12(�
���   �$��Calibri)����� *Mood+�� $	  300��! �� .R��� $��Content��$
��Bold"�$��18(�
����+��" �� .R��� $��12(�
���   �$��Calibri)����� *	Content+�� $
  Auto��" �� .R��� .+��� -
   $
��Edit��$��14(�$
��Bold"�$��Calibri)�$��Right=�#��[ 
��� ���
# � Tag# �� �� -   $��Delete��$��14(�$��5q�$��Calibri)�$��Right=�#��[ 
�����p�# �� �� -   $ ��Name$$ editArea��$��1��$��10q�$y�	Collapsed=�.+��� -   % ��Name$% editTitleTextBox��$��
Edit Title��$��5q��� -   $% editMoodTextBox��$��	Edit Mood��$��5q��� -   & ��Name$& editContentRichTextBox��$��5q�$	��100��. �/� .T�J� .*�" Start editing your diary here...�� -   $��Save Changes��$��5q��� -   $ newEntryTab��$��6��$��
-2,-2,-2,0q�$	��Top=�#��[ .��� ' � RowDefinitions' �� $��40 ��� $��40 ��� $��40 ��� $��* �.+��� $��0��( �� Orientation$( 
Horizontal=�$��Center=�$��Center=�.+��� $
��Date��$
��Bold"�$��Center=�$��10q�(  "System.Windows.Controls.DatePicker  -   )  Name$) 
datePicker��
* �� Now+   SelectedDate#+ Z* , J� RenderTransformOrigin$, 0.441,0.171&�$��22���� $��1��$( 
Horizontal=�$��Center=�.+��� $��Title��$��Center=�$
��Bold"��� -   $% titleTextBox��$	��120��$��20��$��7q�$��14(�
���   �$��Enter title here...��$��Center=����#FFFF99$��Center=��� -   - ��Name$- moodComboBox��$��2��$��0,0,0,5q�$��14(�$��Center=�$��Center=�
����p��. �� SelectedIndex$. 0��.@��� $��How do you feel today?��{�.  �� .���� $( 
Horizontal=�.+��� $5��/D:\WPF\WhiteBook\WhiteBook\resources\笑脸.jpg��$��20��$��20���� $�� Happy��$��Center=�$��10(��� .���� $( 
Horizontal=�.+��� $2��,D:\WPF\WhiteBook\WhiteBook\resources\sad.jpg��$��20��$��20���� $
�� sad��$��Center=�$��10(��� .���� $( 
Horizontal=�.+��� $5��/D:\WPF\WhiteBook\WhiteBook\resources\激动.jpg��$��20��$��20���� $�� excited��$��Center=�$��10(��� .���� $( 
Horizontal=�.+��� $5��/D:\WPF\WhiteBook\WhiteBook\resources\疲惫.jpg��$��20��$��20���� $��Tired��$��Center=�$��10(��� .���� $( 
Horizontal=�.+��� $4��.D:\WPF\WhiteBook\WhiteBook\resources\great.jpg��$��20��$��20���� $�� Great��$��Center=�$��10(��� .���� $( 
Horizontal=�.+��� $2��,D:\WPF\WhiteBook\WhiteBook\resources\emo.jpg��$��20��$��40���� $
�� Emo��$��Center=�$��10(��� -   / ��Name$/ customMoodItem��$��30��$��Your emotion...��$��10(�$��Center=�$
��Left=��� $��3������ $1 +D:\WPF\WhiteBook\WhiteBook\resources\rm.jpg��._��� -   $& contentRichTextBox��$��98,63,118,53q�$��3��
������ . �/� .T�J� .*�" Start writing your diary here...�� -   $��3��$
��Left=�$	��Top=�$��0,10,0,0q�#��[ $��51��$��55��#��[ �� -   $��3��$��Center=�$��5q�$��Bottom=�$��Finish!��$��50��$��50��#��[ #��[ 