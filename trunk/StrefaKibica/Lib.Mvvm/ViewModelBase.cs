using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MES.Library.Mvvm
{
    /// <summary>
    /// Purpose: Public ViewModelBase [Class] implements the INotifyPropertyChanged for other View Models to inherit
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Purpose: Public FirePropertChanged [Function] in order to be called/fired when any property had changed.
        /// </summary>
        /// <param name="PropertyName">Property Name</param>
        public void FirePropertyChanged(String PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
