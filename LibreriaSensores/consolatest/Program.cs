using LibreriaSensores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consolatest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MiSensor miSensor = new MiSensor();
            miSensor.Leer();
        }
    }
}
