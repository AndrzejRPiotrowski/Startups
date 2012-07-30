using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MES.Library.Mvvm
{
    public class EventToCommand
    {
        public static readonly DependencyProperty ClickEventToCommandProperty = DependencyProperty.RegisterAttached(
            "ClickEventToCommand", typeof(String), typeof(EventToCommand),
            new PropertyMetadata(new PropertyChangedCallback(OnClickEventToCommandChanged))
            );

        private static void OnClickEventToCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
        }

        public static String GetClickEventToCommand(DependencyObject obj)
        {
            return (String)obj.GetValue(ClickEventToCommandProperty);
        }

        public static void SetClickEventToCommand(DependencyObject obj, String value)
        {
            obj.SetValue(ClickEventToCommandProperty, value);
        }
    }
}
