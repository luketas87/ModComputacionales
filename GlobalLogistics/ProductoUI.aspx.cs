using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BE;
using System.Data;
using System.Drawing;

namespace GlobalLogistics
{
    public partial class MenuPrincipalUI : System.Web.UI.Page
    {
        List<Producto> mProductos = new List<Producto>();
        Producto mProductoSeleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {
            Actualizar();
            if (Request.Cookies["ProductoSeleccionado"]!=null) mProductoSeleccionado = mProductos.Find(x => x.producto_id == int.Parse(Request.Cookies["ProductoSeleccionado"].Value));
        }

        public void Actualizar()
        {
                mProductos = ProductoBL.Listar();
            //    GridView1.DataSource = mProductos;
            //GridView1.DataBind();
            GridView2.DataSource = mProductos;
            GridView2.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexSeleccionado = (GridView2.PageIndex * 10) + GridView2.SelectedIndex;
            mProductoSeleccionado = mProductos[indexSeleccionado];
            GridView2.SelectedRow.BackColor = Color.Aquamarine;
            txtID.Text = mProductoSeleccionado.producto_id.ToString();
            txtNombre.Text = mProductoSeleccionado.producto_nombre;
            HttpCookie myCookie = new HttpCookie("ProductoSeleccionado");
            myCookie.Value = mProductoSeleccionado.producto_id.ToString();
            Response.Cookies.Add(myCookie);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto mProducto = new Producto();
            mProducto.producto_nombre = txtNombre.Text;
            ProductoBL.Guardar(mProducto);
            GridView2.SelectedIndex = -1;
            txtID.Text = null;
            txtNombre.Text = null;
            Actualizar();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            mProductoSeleccionado.producto_nombre = txtNombre.Text;
            ProductoBL.Guardar(mProductoSeleccionado);
            GridView2.SelectedIndex = -1;
            txtID.Text = null;
            txtNombre.Text = null;
            Actualizar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ProductoBL.Eliminar(mProductoSeleccionado);
            txtID.Text = null;
            txtNombre.Text = null;
            Actualizar();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //FillGrid();
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataBind();
        }
    }
}


