using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using System.Data;


namespace DAL
{
    public class PatenteDAL
    {
        public static int mId;

        public static int ProximoId()
        {
            if (mId == 0)
            {
                DAO mDAObject = new DAO();
                mId = mDAObject.ObtenerId("Patente");
            }
            mId += 1;
            return mId;
        }

        public static void ValorizarEntidad(Patente pPatente, DataRow pDr)
        {
            pPatente.patente_id = int.Parse(pDr["patente_id"].ToString());
            pPatente.patente_nombre = pDr["patente_nombre"].ToString();
        }
        public static List<Patente> Listar()
        {
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            List<Patente> mPatentes = new List<Patente>();
            mDs = mDAObject.ExecuteDataSet("select patente_id, patente_nombre from patente");

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Patente mPatente = new Patente(int.Parse(mDr["patente_id"].ToString()));
                    ValorizarEntidad(mPatente, mDr);
                    mPatentes.Add(mPatente);
                }
            }
            return mPatentes;
        }

        public static Patente Obtener(int pId)
        {
            DAO mDAObject = new DAO();
            DataSet mDs = mDAObject.ExecuteDataSet("select patente_id, patente_nombre from patente where patente_id = " + pId);
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                Patente mPatente = new Patente(pId);
                ValorizarEntidad(mPatente, mDs.Tables[0].Rows[0]);
                return mPatente;
            }
            else return null;
        }
        public static Patente Obtener(string pNombre)
        {
            DAO mDAObject = new DAO();
            DataSet mDs = mDAObject.ExecuteDataSet("select patente_id, patente_nombre from patente where patente_nombre = '" + pNombre + "'");
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                int pId = int.Parse(mDs.Tables[0].Rows[0]["patente_id"].ToString());
                Patente mPatente = new Patente(pId);
                ValorizarEntidad(mPatente, mDs.Tables[0].Rows[0]);
                return mPatente;
            }
            else return null;
        }

        public static List<Patente> ListarExcepto(CuentaUsuario pCuentaUsuario)
        {
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            List<Patente> mPatentes = new List<Patente>();
            mDs = mDAObject.ExecuteDataSet("select t1.patente_id, t1.patente_nombre from patente t1 left join cuenta_usuario_patente t2 on t1.patente_id = t2.patente_id and t2.cuenta_usuario_id <>" + pCuentaUsuario.Cuenta_usuario_id + " where t2.cuenta_usuario_id is null ");

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Patente mPatente = new Patente(int.Parse(mDr["patente_id"].ToString()));
                    ValorizarEntidad(mPatente, mDr);
                    mPatentes.Add(mPatente);
                }
            }
            return mPatentes;
        }
        public static int Guardar(Patente pPatente)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            pPatente.patente_id = ProximoId();
            pCadenaComando = "insert into patente(patente_id, patente_nombre) values (" + pPatente.patente_id + ", '" + pPatente.patente_nombre + "')";

            return mDAObject.ExecuteNonQuery(pCadenaComando);
        }
        public static List<CuentaUsuario> ListarUsuarios(Patente pPatente)
        {
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            List<CuentaUsuario> mCuentasUsuario = new List<CuentaUsuario>();
            string pCadenaComando = "select t2.cuenta_usuario_id, t2.cuenta_usuario_username, t2.cuenta_usuario_password, t2.cuenta_usuario_intentos_login, t2.cuenta_cliente, year(t2.Cuenta_fecha_alta) as anio, month(t2.Cuenta_fecha_alta) as mes, day(t2.Cuenta_fecha_alta) as dia, t2.cuenta_usuario_activa, t2.cuenta_usuario_empleado_id, t2.cuenta_usuario_cliente_id from cuenta_usuario_patente t1 left join cuenta_usuario t2 on t1.cuenta_usuario_id = t2.cuenta_usuario_id where t2.cuenta_usuario_activa = 1 and t1.patente_id = " + pPatente.patente_id;
            mDs = mDAObject.ExecuteDataSet(pCadenaComando);
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    CuentaUsuario mCuentaUsuario = new CuentaUsuario(int.Parse(mDr["cuenta_usuario_id"].ToString()));
                    CuentaUsuarioDAL.ValorizarEntidad(mCuentaUsuario, mDr);
                    mCuentasUsuario.Add(mCuentaUsuario);
                }
            }
            return mCuentasUsuario;
        }
    }
}
