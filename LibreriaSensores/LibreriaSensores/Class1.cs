using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaSensores
{
    public class PuertoSerial
    {
        System.IO.Ports.SerialPort Arduino;

        string puerto;

        public string Puerto { get => puerto; set => puerto = value; }

        public void ConexionArduino()
        {
            Arduino = new System.IO.Ports.SerialPort();
            Puerto = "COM4";
            Arduino.PortName = Puerto;
            Arduino.BaudRate = 9600;
            Arduino.Open();
        }

        public IEnumerable<string> RetornarDatos()
        {
            while (Arduino.IsOpen)
            {
                string dato = Arduino.ReadLine();
                yield return dato;
            }
        }

        public void CerrarConexion()
        {
            Arduino.Close();
        }

    }
}
