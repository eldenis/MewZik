   M S B A M L   `   `   `  ����A  =MewZik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MewZik.ViewModelsMewZik.ViewModels  5   	   +clr-namespace:MewZik.UtilsMewZik.Utils  5   	   +clr-namespace:MewZik.ViewsMewZik.Views  5   	       MewZik.Views.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   U QMahApps.Metro, Version=0.11.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   0
viewModelsclr-namespace:MewZik.ViewModels  5   	   &utilsclr-namespace:MewZik.Utils  5   	   &viewsclr-namespace:MewZik.Views  5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowState$ 	Maximized=�5	   	   $	��600��6"   $	��880��6/    � Icon$! /Recursos\WHITEIcono-Mz.ico��6;    J� InputBindings 5
      �� 5   
   
 �� Key$ F1��6    �� Command 6   �� *SeleccionarFuenteLetras+�� 5   
   $ F2��6    6   �� *SeleccionarFuenteAcordes+�� 5   
   $ F3��6    6   �� *AbrirCancionAnterior+�� 5   
   $ F4��6    6   �� *AbrirSiguienteCancion+�� 5   
   $ F5��6    6   �� *EstablecerFocoBuscar+�� 5   
   $ F6��6    6   �� *EstablecerFocoLista+�� 5   
   $ F7��6    6   �� *EstablecerFocoTexto+�� 5   
   $ F8��6    6   �� *GuardarCancion+�� 5   
   $	 F12��6    6   �� *AbrirPrimeraCancion+ � DataContext 5      #   MewZik.ViewModels.VMPrincipal  5   
   .��5      � .+�5   
   � -   5         �Name$ GridPrincipal��5      ��5      �� 5       �� 
TargetType" �6   �5      �� 5      	 �� Property	 �@J�Effect
 �� Value
 5      -  'System.Windows.Media.Effects.BlurEffect  5   "      Radius$ 5Q�6-      
KernelType$ Gaussian=�68   5!       �� Triggers 5#      �� 5$       �� Binding 6&   �� *	Dialogo+ �� Value 6B   Z� a�5%      �� 5&   "   	 �@J�Effect
 6;   Z� 5(      5*       � RowDefinitions 5,      �� 5-      $
��Auto �6    �� 5.       � ColumnDefinitions 50      �� 51      $��* �6#   �� 52      $
��Auto �6#   �� 53      $��* �6#   .+�56      �� $��3��6   $��0,0,0,1q�6*   ��57      �� 58       �� EndPoint$	 1,1&�6*    � MappingMode$ RelativeToBoundingBox=�69    �� 
StartPoint$	 0,0&�6]   .��59      �  � Color$ White��6'    � Offset$	 0.5Q�65   � 5:      $ 	#FF1E1E1E��6'   $ 1Q�69   � 5;      $ 	#FF1E1E1E��6'   5<      ._�5>      � $��Stretch=�6    5?      �� 5@      $��* �6+   �� 5A      $
��Auto �6+   �� 5B      $
��Auto �6+   .+�5D      ]� $
��Left=�6    .+�5E      	� $��Letras��6&      MetroRadioButton#��[  67    	� 	GroupName$ 
TipoFuente��5F   N   {�6&   �� *TieneFuenteLetras+ d� 	IsChecked 5G   &   �� *FuenteLetras+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�	� 5H      $��Acordes��6&   #��[  68   $ 
TipoFuente��5I   O   {�6&   �� *TieneFuenteAcordes+ 5J   &   �� *FuenteAcordes+$ TwoWay=�$ PropertyChanged=�5K      �� 5M       �� Orientation$ 
Horizontal=�6!   $��1��6:   $��Right=�6J   .+�5N      %   MewZik.Views.ImagedCircleButton    
appbar_add   Visual# �  63      Command 6Y   �� *AgregarCancion+  5O        appbar_save# �  63    6Z   �� *GuardarCancion+  5P        appbar_delete# �  63    6\   �� *EliminarCancionLeida+  5Q        appbar_door_leave# �  63    6`   �� *Salir+5R      �� 5S      $��2��6   $��Right=�6.   $	��0,5q�5T      *  $MahApps.Metro.Controls.TextboxHelper   ClearTextButton . $	��270��6U      	Watermark$ Buscar canciones...��5U   "   %   MewZik.Utils.AttachedProperties    	TieneFoco  5V   #   �� *FocoEnBuscar+��5W   #   �� *Filtro+$ TwoWay=�$ PropertyChanged=�5X      5Y      �� 5\      -   5        ! ��Name$! ListaArchivos��5a   =   $��Disabled=�5\      $" �� IsSynchronizedWithCurrentItem$
" TrueY�6L   ���	#FF1E1E1E$��0��5]   .   $��1��5a   T     5^      �� *FocoEnLista+#   ReturnToStartProperty# 5_      �� *LimpiarEstadoLista+$ �� SelectedItem$ 5`      �� *CancionSeleccionada+$ PropertyChanged=�$ TwoWay=���5a      �� *ListaCanciones+ 5b      �� 5c      $ Return��6!    6.   �� *&$DataContext.AbrirCancionSeleccionada+% �� RelativeSource% �� *FindAncestor+& �� AncestorType"& ���5f      �� 5g      " ��6   .�5i      �� 	 �@�FocusVisualStyle
 6=   Z� �� 5j      	 � ��$
 0q�64   �� 5k      	 � ��$
 0q�63   �� 5l      	 � ��
 68   Z� �� 5n      	 � ��$
 Stretch=�6G   5o      ' � ContextMenu' 5q      �� 5r      .@�5s      m� $��Abrir en notepad��6#   ( m� Command( 6=   �� *AbrirNotepad+m� 5t      $��Localizar en explorer��6#   ( 6B   �� *LocalizarExplorer+m� 5u      $��Abrir en word��6#   ( 6:   �� *	AbrirWord+�� 5v      m� 5w      $��Agregar canción��6#   ( 6<   �� *AgregarCancion+m� 5x      $��Eliminar canción��6#   ( 6=   �� *EliminarCancion+m� 5y      $��Cambiar nombre��6#   ( 6;   �� *CambiarNombre+m� 5z      $��Duplicar canción��6#   ( 6=   �� *DuplicarCancion+5{      ��5}      �� 5~      .R�5      �� ) �� Padding$) 0q�6<   $��0q�6H   $��Stretch=�5�       $��Stretch=�6>   ��5   $   �� *Nombre+ 5�      d� 5�   "   * d� MouseAction$* LeftDoubleClicke�6/    5�   %   �� *&$DataContext.AbrirCancionSeleccionada+% �� *FindAncestor+"& �5�      5�      5�      �� 5�      $��3��6   $��Center=�6%   $��1��6B   $��Stretch=�5�      $��1��63   + �� ResizeDirection$+ Columns=�5�      , �� ShowsPreview, . ��5�      �� 5�      $	 1,1&�6*   $ RelativeToBoundingBox=�69   $	 0,0&�6]   .��5�      � $ White��6'   $	 0.5Q�65   � 5�      $ 	#FF1E1E1E��6'   $ 1Q�69   � 5�      $ 	#FF1E1E1E��6'   5�      ��5�      �� 5�      " ��6   �5�      �� 5�      	 �@J�Opacity$	
 0.2Q�68    5�      :� 5�      - :� RoutedEvent$- 
