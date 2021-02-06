using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace QueueForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void createQ_Click(object sender, EventArgs e)
        {
            var queueName = queueNameTxt.Text;
            var namespaceManager = NamespaceManager.Create();
            if (!namespaceManager.QueueExists(queueName)) namespaceManager.CreateQueue(queueName);

            status.Text = "Queue " + queueName + " created.";
        }

        private void sendQueue_Click(object sender, EventArgs e)
        {
            var sendingClient = QueueClient.Create(queueNameTxt.Text);

            object msgBody = sendQueueTxt.Text;
            var msg = new BrokeredMessage(msgBody);
            var teamCustomProperty = new BrokeredMessageProperty();
            
            sendingClient.Send(new BrokeredMessage(msgBody));

            status.Text = "Message sent to " + queueNameTxt.Text + " queue.";

        }

        private void readQueue_Click(object sender, EventArgs e)
        {
            var message = String.Empty;
            var receivingClient = QueueClient.Create(queueNameTxt.Text);
            BrokeredMessage msg = receivingClient.Receive();

            Stream stream = msg.GetBody<Stream>();
            StreamReader reader = new StreamReader(stream);
            string s = reader.ReadToEnd();

            status.Text = s;
 
        }

        private void sndTopic_Click(object sender, EventArgs e)
        {
            var sendingClient = TopicClient.Create("Rugby");
            BrokeredMessage msgBody = new BrokeredMessage(sendQueueTxt.Text);
            msgBody.Properties.Add("Team", "Munster");

            sendingClient.Send(msgBody);

            status.Text = "Message sent to " + queueNameTxt.Text + " queue.";
        }
    }
}
