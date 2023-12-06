using LibreriaSensores;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensoresForm1
{
    public partial class Form1 : Form
    {
        private MiSensor miSensor;
        private List<MiSensor.Sensor> listaSensores = new List<MiSensor.Sensor>();
        private Timer limpiarListaTimer;

        public Form1()
        {
            InitializeComponent();

            miSensor = new MiSensor();
            miSensor.DatosRecibidos += MiSensor_DatosRecibidos;

            Task.Run(() => miSensor.Leer());

            limpiarListaTimer = new Timer();
            limpiarListaTimer.Interval = 10000; 
            limpiarListaTimer.Tick += LimpiarListaTimer_Tick;
            limpiarListaTimer.Start();
        }

        private void MiSensor_DatosRecibidos(object sender, IEnumerable<MiSensor.Sensor> datos)
        {
            BeginInvoke(new Action(() =>
            {
                foreach (var sensor in datos)
                {
                    listaSensores.Add(sensor);

                    textBox1.Text = $"ID: {sensor.Id}";
                    textBox2.Text = $"Nombre: {sensor.Nombre}";
                    textBox3.Text = $"Valor: {sensor.Unidad}";

                    listBox1.Items.Add($"ID: {sensor.Id}, Nombre: {sensor.Nombre}, Valor: {sensor.Unidad}");
                }
            }));
        }

        private void LimpiarListaTimer_Tick(object sender, EventArgs e)
        {
            listaSensores.Clear();
            listBox1.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
