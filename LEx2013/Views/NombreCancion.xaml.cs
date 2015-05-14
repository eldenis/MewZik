using System.IO;
using System.Windows.Controls;

namespace MewZik.Views
{
    /// <summary>
    /// Interaction logic for NombreCancion.xaml
    /// </summary>
    public partial class NombreCancion : UserControl
    {
        public NombreCancion()
        {
            InitializeComponent();

        }

        private void TextoTargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Texto.Text)) return;

            Texto.SelectionStart=0;
            Texto.SelectionLength = Path.GetFileNameWithoutExtension(Texto.Text).Length;
        }
    }
}
