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
    public class Client
    {
        public static string name = "Client";

        private static IPEndPoint IP;
        private static Socket client;

        public static ListView ListView { get; set; }
        public static TextBox TextBox { get; set; }


        public static void AddMessage(string s)  //Them tin nhan vao listView
        {
            ListView.Items.Add(new ListViewItem() { Text = s });
            TextBox.Clear();
        }
        public static void Send()  //Gui Tin
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
            //Dia chi IP
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);  //Luon dung

            try
            {
                client.Connect(IP); //Ket noi
            }
            catch
            {
                MessageBox.Show("Khong the ket noi sever", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                client.Close();               
            }
            //Lang nghe
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }
        public static void Receive()  //Nhận gói tin từ server
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 10000];
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
                client.Close();
            }
        }
        public static byte[] Serialize(object obj) //Gom mảnh - đóng gói
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);  //chuyen obj thanh day byte
            stream.Close();
            return stream.ToArray();
        }
        public static object Deserialize(byte[] data) //Phân mảnh
        {
            MemoryStream stream = new MemoryStream(data); //lay ma
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream); //chuyen ma
        }
    }
}