MouseEnter��6+   .[�5�   "   �� .��5�   &   �� . g� FillBehavior$. HoldEnd=�61   .��5�   *   W� / g� Duration$/ 0:0:1D�6:   0 �� TargetProperty$0 Opacity�6K   1 W� From$	1 0.2X�6o   	2 W� To$2 1X�6z   5�   '   5�   #   5�      :� 5�      $- 
MouseLeave��6+   .[�5�   "   �� .��5�   &   �� .��5�   *   W� $/ 0:0:1D�6:   $0 Opacity�6K   $1 1X�6o   $	2 0.2X�6x   5�   '   5�   #   5�      :� 5�      $- 	MouseDown��6+   .[�5�   "   �� .��5�   &   �� .��5�   *   W� $0 Opacity�6:   $2 1X�6^   5�   '   5�   #   5�      5�      5�      �� 5�      -   5        3 ��Name$3 TextoCancion��5�   <   $��2��5�      $��Courier New)�6"   $��1��6;   4 �� AcceptsReturn4 . $��16(�5�      $��Visible=�5�      5 �� TextWrapping$
5 Wrap=�6E   $��Disabled=�5�      $��0q�6H   ��5�   R   Z�   5�      �� *FocoEnTexto+# 5�      �� *LimpiarEstadoTexto+��5�      �� *Texto+$ TwoWay=�$ PropertyChanged=�.��6Y   ��5�      �� 5�      6 �� 
TargetType"6 ��6&   .R�5�      �� 7 ��Name$7 bg��6!   ���	#FF1E1E1E��6-   Z� ._�5�      �� 8 ��Name$8 PART_ContentHost��6+   9 J� SnapsToDevicePixels#9 z9 6E   5�      : �� Triggers: 5�      P� 5�      ; P� Property; �@J�IsMouseOver< P� Value< . . �5�   "   �� = �� 
TargetName$= bg��6@   
 6P   Z� 	 � ��5�      P� 5�      ; �@J�	IsFocused< . . �5�   "   �� $= bg��6@   
 6P   Z� 	 � ��5�      5�      .��5�   $   5�      5�      � 5�   
   .+�5�      �� -   5        > ��Name$> TextoTemporal��5�   9   |�.  ? J� IsHitTestVisible? .  $��Center=�5�      $��Center=�63   ��5�      �� *MensajeTemporal+��5�      �� 5�      @ �� BasedOn#@ [B��6   " ��6J    5�      �� 5�       6*   �� *MostrandoMensajeTemporal+ True6W   A N� EnterActionsA 5�   "   �� 5�   &   .��5�   *   �� .��5�   .   T� $0 
Visibility�6L   ..�5�   2   i� B R� KeyTime$B 0:0:0��6I     System.Windows.VisibilityC   VisibleD R� Value#D ZC 6Y   5�   /   W� 5�   .   $0 Opacity�6>   $/ 0:0:2D�6b   $2 1X�6s   5�   +   5�   '   E N� ExitActionsE 5�   "   �� 5�   &   .��5�   *   �� .��5�   .   W� $0 Opacity�6>   $/ 0:0:2D�6b   $	2 0.0X�6s   T� 5�   .   $0 
Visibility�6L   ..�5�   2   i� $B 0:0:2��6I   F   	Collapsed#D ZF 6Y   5�   /   5�   +   5�   '   5�      5�      5�      5�      � 5�   
   ��5�      �� 5�      " �6    5�      �� 5�       6&   �� *	Dialogo+ 6C   Z� a�5�      �� 5   "   	 � y�$
 	Collapsed=�6?   5     5     .+�5     � 
���   �G J� Opacity$	G 0.5Q�6&   �� 5     ��6   �� *	Dialogo+5	     5
     5     