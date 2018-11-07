using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.Collections;

namespace RecipientList
{
    class DynamicRecipientList
    {
        protected MessageQueue inQueue;
        protected MessageQueue controlQueue;
        protected IDictionary routingTable = (IDictionary)(new Hashtable());
        public DynamicRecipientList(MessageQueue inQueue, MessageQueue controlQueue)
        {
            this.inQueue = inQueue;
            this.controlQueue = controlQueue;
            inQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);
            inQueue.BeginReceive();
            controlQueue.ReceiveCompleted += new
            ReceiveCompletedEventHandler(OnControlMessage);
            controlQueue.BeginReceive();
        }
        protected void OnMessage(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue mq = (MessageQueue)source;
            mq.Formatter = new System.Messaging.XmlMessageFormatter(new String[]
            {"System.String,mscorlib"});
            Message message = mq.EndReceive(asyncResult.AsyncResult);
            if (((String)message.Body).Length > 0)
            {
                char key = ((String)message.Body)[0];
                ArrayList destinations = (ArrayList)routingTable[key];
                foreach (MessageQueue destination in destinations)
                {
                    destination.Send(message);
                    Console.WriteLine("sending message " + message.Body + " to " +
                    destination.Path);
                }
            }
            mq.BeginReceive();
        }
        // control message format is XYZ:QueueName as a single string
        protected void OnControlMessage(Object source, ReceiveCompletedEventArgs
        asyncResult)
        {
            MessageQueue mq = (MessageQueue)source;
            mq.Formatter = new System.Messaging.XmlMessageFormatter(new String[]
            {"System.String,mscorlib"});

        }
    }
}
