using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        string name = "Client";
        IPEndPoint IP;
        Socket client;

        public Client()
        {
            InitializeComponent();        
        }
        private void Client_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }
        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Close();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();
            AddMessage(name +": "+txbMessage.Text);
        }
        private void Connect()
        {
            //Dia chi IP
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.IP);  //Luon dung

            try
            {
                client.Connect(IP); //Ket noi
            }
            catch
            {
                MessageBox.Show("Khong the ket noi sever", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Lang nghe
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }
        private void Send()  //Gui Tin
        {
            string temp = name +": "+txbMessage.Text;
            if (txbMessage.Text !=string.Empty) //khac rong
            client.Send(Serialize(temp));
        }
        private void AddMessage(string s)  //Them tin nhan vao listView
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
            txbMessage.Clear();
        }   
        private void Receive()  //Nhận gói tin từ server
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)Deserialize(data);
                    AddMessage(message);
                }
            }
            catch
            {
                Close();
            }
        }   
        private byte[] Serialize(object obj) //Phân mảnh gói tin
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);  //chuyen obj thanh day byte
            return stream.ToArray();  //chuyen thanh mang 01..
        }    
        private object Deserialize(byte[] data) //Gom mảnh
        {
            MemoryStream stream = new MemoryStream(data); //lay ma
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream); //chuyen ma
        }
 
    }
}
