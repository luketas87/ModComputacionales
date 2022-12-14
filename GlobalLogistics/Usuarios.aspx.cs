using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;
using Servicios;

namespace GlobalLogistics
{
    public partial class Usuarios : System.Web.UI.Page
    {
        List<CuentaUsuario> mCuentaUsuarios;
        Encriptador mCripto = new Encriptador();
        CuentaUsuario mUsuarioSeleccionado;
        ComponentePermiso mPermisoSeleccionado;
        List<ComponentePermiso> mPermisos;
        ComponentePermiso mPermisoAsignadoSeleccionado;
        int indexPermisoAsignadoSeleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["IDUsuario"] is null))
            {
                int id = int.Parse(Session["IDUsuario"].ToString());
                CuentaUsuario mUsuarioLogueado = CuentaUsuarioBL.Obtener((int)id, true);
                if (PermisoBL.ValidarPermiso(mUsuarioLogueado, 5))
                {
                    Actualizar();
                    ActualizarPermisos();
                    mUsuarioSeleccionado = (CuentaUsuario)Session["UsuSeleccionado"];
                    mPermisoSeleccionado = (ComponentePermiso)Session["PermisoSeleccionado"];
                    mPermisoAsignadoSeleccionado = (ComponentePermiso)Session["PermisoAsignadoSeleccionado"];
                    if (Session["IndexPermisoAsignadoSeleccionado"] != null) indexPermisoAsignadoSeleccionado = int.Parse(Session["IndexPermisoAsignadoSeleccionado"].ToString());
                }
                else
                {
                    Response.Redirect("MenuPrincipal.aspx");
                }

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        public void Actualizar()
        {
            mCuentaUsuarios = CuentaUsuarioBL.Listar();
            DataTable mdt = new DataTable();
            mdt.Columns.Add("Username", typeof(string));
            mdt.Columns.Add("FechaAlta", typeof(DateTime));
            mdt.Columns.Add("Email", typeof(string));
            foreach (CuentaUsuario CU in mCuentaUsuarios)
            {
                DataRow x = mdt.NewRow();
                x["Username"] = mCripto.Desencriptar(CU.Cuenta_usuario_username);
                x["FechaAlta"] = CU.Cuenta_fecha_alta;
                x["Email"] = CU.Cuenta_usuario_email;
                mdt.Rows.Add(x);
            }
            grdUsuarios.DataSource = mdt;
            grdUsuarios.DataBind();
        }

        public void ActualizarPermisos()
        {
            mPermisos = PermisoBL.GetPermissions();
            DataTable mdt = new DataTable();
            mdt.Columns.Add("Nombre", typeof(string));
            mdt.Columns.Add("Descripcion", typeof(string));
            mdt.Columns.Add("Tipo", typeof(string));
            mdt.Columns.Add("Type", typeof(string));
            foreach (ComponentePermiso p in mPermisos)
            {
                DataRow x = mdt.NewRow();
                x["Nombre"] = p.Nombre;
                x["Type"] = p.GetType().ToString();
                if (p.GetType().ToString() == "BE.Patente")
                {
                    x["Descripcion"] = p.Permiso;
                    x["Tipo"] = "Patente";

                }
                else
                {
                    x["Descripcion"] = "";
                    x["Tipo"] = "Familia";
                }
                mdt.Rows.Add(x);
            }
            grdPatentes.DataSource = mdt;
            grdPatentes.DataBind();
        }

        protected void grdUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            mUsuarioSeleccionado = mCuentaUsuarios[grdUsuarios.SelectedIndex];
            Session["UsuSeleccionado"] = mUsuarioSeleccionado;
            Session["IndexUsuSeleccionado"] = grdUsuarios.SelectedIndex;
            grdUsuarios.SelectedRow.BackColor = Color.Aquamarine;
            txtNombre.Value = mUsuarioSeleccionado.Cuenta_usuario_email;
            txtNombre.Value = mCripto.Desencriptar(mUsuarioSeleccionado.Cuenta_usuario_username);
            PermisoBL.GetPermissions(mUsuarioSeleccionado);
            DataTable mdt = new DataTable();
            mdt.Columns.Add("Nombre", typeof(string));
            mdt.Columns.Add("Descripcion", typeof(string));
            mdt.Columns.Add("Tipo", typeof(string));
            mdt.Columns.Add("Type", typeof(string));
            foreach (ComponentePermiso p in mUsuarioSeleccionado.Permisos)
            {
                DataRow x = mdt.NewRow();
                x["Nombre"] = p.Nombre;
                x["Type"] = p.GetType().ToString();
                if (p.GetType().ToString() == "BE.Patente")
                {
                    x["Descripcion"] = p.Permiso;
                    x["Tipo"] = "Patente";

                }
                else
                {
                    x["Descripcion"] = "";
                    x["Tipo"] = "Familia";
                }
                mdt.Rows.Add(x);
            }
            grdPatAsignadas.DataSource = mdt;
            grdPatAsignadas.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void grdPatentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            mPermisoSeleccionado = mPermisos[grdPatentes.SelectedIndex];
            Session["PermisoSeleccionado"] = mPermisoSeleccionado;
            grdPatentes.SelectedRow.BackColor = Color.Aquamarine;
        }

        protected void btnRemoverPermiso_Click(object sender, EventArgs e)
        {
            mUsuarioSeleccionado.Permisos.Remove(mUsuarioSeleccionado.Permisos[indexPermisoAsignadoSeleccionado]);
            PermisoBL.GuardarPermisos(mUsuarioSeleccionado);
        }

        protected void grdPatAsignadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            mPermisoAsignadoSeleccionado = mUsuarioSeleccionado.Permisos[grdPatAsignadas.SelectedIndex];
            Session["PermisoAsignadoSeleccionado"] = mPermisoAsignadoSeleccionado;
            Session["IndexPermisoAsignadoSeleccionado"] = grdPatAsignadas.SelectedIndex;
            grdPatAsignadas.SelectedRow.BackColor = Color.Aquamarine;
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {

            try
            {
                CuentaUsuarioBL.ValidarEmail(txtEmail.Value);
                CuentaUsuario mCuenta = new CuentaUsuario();
                mCuenta.Cuenta_fecha_alta = DateTime.Now;
                mCuenta.Cuenta_usuario_username = mCripto.EncriptarReversible(txtNombre.Value);
                mCuenta.Cuenta_usuario_email = txtEmail.Value;
                mCuenta.Cuenta_usuario_password = mCripto.EncriptarIrreversible("12345678");
                CuentaUsuarioBL.Guardar(mCuenta);
                Response.Write("<script>alert('Usuario generado')</script>");
            }
            catch (EmailYaExisteException)
            {
                Response.Write("<script>alert('El email ya existe')</script>");
            }
            catch (Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "')</script>");
            }
        }

        protected void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            mUsuarioSeleccionado.Cuenta_usuario_username = mCripto.EncriptarReversible(txtNombre.Value);
            mUsuarioSeleccionado.Cuenta_usuario_email = txtEmail.Value;
            CuentaUsuarioBL.Guardar(mUsuarioSeleccionado);
            txtEmail.Value = null;
            txtNombre.Value = null;
            Actualizar();
        }

        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            CuentaUsuarioBL.Eliminar(mUsuarioSeleccionado);
            txtEmail.Value = null;
            txtNombre.Value = null;
            Actualizar();
        }

        //Control para obtener del site.master
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btnAgregarPermiso(object sender, EventArgs e)
        {
            mUsuarioSeleccionado.Permisos.Add(mPermisoSeleccionado);
            PermisoBL.GuardarPermisos(mUsuarioSeleccionado);
        }
    }
}