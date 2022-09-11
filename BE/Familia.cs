using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Familia
    {
        public int familia_id
        {
            get; set;
        }
        public string familia_nombre
        {
            get; set;
        }

        public List<Patente> mPatentes;

        public Familia()
        {
            mPatentes = new List<Patente>();
        }

        public Familia(int pId)
        {
            mPatentes = new List<Patente>();
            familia_id = pId;
        }
    }
}
