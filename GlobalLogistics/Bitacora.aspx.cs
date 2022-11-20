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
    public partial class Bitacora : System.Web.UI.Page
    {

        List<BE.Bitacora> mBitacora = new List<BE.Bitacora>();
        CuentaUsuario mUsuarioLogueado;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["IDUsuario"] is null))
            {
                int id = int.Parse(Session["IDUsuario"].ToString());
                mUsuarioLogueado = CuentaUsuarioBL.Obtener((int)id, true);
                if (PermisoBL.ValidarPermiso(mUsuarioLogueado, 5))
                {
                    Actualizar();
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
            mBitacora = BitacoraBL.Listar();

            GridView1.DataSource = mBitacora;
            GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            //string TextToSearch = TextSearch.Text;
            //BindingSource bs = new BindingSource();
            //bs.DataSource = dataGridView.DataSource;
            //bs.Filter = $"[Columna] LIKE '%'{TextToSearch}'%' AND [Columna] LIKE '%'{TextToSearch}'%'";
            //dataGridView.DataSource = bs;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int bUsuario = 0;
            int bNivel = 0;

            if (TxtUsuario.Text != "")
            {
                bUsuario = int.Parse(TxtUsuario.Text);
            }
            
            if(TxtNivel.Text != "")
            {
                bNivel = int.Parse(TxtNivel.Text);
            }
            

            var datagrid = from bitacora in this.mBitacora
                           where bitacora.cuenta_usuario_id == bUsuario && bitacora.bitacora_criticidad == bNivel 
                           select bitacora; 
            this.GridView1.DataSource = null;
            GridView1.DataSource = datagrid.ToList();

            GridView1.DataBind();
            HttpCookie myCookie = new HttpCookie("NivelSeleccionado");
            myCookie.Value = TxtNivel.Text;
            Response.Cookies.Add(myCookie);
        }


    }
}