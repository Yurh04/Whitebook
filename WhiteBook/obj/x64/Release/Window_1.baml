   M S B A M L   `   `   `  ���� D  @WhiteBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WhiteBook	WhiteBook  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem     WhiteBook.Window_1   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:WhiteBook     9system&clr-namespace:System;assembly=mscorlib       � Title$  	WhiteBook��$	��700��$
��1200�� � WindowStartupLocation$ CenterScreen=� � 	Resources (   "WhiteBook.IntToVisibilityConverter   IntToVisConverter  TurnoffBrush �� ImageSource 
 Brush2 	 Brush 
 Brush1  RealmadridBrush  	ExitBrush  	BackBrush  RoundButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName �� ScaleX �� ScaleY 	 	ListStyle �� Triggers��%�  &	        &	      &	 +     &	 L     &	 r     &	 �     &	 �     &	 �     &	 �     &		 �    '�� �    '��       �� $  resources/关闭按钮.jpg���� $ resources/皇马1.jpg���� $  resources/设置按钮.jpg���� $ resources/皇马8.jpg���� $ resources/rm.jpg���� $# resources/退出按钮(1).jpg���� $ resources/back.jpg���� " ��.���  � ��$ 50����  � ��$ 50����  � ��
 �������  � ��$ 0q���  � ��$ Center=���  � ��$ Center=���  � ��$
 Bold"���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$	 25��._��� $��Center=�$��Center=�
 P�  �@J�IsMouseOver . . ��� $ border�� � ��
 ��  �P�  � �� . . ���  � z� �� $	 0.8Q�$	 0.8Q���  �@J�RenderTransformOrigin$ 0.5,0.5&��� " ��.���  � �� �	#FFF4F4F5��  � �� �#333333��  � �� �	#FFCCCCCC��  � ��$ 0q���  � ��$ 2q���  � ��$ 
ExtraLight"���  � ��$ Brush Script MT)���  � ��$ 20(��� " ��.���  � ��$ 5q���  � ��$ 10q���  � �� �#DDDDDD��  � ��$ 1q���  � ��$ Stretch=���  � ��
 ����  P�  �@J�IsMouseOver . . ���  � �� �#E5E5E5P�  �@��
IsSelected . . ���  � �� �#CCCCFF��  � �� �#5555FF��  � ��
 ������� " ��.���  � �� �#FFDDDD.���� -    ��Name$ mainTabControl��.@��� -    ��Name$ mainTab��.���  � ColumnDefinitions �� $	��100 ��� $��5 ��� $��177.667 ��� $��* �.+��� $��0��$��3������ $ resources/cr7.jpg��.+��� ���	#00000080$	 15��$��10q� �� Padding$ 10q����#FFFFFF$��1q� J� Opacity$	 0.8Q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ Black��   	Direction$	 320Q�   ShadowDepth$ 5Q�   
BlurRadius$ 10Q�   Opacity$	 0.5Q�._��� $��Center=�$��15(�
�������$
��Bold"����� *CurrentDateTime+ �� StringFormat$ {0:yyyy-MM-dd HH:mm:ss}���� -    ��Name$ Search��$��查看日记��#��[ $	��120��$��20(�$
��Bold"�#��[ $��KaiTi)��� -   $ 	newButton��$�� 新建       ��$��20q�$��KaiTi)�#��[ #��[ $	��100��
���   �$
��Bold"�$��20(��� -   $ DiaryBotton��$��日记��#��[ $��5q�$y�Hidden=�$��KaiTi)�$��20(��� -   $ 
HideBotton��$��49��$��64��$y�Hidden=�#��[ $��隐藏日记��$��15(�$��DemiBold"�#��[ �� -   $ 
ExitButton��$��35��#��[ $y�Hidden=�#��[ �� -   $ TurnoffButton��$��35��#��[ $��10(�$y�Hidden=�#��[ �� -	   #��[ #��[ $��41��$��43��$��Bottom=��� $��3������ $ resources/皇马0.jpg��.+��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+���  �� Orientation$ 
Horizontal=�$��4q�$��40��$��0��.+��� $��提醒事项��$��25(�$��KaiTi)�$
��Bold"�
��� E��$��Center=�$��5q��� $��resources/备忘录.jpg��$��40��$��30��$��5q��� 
����+��$��1q�$ 5q�$	 10��._��� -
     ��Name$  	DoneCount��$��已完成：��$��20(�$��Center=�$��5q�$	��400��
���   �$
��Bold"�$��KaiTi)��� $��1��$"��  你有多久没运动了? ��$��18(�$��KaiTi)�$��2,10,2,0q�$	��Top=�$��45���� -   ! ��Name$! reminderListView��
������ $��0q�$��5q�$��2��$y�	Collapsed=�$	��200��$��KaiTi)�$��20(����� .R�� $��5q�
������  �� $
��Auto ��� $��* �.+��� $ 
DoneButton��-   #��[ $��0��$��10q�$��20��$��20��$��Center=�
" � Tag" �� �� $��1��$ Vertical=�$��1q�.+��� $
��Bold"�$	��Top=�$��20������ *Thing+�� 
�������$��17(�$��Bottom=�$��17������ *	Details+���� " ��.���  � y� �� *Done+# �� 	Converter## [  �� -   $ newMemoButton��
������ 
������ $
��Left=�$
��10,5q�$
��0,10q�$��20(�$
��Bold"�$��3��.���� $ 
Horizontal=�.+��� $��resources/加号.jpg��$��40���� $��新建提醒事项��
����  �$��Center=�$��10,0,0,0q�$��KaiTi)��� -   $ ��Name$$ newMemoStackPanel��$ 
Horizontal=�$��3��$y�	Collapsed=�.+��� -   $��保存��$��15(�#��[ $��10q�#��[ $��Center=��� $ Vertical=�$y�Visible=�$��10q�$��2��.+��� -   % ��Name$% newMemoTextbox��$��添加提醒事项��
�������$��2��$	��300��$��40��$��17(� 
 RoundedTextBoxStyle#��[
 �� -   $% newDetailsTextbox��$��添加备注��
�������$��2��#��[
 $��12(�$��7q��� -   $��15(�#��[ $��10q�#��[ $��Center=��� -   $! entriesListView��#��[	 $y�	Collapsed=�$	��400��$��1��$��KaiTi)�& �� View& �� .P��� ' �� Width$	' 100��( �� HeaderTemplate( �� .R��� $��日期��$
��Bold"�$��18(�
���   �) �� CellTemplate) �� .R��� $��16(�
���   ����� *Date+�� $	' 100��( �� .R��� $��题目��$
��Bold"�$��18(�
���W�.�) �� .R��� $��15(�
���   ����� *Title+�� $	' 100��( �� .R��� $��心情��$
��Bold"�$��18(�
��� E��) �� .R��� $��15(�
���   ����� *Mood+�� $	' 300��( �� .R��� $��内容��$
��Bold"�$��18(�
����+��) �� .R��� $��15(�
���   �$
��Wrap=����� *	Content+�� $
' Auto��) �� .R��� .+��� -   $��编辑��$��16(�$
��Bold"�$��KaiTi)�$��Right=�#��[ 
��� ���" �� �� -   $��删除��$��16(�$��5q�$��KaiTi)�$��Right=�#��[ 
�����p�" �� �� -   $$ newMemo��$��0��$��5q�$y�	Collapsed=�.+��� -   $
% text���� -   $$ editArea��$��1��$��10q�$y�	Collapsed=�.+��� -   $% editTitleTextBox��$��编辑题目��$��5q�$��KaiTi)��� -   $% editMoodTextBox��$��编辑心情��$��5q�$��KaiTi)��� -   * ��Name$* editContentRichTextBox��$��5q�$	��100��$��KaiTi)�. �/� .T�J� .*�" Start editing your diary here...�� -   $��保存日记��$��5q��� -   $ newEntryTab��$��4��$��
-2,-2,-2,0q�$	��Top=�#��[ $y�	Collapsed=�.���  �� $��40 ��� $��40 ��� $��40 ��� $��* �.+��� $��0��$ 
Horizontal=�$��Center=�$��Center=�.+��� $��日期��$
��Bold"�$��Center=�$��10q�(  "System.Windows.Controls.DatePicker  -   +  Name$+ 
datePicker��
, �� Now-   SelectedDate#- Z, . J� RenderTransformOrigin$. 0.441,0.171&�$��22��$��KaiTi)��� $��1��$ 
Horizontal=�$��Center=�.+��� $��标题��$��Center=�$
��Bold"��� -   $% titleTextBox��$	��120��$��20��$��7q�$��14(�
���   �$��在此输入......��$��Center=����#FFFF99$��Center=�$��KaiTi)��� -    / ��Name$/ moodComboBox��$��2��$��0,0,0,5q�$��18(�$��Center=�$��Center=�
����p��0 �� SelectedIndex$0 0��$��KaiTi)�.@��� $��今天心情如何？😄��{�.  �� .���� $ 
Horizontal=�.+��� $��resources/笑脸.jpg��$��20��$��20���� $�� Happy��$��Center=�$��15(��� .���� $ 
Horizontal=�.+��� $��resources/sad.jpg��$��20��$��20���� $
�� sad��$��Center=�$��15(��� .���� $ 
Horizontal=�.+��� $��resources/激动.jpg��$��20��$��20���� $�� excited��$��Center=�$��15(��� .���� $ 
Horizontal=�.+��� $��resources/疲惫.jpg��$��20��$��20���� $��Tired��$��Center=�$��15(��� .���� $ 
Horizontal=�.+��� $��resources/great.jpg��$��20��$��20���� $�� Great��$��Center=�$��15(��� .���� $ 
Horizontal=�.+��� $��resources/emo.jpg��$��20��$��40���� $
�� Emo��$��Center=�$��15(��� -!   1 ��Name$1 customMoodItem��$��30��$��你的心情......��$��10(�$��Center=�$
��Left=��� $��3������ $ resources/rm.jpg��._��� -"   $* contentRichTextBox��$��98,63,118,53q�$��3��
������ $��KaiTi)�$��22(�. �/� .T�J� .*�&$从这里开始写你的日记......�� -#   $��3��$
��Left=�$	��Top=�$��0,10,0,0q�#��[ $��51��$��55��#��[ �� -$   $��3��$��Center=�$��5q�$��Bottom=�$��完成��$��KaiTi)�$��50��$��50��$��20(�#��[ #��[ 