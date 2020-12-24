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
        public static object locker = new object();
        protected internal void AddConnection(ClientObject x)
        {
            if (clients.Count < 2)
            clients.Add(x);
        }
        protected internal void BroadcastMessage(string msg, string id)
        {
            foreach (ClientObject x in clients)
            {
                if (x.Id != id)
                {
                    BinaryWriter bw = new BinaryWriter(x.stream);
                    bw.Write(msg);
                }
            }
        }
        protected internal void SendFile(FileDetails fd, string fs, string id, string type)
        {
            FileStream fstream = File.Open(fs, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            foreach (ClientObject x in clients)
            {
                if (x.Id != id)
                {
                    string tmp = fs.Insert(0, "new");
                    BinaryWriter writer = new BinaryWriter(x.stream);
                    writer.Write(type); //send that it is image
                    writer.Write(tmp); //send filename
                    writer.Write(Convert.ToInt32(fd.FILESIZE)); //send filesize
                    byte[] bites = new byte[fstream.Length];
                    int size = fstream.Read(bites, 0, bites.Length);
                    writer.Write(bites); // send ImageData
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
