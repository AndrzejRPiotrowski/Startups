#if DEBUG
#define TRACE
#endif

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

using MES.Library.Mvvm.Base;
using MES.Library.Mvvm.Interfaces;
using MES.Library.Mvvm.Containers;
using MES.Library.Mvvm.Attributes;

namespace MES.Library.Mvvm
{
    public class MessageManager : IMessageManager
    {
        private List<MessageContainer<Type>> MessagesByType;
        private List<MessageContainer<String>> MessagesByString;
        private List<MessageContainer<int>> MessagesByCode;

        private List<QuestionContainer<Type>> QuestionsByType;

        public MessageManager()
        {
            QuestionsByType = new List<QuestionContainer<Type>>();
            MessagesByType = new List<MessageContainer<Type>>();
            MessagesByCode = new List<MessageContainer<int>>();
            MessagesByString = new List<MessageContainer<String>>();
        }

        public void SubscribeByQuestionType<T>(IReceiveQuestion ReceiverObject)
           where T : QuestionBase
        {
            var FoundQuestions = from question in QuestionsByType
                                 where question.ReceiverObject == ReceiverObject
                                 select question;

            int FoundQuestionsCount = FoundQuestions.Count();

            if (FoundQuestionsCount == 0)
                QuestionsByType.Add(new QuestionContainer<Type>(typeof(T), ReceiverObject));
        }

        public void SubscribeByQuestionType<T>(object ReceiverObject)
            where T : QuestionBase
        {
            var FoundQuestions = from question in QuestionsByType
                                 where question.ReceiverObject == ReceiverObject
                                 select question;

            int FoundQuestionsCount = FoundQuestions.Count();

            if (FoundQuestionsCount == 0)
                QuestionsByType.Add(new QuestionContainer<Type>(typeof(T), ReceiverObject));
        }

        public void SubscribeByQuestionTypeAndCondition<T>(IReceiveQuestion ReceiverObject, Predicate<object> ConditionPredicate)
            where T : MessageBase
        {
            if (ConditionPredicate == null)
                throw new Exception("The ConditionPredicate entered can not be null.");

            var FoundQuestions = from question in QuestionsByType
                                 where question.ReceiverObject == ReceiverObject
                                 select question;

            int FoundQuestionsCount = FoundQuestions.Count();

            if (FoundQuestionsCount == 0)
                QuestionsByType.Add(new QuestionContainer<Type>(typeof(T), ReceiverObject, ConditionPredicate));
        }

        public void SubscribeByQuestionTypeAndCondition<T>(object ReceiverObject, Predicate<object> ConditionPredicate)
            where T : MessageBase
        {
            if (ConditionPredicate == null)
                throw new Exception("The ConditionPredicate entered can not be null.");

            var FoundQuestions = from question in QuestionsByType
                                 where question.ReceiverObject == ReceiverObject
                                 select question;

            int FoundQuestionsCount = FoundQuestions.Count();

            if (FoundQuestionsCount == 0)
                QuestionsByType.Add(new QuestionContainer<Type>(typeof(T), ReceiverObject, ConditionPredicate));
        }

        public void SubscribeByMessageType<T>(IReceiveMessage ReceiverObject) 
            where T : MessageBase
        {
            var FoundMessages = from message in MessagesByType
                                where message.ReceiverObject == ReceiverObject
                                select message;

            int FoundMessagesCount = FoundMessages.Count();

            if (FoundMessagesCount == 0)
                MessagesByType.Add(new MessageContainer<Type>(typeof(T), ReceiverObject));
        }

        public void SubscribeByMessageType<T>(object ReceiverObject)
            where T : MessageBase
        {
            var FoundMessages = from message in MessagesByType
                                where message.ReceiverObject == ReceiverObject
                                select message;

            int FoundMessagesCount = FoundMessages.Count();

            if (FoundMessagesCount == 0)
                MessagesByType.Add(new MessageContainer<Type>(typeof(T), ReceiverObject));
        }

        public void SubscribeByMessageTypeAndCondition<T>(IReceiveMessage ReceiverObject, Predicate<object> ConditionPredicate) 
            where T : MessageBase
        {
            if (ConditionPredicate == null)
                throw new Exception("The ConditionPredicate entered can not be null.");

            var FoundMessages = from message in MessagesByType
                                where message.ReceiverObject == ReceiverObject 
                                select message;

            int FoundMessagesCount = FoundMessages.Count();

            if (FoundMessagesCount == 0)
                MessagesByType.Add(new MessageContainer<Type>(typeof(T), ReceiverObject, ConditionPredicate));
        }

