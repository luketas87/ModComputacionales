using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using System.Data;

namespace DAL
{
    public class FamiliaDAL
    {

        public static int mId;

        public static int ProximoId()
        {
            if (mId == 0)
            {
                DAO mDAObject = new DAO();
                mId = mDAObject.ObtenerId("Familia");
            }
            mId += 1;
            return mId;
        }

        public static void ValorizarEntidad(Familia pFamilia, DataRow pDr)
        {
            pFamilia.familia_id = int.Parse(pDr["Familia_id"].ToString());
            pFamilia.familia_nombre = pDr["familia_nombre"].ToString();
        }
        public static List<Familia> Listar()
        {
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            List<Familia> mFamilias = new List<Familia>();
            mDs = mDAObject.ExecuteDataSet("select Familia_id, familia_nombre from Familia");

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Familia mFamilia = new Familia(int.Parse(mDr["Familia_id"].ToString()));
                    ValorizarEntidad(mFamilia, mDr);
                    mFamilias.Add(mFamilia);
                }
            }
            return mFamilias;
        }

        public static Familia Obtener(int pId)
        {
            DAO mDAObject = new DAO();
            DataSet mDs = mDAObject.ExecuteDataSet("select Familia_id, Familia_nombre from Familia where Familia_id = " + pId);
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                Familia mFamilia = new Familia(pId);
                ValorizarEntidad(mFamilia, mDs.Tables[0].Rows[0]);
                return mFamilia;
            }
            else return null;
        }
        public static Familia Obtener(string pNombre)
        {
            DAO mDAObject = new DAO();
            DataSet mDs = mDAObject.ExecuteDataSet("select Familia_id, Familia_nombre from Familia where Familia_nombre = '" + pNombre + "'");
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                int pId = int.Parse(mDs.Tables[0].Rows[0]["familia_id"].ToString());
                Familia mFamilia = new Familia(pId);
                ValorizarEntidad(mFamilia, mDs.Tables[0].Rows[0]);
                return mFamilia;
            }
            else return null;
        }




        public static int Eliminar(Familia pFamilia)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando = "delete from familia where familia_id = " + pFamilia.familia_id;
            return mDAObject.ExecuteNonQuery(pCadenaComando);
        }

        public static List<Patente> ObtenerPatentes(Familia pFamilia)
        {
            List<Patente> mPatentes = new List<Patente>();
            DAO mDAObject = new DAO();
            DataSet mDs = mDAObject.ExecuteDataSet("select patente_id from Familia_patente where Familia_id = " + pFamilia.familia_id);
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Patente mPatente = PatenteDAL.Obtener(int.Parse(mDr["patente_id"].ToString()));
                    mPatentes.Add(mPatente);
                }
                return mPatentes;
            }
            else return null;
        }
        public static int Guardar(Familia pFamilia)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            if (pFamilia.familia_id == 0)
            {
                pFamilia.familia_id = ProximoId();
                pCadenaComando = "insert into familia(familia_id, familia_nombre) values (" + pFamilia.familia_id + ", '" + pFamilia.familia_nombre + "')";
            }
            else pCadenaComando = "update familia set familia_nombre = '" + pFamilia.familia_nombre + "' where familia_id = " + pFamilia.familia_id;
            return mDAObject.ExecuteNonQuery(pCadenaComando);
        }
        public static int AgregarPatente(Familia pFamilia, Patente pPatente)
        {
            {
                DAO mDAObject = new DAO();
                string pCadenaComando;
                pCadenaComando = "insert into familia_patente(familia_id, patente_id, familia_patente_dvh) values (" + pFamilia.familia_id + ", " + pPatente.patente_id + ", 0)";
                return mDAObject.ExecuteNonQuery(pCadenaComando);
            }
        }
        public static int EliminarPatente(Familia pFamilia, Patente pPatente)
        {
            {
                DAO mDAObject = new DAO();
                string pCadenaComando;
                pCadenaComando = "delete from familia_patente where familia_id = " + pFamilia.familia_id + " and patente_id = " + pPatente.patente_id;
                return mDAObject.ExecuteNonQuery(pCadenaComando);
            }
        }
    }
}
