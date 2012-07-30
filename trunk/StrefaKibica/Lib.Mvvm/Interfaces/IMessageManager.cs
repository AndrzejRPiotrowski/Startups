using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MES.Library.Mvvm.Base;

namespace MES.Library.Mvvm.Interfaces
{
    public interface IMessageManager
    {

        void SubscribeByQuestionType<T>(IReceiveQuestion ReceiverObject)
           where T : QuestionBase;

        void SubscribeByQuestionType<T>(object ReceiverObject)
           where T : QuestionBase;

        void SubscribeByQuestionTypeAndCondition<T>(IReceiveQuestion ReceiverObject, Predicate<object> ConditionPredicate)
          where T : MessageBase;

        void SubscribeByQuestionTypeAndCondition<T>(object ReceiverObject, Predicate<object> ConditionPredicate)
           where T : MessageBase;

        void SubscribeByMessageType<T>(IReceiveMessage ReceiverObject)
           where T : MessageBase;

        void SubscribeByMessageType<T>(object ReceiverObject)
           where T : MessageBase;

        void SubscribeByMessageTypeAndCondition<T>(IReceiveMessage ReceiverObject, Predicate<object> ConditionPredicate)
           where T : MessageBase;

        void SubscribeByMessageTypeAndCondition<T>(object ReceiverObject, Predicate<object> ConditionPredicate)
           where T : MessageBase;

        void SubscribeByString(String MessageString, IReceiveMessage ReceiverObject);
        void SubscribeByCode(int MessageCode, IReceiveMessage ReceiverObject);

        void AskQuestionByType<TPublishType>(TPublishType QuestionToPublish, Action<object> Answering)
            where TPublishType : QuestionBase;

        void PublishMessageByType<TPublishType>(TPublishType MessageToPublish)
            where TPublishType : MessageBase;

        void PublishMessageByString(String MessageString, MessageBase MessageToPublish);
        void PublishMessageByCode(int MessageCode, MessageBase MessageToPublish);

    }
}
