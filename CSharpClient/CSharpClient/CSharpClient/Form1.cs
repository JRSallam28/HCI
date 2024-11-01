﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CSharpClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stream();
        } 

        public void stream()
        {
            Client c = new Client();
            c.connectToSocket("localhost", 65434);
            string msg = "";
            while (true)
            {
                msg = c.recieveMessage();
                if (msg == "q")
                {
                    c.stream.Close();
                    c.client.Close();
                    Console.WriteLine("Connection Terminated !");
                    break;
                }
            }
        }
      
    }
    class Client
    {
        int byteCT;
        public NetworkStream stream;
        byte[] sendData;
        public TcpClient client;

        public bool connectToSocket(string host, int portNumber)
        {
            try
            {
                client = new TcpClient(host, portNumber);
                stream = client.GetStream();
                Console.WriteLine("connection made ! with " + host);
                return true;
            }
            catch (System.Net.Sockets.SocketException e)
            {
                Console.WriteLine("Connection Failed: " + e.Message);
                return false;
            }
        }

        public string recieveMessage()
        {
            try
            {
                
                byte[] receiveBuffer = new byte[1024];
                int bytesReceived = stream.Read(receiveBuffer, 0, 1024);
                Console.WriteLine(bytesReceived);
                string data = Encoding.UTF8.GetString(receiveBuffer, 0, bytesReceived);
                Console.WriteLine(data);
                return data;
            }
            catch (System.Exception e)
            {
            
            }

            return null;
        }

    }
}
