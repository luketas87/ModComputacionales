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
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace GlobalLogistics
{
    public partial class ProductoUI : System.Web.UI.Page
    {
        List<Producto> mProductos = new List<Producto>();
        Producto mProductoSeleccionado;
        List<Producto> listaProcesada;
        CuentaUsuario mUsuarioLogueado;
        protected void Page_Load(object sender, EventArgs e)
        {
            Actualizar();
            if (Request.Cookies["ProductoSeleccionado"]!=null) mProductoSeleccionado = mProductos.Find(x => x.producto_id == int.Parse(Request.Cookies["ProductoSeleccionado"].Value));
            if (Session["ProductosCargados"] != null) listaProcesada = (List<Producto>)Session["ProductosCargados"];
            if (!(Session["IDUsuario"] is null))
            {
                int id = int.Parse(Session["IDUsuario"].ToString());
                CuentaUsuario mUsuarioLogueado = CuentaUsuarioBL.Obtener((int)id, true);
                if (PermisoBL.ValidarPermiso(mUsuarioLogueado, 9) || PermisoBL.ValidarPermiso(mUsuarioLogueado, 6))
                {
                    //OK
                }
                else
                {
                    Response.Redirect("MenuPrincipalUI.aspx");
                }

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        public void Actualizar()
        {
                mProductos = ProductoBL.Listar();
            //    GridView1.DataSource = mProductos;
            //GridView1.DataBind();
            GridView2.DataSource = mProductos;
            GridView2.DataBind();
            gridViewArchivo.Visible = false;

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

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();

            //mProductos = ProductoBL.Listar();

            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            XmlSerializer serializer = new XmlSerializer(mProductos.GetType());
            serializer.Serialize(stream, mProductos);

            XmlTextWriter writer = new XmlTextWriter(stream, System.Text.Encoding.UTF8);

            doc.WriteTo(writer);
            writer.Flush();
            Response.Clear();
            byte[] byteArray = stream.ToArray();
            Response.ContentType = "application/force-download";
            Response.AddHeader("content-disposition", "attachment; filename=Productos.xml");
            Response.BinaryWrite(byteArray);
            Response.End();
            writer.Close();
        }

        protected void btnStock_Click(object sender, EventArgs e)
        {
            ProductoBL.ActualizarStock(mProductoSeleccionado, int.Parse(txtStock.Text));
            ProductoBL.Guardar(mProductoSeleccionado);
            Actualizar();
        }


        protected void btnSubir_Click(object sender, EventArgs e)
        {
            if (btnImportar.HasFile)
            {
                Stream stream = btnImportar.FileContent;
                listaProcesada = ProductoBL.LeerArchivo(stream);
                gridViewArchivo.Visible = true;
                gridViewArchivo.DataSource = listaProcesada;
                Session["ProductosCargados"] = listaProcesada;
                gridViewArchivo.DataBind();
            }
            else
            {
                ViewState["result"] = "Error: No hay un archivo seleccionado";
            }
        }

        protected void gridViewArchivo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //FillGrid();
            gridViewArchivo.PageIndex = e.NewPageIndex;
            gridViewArchivo.DataBind();
        }

        protected void btnGuardarimportado_Click(object sender, EventArgs e)
        {
            foreach(Producto p in listaProcesada)
            {
                Producto aux = ProductoBL.Obtener(p.producto_nombre);
                if(aux == null) {
                    p.producto_id = 0;
                    ProductoBL.Guardar(p);
                }
                else
                {
                    aux.producto_stock = p.producto_stock;
                    ProductoBL.Guardar(aux);
                }
                
            }
            Actualizar();

        }
    }
}


