using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Patente
    {
        public int patente_id
        {
            get; set;
        }
        public string patente_nombre
        {
            get; set;
        }

        public Patente()
        {

        }
        public Patente(int pId)
        {
            patente_id = pId;
        }

    }
}
