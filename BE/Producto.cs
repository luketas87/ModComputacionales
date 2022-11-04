using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BE
{
    [XmlRoot("Producto")]
    public class Producto
    {
        [XmlElement("ID")]
        public int producto_id
        {
            get;set;
        }
        [XmlElement("Nombre")]
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
