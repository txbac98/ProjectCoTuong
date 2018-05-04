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

namespace Sever
{
    public partial class Sever : Form
    {
        public Sever()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            Connect();
        }

        IPEndPoint IP;
        Socket sever;
        List<Socket> clientList;

        private void Sever_Load(object sender, EventArgs e)
        {
            Connect();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            foreach (Socket item in clientList)
            {
                Send(item);       
            }
            txbMessage.Clear();
        }
        void Connect()
        {
            clientList = new List<Socket>();
            //Dia chi IP
            IP = new IPEndPoint(IPAddress.Any, 9999);
            sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);  //Luon dung

            sever.Bind(IP);


            //Lang nghe
            Thread listen = new Thread(() =>
            {
                try
                {
                    while (true)    //lang nghe nhieu client
                    {
                        sever.Listen(100);  //lang nghe
                        Socket client = sever.Accept(); //Lay client

                        clientList.Add(client);

                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    //khoi tao
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);  //Luon dung
                }
                
            });

            listen.IsBackground = true;
            listen.Start();
            
        }

        void Close()
        {
            sever.Close();
        }

        void Send(Socket client)  //Gui Tin
        {
            if (txbMessage.Text != string.Empty) //khac rong
                client.Send(Serialize(txbMessage.Text));
        }

        void Receive(object obj)  //Nhan tin
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
                clientList.Remove(client);
                client.Close();
            }


        }

        void AddMessage(string s)  //Them tin nhan vao listView
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
            txbMessage.Clear();
        }

        byte[] Serialize(object obj) //Phan manh
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);  //chuyen obj thanh day byte

            return stream.ToArray();  //chuyen thanh mang 01..
        }


        object Deserialize(byte[] data) //Gom manh
        {
            MemoryStream stream = new MemoryStream(data); //lay ma
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream); //chuyen ma
        }



        
    }
}
