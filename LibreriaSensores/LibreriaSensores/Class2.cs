using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace LibreriaSensores
{
    public class TipoSensor
    {

        public string id { get; set; }
        public string nombre { get; set; }
        public string unidad { get; set; }
        public TipoSensor(String id,String nombre, String unidad)
        {
            this.id = id;
            this.nombre = nombre;
            this.unidad = unidad;
        }

    }
}
