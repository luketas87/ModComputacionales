using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;

namespace GlobalLogistics
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSGlobalLogistics : System.Web.Services.WebService
    {

        [WebMethod]
        public int ObtenerStock(int id)
        {
            SqlConnection mCon = new SqlConnection(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);
            mCon.Open();
            SqlCommand mCom = new SqlCommand("select producto_stock from producto where producto_id = " + id, mCon);
            int resultado = (int)mCom.ExecuteScalar();
            mCon.Close();
            return resultado;
        }
    }
}
