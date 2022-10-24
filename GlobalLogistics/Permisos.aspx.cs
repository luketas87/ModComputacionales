using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GlobalLogistics
{
    public partial class Permisos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Actualizar();
        }
        IList<Patente> mPermisos = new List<Patente>();

        public void Actualizar()
        {
            mPermisos = PermisoBL.GetAllPatentes();
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Patente mPatente = new Patente();
            mPatente.Nombre = txtNombre.Text;
            mPatente.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), ddlPermisos.SelectedValue);
            PermisoBL.GuardarComponente(mPatente, false);
        }
    }
}