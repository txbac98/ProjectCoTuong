using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KetNoi
{
    public static class KetNoi
    {
        IPEndPoint IP;
        Socket sever;
        Socket client;

        void InitializeSever()
        {

            //Dia chi IP
            IP = new IPEndPoint(IPAddress.Any, 9999);
            sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);  //Luon dung

            //Nap sever
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
        void ConnectSever(string ipSever)
        {
            //Dia chi IP
            IP = new IPEndPoint(IPAddress.Parse(ipSever), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);  //Luon dung

            try
            {
                client.Connect(IP); //Ket noi
            }
            catch
            {
                //MessageBox.Show("Khong the ket noi sever", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Lang nghe
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }

        void Close()
        {
            sever.Close();
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

                }
            }
            catch
            {
                client.Close();
            }
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
