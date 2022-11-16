using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BE;

namespace GlobalLogistics
{
    public partial class MenuPrincipalUI : System.Web.UI.Page
    {
        CuentaUsuario mUsuarioLogueado;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(true )//!(Session["IDUsuario"] is null))
            {
                int id = 1;//int.Parse(Session["IDUsuario"].ToString());
                mUsuarioLogueado = CuentaUsuarioBL.Obtener((int)id, true);
                Label1.Text = mUsuarioLogueado.Cuenta_usuario_email;
                CargarBotonesOperaciones(mUsuarioLogueado);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        private void CargarBotonesOperaciones(CuentaUsuario mUsuarioLogueado)
        {
            btnBitacora.Visible = PermisoBL.ValidarPermiso(mUsuarioLogueado, 4);
            AdmUsuarios.Visible = PermisoBL.ValidarPermiso(mUsuarioLogueado, 5);
            AsignarPermisos.Visible = PermisoBL.ValidarPermiso(mUsuarioLogueado, 10);
            BackRestore.Visible = PermisoBL.ValidarPermiso(mUsuarioLogueado, 9) || PermisoBL.ValidarPermiso(mUsuarioLogueado, 6);
            RecDigitos.Visible = PermisoBL.ValidarPermiso(mUsuarioLogueado, 7);
        }

        protected void btnBitacora_Click(object sender, EventArgs e)
        {
            Response.Redirect("Bitacora.aspx");
        }

        //Control para obtener del site.master
        public override void VerifyRenderingInServerForm(Control control)
        {

        }


        /*CuentaUsuario mCuentaUsuario;
        //string mUsuarioLogueado;
        Encriptador mCripto = new Encriptador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.Session["UsuarioLoggeado"]))
            {
                lblDVVDVH.Visible=false;

                //mUsuarioLogueado = this.Session["Usuario"].ToString();
                mCuentaUsuario = CuentaUsuarioBL.Obtener(int.Parse(this.Session["IDUsuario"].ToString()));
                //txtUsuarioLogueado.Text = mCripto.Desencriptar(mCuentaUsuario.Cuenta_usuario_username);
                //txtTest.Text = mUsuarioLogueado;
                List<Familia> mFamilias = new List<Familia>();
                mFamilias = CuentaUsuarioBL.ObtenerFamilias(mCuentaUsuario);

                if (mFamilias.ElementAt(0).mPatentes != null)
                {
                    foreach (Patente mPat in mFamilias.ElementAt(0).mPatentes)

                    {
                        if (mPat.patente_id == 1) { bitacora.Visible = true; }
                        if (mPat.patente_id == 2) { digitos.Visible = true; }
                    }

                }
                lblUser.Text = "Usuario: " + mCripto.Desencriptar(this.Session["Usuario"].ToString());
                lblRol.Text = "Perfil: " + this.Session["Familia"].ToString();
                if (Convert.ToBoolean(this.Session["BaseCorrupta"]))
                {
                    lblDVVDVH.Text = "La base de datos está corrupta, verificar los DVH y DVV de las tablas.";
                    lblDVVDVH.Visible = true;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                CuentaUsuarioBL.Logout(mCuentaUsuario);
                this.Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            catch (Exception ex)
            {
                string errormsg = "";
                errormsg = "<script>alert('" + ex.Message + "') </script>";
                Response.Write(errormsg);
            }

        }

        protected void btnBackup_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.Session["UsuarioLoggeado"]))
            {
                Response.Redirect("BackupRestore.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.Session["UsuarioLoggeado"]))
            {
                Response.Redirect("ABMProducto.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnProductos_Click1(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.Session["UsuarioLoggeado"]))
            {
                Response.Redirect("Permisos.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }*/
    }
    }


