using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Library.Mvvm.Attributes
{
     [System.AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ReceiveMessageAttribute : Attribute
    {
        public bool IsAllowReceive;
 
        public ReceiveMessageAttribute(bool IsAllowReceive)
        {
            this.IsAllowReceive = IsAllowReceive;
        }
    }
}
