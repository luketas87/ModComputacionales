using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            mCuentaUsuarios = CuentaUsuarioBL.Listar();
            DataTable mdt = new DataTable();
            mdt.Columns.Add("Username", typeof(string));
            mdt.Columns.Add("FechaAlta", typeof(DateTime));
            mdt.Columns.Add("Email", typeof(string));
            foreach(CuentaUsuario CU in mCuentaUsuarios)
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

        protected void grdUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            mUsuarioSeleccionado = mCuentaUsuarios[grdUsuarios.SelectedIndex];
            Session["UsuSeleccionado"] = mUsuarioSeleccionado;
            Session["IndexUsuSeleccionado"] = grdUsuarios.SelectedIndex;
            grdUsuarios.SelectedRow.BackColor = Color.Aquamarine;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try {
            CuentaUsuarioBL.ValidarEmail(txtEmail.Text);
            CuentaUsuario mCuenta = new CuentaUsuario();
            mCuenta.Cuenta_fecha_alta = DateTime.Now;
            mCuenta.Cuenta_usuario_username = mCripto.EncriptarReversible(txtNombre.Text);
            mCuenta.Cuenta_usuario_email = txtEmail.Text;
            mCuenta.Cuenta_usuario_password = mCripto.EncriptarIrreversible("12345678");
            CuentaUsuarioBL.Guardar(mCuenta);
            Response.Write("<script>alert('Usuario generado')</script>");
            }
            catch (EmailYaExisteException)
            {
                Response.Write("<script>alert('El email ya existe')</script>");
            }
            //catch(Exception Ex)
            //{
             //   Response.Write("<script>alert('" + Ex.Message + "')</script>");
            //}
        }
    }
}