using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using System.Data;

namespace DAL
{
    public class ProductoDAL
    {
        public static int mId;

        public static int ProximoId()
        {
            if (mId == 0)
            {
                DAO mDAObject = new DAO();
                mId = mDAObject.ObtenerId("Producto");
            }
            mId += 1;
            return mId;
        }

        public static void ValorizarEntidad(Producto pProducto, DataRow pDr)
        {
            pProducto.producto_id = int.Parse(pDr["producto_id"].ToString());
            pProducto.producto_nombre = pDr["producto_nombre"].ToString();
            pProducto.producto_stock = int.Parse(pDr["producto_stock"].ToString());
        }
        public static List<Producto> Listar()
        {
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            List<Producto> mProductos = new List<Producto>();
            mDs = mDAObject.ExecuteDataSet("select producto_id, Producto_nombre, producto_stock from Producto");

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Producto mProducto = new Producto(int.Parse(mDr["Producto_id"].ToString()));
                    ValorizarEntidad(mProducto, mDr);
                    mProductos.Add(mProducto);
                }
            }
            return mProductos;
        }

        public static Producto Obtener(int pId)
        {
            DAO mDAObject = new DAO();
            DataSet mDs = mDAObject.ExecuteDataSet("select Producto_id, Producto_nombre, producto_stock from Producto where Producto_id = " + pId);
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                Producto mProducto = new Producto(pId);
                ValorizarEntidad(mProducto, mDs.Tables[0].Rows[0]);
                return mProducto;
            }
            else return null;
        }
        public static Producto Obtener(string pNombre)
        {
            DAO mDAObject = new DAO();
            DataSet mDs = mDAObject.ExecuteDataSet("select Producto_id, Producto_nombre, producto_stock from Producto where Producto_nombre = '" + pNombre + "'");
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                int pId = int.Parse(mDs.Tables[0].Rows[0]["Producto_id"].ToString());
                Producto mProducto = new Producto(pId);
                ValorizarEntidad(mProducto, mDs.Tables[0].Rows[0]);
                return mProducto;
            }
            else return null;
        }

        public static int Eliminar(Producto pProducto)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando = "delete from producto where producto_id = " + pProducto.producto_id;
            return mDAObject.ExecuteNonQuery(pCadenaComando);
        }


        public static int Guardar(Producto pProducto)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            

            if (pProducto.producto_id == 0)
            {
                pProducto.producto_id = ProximoId();
                pCadenaComando = "insert into Producto(Producto_id, Producto_nombre, producto_stock) values (" + pProducto.producto_id + ", '" + pProducto.producto_nombre + "', " + pProducto.producto_stock + ")";
            }
            else pCadenaComando = "update Producto set producto_nombre = '" + pProducto.producto_nombre+"', producto_stock = " + pProducto.producto_stock +" where producto_id = " + pProducto.producto_id; 
            return mDAObject.ExecuteNonQuery(pCadenaComando);
        }

        public static List<Producto> ListarClientes()
        {
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            List<Producto> mProductos = new List<Producto>();
            mDs = mDAObject.ExecuteDataSet("select producto_id, Producto_nombre from Producto");

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Producto mProducto = new Producto(int.Parse(mDr["Producto_id"].ToString()));
                    ValorizarEntidadSStock(mProducto, mDr);
                    mProductos.Add(mProducto);
                }
            }
            return mProductos;
        }

        public static void ValorizarEntidadSStock(Producto pProducto, DataRow pDr)
        {
            pProducto.producto_id = int.Parse(pDr["producto_id"].ToString());
            pProducto.producto_nombre = pDr["producto_nombre"].ToString();
        }
    }
    
}
