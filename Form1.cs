using System;
using System.Threading;
using System.Management;
using System.Windows.Forms;

namespace esp8266loader
{
    public partial class Form1 : Form
    {
        bool drag = false;
        int mousex = 0;
        int mousey = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void upload_btn_Click(object sender, EventArgs e)
        {
            int i;
            string deviceID = AutodetectPort();

            for (i = 0; i <= customProgressBar1.Maximum; i++)
            {
                customProgressBar1.Value = i;
                customProgressBar1.CustomText = State.Upload + i.ToString() + "% ";
            }

            customProgressBar1.CustomText = State.Finish;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            //Refresh();
        }

        private string AutodetectPort()
        {
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            try
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    if (desc.Contains(Globals.deviceName))
                    {
                        return deviceId;
                    }
                    /*else
                        {
                            return Returns.NotFound;
                        }*/
                }
            }
            catch (ManagementException ex)
            {
                /* Do Nothing */
            }

            return null;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimize_btn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(drag == true)
            {
                Top = Cursor.Position.Y - mousey;
                Left = Cursor.Position.X - mousex;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mousex = Cursor.Position.X - Left;
            mousey = Cursor.Position.Y - Top;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mousex = Cursor.Position.X - Left;
            mousey = Cursor.Position.Y - Top;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag == true)
            {
                Top = Cursor.Position.Y - mousey;
                Left = Cursor.Position.X - mousex;
            }
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        
    }
}