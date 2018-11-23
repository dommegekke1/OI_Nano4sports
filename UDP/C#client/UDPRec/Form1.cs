using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace UDPRec
{
    public partial class Form1 : Form
    {
        UdpClient Client = new UdpClient(1111); //port
        string data = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Client.BeginReceive(new AsyncCallback(recv), null);
            }
            catch (Exception ex)
            {
                richTextBox1.Text += ex.Message.ToString();
                throw;
            }
        }

        void recv(IAsyncResult res)
        {
            IPEndPoint RemoteIP = new IPEndPoint(IPAddress.Any, 60240);
            byte[] received = Client.EndReceive(res, ref RemoteIP);
            data = Encoding.UTF8.GetString(received);

            //to avoid cross-trheading we use Method Invoker
            this.Invoke(new MethodInvoker(delegate
            {
                richTextBox1.Text += "\nReceived data: " + data;
            }));

            Client.BeginReceive(new AsyncCallback(recv), null);
        }
    }
}
