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
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<string> mDVHCorruptos;
        List<string> mDVVCorruptos;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //if (CuentaUsuarioBL.Obtener(1).Cuenta_usuario_id == 0)
            //{
            //    //-------------------------------------------------- CREAR USUARIOS HASTA HABILITAR ABM --------------------------------------------------
            //    //                                                        NO ES NECESARIO COMENTARLO

            //    Encriptador micripto = new Encriptador();
            //    BE.CuentaUsuario nuevousuario = new CuentaUsuario();
            //    nuevousuario.Cuenta_usuario_id = 0;
            //    nuevousuario.Cuenta_usuario_username = micripto.EncriptarReversible("webmaster");
            //    nuevousuario.Cuenta_usuario_password = micripto.EncriptarIrreversible("12345678");
            //    nuevousuario.Cuenta_fecha_alta = DateTime.Now;
            //    nuevousuario.cuenta_usuario_activa = 1;
            //    CuentaUsuarioBL.Guardar(nuevousuario);

            //    nuevousuario = new CuentaUsuario();
            //    nuevousuario.Cuenta_usuario_id = 0;
            //    nuevousuario.Cuenta_usuario_username = micripto.EncriptarReversible("cliente");
            //    nuevousuario.Cuenta_usuario_password = micripto.EncriptarIrreversible("12345678");
            //    nuevousuario.Cuenta_fecha_alta = DateTime.Now;
            //    nuevousuario.cuenta_usuario_activa = 1;
            //    CuentaUsuarioBL.Guardar(nuevousuario);

            //    //----------------------------------------------------------- CALCULA DVH y DVV ----------------------------------------------------------


            //    for (int i = 1; i < 7; i++)
            //    {
            //        DVHBL.ActualizarDV("cuenta_usuario", i);
            //    }

            //    DVVBL.ActualizarDVV("cuenta_usuario");


            //    DVHBL.ActualizarDV("cuenta_usuario", 1, 1);
            //    DVHBL.ActualizarDV("cuenta_usuario", 1, 2);

               

                //for (int i = 1; i < 70; i++)
                //{
                //    DVHBL.ActualizarDV("bitacora", i);

                //}
                //DVVBL.ActualizarDVV("cuenta_usuario_patente");


                ////-------------------------------------------------- CREAR USUARIOS HASTA HABILITAR ABM ---------------------------------------------------

                //for (int i = 1; i < 70; i++)
                //{
                //    DVHBL.ActualizarDV("bitacora", i);

                //}
                //DVVBL.ActualizarDVV("cuenta_usuario_patente");

            //}
            //DVHBL.ActualizarDV("cuenta_usuario_patente", 1, 1);
            //DVHBL.ActualizarDV("cuenta_usuario_patente", 1, 2);

            //DVHBL.ActualizarDV("cuenta_usuario_familia", 1, 1);
            //DVHBL.ActualizarDV("cuenta_usuario_familia", 1, 2);


        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            bool adminlogged = false;

            try
            {
                CuentaUsuario mCuentaUsuario = CuentaUsuarioBL.ValidarLogin(txtUser.Value, txtPassword.Value);

                //bool resultado = mCuentaUsuario.Cuenta_usuario_username != "";

                //HttpCookie myCookie = new HttpCookie("UserLogueado");
                //myCookie.Value = mCuentaUsuario.Cuenta_usuario_id.ToString();
                //myCookie.Expires = DateTime.Now.AddDays(1d);
                //Response.Cookies.Add(myCookie);

                //HttpCookie myCookie2 = new HttpCookie("NombreUsuario");
                //myCookie2.Value = mCuentaUsuario.Cuenta_usuario_username.ToString();
                //myCookie2.Expires = DateTime.Now.AddDays(1d);
                //Response.Cookies.Add(myCookie2);
                VerificarBase();
                List<Familia> mFamilias = new List<Familia>();
                mFamilias = CuentaUsuarioBL.ObtenerFamilias(mCuentaUsuario);
                if (mFamilias.Any(x => x.familia_nombre.Equals("Administrador"))){adminlogged = true;}
                Session.Add("UsuarioLoggeado", true);
                Session.Add("IDUsuario", mCuentaUsuario.Cuenta_usuario_id.ToString());
                Session.Add("Usuario", mCuentaUsuario.Cuenta_usuario_username.ToString());
                Session.Add("Familia", mFamilias.Count > 0 ? mFamilias.ElementAt(0).familia_nombre : "Sin Familia");
                Session.Add("BaseCorrupta",false);

                DVHBL.ValidarConsistenciaDVH();
                DVVBL.ValidarConsistenciaDVV();
                Response.Redirect("MenuPrincipalUI.aspx");
            }
            catch (Servicios.UsuarioInexistenteException ex)
            {
                lblError.Visible = true;
                txtUser.Value = "";
                txtPassword.Value = "";
                lblError.InnerText = "Credenciales incorrectas.";
            }
            catch (Servicios.ContraseniaIncorrectaException ex)
            {
                lblError.Visible = true;
                txtUser.Value = "";
                txtPassword.Value = "";
                lblError.InnerText = "Credenciales incorrectas.";
            }

            catch (Servicios.CuentaBloqueadaException ex)
            {
                lblError.Visible = true;
                txtUser.Value = "";
                txtPassword.Value = "";
                lblError.InnerText = "Usuario bloqueado por intentos fallidos.";
            }
            catch (Servicios.ErrorConsistenciaDVHException ex)
            {
                if (adminlogged)
                {
                    Session["DVH"] = mDVHCorruptos;
                    Session["DVV"] = mDVVCorruptos;
                    Session["BaseCorrupta"] = true;
                    Response.Redirect("MenuPrincipalUI.aspx");
                }
                else
                {
                    lblError.Visible = true;
                    txtUser.Value = "";
                    txtPassword.Value = "";
                    lblError.InnerText = "Base de datos corrupta, contacte al webmaster.";
                }
                //lblDVVDVH.Text = "Error de dígito verificador horizontal en la tabla " + ex.mDVH.tabla + ", registro " + ex.mDVH.clavePrimaria + ".";
                //if (adminlogged) 
                //{
                //    //HttpCookie myCookie = new HttpCookie("DVV");
                //    //myCookie.Value = "Error de dígito verificador horizontal del registro " + ex.mDVH.clavePrimaria + " en la tabla " + ex.mDVH.tabla + ".";
                //    //myCookie.Expires = DateTime.Now.AddDays(1d);
                //    //Response.Cookies.Add(myCookie);
                //    Dictionary<string, string> mRegistrosCorruptos = new Dictionary<string, string>();
                //    Session.Add("DVH", mRegistrosCorruptos);
                //    Response.Redirect("MenuPrincipalUI.aspx");
                //}

            }

            catch (Servicios.ErrorConsistenciaDVVException ex)
            {
                if (adminlogged)
                {
                    Session["DVH"] = mDVHCorruptos;
                    Session["DVV"] = mDVVCorruptos;
                    Response.Redirect("MenuPrincipalUI.aspx");
                }
                else
                {
                    lblError.Visible = true;
                    txtUser.Value = "";
                    txtPassword.Value = "";
                    lblError.InnerText = "Base de datos corrupta, contacte al webmaster.";
                }
                //if (adminlogged)
                //{
                //    //HttpCookie myCookie = new HttpCookie("DVE");
                //    //myCookie.Value = "Error de dígito verificador vertical en la tabla " + ex.mDVV.tabla + ".";
                //    //myCookie.Expires = DateTime.Now.AddDays(1d);
                //    //Response.Cookies.Add(myCookie);
                //    Response.Redirect("MenuPrincipalUI.aspx");
                //}
            }
            
        }
        void VerificarBase()
        {

            Session.Add("BaseCorrupta", true);

            mDVVCorruptos = DVVBL.ListarDVVsAlterados();
            //Session.Add("DVV", mDVVCorruptos);
            mDVHCorruptos = DVHBL.ListarDVHsAlterados();
            //Session.Add("DVH", mDVHCorruptos);

        }
    }
}