        public void SubscribeByMessageTypeAndCondition<T>(object ReceiverObject, Predicate<object> ConditionPredicate)
            where T : MessageBase
        {
            if (ConditionPredicate == null)
                throw new Exception("The ConditionPredicate entered can not be null.");

            var FoundMessages = from message in MessagesByType
                                where message.ReceiverObject == ReceiverObject
                                select message;

            int FoundMessagesCount = FoundMessages.Count();

            if (FoundMessagesCount == 0)
                MessagesByType.Add(new MessageContainer<Type>(typeof(T), ReceiverObject, ConditionPredicate));
        }

        public void SubscribeByString(String MessageString, IReceiveMessage ReceiverObject)
        {
            MessagesByString.Add(new MessageContainer<String>(MessageString, ReceiverObject));
        }

        public void SubscribeByCode(int MessageCode, IReceiveMessage ReceiverObject)
        {
            MessagesByCode.Add(new MessageContainer<int>(MessageCode, ReceiverObject));
        }

        public void AskQuestionByType<TPublishType>(TPublishType QuestionToPublish, Action<object> Answering)
            where TPublishType : QuestionBase
        {
            // Purpose: Should be removed soon
            if (QuestionToPublish == null)
                throw new Exception("You are trying to publish a question with a null value. ");

            if (Answering == null)
                throw new Exception("\"Answering\" Callback is null. ");

            List<QuestionContainer<Type>> FoundQuestions = new List<QuestionContainer<Type>>();

            for (int i = 0; i < QuestionsByType.Count; i++)
            {
                // Purpose: To get all of the messages that of the sametime of TPublishType
                if (QuestionsByType[i].MessageIdentifier == typeof(TPublishType))
                {
                    // Purpose: To check if there is condition predicate or not
                    if (QuestionsByType[i].ConditionPredicate != null)
                    {
                        // Purpose: To check if the condition predicate is validated or not
                        if (QuestionsByType[i].ConditionPredicate(QuestionToPublish))
                            FoundQuestions.Add(QuestionsByType[i]);
                    }
                    else
                    {
                        FoundQuestions.Add(QuestionsByType[i]);
                    }
                }
            }

            if (FoundQuestions.Count > 0)
            {
                int FoundQuestionsCount = FoundQuestions.Count();

                for (int i = 0; i < FoundQuestionsCount; i++)
                {
                    
                    if (FoundQuestions[i].ReceiverObject != null)
                    {
                        // Purpose: To send by identifying the receiver through the "IReceiveQuestion" interface
                        FoundQuestions[i].ReceiverObject.ReceiveQuestion(QuestionToPublish, Answering);
                    }
                    else
                    {
                        // Purpose: To send by identifying the receiver through the "ReceiveQuestionAttribute" attribute
                        InvokeQuestionReceiveMethod(FoundQuestions[i].GenericReceiverObject, QuestionToPublish, Answering);
                    }
                }
            }
        }

        public void PublishMessageByType<TPublishType>(TPublishType MessageToPublish) 
            where TPublishType : MessageBase
        {

            // Purpose: Should be removed soon
            if (MessageToPublish.GetType() != typeof(TPublishType))
                throw new Exception("You are trying to publish a message with the wrong message type");

            List<MessageContainer<Type>> FoundMessages = new List<MessageContainer<Type>>();

            for (int i = 0; i < MessagesByType.Count; i++)
            {
                // Purpose: To get all of the messages that of the sametime of TPublishType
                if (MessagesByType[i].MessageIdentifier == typeof(TPublishType))
                {
                    // Purpose: To check if there is condition predicate or not
                    if (MessagesByType[i].ConditionPredicate != null)
                    {
                        // Purpose: To check if the condition predicate is validated or not
                        if (MessagesByType[i].ConditionPredicate(MessageToPublish))
                            FoundMessages.Add(MessagesByType[i]);
                    }
                    else
                    {
                        FoundMessages.Add(MessagesByType[i]);
                    }
                }
            }

            if (FoundMessages.Count > 0)
            {
                int FoundMessagesCount = FoundMessages.Count();

                for (int i = 0; i < FoundMessagesCount; i++)
                {

                    if (FoundMessages[i].ReceiverObject != null)
                    {
                        // Purpose: To send by identifying the receiver through the "IReceiveQuestion" interface
                        FoundMessages[i].ReceiverObject.ReceiveMessage(MessageToPublish);
                    }
                    else
                    {
                        // Purpose: To send by identifying the receiver through the "ReceiveQuestionAttribute" attribute
                        InvokeMessageReceiveMethod(FoundMessages[i].GenericReceiverObject, MessageToPublish);
                    }
                }
            }
        }

