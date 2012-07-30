using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Library.Mvvm.Base
{
    internal class ContainerBase<T>
    {
        public T MessageIdentifier;
        public Predicate<object> ConditionPredicate;

        public ContainerBase(T MessageIdentifier, Predicate<object> ConditionPredicate = null)
        {
            this.MessageIdentifier = MessageIdentifier;
            this.ConditionPredicate = ConditionPredicate;
        }
    }
}
