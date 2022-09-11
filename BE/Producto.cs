using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Producto
    {
        public int producto_id
        {
            get;set;
        }
        public string producto_nombre
        {
            get;set;
        }
        public Producto(int pId)
        {
            producto_id = pId;
        }

        public Producto()
        {

        }
    }
}
