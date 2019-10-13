using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorDLL
{
    public class Class1
    {
        private static int id;
        private string nombre;

        public Class1()
        {
            id++;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public string getNombre()
        {
            return this.nombre;
        }
    }
}
