using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows;



using MES.Library.Mvvm.Interfaces;

namespace MES.Library.Mvvm
{
    /// <summary>
    /// Purpose: Public VVMManager [Generic Class] to control the binding between the view and the viewmodel
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    public class VVMManager<TView, TViewModel> : IMvvmManager<TView, TViewModel>
        where TView : FrameworkElement
        where TViewModel : ViewModelBase
    {
        // Purpose: Private VVMList [List<VVMContainer>] to store the views and view models registered to the VVMManager.
        private List<VVMContainer> _VVMList;

        // Purpose: Private VVMContainer [struct] to act as a container for both the views and the view models.
        internal sealed class VVMContainer
        {
            public TView View;
            public TViewModel ViewModel;
            public int ViewHashCode;
            public int ViewModelHashCode;
            public String ViewRegion;

            public VVMContainer(TView View, TViewModel ViewModel)
            {
                this.View = View;
                this.ViewModel = ViewModel;
                this.ViewHashCode = View.GetHashCode();
                this.ViewModelHashCode = ViewModel.GetHashCode();
            }
        }

        /// <summary>
        /// Purpose: Public Indexer to return the required View by passing the ViewModel.
        /// </summary>
        /// <param name="OViewModel"> OViewModel: ViewModelBase derived object</param>
        /// <returns> TView: FrameworkElement derived object </returns>
        public TView this[TViewModel OViewModel]
        {
            get
            {
                VVMContainer KeyContainer = FindViewOrViewModel(OViewModel, false);
                return KeyContainer.View;
            }
        }

        /// <summary>
        /// Purpose: Public Indexer to return the required ViewModel by passing the view.
        /// </summary>
        /// <param name="OView"> OView: FrameworkElement derived object</param>
        /// <returns> TViewModel: ViewModelBase derived object </returns>
        public TViewModel this[TView OView]
        {
            get
            {
                VVMContainer KeyContainer = FindViewOrViewModel(OView, true);
                return KeyContainer.ViewModel;
            }
        }

        /// <summary>
        /// Purpose: Returning a list of views by view type, mostly will be used by the RegionManager
        /// </summary>
        /// <param name="ViewType"></param>
        /// <returns></returns>
        public List<TView> this[Type OViewType]
        {
            get
            {
                //List<TView> ReturnViews = null;
                //List<VVMContainer> FoundContainers =
                //    _VVMList.FindAll((VVMContainerTemp) =>
                //    { return VVMContainerTemp.View.GetType() == OViewType; });

                //if (FoundContainers != null)
                //{
                //    for (int i = 0; i < FoundContainers.Count; i++)
                //        ReturnViews.Add(FoundContainers[i].View);
                //}

                //return ReturnViews;

                return null;
            }
        }

        public TView this[Type OViewType, String Name]
        {
            get
            {
                //VVMContainer FoundContainer =
                //    _VVMList.Find((VVMContainerTemp) =>
                //    {
                //        return
                //          VVMContainerTemp.View.GetType() == OViewType
                //          &&
                //          VVMContainerTemp.View.Name == Name;
                //    });

                //if (FoundContainer != null)
                //    return FoundContainer.View;
                //else
                //    return null;

                return null;

            }
        }

        /// <summary>
        /// Purpose: Public Constructor for the VVMManager class
        /// </summary>
        public VVMManager()
        {
            // Initializing Data Members
            _VVMList = new List<VVMContainer>();
        }

        /// <summary>
        /// Purpose: Public Register() [Function] for the manager caller to register new views and viewmodels
        /// </summary>
        /// <param name="View"> View: the current view to be registered. </param>
        /// <param name="ViewModel"></param>
        public void Register(TView View, TViewModel ViewModel)
        {
            // Purpose: To start registering the view with the viewmodel (DataContext)
            ProcessRegistration(View, ViewModel);
        }

        /// <summary>
        /// Purpose: Public UnRegister() [Function] for unregistering the viewmodel & view specificied.
        /// </summary>
        /// <param name="ViewOrViewModel"></param>
        /// <param name="IsView"></param>
        public void UnRegister(object ViewOrViewModel, bool IsView)
        {
            VVMContainer KeyContainer = FindViewOrViewModel(ViewOrViewModel, IsView);

            if (!KeyContainer.Equals(null))
            {
                KeyContainer.View = null;
                KeyContainer.ViewModel = null;
                _VVMList.Remove(KeyContainer);
                GC.Collect(0);

#if !DEBUG
                Console.WriteLine("GC Generation Number: " + GC.MaxGeneration);
                Console.WriteLine("GC Collected objects: " + GC.CollectionCount(2));
#endif
            }

        }


        // Purpose: Private ProcessRegistration() [Function] to perform the initialization of the view and viewmodel registered.
        private void ProcessRegistration(TView View, TViewModel ViewModel)
        {
            // Assigning the datacontext of the view to the viewmodel
            View.DataContext = ViewModel;

            // Storing the registered view with its respective viewmodel
            _VVMList.Add(new VVMContainer(View, ViewModel));
        }

        private VVMContainer FindViewOrViewModel(object ViewOrViewModel, bool IsView)
        {
            //TViewModel OViewModel;

            //if (IsView)
            //{
            //    TView OView = (TView)ViewOrViewModel;

            //    VVMContainer KeyContainer;

            //    KeyContainer = _VVMList.Find
            //        (
            //        new Predicate<VVMContainer>
            //            (
            //            (Container) =>
            //            {
            //                if (Container.View == OView)
            //                    return Container.ViewHashCode == OView.GetHashCode();
            //                else
            //                    return false;
            //            }
            //            )
            //         );

            //    return KeyContainer;
            //}
            //else
            //{
            //    OViewModel = (TViewModel)ViewOrViewModel;

            //    VVMContainer KeyContainer;

            //    KeyContainer = _VVMList.Select(
            //        (
            //        new Predicate<VVMContainer>
            //            (
            //            (Container) =>
            //            {
            //                if (Container.ViewModel == OViewModel)
            //                    return Container.ViewModelHashCode == OViewModel.GetHashCode();
            //                else
            //                    return false;
            //            }
            //            )
            //         );
            //    return KeyContainer;

            return null;
        }
    }
}

