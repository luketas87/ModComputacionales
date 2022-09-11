using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace GlobalLogistics
{
    public partial class BackupRestore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {

                BackupeadorBL.RealizarBackup(txtNombre.Text, txtRuta.Text, int.Parse(txtVolumenes.Text));
                string errormsg = "<script>alert('Backup generado correctamente') </script>";
                Response.Write(errormsg);
            }
            catch (Exception ex)
            {
                string errormsg = "<script>alert('" + ex.Message + "') </script>";
                Response.Write(errormsg);
            }
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                BackupeadorBL.RealizarRestore(txtNombreRestore.Text, txtRutaRestore.Text, int.Parse(txtVolumenesRestore.Text));
                string errormsg = "<script>alert('Backup generado correctamente') </script>";
                Response.Write(errormsg);
            }
            catch (Exception ex)
            {
                string errormsg = "<script>alert('" + ex.Message + "') </script>";
                Response.Write(errormsg);
            }
        }
    }
}