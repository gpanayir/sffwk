using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Mail.Pop3;
using System.Net.Sockets;
using System.Diagnostics;
using System.Collections;
using Fwk.Mail.Common;

namespace Fwk.Mail.Pop3
{
    sealed class Pop3
    {
        private List<Pop3Message> MessageList;

        // Singleton
        private Pop3() { }
        public static readonly Pop3 Instance = new Pop3();

        public LoginResponseEnum Connect(string pServer, string pUsername, string pPassword)
        {
            String Response = String.Empty;

            // Create a TCP client for a TCP connection
            using (TcpClient tcpClient = new TcpClient())
            {

                try
                {
                    // Connect this TCP client to the server IP/name and port specified in the form
                    tcpClient.Connect(pServer, 110);

                    // Create a network stream to retrieve data from the TCP client
                    NetworkStream netStream = tcpClient.GetStream();
                    // We need a stream reader to be able to read the network stream
                    System.IO.StreamReader strReader = new System.IO.StreamReader(netStream);
                    // If the connection was made successfully
                    if (tcpClient.Connected)
                    {
                        byte[] WriteBuffer = new byte[1024];
                        // We're passing ASCII characters
                        ASCIIEncoding enc = new System.Text.ASCIIEncoding();

                        //Pass the username to the server
                        WriteBuffer = enc.GetBytes(String.Format("USER {0}\r\n", pUsername));
                        netStream.Write(WriteBuffer, 0, WriteBuffer.Length);

                        Response = strReader.ReadLine();


                        // Pass the password to the server
                        WriteBuffer = enc.GetBytes("PASS " + pPassword + "\r\n");
                        netStream.Write(WriteBuffer, 0, WriteBuffer.Length);

                        Response = strReader.ReadLine();

                        if (Response.Contains("-ERR"))
                        {
                            return LoginResponseEnum.LOGIN_FAIL;
                        }


                        // se listan los mensajes
                        WriteBuffer = enc.GetBytes("LIST\r\n");
                        netStream.Write(WriteBuffer, 0, WriteBuffer.Length);

                        Response = strReader.ReadLine();
                        string ListMessage;

                        ListMessage = strReader.ReadLine();

                        MessageList = new List<Pop3Message>();

                        while (true)
                        {
                            ListMessage = strReader.ReadLine();
                            if (ListMessage == ".")
                            {
                               // no hay mas mensajes
                                break;
                            }
                            else
                            {
                                Pop3Message msg = new Pop3Message();
                                char[] seps = { ' ' };
                                string[] values = ListMessage.Split(seps);
                                msg.number = Int32.Parse(values[0]);
                                msg.bytes = Int32.Parse(values[1]);
                                msg.retrieved = false;
                                MessageList.Add(msg);
                                continue;
                            }
                        }
                        
                        // Quit del servidor Pop3
                        WriteBuffer = enc.GetBytes("QUIT\r\n");
                        netStream.Write(WriteBuffer, 0, WriteBuffer.Length);
                    }
                    return LoginResponseEnum.LOGIN_SUCCESS;
                }
                catch (System.Net.Sockets.SocketException)
                {
                    return LoginResponseEnum.CONNECTION_FAIL;
                }
                catch (Exception)
                {
                    return LoginResponseEnum.LOGIN_FAIL;
                }
            }
                
        }
              

        public List<Pop3Message> List()
        {
            return MessageList;
        }
        
        public Pop3Message Retrieve(Pop3Message rhs)
        {
            string message;
            string response;
            Pop3Message msg = new Pop3Message();
            //msg.bytes = rhs.bytes;
            //msg.number = rhs.number;
            //message = "RETR " + rhs.number + "\r\n";
            //Write(message);
            //response = Response();
            //if (response.Substring(0, 3) != "+OK")
            //{
            //    throw new Pop3Exception(response);
            //}
            //msg.retrieved = true;
            //while (true)
            //{
            //    response = Response();
            //    if (response == ".\r\n")
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        msg.message += response;
            //    }
            //}
            return msg;
        }

    }

    public class Pop3Message
    {
        public long number;
        public long bytes;
        public bool retrieved;
        public string message;
    }
}
