using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using MewZik.Utils;

namespace MewZik.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        const double UnidadMinimaScroll = 120;

        public MainWindow()
        {
            InitializeComponent();
            GridPrincipal.ColumnDefinitions.First().Width = new GridLength(230);
            Closing += (s, e) =>
            {
                if (App.ShuttingDown) return;
                e.Cancel = true;
                WindowState = WindowState.Minimized;
            };
        }

        private void TextBoxMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (!Keyboard.IsKeyDown(Key.LeftCtrl) && !Keyboard.IsKeyDown(Key.RightCtrl)) return;

            e.Handled = true;

            var cambio = (int)Math.Round(e.Delta / UnidadMinimaScroll, MidpointRounding.AwayFromZero);

            if (cambio > 0 && TextoCancion.FontSize >= 120) return;
            if (cambio < 0 && TextoCancion.FontSize <= 1) return;

            TextoCancion.FontSize += cambio;
        }

        private void ListaArchivos_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null)
            {
                if (e.AddedItems != null && e.AddedItems.Count > 0 && sender is ListBox)
                {
                    var dg = sender as ListBox;
                    dg.ScrollIntoView(e.AddedItems[0]);
                }
            }
        }


    }
}
