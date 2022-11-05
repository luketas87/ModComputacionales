using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BE;

namespace DAL
{
    public class CuentaUsuarioDAL
    {
        public static int mId;
        public static int ProximoId()
        {
            if (mId == 0)
            {
                DAO mDAObject = new DAO();
                mId = mDAObject.ObtenerId("Cuenta_usuario");
            }
            mId += 1;
            return mId;
        }
        public static int Guardar(CuentaUsuario pCuentaUsuario)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            if (pCuentaUsuario.Cuenta_usuario_id == 0)
            {
                pCuentaUsuario.Cuenta_usuario_id = ProximoId();
                pCadenaComando = "insert into cuenta_usuario(Cuenta_usuario_id, Cuenta_usuario_username, Cuenta_usuario_password, Cuenta_usuario_intentos_login,  cuenta_usuario_activa, cuenta_fecha_alta, cuenta_usuario_email) values (" + pCuentaUsuario.Cuenta_usuario_id + ", '" + pCuentaUsuario.Cuenta_usuario_username + "', '" + pCuentaUsuario.Cuenta_usuario_password + "', " + pCuentaUsuario.Cuenta_usuario_intentos_login + ", " + pCuentaUsuario.cuenta_usuario_activa + ", '" + pCuentaUsuario.GetFechaAltaToString() + "', '" + pCuentaUsuario.Cuenta_usuario_email + "')";
            }
            else pCadenaComando = "update Cuenta_Usuario set Cuenta_usuario_username = '" + pCuentaUsuario.Cuenta_usuario_username + "', Cuenta_usuario_password = '" + pCuentaUsuario.Cuenta_usuario_password + "', Cuenta_usuario_intentos_login = " + pCuentaUsuario.Cuenta_usuario_intentos_login + ", Cuenta_fecha_alta = '" + pCuentaUsuario.GetFechaAltaToString() + "', cuenta_usuario_activa = " + pCuentaUsuario.cuenta_usuario_activa +", cuenta_usuario_email = '"+pCuentaUsuario.Cuenta_usuario_email +"' where cuenta_usuario_id = " + pCuentaUsuario.Cuenta_usuario_id;
            return mDAObject.ExecuteNonQuery(pCadenaComando);
        }
        public static int Eliminar(CuentaUsuario pCuentaUsuario)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando = "update Cuenta_Usuario set cuenta_usuario_activa = 0 where cuenta_usuario_id = " + pCuentaUsuario.Cuenta_usuario_id;
            return mDAObject.ExecuteNonQuery(pCadenaComando);
        }

        public static CuentaUsuario Obtener(int pId)
        {
            DAO mDAObject = new DAO();
            DataSet mDs = mDAObject.ExecuteDataSet("select Cuenta_usuario_id, Cuenta_usuario_username, Cuenta_usuario_password, Cuenta_usuario_intentos_login,  cuenta_usuario_activa, cuenta_fecha_alta, year(Cuenta_fecha_alta) as anio, month(Cuenta_fecha_alta) as mes, day(Cuenta_fecha_alta) as dia from cuenta_usuario where cuenta_usuario_activa = 1 and  Cuenta_usuario_id = " + pId);
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                CuentaUsuario mCuentaUsuario = new CuentaUsuario(pId);
                ValorizarEntidad(mCuentaUsuario, mDs.Tables[0].Rows[0]);
                return mCuentaUsuario;
            }
            else return null;
        }

        public static CuentaUsuario Obtener(string pUsername)
        {
            DAO mDAObject = new DAO();
            DataSet mDs = mDAObject.ExecuteDataSet("select Cuenta_usuario_id, Cuenta_usuario_username, Cuenta_usuario_email, Cuenta_usuario_password, Cuenta_usuario_intentos_login,  cuenta_usuario_activa, cuenta_fecha_alta, year(Cuenta_fecha_alta) as anio, month(Cuenta_fecha_alta) as mes, day(Cuenta_fecha_alta) as dia from cuenta_usuario where cuenta_usuario_username = '" + pUsername + "' ");
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                int pId = int.Parse(mDs.Tables[0].Rows[0]["cuenta_usuario_id"].ToString());
                CuentaUsuario mCuentaUsuario = new CuentaUsuario(pId);
                mCuentaUsuario.cuenta_usuario_activa = int.Parse(mDs.Tables[0].Rows[0]["cuenta_usuario_activa"].ToString());
                ValorizarEntidad(mCuentaUsuario, mDs.Tables[0].Rows[0]);
                return mCuentaUsuario;
            }
            else return null;
        }

        public static void ValorizarEntidad(CuentaUsuario pCuentaUsuario, DataRow pDr)
        {
            pCuentaUsuario.Cuenta_usuario_id = int.Parse(pDr["Cuenta_usuario_id"].ToString());
            pCuentaUsuario.Cuenta_usuario_username = pDr["Cuenta_usuario_username"].ToString();
            pCuentaUsuario.Cuenta_usuario_password = pDr["Cuenta_usuario_password"].ToString();
            pCuentaUsuario.Cuenta_usuario_email = pDr["Cuenta_usuario_email"].ToString();
            pCuentaUsuario.Cuenta_usuario_intentos_login = int.Parse(pDr["Cuenta_usuario_intentos_login"].ToString());
            pCuentaUsuario.SetFechaAlta(int.Parse(pDr["dia"].ToString()), int.Parse(pDr["mes"].ToString()), int.Parse(pDr["anio"].ToString()));

        }

        public static List<CuentaUsuario> Listar()
        {
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            List<CuentaUsuario> mCuentaUsuarios = new List<CuentaUsuario>();
            mDs = mDAObject.ExecuteDataSet("select Cuenta_usuario_id, Cuenta_usuario_username, Cuenta_usuario_email, Cuenta_usuario_password, Cuenta_usuario_intentos_login,  cuenta_usuario_activa, cuenta_fecha_alta, year(Cuenta_fecha_alta) as anio, month(Cuenta_fecha_alta) as mes, day(Cuenta_fecha_alta) as dia from cuenta_usuario where cuenta_usuario_activa = 1");

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    CuentaUsuario mCuentaUsuario = new CuentaUsuario(int.Parse(mDr["Cuenta_usuario_id"].ToString()));
                    ValorizarEntidad(mCuentaUsuario, mDr);
                    mCuentaUsuarios.Add(mCuentaUsuario);
                }
            }
            return mCuentaUsuarios;
        }

        public static List<Patente> ObtenerPatentes(CuentaUsuario pCuentaUsuario)
        {
            List<Patente> mPatentes = new List<Patente>();
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            mDs = mDAObject.ExecuteDataSet("select t1.patente_id, t2.patente_nombre from cuenta_usuario_patente t1 left join patente t2 on t1.patente_id = t2.patente_id where cuenta_usuario_id = " + pCuentaUsuario.Cuenta_usuario_id);
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Patente mPatente = new Patente(int.Parse(mDr["patente_id"].ToString()));
                    PatenteDAL.ValorizarEntidad(mPatente, mDr);
                    mPatentes.Add(mPatente);
                }

            }
            return mPatentes;
        }
        public static List<Familia> ObtenerFamilias(CuentaUsuario pCuentaUsuario)
        {
            List<Familia> mFamilias = new List<Familia>();
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            mDs = mDAObject.ExecuteDataSet("select t1.familia_id, t2.familia_nombre from cuenta_usuario_familia t1 left join familia t2 on t1.familia_id = t2.familia_id where cuenta_usuario_id = " + pCuentaUsuario.Cuenta_usuario_id);
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Familia mFamilia = new Familia(int.Parse(mDr["familia_id"].ToString()));
                    FamiliaDAL.ValorizarEntidad(mFamilia, mDr);
                    mFamilias.Add(mFamilia);
                }

            }
            return mFamilias;
        }

        public static int AgregarPatente(Patente pPatente, CuentaUsuario pCuentaUsuario)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            pCadenaComando = "insert into cuenta_usuario_patente (cuenta_usuario_id, patente_id) values (" + pCuentaUsuario.Cuenta_usuario_id + ", " + pPatente.patente_id + ")";
            return mDAObject.ExecuteNonQuery(pCadenaComando);
        }

        public static int EliminarPatente(Patente pPatente, CuentaUsuario pCuentaUsuario)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            pCadenaComando = "delete from cuenta_usuario_patente where cuenta_usuario_id = " + pCuentaUsuario.Cuenta_usuario_id + " and patente_id = " + pPatente.patente_id;
            return mDAObject.ExecuteNonQuery(pCadenaComando);
        }
        public static int AgregarFamilia(Familia pFamilia, CuentaUsuario pCuentaUsuario)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            pCadenaComando = "insert into cuenta_usuario_familia(cuenta_usuario_id, familia_id) values (" + pCuentaUsuario.Cuenta_usuario_id + ", " + pFamilia.familia_id + ")";
            return mDAObject.ExecuteNonQuery(pCadenaComando);
        }

        public static int EliminarFamilia(Familia pFamilia, CuentaUsuario pCuentaUsuario)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            pCadenaComando = "delete from cuenta_usuario_familia where cuenta_usuario_id = " + pCuentaUsuario.Cuenta_usuario_id + " and familia_id = " + pFamilia.familia_id;
            return mDAObject.ExecuteNonQuery(pCadenaComando);
        }

        public static List<CuentaUsuario> ObtenerUsuarios(Familia pFamilia)
        {
            DAO mDAObject = new DAO();
            List<CuentaUsuario> mCuentasUsuario = new List<CuentaUsuario>();
            DataSet mDs = mDAObject.ExecuteDataSet("select t2.cuenta_usuario_id, t2.cuenta_usuario_username, t2.cuenta_usuario_password, t2.Cuenta_usuario_email, t2.cuenta_usuario_intentos_login, year(t2.Cuenta_fecha_alta) as anio, month(t2.Cuenta_fecha_alta) as mes, day(t2.Cuenta_fecha_alta) as dia from cuenta_usuario_familia t1 inner join cuenta_usuario t2 on t1.cuenta_usuario_id = t2.cuenta_usuario_id where t1.familia_id = " + pFamilia.familia_id);
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow x in mDs.Tables[0].Rows)
                {
                    int pId = int.Parse(mDs.Tables[0].Rows[0]["cuenta_usuario_id"].ToString());
                    CuentaUsuario mCuentaUsuario = new CuentaUsuario(pId);
                    ValorizarEntidad(mCuentaUsuario, mDs.Tables[0].Rows[0]);
                    mCuentasUsuario.Add(mCuentaUsuario);
                }
                return mCuentasUsuario;
            }
            else return null;
        }

        public static bool ValidarEmail(string pCadena)
        {
            DAO mDAObject = new DAO();
            CuentaUsuario mCuentasUsuario = new CuentaUsuario();
            DataSet mDs = mDAObject.ExecuteDataSet("select cuenta_usuario_id from cuenta_usuario where cuenta_usuario_email = '" + pCadena + "' ");
            return (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0);
        }
    }
}
