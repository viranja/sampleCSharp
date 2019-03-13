using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using System.Data.SQLite;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Desktop_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SQLiteConnection _connection;
        SQLiteCommand _command;
        SQLiteDataAdapter _adapter;
        DataSet ds = null;

        private void dbconnect()
        {
            //            string constring = "Data Source= D:\\Viranja\\Samples\\db\\3\\inv3004.s3db;";
            //            try
            //            {

            //                _connection = new SQLiteConnection(constring);
            //                //_connection.SetPassword("123");
            //                _connection.Open();

            //                string insert = @"INSERT INTO Customer (
            //                         CustomerCode,
            //                         Description
            //                     )
            //                     VALUES (
            //                         'mk',
            //                         'mark kinght'
            //                     )";


            //                _command = new SQLiteCommand(insert, _connection);
            //                _command.ExecuteNonQuery();

            //                SQLiteDataReader reader = _command.ExecuteReader();
            //                while (true)
            //                {

            //                }
            //                //_adapter = new SQLiteDataAdapter(_command);
            //                //ds = new DataSet();
            //                //_adapter.Fill(ds);

            //                ////User u = new User();
            //                ////u.Validate();

            //                //SupperUser su = new SupperUser();
            //                //su.Validate();
            //            }
            //            catch (Exception ex)
            //            {

            //                MessageBox.Show(ex.Message);
            //            }

        }



        private Thread n_server;
        private Thread n_client;
        private Thread n_send_server;
        private TcpClient client;
        private TcpListener listener;
        private int port = 1000;
        private string IP = " ";
        private Socket socket;

        private void Form1_Load(object sender, EventArgs e)
        {

            server.Connect("test server", "hello");
        }
        public void Server()
        {
            
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
           
            try
            {

                txtServerResponse.Invoke((MethodInvoker)delegate { txtServerResponse.AppendText("\r\nServer connecting"); });

                var timerTimer = new System.Threading.Timer((state) => { listener.Stop();
                txtServerResponse.Invoke((MethodInvoker)delegate { txtServerResponse.AppendText("\r\nconnection faild,please try again"); });
                
                }, null, 20000, Timeout.Infinite);



                int attapt = 1;
                while (!listener.Pending())
                {
                    //txtServerResponse.Invoke((MethodInvoker)delegate { txtServerResponse.AppendText("\r\nAttempt" + (attapt).ToString()); });
                    //txtServerResponse.Invoke((MethodInvoker)delegate { txtServerResponse.AppendText("Server connecting"); });
                    for (int i = 1; i <= 10; i++)
                    {
                        txtServerResponse.Invoke((MethodInvoker)delegate { txtServerResponse.AppendText("."); });
                        Thread.Sleep(200);
                    }
                    txtServerResponse.Invoke((MethodInvoker)delegate { txtServerResponse.Text = txtServerResponse.Text.Replace(".",""); });
                    attapt++;
                }


                
                

                if (socket.Connected)
                {
                    txtServerResponse.Invoke((MethodInvoker)delegate { txtServerResponse.Text = "Client : " + socket.RemoteEndPoint.ToString(); });
                }
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n_server = new Thread(new ThreadStart(Server));
            n_server.IsBackground = true;
            n_server.Start();
            txtServerResponse.Text = "Server up";
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread fileGen = new Thread(new ThreadStart(FileGenration));
            fileGen.IsBackground = true;
            fileGen.Start();
        }


        private void FileGenration()
        {
            for (int i = 0; i < 100; i++)
            {
                label1.Invoke((MethodInvoker)delegate { label1.Text = "file excuting 0000000"+i.ToString(); });
                Thread.Sleep(300);
            }
        }


        
    }
}
