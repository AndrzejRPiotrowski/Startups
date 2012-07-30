using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MES.Library.Mvvm.Base;
using MES.Library.Mvvm.Interfaces;

namespace MES.Library.Mvvm.Containers
{
    internal class MessageContainer<T> : ContainerBase<T>
    {
        public IReceiveMessage ReceiverObject;
        public object GenericReceiverObject;

        public MessageContainer(T MessageIdentifier, IReceiveMessage ReceiverObject, Predicate<object> ConditionPredicate = null)
            : base(MessageIdentifier, ConditionPredicate)
        {
            this.MessageIdentifier = MessageIdentifier;
            this.ReceiverObject = ReceiverObject;
            this.ConditionPredicate = ConditionPredicate;
        }

        public MessageContainer(T MessageIdentifier, object GenericReceiverObject, Predicate<object> ConditionPredicate = null)
            : base(MessageIdentifier, ConditionPredicate)
        {
            this.MessageIdentifier = MessageIdentifier;
            this.GenericReceiverObject = GenericReceiverObject;
            this.ConditionPredicate = ConditionPredicate;
        }
    }
}
