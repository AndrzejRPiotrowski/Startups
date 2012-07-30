using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MES.Library.Mvvm.Interfaces;
using System.Windows;

namespace MES.Library.Mvvm
{
    public class RegionManager: IRegionManager
    {
        public static readonly DependencyProperty UsingRegionManagerProperty =
            DependencyProperty.RegisterAttached("UsingRegionManager", typeof(bool), typeof(IRegionManager),
            new PropertyMetadata(new PropertyChangedCallback(OnUsingRegionChanged)));
            
        private static object _ThreadingCheckObject = new object();
        private static IRegionManager _Default;
        
        private static IMvvmManager<FrameworkElement, ViewModelBase> _MvvmManagerInstance;
        public static IMvvmManager<FrameworkElement, ViewModelBase> MvvmManagerInstance
        {
            set { RegionManager._MvvmManagerInstance = value; }
            private get { return RegionManager._MvvmManagerInstance; }
        }

        private RegionManager()
        {
        }

        public void Init()
        {
            if (_Default == null)
            {
                //Purpose: We lock the synchronized object in order to block
                //         multiple threads from accessing it at the same time
                lock (_ThreadingCheckObject)
                {
                    if (_Default == null)
                        _Default = new RegionManager();
                }
            }
        }

        public static IRegionManager ReturnInstance()
        {
            return _Default;
        }

        public void AssignShell<TView>(TView ShellToAssign) where TView : UIElement
        {
            throw new NotImplementedException();
        }

        public void ReplaceView<TView>(TView ViewToReplace) where TView : UIElement
        {
        }

        public void AddView<TView>(TView ViewToAdd) where TView : UIElement
        {
            throw new NotImplementedException();
        }

        public void OverlayView<TView>(TView ViewToOverlay) where TView : UIElement
        {
            throw new NotImplementedException();
        }

        private static void OnUsingRegionChanged(DependencyObject Element, DependencyPropertyChangedEventArgs Args)
        {
            // Purpose: To get the string value of the view type in which the user had specified.
        }

        public static bool GetUsingRegionManager(DependencyObject obj)
        {
            return (bool)obj.GetValue(UsingRegionManagerProperty);
        }

        public static void SetUsingRegionManager(DependencyObject obj, bool value)
        {
            obj.SetValue(UsingRegionManagerProperty, value);
        }


    }
}
