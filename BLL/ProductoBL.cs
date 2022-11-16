using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using BE;
using DAL;

namespace BLL
{
    public class ProductoBL
    {
        public static List<Producto> Listar()
        {
            return ProductoDAL.Listar();
        }

        public static int Guardar(Producto pProducto)
        {
            return ProductoDAL.Guardar(pProducto);
        }

        public static Producto Obtener(int pId)
        {
            Producto mProducto = ProductoDAL.Obtener(pId);
            return mProducto;
        }

        public static void Eliminar(Producto pProducto)
        {
            ProductoDAL.Eliminar(pProducto);
        }
        public static Producto Obtener(string pNombre)
        {
            Producto mProducto = ProductoDAL.Obtener(pNombre);
            return mProducto;
        }

        public static void ActualizarStock(Producto pProducto, int Cantidad)
        {
            pProducto.producto_stock += Cantidad;
        }

        public static List<Producto> ListarClientes()
        {
            return ProductoDAL.ListarClientes();
        }

        public static List<Producto> LeerArchivo(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Producto>));
            List<Producto> lista = (List<Producto>)serializer.Deserialize(stream);
            return lista;
        }
    }
}
