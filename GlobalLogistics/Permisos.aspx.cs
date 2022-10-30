using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GlobalLogistics
{
    public partial class Permisos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ActualizarPatentes();
            ActualizarFamilia();
        }
        IList<ComponentePermiso> mPermisos = new List<ComponentePermiso>();

        IList<ComponentePermiso> mPatFam;

        ComponentePermiso mPatSeleccionada;

        public void ActualizarPatentes()
        {
            mPermisos = PermisoBL.GetPermissions();
            DataTable mdt = new DataTable();
            mdt.Columns.Add("Nombre", typeof(string));
            mdt.Columns.Add("Descripcion", typeof(string));
            foreach (Patente p in mPermisos)
            {
                DataRow x = mdt.NewRow();
                x["Nombre"] = p.Nombre;
                x["Descripcion"] = p.Permiso;
                mdt.Rows.Add(x);
            }
            grdPermisos.DataSource = mdt;
            grdPermisos.DataBind();
            Array mlistadoPermisos = PermisoBL.GetAllPermission();
            foreach (TipoPermiso i in mlistadoPermisos)
            {
                ddlPermisos.Items.Add(i.ToString());
            }

            //DataList1.DataSource = mProductos;
            //DataList1.DataBind();
        }
        public void ActualizarFamilia()
        {
            if (mPatSeleccionada.GetType().ToString() == "Familia")
            {
                PermisoBL.GetHijos((Familia)mPatSeleccionada);
                DataTable mdt = new DataTable();
                mdt.Columns.Add("Nombre", typeof(string));
                mdt.Columns.Add("Descripcion", typeof(string));
                foreach (Patente p in mPatSeleccionada.Hijos)
                {
                    DataRow x = mdt.NewRow();
                    x["Nombre"] = p.Nombre;
                    x["Descripcion"] = p.Permiso;
                    mdt.Rows.Add(x);
                }
                grdFamilia.DataSource = mdt;
                grdFamilia.DataBind();
                foreach (GridViewRow x in grdFamilia.Rows)
                {
                    x.BackColor = Color.Aquamarine;
                }
            }

            if (mPatSeleccionada == null || mPatSeleccionada.GetType().ToString() == "Patente")
            {
                mPatFam = PermisoBL.GetPermissions();
                DataTable mdt = new DataTable();
                mdt.Columns.Add("Nombre", typeof(string));
                mdt.Columns.Add("Descripcion", typeof(string));
                foreach (Patente p in mPermisos)
                {
                    DataRow x = mdt.NewRow();
                    x["Nombre"] = p.Nombre;
                    x["Descripcion"] = p.Permiso;
                    mdt.Rows.Add(x);
                }
                grdFamilia.DataSource = mdt;
                grdFamilia.DataBind();

            }
        }

        public void LimpiarFamilia()
        {
            grdFamilia.DataSource = null;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Patente mPatente = new Patente();
            mPatente.Nombre = txtNombre.Text;
            mPatente.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), ddlPermisos.SelectedValue);
            PermisoBL.GuardarComponente(mPatente, false);
            Response.Write("<script>alert('Patente generada correctamente')</script>");
            ActualizarPatentes();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPrincipalUI.aspx");
        }

        protected void grdPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            mPatSeleccionada = mPermisos[grdPermisos.SelectedIndex];
            txtNombre.Text = mPatSeleccionada.Nombre;
            ddlPermisos.SelectedValue = mPatSeleccionada.Permiso.ToString();
            grdPermisos.SelectedRow.BackColor = Color.Aquamarine;
            ActualizarFamilia();
        }

        protected void btnCrearFamilia_Click(object sender, EventArgs e)
        {

        }

        protected void btnBorrarSeleccion_Click(object sender, EventArgs e)
        {
            grdPermisos.SelectedIndex = -1;
            mPatSeleccionada = null;
            txtNombre.Text = "";
            ddlPermisos.SelectedIndex = -1;
            LimpiarFamilia();
        }

        protected void gtnGuardarFamilia_Click(object sender, EventArgs e)
        {

        }

        protected void grdFamilia_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void grdFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}