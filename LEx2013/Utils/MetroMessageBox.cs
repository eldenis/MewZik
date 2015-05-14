using System;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Input;
using System.Text;
using System.Security.Permissions;
using System.Security;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls;
using MewZik.Views;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Primitives;
using System.Diagnostics;
using System.Windows.Media.Imaging;


namespace MewZik.Utils
{
    public class MetroMessageBox : ViewModelBase
    {
        Window _owner;
        string _messageText;
        string _caption;
        MessageBoxButton _button;
        MessageBoxImage _icon;
        MessageBoxResult _defaultResult;


        private MetroMessageBox() { }

        private void InitializeMessageBox(Window owner, string messageText, string caption,
            MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
        {
            _owner = owner;
            _messageText = messageText;
            _caption = caption;
            _button = button;
            _icon = icon;
            _defaultResult = defaultResult;
        }



        public string Caption { get { return _caption; } }
        public string Text { get { return _messageText; } }
        public bool VisibilidadBotonSi { get { return _button == MessageBoxButton.YesNo || _button == MessageBoxButton.YesNoCancel; } }
        public bool VisibilidadBotonNo { get { return _button == MessageBoxButton.YesNo || _button == MessageBoxButton.YesNoCancel; } }
        public bool VisibilidadBotonAceptar { get { return _button == MessageBoxButton.OK || _button == MessageBoxButton.OKCancel; } }
        public bool VisibilidadBotonCancelar { get { return _button == MessageBoxButton.OKCancel || _button == MessageBoxButton.YesNoCancel; } }
        public Canvas ImageSource
        {
            get
            {
                var nombre = string.Empty;
                switch (_icon)
                {
                    case MessageBoxImage.Error: nombre = "appbar_error"; break;
                    case MessageBoxImage.Information: nombre = "appbar_information_circle"; break;
                    case MessageBoxImage.Question: nombre = "appbar_question"; break;
                    case MessageBoxImage.Warning: nombre = "appbar_warning"; break;
                    case MessageBoxImage.None:
                    default: return null;
                }

                return (Canvas)Application.Current.FindResource(nombre);
            }
        }

        public bool ConImagen { get { return _icon != MessageBoxImage.None; } }


        private RelayCommand<MessageBoxResult> _boton;

        /// <summary>
        /// Gets the TestAgainCommand.
        /// </summary>
        public RelayCommand<MessageBoxResult> Boton
        {
            get
            {
                return _boton ?? (_boton = new RelayCommand<MessageBoxResult>(
                    p => { _defaultResult = p; }));
            }
        }


        #region Public Static


        /// <summary>
        /// Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="messageText">A System.String that specifies the text to display.</param>
        /// <param name="messageBoxStyle">A Style that will be applied to the MessageBox instance.</param>
        /// <returns>A System.Windows.MessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static MessageBoxResult Show(string messageText)
        {
            return Show(messageText, string.Empty, MessageBoxButton.OK);
        }

        /// <summary>
        /// Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="owner">A System.Windows.Window that represents the owner of the MessageBox</param>
        /// <param name="messageText">A System.String that specifies the text to display.</param>
        /// <param name="messageBoxStyle">A Style that will be applied to the MessageBox instance.</param>
        /// <returns>A System.Windows.MessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static MessageBoxResult Show(Window owner, string messageText)
        {
            return Show(owner, messageText, string.Empty, MessageBoxButton.OK);
        }

        /// <summary>
        /// Displays a message box that has a message and title bar caption; and that returns a result.
        /// </summary>
        /// <param name="messageText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <returns>A System.Windows.MessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static MessageBoxResult Show(string messageText, string caption)
        {
            return Show(messageText, caption, MessageBoxButton.OK);
        }

        public static MessageBoxResult Show(Window owner, string messageText, string caption)
        {
            return Show(owner, messageText, caption);
        }


        public static MessageBoxResult Show(string messageText, string caption, MessageBoxButton button)
        {
            return Show(messageText, caption, button);
        }


        public static MessageBoxResult Show(Window owner, string messageText, string caption, MessageBoxButton button)
        {
            return Show(owner, messageText, caption, button);
        }

        public static MessageBoxResult Show(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            return ShowCore(null, messageText, caption, button, icon, MessageBoxResult.None);
        }

        public static MessageBoxResult Show(Window owner, string messageText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            return Show(owner, messageText, caption, button, icon);
        }



        public static MessageBoxResult Show(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
        {
            return Show(messageText, caption, button, icon, defaultResult);
        }


        public static MessageBoxResult Show(Window owner, string messageText, string caption,
            MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
        {
            return Show(owner, messageText, caption, button, icon, defaultResult);
        }



        #endregion //Public Static

        private static MessageBoxResult ShowCore(Window owner, string messageText,
            string caption, MessageBoxButton button, MessageBoxImage icon,
            MessageBoxResult defaultResult)
        {
            var msgBox = new MetroMessageBox();

            msgBox.InitializeMessageBox(owner, messageText, caption, button, icon, defaultResult);

            var window = new MetroMessageBoxView
            {
                DataContext = msgBox,
                Owner = owner,
                WindowStartupLocation = owner != null ? System.Windows.WindowStartupLocation.CenterOwner : System.Windows.WindowStartupLocation.CenterScreen,
            };

            window.ShowDialog();

            return msgBox._defaultResult;
        }

    }

}
