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
        protected void Page_Load(object sender, EventArgs e)
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
            //int bUsuario = int.Parse(TxtUsuario.Text);
            int bNivel = int.Parse(TxtNivel.Text);

            GridView1.DataSource = mBitacora.Where(x => x.bitacora_criticidad == bNivel);
            //var datagrid = from bitacora in this.mBitacora
            //               where bitacora.cuenta_usuario_id == bUsuario && bitacora.bitacora_criticidad == bNivel 
            //               select bitacora; 
            //this.GridView1.DataSource = null;
            //GridView1.DataSource = datagrid;
            GridView1.DataBind();
        }


    }
}