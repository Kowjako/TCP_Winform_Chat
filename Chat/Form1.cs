using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChatBubble;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json;
namespace Chat
{
    public partial class Form1 : Form
    {
        [Serializable]
        public class FileDetails
        {
            public string FILETYPE = "";
            public string FILESIZE = "";
        }
        static object locker = new object();
        List<MyBubble> msglist = new List<MyBubble>();
        List<GetBubble> receivelist = new List<GetBubble>();
        List<SendImage> photolist = new List<SendImage>();
        Random rnd = new Random();
        private Point lastpoint;
        private static int port = 8888;
        private static string ip = "127.0.0.1";
        private static TcpClient client;
        protected static NetworkStream stream;
        private FileDetails fileDet = new FileDetails();
        private static string gettedMessage = "";
        private static string path = "";
        private static string fileName = "";
        private static SendImage image;
        public Form1()
        {
            InitializeComponent();
            client = new TcpClient();
            client.Connect(ip, port);
            Thread t = new Thread(new ThreadStart(ReceiveMessage));
            t.Start();
            stream = client.GetStream();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nameLbl.Text = $"User{rnd.Next(100)}";
            panel3.HorizontalScroll.Maximum = 0;
            panel3.AutoScroll = false;
            panel3.HorizontalScroll.Enabled = false;
            panel3.VerticalScroll.Visible = false;
            panel3.AutoScroll = true;
            TimeSelector ts = new TimeSelector();
            DateTime dt = DateTime.Today;
            ts.Body = $"{dt.Day} {dt.ToString("MMMM")}";
            ts.Size = new Size(539, 23);
            ts.Left = 0;
            ts.Top = 6;
            panel3.Controls.Add(ts);
            timer1.Start();
        }

        private bool CheckScrollBar()
        {
            if (panel3.VerticalScroll.Visible == true)
            {
                foreach (MyBubble bub in msglist)
                {
                    if (bub.Left != 270) bub.Left = 270;
                }
                foreach (SendImage img in photolist)
                {
                    if (img.Left == 5) continue;
                    if (img.Left != 270) img.Left = 270;
                }
                return true;
            }
            return false;
        }

