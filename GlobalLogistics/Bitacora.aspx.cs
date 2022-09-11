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
    }
}