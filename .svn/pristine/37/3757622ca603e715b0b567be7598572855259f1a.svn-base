using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MES.Library.Mvvm.Interfaces
{
    public interface IRegionManager
    {
        void AssignShell<TView>(TView ShellToAssign) where TView : UIElement;

        /// <summary>
        /// Purpose: In order to replace one view with another inside the region manager
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <param name="OriginalView"></param>
        /// <param name="ToReplaceView"></param>
        void ReplaceView<TView>(TView ViewToReplace) where TView : UIElement;

        /// <summary>
        /// Purpose: In order to add a view in an empty region
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <param name="ViewToAdd"></param>
        void AddView<TView>(TView ViewToAdd) where TView : UIElement;


        /// <summary>
        /// Purpose: In order to overlay a view on top of another
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <param name="ViewToOverlay"></param>
        void OverlayView<TView>(TView ViewToOverlay) where TView : UIElement;
    }
}
