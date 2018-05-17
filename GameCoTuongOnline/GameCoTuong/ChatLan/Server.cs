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

namespace GameCoTuong.ChatLan
{

    public static class Server
    {
        

        public static string name="Server";


        private static IPEndPoint IPserver;
        private static Socket server;
        private static Socket client;
        private static ListView listView;
        private static TextBox textBox;

        

        public static void AddMessage(string s)  //Thêm tin vừa gửi vào listView
        {
            listView.Items.Add(new ListViewItem() { Text = s });
            textBox.Clear();
        }
        

        //Neu no la server
        public static void Init(string IP)
        {
            //Dia chi IP
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), 9999);//IP = "127.0.0.1"; PORT = 100;
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  //Luon dung

            server.Bind(iep);
            //Lang nghe
            Thread listen = new Thread(() =>
            {
                try
                {
                    bool count = true;
                    while (count)    //Lắng nghe client
                    {
                        server.Listen(1);  //Lắng nghe
                        client = server.Accept(); //Lấy client
                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                        count = false;
                    }
                }
                catch
                {
                    //khoi tao
                    iep = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);  //Luon dung
                }
            });
            listen.IsBackground = true;
            listen.Start();
        }

        //Neu no la client
        public static void Connect(string IP)
        {
            //Dia chi IP
            IPserver = new IPEndPoint(IPAddress.Parse(IP), 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);  //Luon dung

            try
            {
                server.Connect(IPserver); //Ket noi
            }
            catch
            {
                MessageBox.Show("Không thể kết nối server", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                server.Close();
            }

            //Lang nghe
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }



        public static void Send(Socket client)  //Gửi gói tin
        {
            string temp = textBox.Text;
            if (textBox.Text != string.Empty) //khac rong
                client.Send(Serialize(temp));
        }

        private static void Receive(object obj)  //Nhan tin
        {
            Socket client = obj as Socket;
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
                client.Close();
            }
        }
        private static byte[] Serialize(object obj) //Gom mảnh -  đóng gói
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);  //chuyen obj thanh day byte
            return stream.ToArray();  //chuyen thanh mang 01..
        }
        private static object Deserialize(byte[] data) //Phân mảnh
        {
            MemoryStream stream = new MemoryStream(data); //lay ma
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream); //chuyen ma
        }
    }
}
