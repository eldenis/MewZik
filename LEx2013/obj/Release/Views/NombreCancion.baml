   M S B A M L   `   `   `  ���� 
  MewZik     MewZik.Views.NombreCancion   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       +� FocusedElement  ��  �� ElementName$ Texto��.���  � RowDefinitions �� �� �� $
��Auto �.+��� $��Nombre de la canción��$��Bottom=�$��40(����	#FF00AEC9 �� Padding$ 10q�$��
-400,5,0,5q�$��Center=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Opacity$	 0.5Q�   ShadowDepth$ 0Q�   
BlurRadius$ 10Q�   Color$ Black���� -   	 ��Name$	 Texto��$	��Top=�$��1��$	��600������ *NombreCancion+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnTargetUpdated . �� $��2�� �� Orientation$ 
Horizontal=�$��Right=�$��10q�.+��� $��Aceptar�� �� 	IsDefault . ���� *	Aceptar+�� $��Cancelar�� �� IsCancel . ���� *
Cancelar+