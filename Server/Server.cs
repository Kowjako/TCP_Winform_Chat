using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using Newtonsoft.Json;
using static Server.ClientObject;

namespace Server
{
    public class Server
    {
        static TcpListener listener;
        private FileDetails fileData = new FileDetails();
        List<ClientObject> clients = new List<ClientObject>();
        static object locker = new object();
        protected internal void AddConnection(ClientObject x)
        {
            if (clients.Count < 2)
            clients.Add(x);
        }
        protected internal void BroadcastMessage(string msg, string id)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);
            foreach (ClientObject x in clients)
            {
                if (x.Id != id) x.stream.Write(data, 0, data.Length);
            }
        }
        protected internal void SendPhoto(FileDetails fd, string fs,string id)
        {
            FileStream fstream = File.Open(fs, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            foreach (ClientObject x in clients)
            {
                if (x.Id != id)
                {
                    try
                    {
                        byte[] data = Encoding.UTF8.GetBytes(fs);
                        x.stream.Write(data, 0, data.Length);
                    }
                    catch
                    {
                        Console.WriteLine("Sending imagemsg error");
                    }
                    try
                    {
                        fileData.FILESIZE = fd.FILESIZE;
                        fileData.FILETYPE = fd.FILETYPE;
                        //Send metadata//
                        string json = JsonConvert.SerializeObject(fileData);
                        Console.WriteLine($"send metadata {json}");
                        byte[] bytes = Encoding.UTF8.GetBytes(json);
                        x.stream.Write(bytes, 0, bytes.Length);
                    }
                    catch
                    {
                        Console.WriteLine("Sending metadata error");
                    }
                    //Send Photo//
                    try
                    {
                        Console.WriteLine($"Server fs = {fs}");
                        byte[] bites = new byte[255];
                        int size = 0;
                        int i = 0;
                        while ((size = fstream.Read(bites, 0, bites.Length)) > 0)
                        {
                            Console.WriteLine($"Sending {i} part of file");
                            x.stream.Write(bites, 0, size);
                            i++;
                        }                        
                        Console.WriteLine("100% file sended");
                    }
                    catch
                    {
                        Console.WriteLine("Sending file error");
                    }
                    finally
                    {
                        fstream.Close();
                    }
                }
            }
        }
        protected internal void RemoveConnection(string id)
        {
            ClientObject tmp = clients.FirstOrDefault(c => c.Id == id);
            if (tmp != null) clients.Remove(tmp);
            Console.WriteLine($"Client has left the chat");
        }
        protected internal void Disconnect()
        {
            listener.Stop();
            foreach (ClientObject t in clients) t.Close();
            Environment.Exit(0);
        }
        protected internal void Listen()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, 8888);
                listener.Start();
                Console.WriteLine("Server is started");
                while (true)
                {
                    TcpClient tmp = listener.AcceptTcpClient();
                    ClientObject cobject = new ClientObject(tmp, this);
                    Thread t = new Thread(new ThreadStart(cobject.Process));
                    t.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }
    }
}
