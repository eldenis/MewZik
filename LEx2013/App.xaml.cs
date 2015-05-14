using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shell;
using Microsoft.Shell;
using MessageBox = Xceed.Wpf.Toolkit.MessageBox;

namespace MewZik
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, ISingleInstanceApp
    {
        public static bool ShuttingDown { get; private set; }

        [STAThread]
        public static void Main()
        {
            if (!SingleInstance<App>.InitializeAsFirstInstance("MewZik")) return;

            var app = new App();
            app.InitializeComponent();
            app.Run();

            // Allow single instance code to perform cleanup operations
            SingleInstance<App>.Cleanup();
        }


        public bool SignalExternalCommandLineArgs(IList<string> args)
        {
            if (args == null || args.Count == 0) return true;

            if (args.Count > 1 && args[1].ToLowerInvariant() == "/cerrar")
                Task.Factory.StartNew(() => { Thread.Sleep(50); Dispatcher.Invoke(Salir); });

            return true;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SessionEnding += delegate { Salir(); };
            CrearHandlerExcepciones();
            //AgregarJumpListCerrar();
        }

        internal static void Salir()
        {
            ShuttingDown = true;
            Current.Shutdown(0);
        }

        private void AgregarJumpListCerrar()
        {
            var jumpList = new JumpList();
            jumpList.JumpItems.Add(new JumpTask
            {
                Title = "Cerrar MewZik",
                Arguments = "/cerrar",
                Description = "Cierra la aplicación",
                CustomCategory = "Acciones",
                IconResourcePath = Assembly.GetEntryAssembly().CodeBase,
                ApplicationPath = Assembly.GetEntryAssembly().Location
            });
            jumpList.ShowFrequentCategory = false;
            jumpList.ShowRecentCategory = false;

            JumpList.SetJumpList(Current, jumpList);
        }

        private void CrearHandlerExcepciones()
        {
            DispatcherUnhandledException += (s, e) =>
            {
                e.Handled = true;
                MessageBox.Show(string.Format("Hubo un error: {0}\n\n{1}", e.Exception.Message, e.Exception.StackTrace));
            };
        }

    }
}
