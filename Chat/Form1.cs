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
using AForge.Video;
using AForge;
using AForge.Video.DirectShow;
using Accord.Video.FFMPEG;
using Newtonsoft.Json;
using NAudio.Wave;

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

        /*Variables*/
        #region
        private FilterInfoCollection VideoCaptureDevices;
        private VideoFileWriter FileWriter = new VideoFileWriter();
        private VideoCaptureDevice FinalVideo = null;
        private Bitmap video;
        private VideoCaptureDeviceForm captureDevice;

        static object locker = new object();
        static ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();
        List<MyBubble> msglist = new List<MyBubble>();
        List<GetBubble> receivelist = new List<GetBubble>();
        List<SendImage> photolist = new List<SendImage>();
        List<SendFile> filelist = new List<SendFile>();
        List<SendAudio> audiolist = new List<SendAudio>();
        List<SendVideo> videolist = new List<SendVideo>();
        Random rnd = new Random();
        BinaryReader reader;
        BinaryWriter writer;
        private System.Drawing.Point lastpoint;
        private static int port = 8888;
        private static string ip = "127.0.0.1";
        private static TcpClient client;
        protected static NetworkStream stream;
        private FileDetails fileDet = new FileDetails();
        private static string gettedMessage = "";
        private string path = "", filepath = "", audiopath = "", videopath = "";
        private static SendImage image;
        private static SendFile file;
        private static SendAudio audio;
        private static SendVideo wideo;
        #endregion
        public Form1()
        {
            InitializeComponent();
            altoTextBox1.Text = "Write message";
            client = new TcpClient();
            client.Connect(ip, port);
            Thread t = new Thread(new ThreadStart(ReceiveMessage));
            t.Start();
            stream = client.GetStream();
            reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            captureDevice = new VideoCaptureDeviceForm();
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
                    else
                    if (img.Left != 270) img.Left = 266;
                }
                foreach (SendFile file in filelist)
                {
                    if (file.Left == 5) continue;
                    else
                    if (file.Left != 270) file.Left = 266;
                }
                foreach(SendAudio aud in audiolist)
                {
                    if (aud.Left == 5) continue;
                    else
                    if (aud.Left != this.Width - 240) aud.Left = this.Width - 250;
                }
                foreach (SendVideo vid in videolist)
                {
                    if (vid.Left == 5) continue;
                    else
                    if (vid.Left != this.Width - 168) vid.Left = this.Width - 168;
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
            if (msglist.Count == 0 && receivelist.Count == 0 && photolist.Count == 0 && filelist.Count == 0 && audiolist.Count == 0 && videolist.Count==0) return 40;
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
            if (lastObject is SendFile)
            {
                SendFile tmp = (SendFile)lastObject;
                return tmp.Top + tmp.Height;
            }
            if (lastObject is SendAudio)
            {
                SendAudio tmp = (SendAudio)lastObject;
                return tmp.Top + tmp.Height;
            }
            if (lastObject is SendVideo)
            {
                SendVideo tmp = (SendVideo)lastObject;
                return tmp.Top + tmp.Height;
            }
            else return 0;
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
            byte[] bytes = new byte[256];
            int size = 0;
            try
            {
                while ((size = fs.Read(bytes, 0, bytes.Length)) > 0)
                {
                    stream.Write(bytes, 0, size);
                }
            }
            catch
            {
                altoTextBox1.Text = "Sending file error";
            }
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new System.Drawing.Point(e.X, e.Y);
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
                isTyped = false;
                altoTextBox1.Text = "Write message";
                altoTextBox1.ForeColor = Color.DimGray;
                isTyped = true;
            }
            panel3.VerticalScroll.Value = panel3.VerticalScroll.Maximum;
            panel3.PerformLayout();
        }

        private void zeroitClassicRndButton1_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.UTF8.GetBytes("expectedexit");
            stream.Write(data, 0, data.Length);
            if (stream != null)  stream.Close();
            if (client != null) client.Close();
            this.Close();
        }
        private object lastObject = 30;
        private void ReceiveBubble(string text)
        {
            string output = new string(text.Where(c => char.IsLetter(c) || char.IsDigit(c) || char.IsSymbol(c) || char.IsSeparator(c) || char.IsPunctuation(c)).ToArray());
            CheckScrollBar();
            GetBubble msg = new GetBubble();
            msg.Width = 242;
            msg.Left = 5;
            msg.Top = getPosition();
            msg.Height = 10;
            msg.Body = output;
            msg.AutoSize = true;
            msg.AddTimeLabel();
            panel3.Controls.Add(msg);
            receivelist.Add(msg);
            lastObject = msg;
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
                image.SetImage(path);
                image.Left = 5;
                image.PhotoColor = Color.SkyBlue;
                image.Top = getPosition();
                image.AddTimeLabelGetter();
                panel3.Controls.Add(image);
                lastObject = image;
                photolist.Add(image);
                path = "";
                CheckScrollBar();
            }
            if (filepath != "")
            {
                file = new SendFile();
                file.SetFile(filepath);
                file.FileName = filepath;
                file.FileSize = fileSizeString;
                file.Left = 5;
                file.Top = getPosition();
                file.AddTimeLabelGetter();
                panel3.Controls.Add(file);
                lastObject = file;
                filelist.Add(file);
                filepath = "";
                CheckScrollBar();
            }
            if (audiopath != "")
            {
                audio = new SendAudio();
                audio.SetFile(audiopath);
                audio.AudioTime = (GetWavFileDuration(audiopath)).ToString();
                audio.Left = 5;
                audio.Top = getPosition();
                audio.AddTimeLabelGetter();
                panel3.Controls.Add(audio);
                lastObject = audio;
                audiolist.Add(audio);
                audiopath = "";
                CheckScrollBar();
            }
            if (videopath != "")
            {
                wideo = new SendVideo();
                wideo.SetFile(videopath);
                wideo.Left = 5;
                wideo.Top = getPosition();
                wideo.AddTimeLabelGetter();
                panel3.Controls.Add(wideo);
                lastObject = wideo;
                videolist.Add(wideo);
                videopath = "";
                CheckScrollBar();
            }
        }
        public static TimeSpan GetWavFileDuration(string fileName)
        {
            WaveFileReader wf = new WaveFileReader(fileName);
            return new TimeSpan(wf.TotalTime.Hours,wf.TotalTime.Minutes,wf.TotalTime.Seconds);
        }
        private string fileSizeString = null;
        public string[] SaveFileOnPC()
        {
            string fileName = reader.ReadString();
            int fileSize = reader.ReadInt32(); // 2 GB max
            byte[] imageData = reader.ReadBytes(fileSize);
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                fs.Write(imageData, 0, imageData.Length);
            }
            return new string[] { fileName, Convert.ToString(fileSize) };
        }
        public void ReceiveMessage()
        {
            while (true)
            {
                string messageType = reader.ReadString();
                switch (messageType)
                {
                    case "image":
                        {
                            path = SaveFileOnPC()[0];
                            break;
                        }
                    case "file":
                        {
                            string[] data = SaveFileOnPC();
                            fileSizeString = data[1];
                            filepath = data[0];
                            break;
                        }
                    case "audio":
                        {
                            audiopath = SaveFileOnPC()[0];
                            break;
                        }
                    case "video":
                        {
                            videopath = SaveFileOnPC()[0];
                            break;
                        }
                    default:
                        {
                            gettedMessage = messageType;
                            break;
                        }
                }
            }  
        }

        private void altoButton3_Click_1(object sender, EventArgs e)
        {
            String path;
            SendImage image = new SendImage();
            if ((path = image.SetImage()) != null)
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                byte[] bytes = Encoding.UTF8.GetBytes("photo");
                stream.Write(bytes, 0, bytes.Length);
                SendFileInfo(fs);
                SendFile(fs);
                fs.Close();
                image.Left = 285;
                CheckScrollBar();
                image.Top = getPosition();
                image.AddTimeLabelSender();
                panel3.Controls.Add(image);
                lastObject = image;
                photolist.Add(image);
            }
        }
        private int isRecord = 1;
        private WaveIn waveIn;
        private WaveFileWriter wavewriter;
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler<WaveInEventArgs>(waveIn_DataAvailable), sender, e);
            }
            else
            {
                wavewriter.Write(e.Buffer, 0, e.BytesRecorded);
                wavewriter.Flush();
            }
        }
        static string audiofilename;
        private void pictureBox2_Click(object sender, EventArgs e)
        {  
            switch (isRecord)
            {
                case 1:
                    {
                        audiofilename = $"audio{rnd.Next(1000, 9999)}.wav";
                        pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
                        pictureBox2.Image = Properties.Resources.record;
                        isRecord = 0;
                        waveIn = new WaveIn();
                        waveIn.DeviceNumber = 0;
                        waveIn.DataAvailable += waveIn_DataAvailable;
                        waveIn.WaveFormat = new WaveFormat(8000, 1);
                        wavewriter = new WaveFileWriter(audiofilename, waveIn.WaveFormat);
                        waveIn.StartRecording(); 
                        break;
                    }
                case 0:
                    {
                        if (waveIn != null)
                        {
                            waveIn.StopRecording();
                            waveIn.Dispose();
                            waveIn = null;
                        }
                        if (wavewriter != null)
                        {
                            wavewriter.Dispose();
                            wavewriter = null;
                        }
                        pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox2.Image = Properties.Resources.startrecord;
                        isRecord = 1;
                        SendAudioMessage();
                        break;
                    }
            }
        }
        private void SendAudioMessage()
        {
            if (File.Exists(audiofilename) && isRecord == 1)
            {
                //Sending to server
                byte[] bytes = Encoding.UTF8.GetBytes("audiofile");
                stream.Write(bytes, 0, bytes.Length);
                SendAudio audio = new SendAudio();
                audio.SetFile(audiofilename);
                audio.AudioTime = GetWavFileDuration(audiofilename).ToString();
                using (FileStream fstream = new FileStream(audiofilename, FileMode.Open, FileAccess.Read))
                {
                    SendFileInfo(fstream);
                    SendFile(fstream);
                }
                //Ending send file
                //Locate control on GUI
                audio.Left = this.Width - 230;
                CheckScrollBar();
                audio.Top = getPosition();
                audio.AddTimeLabelSender();
                panel3.Controls.Add(audio);
                lastObject = audio;
                audiolist.Add(audio);
                //Ending add control
            }
        }
        private void WaveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private string isRecording = "false";
        RoundedImage videoPanel = new RoundedImage();
        static string videofilename;
        private void btnRecord_Click(object sender, EventArgs e)
        {
            switch(isRecording)
            {
                case "false":
                    {
                        isRecording = "true";
                        if (captureDevice.ShowDialog(this) == DialogResult.OK)
                        {
                            videofilename = $"video{rnd.Next(1000, 9999)}.avi";
                            videoPanel.Size = new Size(160, 160);
                            videoPanel.Left = panel3.Width / 2-80;
                            videoPanel.Top = panel3.Height / 2-80;
                            videoPanel.SizeMode = PictureBoxSizeMode.StretchImage;
                            panel3.Controls.Add(videoPanel);
                            int h = captureDevice.VideoDevice.VideoResolution.FrameSize.Height;
                            int w = captureDevice.VideoDevice.VideoResolution.FrameSize.Width;
                            FileWriter.Open(videofilename, w, h, 25, VideoCodec.Default, 5000000);
                            FinalVideo = captureDevice.VideoDevice;
                            FinalVideo.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
                            FinalVideo.Start();
                        }
                        break;
                    }
                case "true":
                    {
                        isRecording = "false";
                        FinalVideo.Stop();
                        FileWriter.Close();
                        panel3.Controls.Remove(videoPanel);
                        SendVideoMessage();
                        break;
                    }
            }         
        }

        private void SendVideoMessage()
        {
            if (File.Exists(videofilename) && isRecording == "false")
            {
                //Sending to server
                byte[] bytes = Encoding.UTF8.GetBytes("videofile");
                stream.Write(bytes, 0, bytes.Length);
                SendVideo video = new SendVideo();
                video.SetFile(videofilename);
                using (FileStream fstream = new FileStream(videofilename, FileMode.Open, FileAccess.Read))
                {
                    SendFileInfo(fstream);
                    SendFile(fstream);
                }
                //Ending send file
                //Locate control on GUI
                video.Left = this.Width - 158;
                CheckScrollBar();
                video.Top = getPosition();
                video.AddTimeLabelSender();
                panel3.Controls.Add(video);
                lastObject = video;
                videolist.Add(video);
                //Ending add control
            }
        }


        bool isTyped = false;


        private void altoTextBox1_Enter(object sender, EventArgs e)
        {
            if(altoTextBox1.Text=="Write message")
            {
                altoTextBox1.ForeColor = Color.Black;
                altoTextBox1.Text = null;
            }
        }

        private void altoTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (isTyped)
            {
                if (altoTextBox1.Text.Contains("Write message"))
                {
                    altoTextBox1.ForeColor = Color.Black;
                    altoTextBox1.Text = altoTextBox1.Text.Replace("Write message", "").Trim();
                    string firstSymbol = altoTextBox1.Text;
                    altoTextBox1.Text = null;
                    SendKeys.Send($"{firstSymbol}");
                }
            }
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (isRecording=="true")
            {
                video = (Bitmap)eventArgs.Frame.Clone();
                videoPanel.Image = (Bitmap)eventArgs.Frame.Clone();
                FileWriter.WriteVideoFrame(video);
            }
            else
            {
                video = (Bitmap)eventArgs.Frame.Clone();
                videoPanel.Image = (Bitmap)eventArgs.Frame.Clone();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SendFile file = new SendFile();
            string filename;
            if ((filename = file.SetFile()) != null)
            {
                byte[] bytes = Encoding.UTF8.GetBytes("attachment");
                stream.Write(bytes, 0, bytes.Length);
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                file.SetFile(fs.Name);
                file.FileName = getNameOfFile(fs.Name);
                file.FileSize = Convert.ToString(fs.Length);
                SendFileInfo(fs);
                SendFile(fs);
                fs.Close();
                file.Left = 285;
                CheckScrollBar();
                file.Top = getPosition();
                file.AddTimeLabelSender();
                panel3.Controls.Add(file);
                lastObject = file;
                filelist.Add(file);
            }
        }
        private string getNameOfFile(string path)
        {
            return Path.GetFileName(path);
        }
    }
}

