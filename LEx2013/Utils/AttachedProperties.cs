using System.Windows;
using System.Windows.Controls;

namespace MewZik.Utils
{
    public class AttachedProperties
    {
        #region ReturnToStart
        public static bool GetReturnToStartProperty(DependencyObject obj)
        {
            return (bool)obj.GetValue(ReturnToStartPropertyProperty);
        }

        public static void SetReturnToStartProperty(DependencyObject obj, bool value)
        {
            obj.SetValue(ReturnToStartPropertyProperty, value);
        }

        // Using a DependencyProperty as the backing store for ReturnToStartProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReturnToStartPropertyProperty =
            DependencyProperty.RegisterAttached("ReturnToStartProperty", typeof(bool), typeof(AttachedProperties),
            new PropertyMetadata(false, null, CambioValorReturnToStart));



        public static object CambioValorReturnToStart(DependencyObject d, object baseValue)
        {
            if (d is TextBox)
            {
                var tb = d as TextBox;
                tb.BeginChange();
                tb.ScrollToHome();
                tb.EndChange();
            }
            else if (d is ListBox)
            {
                var lb = d as ListBox;
                if (lb.Items.Count > 0)
                    lb.ScrollIntoView(lb.Items[0]);
            }
            return false;
        }
        #endregion


        #region TieneFoco
        public static bool GetTieneFoco(DependencyObject obj)
        {
            return (bool)obj.GetValue(TieneFocoProperty);
        }

        public static void SetTieneFoco(DependencyObject obj, bool value)
        {
            obj.SetValue(TieneFocoProperty, value);
        }

        public static readonly DependencyProperty TieneFocoProperty =
                DependencyProperty.RegisterAttached("TieneFoco", typeof(bool), typeof(AttachedProperties),
                new UIPropertyMetadata(false, null, (s, e) =>
                {
                    var valorBooleano = (bool)e;
                    if (valorBooleano)
                    {
                        var uie = (FrameworkElement)s;

                        if (uie != null && !uie.IsKeyboardFocusWithin)
                        {
                            var cambiar = !uie.Focusable;
                            if (cambiar) uie.Focusable = true;
                            uie.Focus();
                            if (cambiar) uie.Focusable = false;
                        }
                    }
                    return valorBooleano;
                }));
        #endregion
    }
}
