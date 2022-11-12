using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using BE;
using BLL;

namespace GlobalLogistics
{
    public partial class ABMProducto : System.Web.UI.Page
    {
        List<Producto> mProductos = new List<Producto>();
        Producto mProductoSeleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {
            Actualizar();
            
        }

        public void Actualizar()
        {
            mProductos = ProductoBL.Listar();
            grdProductos.DataSource = mProductos;
            grdProductos.DataBind();

            DataList1.DataSource = mProductos;
            DataList1.DataBind();
        }

        protected void grdProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Producto mProducto = ProductoBL.Obtener(grdProductos.SelectedIndex-1);
            //TextBox1.Text = mProducto.producto_nombre;
            GridViewRow row = grdProductos.Rows[grdProductos.SelectedIndex];
            mProductoSeleccionado = ProductoBL.Obtener(int.Parse(row.Cells[1].Text));
            TextBox1.Text = mProductoSeleccionado.producto_nombre;
            HttpCookie mNombreProducto = new HttpCookie("Nombre Producto");
            mNombreProducto.Value = mProductoSeleccionado.producto_nombre;
            Response.Cookies.Add(mNombreProducto);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto mProducto = new Producto();
            mProducto.producto_nombre = TextBox1.Text;
            ProductoBL.Guardar(mProducto);
            Actualizar();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Producto mProducto = ProductoBL.Obtener(Request.Cookies["Nombre Producto"].Value);
            mProducto.producto_nombre = TextBox1.Text;
            ProductoBL.Guardar(mProducto);
            Actualizar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Producto mProducto = ProductoBL.Obtener(Request.Cookies["Nombre Producto"].Value);
            ProductoBL.Eliminar(mProducto);
            Actualizar();
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();

            mProductos = ProductoBL.Listar();

            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            XmlSerializer serializer = new XmlSerializer(mProductos.GetType());
            serializer.Serialize(stream, mProductos);

            XmlTextWriter writer = new XmlTextWriter(stream, System.Text.Encoding.UTF8);

            doc.WriteTo(writer);
            writer.Flush();
            Response.Clear();
            byte[] byteArray = stream.ToArray();
            Response.ContentType = "application/force-download";
            Response.AddHeader("content-disposition", "attachment; filename=Productos.txt");
            Response.BinaryWrite(byteArray);
            Response.End();
            writer.Close();
        }
    }
}