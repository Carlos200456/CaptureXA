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
    public partial class CaptureXA : Form
    {
        public CaptureXA()
        {
            InitializeComponent();
        }

        private const string DefaultPort = "COM7";

        private static readonly string PortFile = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CaptureXA", "port.txt");

        // Puerto por argumento de linea de comandos (ej. shortcut: CaptureXA.exe COM5 o /port:COM5)
        private static string PortFromArgs()
        {
            foreach (string arg in Environment.GetCommandLineArgs().Skip(1))
            {
                string a = arg.Trim().TrimStart('/', '-');
                if (a.StartsWith("port:", StringComparison.OrdinalIgnoreCase) || a.StartsWith("port=", StringComparison.OrdinalIgnoreCase))
                    a = a.Substring(5);
                if (a.StartsWith("COM", StringComparison.OrdinalIgnoreCase))
                    return a.ToUpperInvariant();
            }
            return null;
        }

        private static string PortFromFile()
        {
            try { return System.IO.File.Exists(PortFile) ? System.IO.File.ReadAllText(PortFile).Trim() : null; }
            catch { return null; }
        }

        private static void SavePort(string port)
        {
            try
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(PortFile));
                System.IO.File.WriteAllText(PortFile, port);
            }
            catch { }
        }

        private void RefreshPorts(string select)
        {
            string[] ports = SerialPort.GetPortNames().OrderBy(p => p.Length).ThenBy(p => p).ToArray();
            comboPort.Items.Clear();
            comboPort.Items.AddRange(ports);
            if (!string.IsNullOrEmpty(select))
            {
                // Si el puerto pedido no esta listado, se agrega igual para poder intentar abrirlo
                if (!comboPort.Items.Contains(select)) comboPort.Items.Add(select);
                comboPort.SelectedItem = select;
            }
        }

        private void OpenPort(string name)
        {
            try
            {
                if (serialPort1.IsOpen) serialPort1.Close();
                serialPort1.PortName = name;
                serialPort1.BaudRate = int.Parse("57600");
                serialPort1.DataBits = int.Parse("8");
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                serialPort1.Encoding = Encoding.GetEncoding("iso-8859-1");
                // Encoding = Encoding.GetEncoding("Windows-1252");
                serialPort1.Open();
                SavePort(name);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CaptureXA_Load(object sender, EventArgs e)
        {
            // Prioridad: argumento del shortcut > ultimo puerto usado > COM7
            string port = PortFromArgs() ?? PortFromFile() ?? DefaultPort;
            RefreshPorts(port);
            OpenPort(port);
        }

        private void comboPort_DropDown(object sender, EventArgs e)
        {
            string current = comboPort.SelectedItem as string;
            RefreshPorts(current);
        }

        private void comboPort_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string port = comboPort.SelectedItem as string;
            if (!string.IsNullOrEmpty(port)) OpenPort(port);
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
