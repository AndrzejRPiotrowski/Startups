using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MES.Library.Mvvm.Interfaces
{
    public interface IMvvmManager<TView, TViewModel>
        where TView : FrameworkElement
        where TViewModel : ViewModelBase
    {
        TView this[TViewModel OViewModel]
        { get; }
        TViewModel this[TView OView]
        { get; }
        void Register(TView View, TViewModel ViewModel);
        void UnRegister(object ViewOrViewModel, bool IsView);
    }
}
