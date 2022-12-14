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
    public partial class Verificadores : System.Web.UI.Page
    {
        Dictionary<string, string> mCorrupcionBD;
        CuentaUsuario mUsuarioLogueado;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["IDUsuario"] is null))
            {
                int id = int.Parse(Session["IDUsuario"].ToString());
                mUsuarioLogueado = CuentaUsuarioBL.Obtener((int)id, true);
                if (PermisoBL.ValidarPermiso(mUsuarioLogueado, 7))
                {
                    mCorrupcionBD = new Dictionary<string, string>();
                    if (this.Session["DVV"] as List<string> != null)
                    {
                        foreach (string x in this.Session["DVV"] as List<string>)
                        {
                            mCorrupcionBD.Add(x, "DVV");
                        }
                    }
                    if (this.Session["DVH"] as List<string> != null)
                    {
                        foreach (string x in this.Session["DVH"] as List<string>)
                        {
                            mCorrupcionBD.Add(x, "DVH");
                        }
                    }
                    GridView1.DataSource = mCorrupcionBD;
                    GridView1.DataBind();
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
        protected void btnRecalcularDigitos_Click(object sender, EventArgs e)
        {
            DVHBL.CalcularTodos();
            DVVBL.CalcularTodo();
            Session["DVH"] = null;
            Session["DVV"] = null;
            this.Session["BaseCorrupta"] = false;
            Response.Redirect("MenuPrincipalUI.aspx");
        }
        void VerificarBase()
        {
            mCorrupcionBD.Clear();


            foreach (string x in DVVBL.ListarDVVsAlterados())
            {
                mCorrupcionBD.Add(x, "DVV");
            }
            foreach (string x in DVHBL.ListarDVHsAlterados())
            {
                mCorrupcionBD.Add(x, "DVH");
            }
            GridView1.DataSource = mCorrupcionBD;
            GridView1.DataBind();
        }
    }
}
