using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BackgrundProcess;
using System.Threading;
using System.Diagnostics;

namespace MonitorClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CustomerMessageBox.MessageForm MessageBox = new CustomerMessageBox.MessageForm();
        Thread t1;
        private void button1_Click(object sender, EventArgs e)
        {
            //TcpServer.SocketListener server = new TcpServer.SocketListener();
            //server.serverResponse += new TcpServer.ServerResponseDelegate(server_serverResponse);
             IInvoiceModle mode = new invoice();
            mode.InvoiceNo = 220;
            mode.InvoiceDate = new DateTime();
            
            ISave core = (invoice)mode;

            IUpdate update = (invoice)mode;

            update.Update();

            


            t1 = new Thread(new ThreadStart(core.Save));
            label4.Invoke((MethodInvoker)(() => label4.Text = t1.ThreadState.ToString()));
            t1.Start();
           // t1.Join();
           // server.StartServer();
            //MessageBox.Show("Next Customer Please","System");

            // 
            //ProcessOne one = new ProcessOne();
            //one.count += new GetCount(one_count);

            //Thread t1 = new Thread(new ThreadStart(one.Calculation));
            //t1.Start();

            //ProcessOne two = new ProcessOne();
            //two.count += new GetCount(two_count);
            //Thread t2 = new Thread(new ThreadStart(two.Calculation));



            

           
           
          
        }

        void server_serverResponse(string msg)
        {
            label1.Invoke((MethodInvoker)(() => label1.Text = msg.ToString()));
        }

        void two_count(int i)
        {
            label2.Invoke((MethodInvoker)(() => label2.Text = i.ToString()));
        }

        void one_count(int i)
        {
            label1.Invoke((MethodInvoker)(() => label1.Text = i.ToString()));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tcpClient.SocketClient client = new tcpClient.SocketClient();
            client.ClientResponse += new tcpClient.ServerResponseDelegate(client_ClientResponse);
            string messge = "empty";
            messge = textBox1.Text;
            t1 = new Thread(new ParameterizedThreadStart(client.StartClient));
            t1.Start(messge);
          //  t1.Join();
        }

        void client_ClientResponse(string msg)
        {
            label2.Invoke((MethodInvoker)(() => label2.Text = msg.ToString()));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = "Thread count";
            int number = Process.GetCurrentProcess().Threads.Count;
            label3.Invoke((MethodInvoker)(() => label3.Text = number.ToString()));

            if (t1 != null)
            {
                label4.Invoke((MethodInvoker)(() => label4.Text = t1.ThreadState.ToString()));
            }

           
                
        }

       
    }
}
