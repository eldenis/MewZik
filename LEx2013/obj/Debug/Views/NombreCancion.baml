   M S B A M L   `   `   `  ����
  MewZik     MewZik.Views.NombreCancion   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        +� FocusedElement  5       ��  �� ElementName$ Texto��.��5      �  � RowDefinitions 5	   
   �� 5
      �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��Nombre de la canción��6   $��Bottom=�60   $��40(�6K   ���	#FF00AEC9 �� Padding$ 10q�5      $��
-400,5,0,5q�6   $��Center=�61    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Opacity$	 0.5Q�6#      ShadowDepth$ 0Q�61      
BlurRadius$ 10Q�5   #      Color$ Black��63   5      �� 5   
   -   5        	 ��Name$	 Texto��5   f   $	��Top=�65   $��1��6M   $	��600��6Z   ��5      �� *NombreCancion+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnTargetUpdated . 5   f   �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��10q�6W   .+�5      �� $��Aceptar��6    �� 	IsDefault . ��68   �� *	Aceptar+�� 5      $��Cancelar��6    �� IsCancel . ��68   �� *
Cancelar+5      5      5       