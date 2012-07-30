using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Diagnostics;

namespace MES.Library.Mvvm.Base
{
    // public class CommandBase<T> : ICommand
    //    where T: class
    //{
    //    protected Func<T, bool> CanExecuteDelegate;
    //    protected Action<T> ExecuteDelegate;

    //    public event EventHandler CanExecuteChanged
    //    {
    //        add
    //        {
    //            if (CanExecuteDelegate != null)
    //                CommandManager.RequerySuggested += value;
    //        }
    //        remove
    //        {
    //            if (CanExecuteDelegate != null)
    //                CommandManager.RequerySuggested -= value;
    //        }
    //    }

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="CommandBase&lt;T&gt;"/> class and the command can always be executed.
    //    /// </summary>
    //    /// <param name="execute">The execution logic.</param>
    //    public CommandBase(Action<T> ExecuteDelegate)
    //        : this(null, ExecuteDelegate)
    //    {
    //    }

    //    public CommandBase(Func<T, bool> CanExecuteDelegate, Action<T> ExecuteDelegate)
    //    {
    //        this.CanExecuteDelegate = CanExecuteDelegate;
    //        this.ExecuteDelegate = ExecuteDelegate;
    //    }

    //    //public abstract bool CanExecute(object parameter);
    //    //public abstract void Execute(object parameter);
    //    [DebuggerStepThrough]
    //    public virtual bool CanExecute(object parameter)
    //    {
    //        return CanExecuteDelegate == null ? true : CanExecuteDelegate(parameter as T);
    //    }

    //    public virtual void Execute(object parameter)
    //    {
    //        ExecuteDelegate(parameter as T);
    //    }

    //}

    // public class CommandBase : ICommand
    // {
    //     protected Func<bool> CanExecuteDelegate;
    //     protected Action ExecuteDelegate;

    //     public event EventHandler CanExecuteChanged
    //     {
    //         add
    //         {
    //             if (CanExecuteDelegate != null)
    //                 CommandManager.RequerySuggested += value;
    //         }
    //         remove
    //         {
    //             if (CanExecuteDelegate != null)
    //                 CommandManager.RequerySuggested -= value;
    //         }
    //     }

    //     /// <summary>
    //     /// Initializes a new instance of the <see cref="CommandBase"/> class and the command can always be executed.
    //     /// </summary>
    //     /// <param name="execute">The execution logic.</param>
    //     public CommandBase(Action ExecuteDelegate)
    //         : this(null, ExecuteDelegate)
    //     {
    //     }

    //     public CommandBase(Func<bool> CanExecuteDelegate, Action ExecuteDelegate)
    //     {
    //         this.CanExecuteDelegate = CanExecuteDelegate;
    //         this.ExecuteDelegate = ExecuteDelegate;
    //     }

    //     [DebuggerStepThrough]
    //     public bool CanExecute(object parameter)
    //     {
    //         return CanExecuteDelegate == null ? true : CanExecuteDelegate();
    //     }

    //     public void Execute(object parameter)
    //     {
    //         ExecuteDelegate();
    //     }

    // }

}
