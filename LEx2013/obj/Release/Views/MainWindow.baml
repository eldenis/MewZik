   M S B A M L   `   `   `  ���� A  =MewZik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MewZik.ViewModelsMewZik.ViewModels  +clr-namespace:MewZik.UtilsMewZik.Utils  +clr-namespace:MewZik.ViewsMewZik.Views      MewZik.Views.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     U QMahApps.Metro, Version=0.11.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls  0
viewModelsclr-namespace:MewZik.ViewModels  &utilsclr-namespace:MewZik.Utils  &viewsclr-namespace:MewZik.Views    � WindowStartupLocation$  CenterScreen=� � WindowState$ 	Maximized=�$	��600��$	��880�� � Icon$! /Recursos\WHITEIcono-Mz.ico�� J� InputBindings �� 
 �� Key$ F1�� �� Command �� *SeleccionarFuenteLetras+�� $ F2�� �� *SeleccionarFuenteAcordes+�� $ F3�� �� *AbrirCancionAnterior+�� $ F4�� �� *AbrirSiguienteCancion+�� $ F5�� �� *EstablecerFocoBuscar+�� $ F6�� �� *EstablecerFocoLista+�� $ F7�� �� *EstablecerFocoTexto+�� $ F8�� �� *GuardarCancion+�� $	 F12�� �� *AbrirPrimeraCancion+ � DataContext #   MewZik.ViewModels.VMPrincipal  .��� .+�� -    �Name$ GridPrincipal������  �� 
TargetType" ���� 	 �� Property	 �@J�Effect
 �� Value
 -  'System.Windows.Media.Effects.BlurEffect     Radius$ 5Q�   
KernelType$ Gaussian=� �� Triggers ��  �� Binding �� *	Dialogo+ �� Value Z� a��� 	 �@J�Effect
 Z�  � RowDefinitions �� $
��Auto ���  � ColumnDefinitions �� $��* ��� $
��Auto ��� $��* �.+��� $��3��$��0,0,0,1q�����  �� EndPoint$	 1,1&� � MappingMode$ RelativeToBoundingBox=� �� 
StartPoint$	 0,0&�.���  � Color$ White�� � Offset$	 0.5Q�� $ 	#FF1E1E1E��$ 1Q�� $ 	#FF1E1E1E��._�� $��Stretch=� �� $��* ��� $
��Auto ��� $
��Auto �.+�]� $
��Left=�.+�	� $��Letras��   MetroRadioButton#��[   	� 	GroupName$ 
TipoFuente��{��� *TieneFuenteLetras+ d� 	IsChecked �� *FuenteLetras+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�	� $��Acordes��#��[  $ 
TipoFuente��{��� *TieneFuenteAcordes+ �� *FuenteAcordes+$ TwoWay=�$ PropertyChanged=���  �� Orientation$ 
Horizontal=�$��1��$��Right=�.+�%   MewZik.Views.ImagedCircleButton    
appbar_add   Visual# �     Command �� *AgregarCancion+    appbar_save# �   �� *GuardarCancion+    appbar_delete# �   �� *EliminarCancionLeida+    appbar_door_leave# �   �� *Salir+�� $��2��$��Right=�$	��0,5q�*  $MahApps.Metro.Controls.TextboxHelper   ClearTextButton . $	��270��   	Watermark$ Buscar canciones...��%   MewZik.Utils.AttachedProperties    	TieneFoco  �� *FocoEnBuscar+���� *Filtro+$ TwoWay=�$ PropertyChanged=��� -   ! ��Name$! ListaArchivos��$��Disabled=�$" �� IsSynchronizedWithCurrentItem$
" TrueY����	#FF1E1E1E$��0��$��1��  �� *FocoEnLista+#   ReturnToStartProperty# �� *LimpiarEstadoLista+$ �� SelectedItem$ �� *CancionSeleccionada+$ PropertyChanged=�$ TwoWay=����� *ListaCanciones+ �� $ Return�� �� *&$DataContext.AbrirCancionSeleccionada+% �� RelativeSource% �� *FindAncestor+& �� AncestorType"& ����� " ��.��� 	 �@�FocusVisualStyle
 Z� �� 	 � ��$
 0q��� 	 � ��$
 0q��� 	 � ��
 Z� �� 	 � ��$
 Stretch=�' � ContextMenu' �� .@�m� $��Abrir en notepad��( m� Command( �� *AbrirNotepad+m� $��Localizar en explorer��( �� *LocalizarExplorer+m� $��Abrir en word��( �� *	AbrirWord+�� m� $��Agregar canción��( �� *AgregarCancion+m� $��Eliminar canción��( �� *EliminarCancion+m� $��Cambiar nombre��( �� *CambiarNombre+m� $��Duplicar canción��( �� *DuplicarCancion+���� .R��� ) �� Padding$) 0q�$��0q�$��Stretch=�$��Stretch=����� *Nombre+ d� * d� MouseAction$* LeftDoubleClicke� �� *&$DataContext.AbrirCancionSeleccionada+% �� *FindAncestor+"& ��� $��3��$��Center=�$��1��$��Stretch=�$��1��+ �� ResizeDirection$+ Columns=�, �� ShowsPreview, . ���� $	 1,1&�$ RelativeToBoundingBox=�$	 0,0&�.��� $ White��$	 0.5Q�� $ 	#FF1E1E1E��$ 1Q�� $ 	#FF1E1E1E������ " ����� 	 �@J�Opacity$	
 0.2Q� :� - :� RoutedEvent$- 
MouseEnter��.[��� .���� . g� FillBehavior$. HoldEnd=�.��W� / g� Duration$/ 0:0:1D�0 �� TargetProperty$0 Opacity�1 W� From$	1 0.2X�	2 W� To$2 1X�:� $- 
MouseLeave��.[��� .���� .��W� $/ 0:0:1D�$0 Opacity�$1 1X�$	2 0.2X�:� $- 	MouseDown��.[��� .���� .��W� $0 Opacity�$2 1X��� -   3 ��Name$3 TextoCancion��$��2��$��Courier New)�$��1��4 �� AcceptsReturn4 . $��16(�$��Visible=�5 �� TextWrapping$
5 Wrap=�$��Disabled=�$��0q���Z�   �� *FocoEnTexto+# �� *LimpiarEstadoTexto+���� *Texto+$ TwoWay=�$ PropertyChanged=�.������ 6 �� 
TargetType"6 ��.R��� 7 ��Name$7 bg�����	#FF1E1E1E��Z� ._��� 8 ��Name$8 PART_ContentHost��9 J� SnapsToDevicePixels#9 z9 : �� Triggers: P� ; P� Property; �@J�IsMouseOver< P� Value< . . ��� = �� 
TargetName$= bg��
 Z� 	 � ��P� ; �@J�	IsFocused< . . ��� $= bg��
 Z� 	 � ��.��� .+��� -   > ��Name$> TextoTemporal��|�.  ? J� IsHitTestVisible? .  $��Center=�$��Center=����� *MensajeTemporal+���� @ �� BasedOn#@ [B��" �� ��  �� *MostrandoMensajeTemporal+ TrueA N� EnterActionsA �� .���� .��T� $0 
Visibility�..�i� B R� KeyTime$B 0:0:0��  System.Windows.VisibilityC   VisibleD R� Value#D ZC W� $0 Opacity�$/ 0:0:2D�$2 1X�E N� ExitActionsE �� .���� .��W� $0 Opacity�$/ 0:0:2D�$	2 0.0X�T� $0 
Visibility�..�i� $B 0:0:2��F   	Collapsed#D ZF � ���� " � ��  �� *	Dialogo+ Z� a��� 	 � y�$
 	Collapsed=�.+�� 
���   �G J� Opacity$	G 0.5Q��� ���� *	Dialogo+