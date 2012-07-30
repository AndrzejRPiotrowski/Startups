using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Library.Mvvm.Base
{
    public abstract class MessageBase
    {
        public virtual object MessageObject { set; get; }

        public MessageBase()
        {
        }

        public MessageBase(object MessageObject)
        {
            this.MessageObject = MessageObject;
        }

    }
}
