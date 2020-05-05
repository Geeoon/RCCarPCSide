using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.XInput;

namespace WindowsFormsApp1 //1k-2k
{
    public partial class Form1 : Form
    {
        private bool enabled = false;
        Controller controller;
        Gamepad gamepad;
        public bool controllerConnected = false;
        public int deadband = 2500;
        public float leftThumbx, leftThumby, rightThumbx, rightThumby;
        public float leftTrigger, rightTrigger;
        sbyte lastRThy = 0;
        sbyte lastLThx = 0;
        byte[] data = Encoding.ASCII.GetBytes("");
        string ipAddress = "192.168.0.42";
        int sendPort = 1337;
        public byte throttle;
        public byte steer;
        int everyFew = 0;
        int everyFewT = 0;
        public Form1()
        {
            InitializeComponent();
            controller = new Controller(UserIndex.One);
            controllerConnected = controller.IsConnected;
            Application.Idle += HandleApplicationIdle;
        }

        public void HandleApplicationIdle (object sender, EventArgs e)
        {
            while (IsApplicationIdle()) //continuous loop while idle; "game" loop
            {
                controllerConnected = controller.IsConnected;
                if (controllerConnected == true)
                {
                    gamepad = controller.GetState().Gamepad;

                    leftThumbx = (Math.Abs((float)gamepad.LeftThumbX) < deadband) ? 0 : (float)gamepad.LeftThumbX / short.MinValue * -100;
                    leftThumby = (Math.Abs((float)gamepad.LeftThumbY) < deadband) ? 0 : (float)gamepad.LeftThumbY / short.MaxValue * 100;
                    rightThumbx = (Math.Abs((float)gamepad.RightThumbX) < deadband) ? 0 : (float)gamepad.RightThumbX / short.MaxValue * 100;
                    rightThumby = (Math.Abs((float)gamepad.RightThumbY) < deadband) ? 0 : (float)gamepad.RightThumbY / short.MaxValue * 100;

                    leftTrigger = gamepad.LeftTrigger;
                    rightTrigger = gamepad.RightTrigger;


                    if (enabled == true)
                    {


                        lblEn.Text = "Enabled";
                        throttle = (byte)rightThumby;
                        steer = (byte)leftThumbx;

                        
                        if (lastRThy != (sbyte)rightThumby && everyFewT >= 1000)
                        {
                            everyFewT = 0;
                            try
                            {
                                using (var client = new UdpClient())
                                {
                                    lblJoy.Text = throttle.ToString();
                                    data = BitConverter.GetBytes(throttle);
                                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress), sendPort);
                                    client.Connect(ep);
                                    client.Send(data, data.Length);
                                    client.Close();
                                    lastRThy = (sbyte)rightThumby;
                                }
                            }
                            catch (Exception ex)
                            {
                                rtbLog.Text = rtbLog.Text + "\nError sending packet: " + ex.ToString();
                            }
                        }
                        
                        
                        if (lastLThx != (sbyte)leftThumbx && everyFew >= 10000)
                        {
                            everyFew = 0;
                            try
                            {
                                using (var client = new UdpClient())
                                {
                                    steer = (byte)(steer / (int)5);
                                    if (steer <= 20)
                                    {
                                        steer = (byte)(steer + 30);
                                    }
                                    else
                                    {
                                        steer = (byte)((30 - (50 - steer)));
                                    }
                                    steer = (byte)(steer + 100);
                                    lblSteer.Text = steer.ToString();
                                    data = BitConverter.GetBytes(steer);
                                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress), sendPort);
                                    client.Connect(ep);
                                    client.Send(data, data.Length);
                                    client.Close();
                                    lastLThx = (sbyte)leftThumbx;
                                }
                            }
                            catch (Exception ex)
                            {
                                rtbLog.Text = rtbLog.Text + "\nError sending packet: " + ex.ToString();
                            }
                        }
                        everyFewT++;
                        everyFew++;
                       

                    }
                    else
                    {
                        lblEn.Text = "Disabled";
                        lblJoy.Text = "";
                        lblSteer.Text = "";
                        throttle = 0;
                    }

                    
                } else {
                    leftThumbx = 0f;
                    leftThumby = 0f;
                    rightThumbx = 0f;
                    rightThumby = 0f;

                    leftTrigger = 0f;
                    rightTrigger = 0f;
                }
            }
        }

        private void btnEn_Click(object sender, EventArgs e)
        {
            enabled = true;
            try
            {
                using (var client = new UdpClient())
                {
                    data = BitConverter.GetBytes(101);
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress), sendPort);
                    client.Connect(ep);
                    client.Send(data, data.Length);
                    client.Close();
                }
            }
            catch (Exception ex)
            {
                rtbLog.Text = rtbLog.Text + "\nError sending packet: " + ex.ToString();
            }
        }

        private void btnDis_Click(object sender, EventArgs e)
        {
            enabled = false;
            try
            {
                using (var client = new UdpClient())
                {
                    data = BitConverter.GetBytes(102);
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress), sendPort);
                    client.Connect(ep);
                    client.Send(data, data.Length);
                    client.Close();
                }
            }
            catch (Exception ex)
            {
                rtbLog.Text = rtbLog.Text + "\nError sending packet: " + ex.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnShut_Click(object sender, EventArgs e)
        {
            if (enabled == false)
            {
                try
                {
                    using (var client = new UdpClient())
                    {
                        data = BitConverter.GetBytes(105);
                        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress), sendPort);
                        client.Connect(ep);
                        client.Send(data, data.Length);
                        client.Close();
                    }
                }
                catch (Exception ex)
                {
                    rtbLog.Text = rtbLog.Text + "\nError sending packet: " + ex.ToString();
                }
            } else {
                rtbLog.Text = rtbLog.Text + "\nYou must disable first before shutting down.";
            }
        }

        private void lblJoy_Click(object sender, EventArgs e)
        {

        }

        bool IsApplicationIdle()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, (uint)0, (uint)0, (uint)0) == 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Location;
        }

        [DllImport("user32.dll")]
        public static extern int PeekMessage(out NativeMessage message, IntPtr window, uint filterMin, uint filterMax, uint remove);
    }
}
