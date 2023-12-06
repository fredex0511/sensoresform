using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace LibreriaSensores
{
    public class MiSensor
    {
        public event EventHandler<IEnumerable<MiSensor.Sensor>> DatosRecibidos;

        private PuertoSerial serial;

        public MiSensor()
        {
            serial = new PuertoSerial();
            serial.ConexionArduino();
        }

        private const string Datajson = "C:/Users/elcho/OneDrive/Escritorio/UTT/Cuatri4/IOT/DiccionarioSensores.json";

        public class Sensor
        {
            public string Id { get; set; }
            public string Nombre { get; set; }
            public string Unidad { get; set; }
        }

        public void Leer()
        {
            foreach (string dato in serial.RetornarDatos())
            {
                string data = dato.Trim();

                string JsonData = File.ReadAllText(Datajson);
                List<Sensor> sensors = JsonConvert.DeserializeObject<List<Sensor>>(JsonData);

                string[] cadenas = data.Split(new char[] { ':' });


                Sensor us = sensors.Find(item => item.Id == cadenas[0]);
                if (cadenas.Length >= 2 && us != null)
                {
                    string tipo = cadenas[1];
                    string valor = cadenas[2];

                    valor = valor + us.Unidad;

                    Sensor nuevoSensor = new Sensor { Id = tipo, Nombre = us.Nombre, Unidad = valor };

                    OnDatosRecibidos(new List<Sensor> { nuevoSensor });
                    MostrarDatosEnConsola(nuevoSensor);

                }
            }
        }

        protected virtual void OnDatosRecibidos(IEnumerable<Sensor> datos)
        {
            DatosRecibidos?.Invoke(this, datos);
        }

        private void MostrarDatosEnConsola(Sensor sensor)
        {
            Console.WriteLine($"ID: {sensor.Id}, Nombre: {sensor.Nombre}, Valor: {sensor.Unidad}");
        }
    }
}
