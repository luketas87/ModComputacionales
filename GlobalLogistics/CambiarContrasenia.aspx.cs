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
    public partial class CambiarContrasenia : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {

            
        }

        protected void BtnCambiarContrasenia_Click(object sender, EventArgs e)
        {
            try
            {
                Encriptador mCripto = new Encriptador();
                CuentaUsuario mCuentaUsuario = CuentaUsuarioBL.ValidarLogin(txtUser.Value, txtPassword.Value);
                if (Password2.Value == Password3.Value) CuentaUsuarioBL.ModificarContrasenia(mCuentaUsuario, mCripto.EncriptarIrreversible(Password2.Value));
                else throw new ClavesNoCoincidenException();
            }
            catch (ClavesNoCoincidenException)
            {
                lblError.InnerText = "Las claves ingresadas con coinciden";
            }
            catch (UsuarioInexistenteException)
            {
                lblError.InnerText = "Las credenciales son incorrectas";
            }

            catch (ContraseniaIncorrectaException)
            {
                lblError.InnerText = "Las credenciales son incorrectas";
            }
            catch (Exception Ex)
            {
                lblError.InnerText = Ex.Message;
            }
        }
        void VerificarBase()
        {



        }
    }
}