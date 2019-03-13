using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace tcpClient
{
    public delegate void ServerResponseDelegate(string msg);

    public class SocketClient
    {
        public event ServerResponseDelegate ClientResponse;

        public void StartClient(object message)
        {
            byte[] bytes = new byte[1024];

            try
            {
                // Connect to a Remote server  
                // Get Host IP Address that is used to establish a connection  
                // In this case, we get one IP address of localhost that is IP : 127.0.0.1  
                // If a host has multiple addresses, you will get a list of addresses  
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.    
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.    
                try
                {
                    // Connect to Remote EndPoint  
                    sender.Connect(remoteEP);

                   // Console.WriteLine("Socket connected to {0}",
                    //    sender.RemoteEndPoint.ToString());
                    ClientResponse(string.Format("Socket connected to {0}",sender.RemoteEndPoint.ToString()));
                    // Encode the data string into a byte array.    
                    //byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");
                    byte[] msg = Encoding.ASCII.GetBytes(message.ToString()+"<EOF>");

                    // Send the data through the socket.    
                    int bytesSent = sender.Send(msg);

                    // Receive the response from the remote device.    
                    int bytesRec = sender.Receive(bytes);
                 //   Console.WriteLine("Echoed test = {0}",
                    //    Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    ClientResponse(string.Format("Echoed test = {0}",
                        Encoding.ASCII.GetString(bytes, 0, bytesRec)));
                    // Release the socket.    
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());

                    ClientResponse(string.Format("ArgumentNullException : {0}", ane.ToString()));
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());

                    ClientResponse(string.Format("SocketException : {0}", se.ToString()));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());

                    ClientResponse(string.Format("Unexpected exception : {0}", e.ToString()));
                }

            }
            catch (Exception e)
            {
                ClientResponse(string.Format("Unexpected exception : {0}", e.ToString()));
            }
        }
    }  
}