        public void PublishMessageByString(String MessageString, MessageBase MessageToPublish)
        {
            IEnumerable<MessageContainer<String>> FoundMessages =
                from Msg in MessagesByString
                where Msg.MessageIdentifier == MessageString
                select Msg;

            if (FoundMessages != null)
            {
                int FoundMessagesCount = FoundMessages.Count();

                for (int i = 0; i < FoundMessagesCount; i++)
                    FoundMessages.ElementAt(i).ReceiverObject.ReceiveMessage(MessageToPublish);
            }
        }

        public void PublishMessageByCode(int MessageCode, MessageBase MessageToPublish)
        {
            IEnumerable<MessageContainer<int>> FoundMessages =
                from Msg in MessagesByCode
                where
                Msg.MessageIdentifier == MessageCode
                select Msg;

            if (FoundMessages != null)
            {
                int FoundMessagesCount = FoundMessages.Count();

                for (int i = 0; i < FoundMessagesCount; i++)
                    FoundMessages.ElementAt(i).ReceiverObject.ReceiveMessage(MessageToPublish);
            }
        }

        #region "Utility Functions"

        private T Cast<T>(object o)
        {
            return (T)o;
        }

        private object CastObject(object ObjectToCast, Type ToType)
        {
            MethodInfo CastingGenericMethod = this.GetType().GetMethod("Cast", BindingFlags.NonPublic | BindingFlags.Instance).MakeGenericMethod(ToType);
            return CastingGenericMethod.Invoke(this, new object[] { ObjectToCast });
        }

        private void InvokeQuestionReceiveMethod(object ReceiverObject, object QuestionToPublish, Action<object> Answering)
        {
            List<MethodInfo> MethodsToCall = new List<MethodInfo>();

            MethodInfo[] Methods = ReceiverObject.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);

            foreach (MethodInfo Meth in Methods)
            {
                object[] AttributesFound = Meth.GetCustomAttributes(typeof(ReceiveQuestionAttribute), false);

                if (AttributesFound.Length == 1)
                {
                    ReceiveQuestionAttribute AttributeFound = AttributesFound.FirstOrDefault() as ReceiveQuestionAttribute;

                    if (AttributeFound != null)
                    {
                        if (AttributeFound.IsAllowReceive)
                        {
                            ParameterInfo[] Parameters = Meth.GetParameters();

                            if (Parameters.Length == 2)
                            {
                                if (Parameters[0].ParameterType == typeof(object) && Parameters[1].ParameterType == typeof(Action<object>))
                                    MethodsToCall.Add(Meth);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < MethodsToCall.Count; i++)
                MethodsToCall[i].Invoke(ReceiverObject, new Object[] { QuestionToPublish, Answering });
        }

        private void InvokeMessageReceiveMethod(object ReceiverObject, object MessageToPublish)
        {
            List<MethodInfo> MethodsToCall = new List<MethodInfo>();

            MethodInfo[] Methods = ReceiverObject.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);

            foreach (MethodInfo Meth in Methods)
            {
                object[] AttributesFound = Meth.GetCustomAttributes(typeof(ReceiveMessageAttribute), false);

                if (AttributesFound.Length == 1)
                {
                    ReceiveMessageAttribute AttributeFound = AttributesFound.FirstOrDefault() as ReceiveMessageAttribute;

                    if (AttributeFound != null)
                    {
                        if (AttributeFound.IsAllowReceive)
                        {
                            ParameterInfo[] Parameters = Meth.GetParameters();

                            if (Parameters.Length == 1)
                            {
                                if (Parameters[0].ParameterType == typeof(object))
                                    MethodsToCall.Add(Meth);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < MethodsToCall.Count; i++)
                MethodsToCall[i].Invoke(ReceiverObject, new Object[] { MessageToPublish });
        }

        #endregion
    }
}
