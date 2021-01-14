using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
namespace Server
{
    public class ClientObject
    {
        [Serializable]
        public class FileDetails
        {
            public string FILETYPE = "";
            public string FILESIZE = "";
        }

        #region Variables
        private static FileDetails fileDet = new FileDetails();
        private string username;
        private string servermsg = "";
        protected internal string Id { get; set; }
        protected internal NetworkStream stream { get; set; }
        static TcpClient client;
        Server server;
        Random rnd = new Random();
        #endregion

        public ClientObject(TcpClient x, Server y)
        {
            server = y;
            client = x;
            Id = Guid.NewGuid().ToString();
            y.AddConnection(this);
        }

        private void GetFileDetails()
        {
            try
            {
                Byte[] receiveBytes = new Byte[256];
                do
                {
                    int bytes = stream.Read(receiveBytes, 0, receiveBytes.Length);
                }
                while (stream.DataAvailable);
                string json = Encoding.UTF8.GetString(receiveBytes);               
                fileDet = JsonConvert.DeserializeObject<FileDetails>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetFileDetails Error in ClientObject class");
            }
        }

        public void GetFile(string type)
        {
            mark = rnd.Next(1000, 9999);
            FileStream fs = new FileStream($"{type}{mark}" + fileDet.FILETYPE, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            Byte[] receiveBytes = new Byte[256];
            try
            {
                do
                {
                    int bytes = stream.Read(receiveBytes, 0, receiveBytes.Length);
                    fs.Write(receiveBytes, 0, bytes);
                }
                while (fs.Length != Convert.ToInt64(fileDet.FILESIZE));
                fs.Close();
            }
            catch (Exception eR)
            {
                Console.WriteLine(eR.ToString() + " GET FILE ERROR");
            }
        }

        public static int mark = 0;

        private void SendFile(string type)
        {
            server.SendFile(fileDet, $"{type}{mark}{fileDet.FILETYPE}", Id, type);
            Console.WriteLine("file has sent");
        }

        private void FileGetterAndSender(string type, string username, string output)
        {
            string servermsg;
            GetFileDetails();
            servermsg = String.Format("{0}: {1}, {2}, {3}", username, output, "ok", fileDet.FILETYPE);
            output = "";
            Console.WriteLine(servermsg);
            GetFile(type);
            Console.WriteLine("Получен файл типа " + fileDet.FILETYPE + " имеющий размер " + fileDet.FILESIZE + " байт");
            SendFile(type);
        }
        
        public void Process()
        {
            try
            {
                stream = client.GetStream();
                username = $"User{rnd.Next(500)}";
                Console.WriteLine(username + "connected :)");
                while (true)
                {
                    string msg = GetMessage();
                    string output = new string(msg.Where(c => char.IsLetter(c) || char.IsDigit(c) || char.IsSymbol(c) || char.IsSeparator(c) || char.IsPunctuation(c)).ToArray());
                    switch (output)
                    {
                        case "photo":
                            {
                                FileGetterAndSender("image", username, output);
                                break;
                            }
                        case "attachment":
                            {
                                FileGetterAndSender("file", username, output);
                                break;
                            }
                        case "audiofile":
                            {
                                FileGetterAndSender("audio", username, output);
                                break;
                            }
                        case "videofile":
                            {
                                FileGetterAndSender("video", username, output);
                                break;
                            }
                        case "expectedexit":
                            {
                                server.RemoveConnection(Id);
                                Close();
                                break;
                            }
                        default:
                            {
                                servermsg = String.Format("{0}: {1}", username, output);
                                Console.WriteLine(servermsg);
                                server.BroadcastMessage(msg, Id);
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                servermsg = String.Format("{0}: leave chat", username);
                Console.WriteLine(servermsg);
            }
        }

        public string GetMessage()
        {
            byte[] data = new byte[256];
            StringBuilder sb = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = stream.Read(data, 0, data.Length);
                sb.Append(Encoding.UTF8.GetString(data));
            }
            while (stream.DataAvailable);
            return sb.ToString();
        }

        protected internal void Close()
        {
            if (stream != null) stream.Close();
            if (client != null) client.Close();
        }
    }
}