        private void AddBubble()
        {
            MyBubble msg = new MyBubble();
            msg.Width = 242;
            if (CheckScrollBar()) msg.Left = 270;
            else msg.Left = 289;
            msg.Height = 10;
            msg.Top = getPosition();
            msg.Body = altoTextBox1.Text;
            panel3.Controls.Add(msg);
            msg.AddTimeLabel();
            msg.AutoSize = true;
            msglist.Add(msg);
            lastObject = msg;
        }
        private int getPosition()
        {
            if (msglist.Count == 0 && receivelist.Count == 0 && photolist.Count == 0) return 30;
            if (lastObject is MyBubble)
            {
                MyBubble tmp = (MyBubble)lastObject;
                return tmp.Top + tmp.Height;
            }
            if (lastObject is GetBubble)
            {
                GetBubble tmp = (GetBubble)lastObject;
                return tmp.Top + tmp.Height;
            }
            if (lastObject is SendImage)
            {
                SendImage tmp = (SendImage)lastObject;
                return tmp.Top + tmp.Height;
            }
            else return 0;
        }
        private void GetFileDetails()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                byte[] receiveBytes = new byte[255];
                do
                {
                    int bytes = stream.Read(receiveBytes, 0, receiveBytes.Length);
                    sb.Append(Encoding.UTF8.GetString(receiveBytes));
                }
                while (stream.DataAvailable);
                int startindex = sb.ToString().IndexOf('{');
                int endindex = sb.ToString().IndexOf('}');
                string json = sb.ToString().Substring(startindex, endindex - startindex + 1);
                fileDet = JsonConvert.DeserializeObject<FileDetails>(json);
            }
            catch (Exception ex)
            {
                altoTextBox1.Text = $"GetFileDetails Error";
            }
        }
        public void GetFile()
        {
            FileStream fs = new FileStream(fileName, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
            try
            {
                int i = 0;
                byte[] receiveBytes = new byte[255];
                
                while (fs.Length != Convert.ToInt64(fileDet.FILESIZE))
                {
                    altoTextBox1.Text = $"{i} part of file received";
                    altoButton1.Enabled = false;
                    altoButton3.Enabled = false;
                    int bytes = stream.Read(receiveBytes, 0, receiveBytes.Length);
                    fs.Write(receiveBytes, 0, bytes);
                    i++;
                }
            }
            catch (Exception eR)
            {
                altoTextBox1.Text = eR.Message;
            }
            finally
            {
                fs.Close();
                altoButton3.Enabled = true;
                altoButton1.Enabled = true;
            }
        }
        public void SendFileInfo(FileStream fs)
        {
            try
            {
                fileDet.FILETYPE = Path.GetExtension(fs.Name);
                fileDet.FILESIZE = Convert.ToString(fs.Length);
                string json = JsonConvert.SerializeObject(fileDet);
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                stream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
            }
        }
        private void SendFile(FileStream fs)
        {
            byte[] bytes = new byte[255];
            int size = 0;
            try
            {
                while ((size = fs.Read(bytes, 0, bytes.Length)) > 0)
                {
                    stream.Write(bytes, 0, size);
                }
                fs.Close();
            }
            catch
            {
                altoTextBox1.Text = "Sending file error";
            }
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }
        private void altoButton1_Click(object sender, EventArgs e)
        {
            if (altoTextBox1.Text != "" && altoTextBox1.Text != "Write message")
            {
                string msg = altoTextBox1.Text;
                AddBubble();
                byte[] data = Encoding.UTF8.GetBytes(msg);
                stream.Write(data, 0, data.Length);
            }
            panel3.VerticalScroll.Value = panel3.VerticalScroll.Maximum;
            panel3.PerformLayout();
        }

        private void zeroitClassicRndButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void altoTextBox1_Enter(object sender, EventArgs e)
        {
            if (altoTextBox1.Text == "Write message")
            {
                altoTextBox1.ForeColor = Color.Black;
                altoTextBox1.Text = "";
            }
        }
        private object lastObject = 30;
        private void ReceiveBubble(string text)
        {
            string output = new string(text.Where(c => char.IsLetter(c) || char.IsDigit(c) || char.IsSymbol(c) || char.IsSeparator(c) || char.IsPunctuation(c)).ToArray());
            if (CheckScrollBar()) { }
            GetBubble msg = new GetBubble();
            msg.Width = 242;
            msg.Left = 5;
            msg.Top = getPosition();
            msg.Height = 10;
            msg.Body = output;
            msg.AddTimeLabel();
            msg.AutoSize = true;
            panel3.Controls.Add(msg);
            receivelist.Add(msg);
            lastObject = msg;
        }
        private void altoTextBox1_Leave(object sender, EventArgs e)
        {
            if (altoTextBox1.Text == "")
            {
                altoTextBox1.ForeColor = Color.Gray;
                altoTextBox1.Text = "Write message";
            }
        }
        private void altoTextBox2_TextChanged(object sender, EventArgs e)
        {
            statusLbl.Text = "typing...";
        }
        private string sendmsg = "";
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            sendmsg = statusLbl.Text;
            if (statusLbl.Text == sendmsg) statusLbl.Text = "online";
            if (gettedMessage != "")
            {
                ReceiveBubble(gettedMessage);
                gettedMessage = "";
            }
            if (path != "")
            {
                image = new SendImage();
                image.SetImage(fileName);
                image.Left = 5;
                image.PhotoColor = Color.SkyBlue;
                image.Top = getPosition();
                image.AddTimeLabelGetter();
                panel3.Controls.Add(image);
                lastObject = image;
                photolist.Add(image);
                path = "";
                fileName = "";
            }
        }
        private void altoButton3_Click(object sender, EventArgs e)
        {
            byte[] bytes = Encoding.UTF8.GetBytes("photo");
            stream.Write(bytes, 0, bytes.Length);
            SendImage image = new SendImage();
            FileStream fs = new FileStream(image.SetImage(), FileMode.Open, FileAccess.Read);
            SendFileInfo(fs);
            SendFile(fs);
            if (panel3.VerticalScroll.Visible == true) image.Left = 270;
            else image.Left = 285;
            image.Top = getPosition();
            image.AddTimeLabelSender();
            panel3.Controls.Add(image);
            lastObject = image;
            photolist.Add(image);
        }
        public void ReceiveMessage()
        {
            while (true)
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
                gettedMessage = sb.ToString();
                string output = new string(gettedMessage.Where(c => char.IsLetter(c) || char.IsDigit(c) || char.IsSymbol(c) || char.IsSeparator(c) || char.IsPunctuation(c)).ToArray());
                if (output.Contains("image"))
                {
                    lock (locker)
                    {
                        gettedMessage = "";
                        fileName = output;
                        GetFileDetails();
                        GetFile();
                        path = $"{output}";
                    }
                }
            }
        }
    }
}

