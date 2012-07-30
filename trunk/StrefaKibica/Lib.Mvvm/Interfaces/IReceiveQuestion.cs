using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Library.Mvvm.Interfaces
{
    public interface IReceiveQuestion
    {
        void ReceiveQuestion(object Question, Action<object> DoAnswer);
    }
}
