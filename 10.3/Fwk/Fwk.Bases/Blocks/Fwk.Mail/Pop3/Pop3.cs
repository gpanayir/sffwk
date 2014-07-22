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
        private List<Pop3Message> mMessagesList;        

        // Singleton
        private Pop3() { }
        public static readonly Pop3 Instance = new Pop3();

        public LoginResponseEnum Connect(string pServer, string pUsername, string pPassword)
        {
            String Response = String.Empty;

            // Create a TCP client for a TCP connection
            using (TcpClient tcpClient = new TcpClient())
            {
                // Connect this TCP client to the server IP/name and port specified in the form
                try
                {
                    tcpClient.Connect(pServer, 110);
                }
                catch (System.Net.Sockets.SocketException)
                {
                    return LoginResponseEnum.CONNECTION_FAIL;
                }

                // Create a network stream to retrieve data from the TCP client
                NetworkStream netStream = tcpClient.GetStream();
                // We need a stream reader to be able to read the network stream
                System.IO.StreamReader strReader = new System.IO.StreamReader(netStream);

                // If the connection was made successfully
                if (tcpClient.Connected)
                {
                    // Buffer to which we're going to write the commands
                    byte[] WriteBuffer = new byte[1024];
                    // We're passing ASCII characters
                    ASCIIEncoding enc = new System.Text.ASCIIEncoding();

                    // Pass the username to the server
                    WriteBuffer = enc.GetBytes(String.Format("USER {0}\r\n", pUsername));

                    netStream.Write(WriteBuffer, 0, WriteBuffer.Length);

                    Response = strReader.ReadLine();

                    // Pass the password to the server
                    WriteBuffer = enc.GetBytes(String.Format("PASS {0}\r\n", pPassword));

                    netStream.Write(WriteBuffer, 0, WriteBuffer.Length);

                    Response = strReader.ReadLine();

                    if (Response.Contains("-ERR"))
                    {
                        return LoginResponseEnum.LOGIN_FAIL;
                    }

                    // Now that we are (probably) authenticated, list the messages
                    WriteBuffer = enc.GetBytes("LIST\r\n");

                    netStream.Write(WriteBuffer, 0, WriteBuffer.Length);

                    Response = strReader.ReadLine();

                    string ListMessage;

                    Pop3Message wMessage;
                    mMessagesList = new List<Pop3Message>();
                    try
                    {
                        strReader.ReadLine();
                        while (true)
                        {
                            ListMessage = strReader.ReadLine();
                            if (ListMessage != null)
                            {
                                if (ListMessage == ".")
                                {
                                    // Este es el último mensaje
                                    break;
                                }
                                else
                                {
                                    char[] seps = { ' ' };
                                    string[] values = ListMessage.Split(seps);
                                    // Lista de mensajes                                
                                    wMessage = new Pop3Message();
                                    wMessage.number = Int32.Parse(values[0]);
                                    wMessage.bytes = Int32.Parse(values[1]);
                                    wMessage.retrieved = false;
                                    mMessagesList.Add(wMessage);
                                    continue;
                                }
                            }
                            else
                                break;
                                                        
                        }
                                                
                        WriteBuffer = enc.GetBytes("QUIT\r\n");
                        netStream.Write(WriteBuffer, 0, WriteBuffer.Length);
                        tcpClient.Close();
                    }
                    catch (Exception)
                    {
                        tcpClient.Close();
                    }
                    

                }

                return LoginResponseEnum.LOGIN_SUCCESS;
            }
        }

        public List<Pop3Message> List()
        {
            return mMessagesList;
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
