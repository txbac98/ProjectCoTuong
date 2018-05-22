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
    public class Server
    {
        public static string name = "Server";
        private static string IP = "127.0.0.1";
        private static Socket server;
        public static List<Socket> ClientList { get; set; }
        public static ListView ListView { get; set; }
        public static TextBox TextBox { get; set; }

        public static void AddMessage(string s)  //Thêm tin vừa gửi vào listView
        {
            ListView.Items.Add(new ListViewItem() { Text = s });
            TextBox.Clear();
        }
        public static void Send(Socket client)  //Gửi gói tin
        {
            string temp = "1" + name + ": " + TextBox.Text;
            if (TextBox.Text != string.Empty) //khac rong
                client.Send(Serialize(temp));
            else
            {
                CoTuong.BanCo.ConvertToString();
                client.Send(Serialize(CoTuong.BanCo.Data));
            }
        }

        public static void Connect()
        {
            ClientList = new List<Socket>();
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
                        server.Listen(1000);  //Lắng nghe
                        Socket client = server.Accept(); //Lấy client
                        ClientList.Add(client);
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
        private static void Receive(object obj)  //Nhan tin
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    CoTuong.BanCo.Data = (string)Deserialize(data);
                    if (CoTuong.BanCo.Data[0] == '1')
                    {
                        string text = "";
                        for (int i = 1; i < CoTuong.BanCo.Data.Length; i++)
                            text += CoTuong.BanCo.Data[i];
                        AddMessage(text);
                    }
                    else if (CoTuong.BanCo.Data[0] == '0')
                        CoTuong.BanCo.ThayDoiViTri(CoTuong.BanCo.Data);
                }
            }
            catch
            {
                ClientList.Remove(client);
                client.Close();
            }
        }
        private static byte[] Serialize(object obj) //Gom mảnh -  đóng gói
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);  //chuyen obj thanh day byte
            stream.Close();
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
