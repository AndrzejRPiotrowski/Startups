using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace StrefaKibicaGeek.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        // Purpose: Public PropertyChangedEventHandler [Delegate] which will be fired in case any property had been changed
        public event PropertyChangedEventHandler PropertyChanged;

        public void FirePropertyChanged(String PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
