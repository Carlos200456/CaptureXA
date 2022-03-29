using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureXA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CaptureXA_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            try
            {
                serialPort1.PortName = "COM3";
                serialPort1.BaudRate = int.Parse("57600");
                serialPort1.DataBits = int.Parse("8");
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                serialPort1.Encoding = Encoding.GetEncoding("iso-8859-1");
                // Encoding = Encoding.GetEncoding("Windows-1252");
                serialPort1.Open();
             }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonFLOn_MouseDw(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine("FluoroOn\r");
                buttonFluoro.BackColor = Color.Yellow;
            }
        }

        private void buttonFLOn_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine("FluoroOff\r");
                buttonFluoro.BackColor = Color.LightGray;
            }

        }

        private void buttonCine_MouseDw(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine("CineOn\r");
                buttonCine.BackColor = Color.Yellow;
            }
        }

        private void buttonCine_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine("CineOff\r");
                buttonCine.BackColor = Color.LightGray;
            }
        }

    }
}
