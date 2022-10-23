using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    }
}