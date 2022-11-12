using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;
using Servicios;

namespace GlobalLogistics
{
    public partial class ABMUsuario : System.Web.UI.Page
    {
        string mUsuarioLogueado;
        CuentaUsuario mCuentaUsuarioLogueada;
        Encriptador mCripto = new Encriptador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserLogueado"] != null)
            {
                if (Request.Cookies["UserLogueado"] != null)
                {
                    mUsuarioLogueado = Request.Cookies["UserLogueado"].Value;
                    mCuentaUsuarioLogueada = CuentaUsuarioBL.Obtener(int.Parse(mUsuarioLogueado));
                }
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Encriptador mCripto = new Encriptador();
            CuentaUsuario mCuentaUsuario = new CuentaUsuario();
            //mCuentaUsuario.Cuenta_usuario_username = mCripto.EncriptarReversible(txtUsuario.Text);
            //mCuentaUsuario.Cuenta_usuario_password = mCripto.EncriptarIrreversible(txtContrasenia.Text);
            mCuentaUsuario.Cuenta_fecha_alta = DateTime.Now;
            mCuentaUsuario.Cuenta_usuario_intentos_login = 0;
            mCuentaUsuario.cuenta_usuario_activa = 1;
            CuentaUsuarioBL.Guardar(mCuentaUsuario);
            DVHBL.ActualizarDV("cuenta_usuario", mCuentaUsuario.Cuenta_usuario_id);
            BE.Bitacora mRegistro = new BE.Bitacora();
            mRegistro.cuenta_usuario_id = mCuentaUsuario.Cuenta_usuario_id;
            mRegistro.bitacora_fecha = DateTime.Now;
            mRegistro.bitacora_hora = DateTime.Now.TimeOfDay;
            mRegistro.cuenta_usuario_id = mCuentaUsuarioLogueada.Cuenta_usuario_id;
            mRegistro.bitacora_criticidad = 4;
            mRegistro.bitacora_transaccion_id = 5;
            BitacoraBL.Guardar(mRegistro);
        }
    }
}