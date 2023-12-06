using LibreriaSensores;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuProyectoForms
{
    public partial class Form1 : Form
    {
        private MiSensor miSensor;

        public Form1()
        {
            InitializeComponent();

            // Crear instancias de TextBox en tu formulario
            textBoxId = new TextBox();
            textBoxNombre = new TextBox();
            textBoxValor = new TextBox();

            // Agregar TextBox al formulario
            Controls.Add(textBoxId);
            Controls.Add(textBoxNombre);
            Controls.Add(textBoxValor);

            // Configurar posición y diseño de los TextBox según tus necesidades
            textBoxId.Location = new System.Drawing.Point(100, 50);
            textBoxNombre.Location = new System.Drawing.Point(100, 100);
            textBoxValor.Location = new System.Drawing.Point(100, 150);

            // Otros ajustes y configuraciones según tus necesidades

            miSensor = new MiSensor();
            miSensor.DatosRecibidos += MiSensor_DatosRecibidos;

            // Iniciar la lectura de datos
            // Puedes hacerlo en un hilo aparte si es necesario
            Task.Run(() => miSensor.Leer());
        }

        private TextBox textBoxId;
        private TextBox textBoxNombre;
        private TextBox textBoxValor;

        private void MiSensor_DatosRecibidos(object sender, IEnumerable<MiSensor.Sensor> datos)
        {
            // Actualizar la interfaz de usuario en el hilo principal
            BeginInvoke(new Action(() =>
            {
                foreach (var sensor in datos)
                {
                    // Actualizar los valores de los TextBox
                    textBoxId.Text = $"ID: {sensor.Id}";
                    textBoxNombre.Text = $"Nombre: {sensor.Nombre}";
                    textBoxValor.Text = $"Valor: {sensor.Unidad}";
                }
            }));
        }
    }
}
