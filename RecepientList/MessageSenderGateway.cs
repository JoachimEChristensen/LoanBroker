using System;
using System.Messaging;

namespace MessageGateway
{
    public class MessageSenderGateway
    {
        public MessageSenderGateway(MessageQueue queue)
        {

        }

        public MessageSenderGateway(string queueName)
        {

        }
    }

    public interface IMessageSender
    {
        void Send(Message message);
    }     
}
