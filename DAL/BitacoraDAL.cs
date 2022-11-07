using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using System.Data;

namespace DAL
{
    public class BitacoraDAL
    {
        public static int mId;

        public static int ProximoId()
        {
            if (mId == 0)
            {
                DAO mDAObject = new DAO();
                mId = mDAObject.ObtenerId("bitacora");
            }
            mId += 1;
            return mId;
        }
        public static int Guardar(Bitacora pBitacora)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            pBitacora.bitacora_id = ProximoId();
            pCadenaComando = "insert into bitacora(bitacora_id, cuenta_usuario_id, bitacora_criticidad, bitacora_transaccion_id, bitacora_fecha, bitacora_hora, bitacora_DVH) values (" + pBitacora.bitacora_id + ", " + pBitacora.cuenta_usuario_id + ", " + pBitacora.bitacora_criticidad + ", " + pBitacora.bitacora_transaccion_id + ", '" + pBitacora.bitacora_fecha.ToString("yyyy-MM-dd") + "', '" + pBitacora.bitacora_hora.ToString()/*(@"hh\:mm\:ss")*/ + "', 0)";
            return mDAObject.ExecuteNonQuery(pCadenaComando);
        }

        public static void ValorizarEntidad(Bitacora pBitacora, DataRow pDr)
        {
            pBitacora.bitacora_id = int.Parse(pDr["bitacora_id"].ToString());
            pBitacora.cuenta_usuario_id = int.Parse(pDr["cuenta_usuario_id"].ToString());
            pBitacora.bitacora_criticidad = int.Parse(pDr["bitacora_criticidad"].ToString());
            pBitacora.bitacora_transaccion_id = int.Parse(pDr["bitacora_transaccion_id"].ToString());
            pBitacora.bitacora_transaccion = pDr["bitacora_transaccion_desc"].ToString();
            pBitacora.bitacora_hora = TimeSpan.Parse(pDr["bitacora_hora"].ToString());
            pBitacora.bitacora_fecha = DateTime.Parse(pDr["bitacora_fecha"].ToString());

        }

        public static List<Bitacora> Listar()
        {
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            List<Bitacora> mRegistros = new List<Bitacora>();
            mDs = mDAObject.ExecuteDataSet("Select B.bitacora_id, CU.cuenta_usuario_id, bitacora_criticidad, B.bitacora_transaccion_id ,BTM.bitacora_transaccion_desc, B.bitacora_fecha, B.bitacora_hora from bitacora B left join cuenta_usuario CU on B.cuenta_usuario_id = CU.cuenta_usuario_id left join bitacora_tipo_movimiento BTM on B.bitacora_transaccion_id = BTM.bitacora_transaccion_id ");

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Bitacora mBitacora = new Bitacora(int.Parse(mDr["bitacora_id"].ToString()));

                    ValorizarEntidad(mBitacora, mDr);
                    mRegistros.Add(mBitacora);
                }
            }
            return mRegistros;
        }

        public static Bitacora Obtener(int pId)
        {
            DAO mDAObject = new DAO();
            DataSet mDs = mDAObject.ExecuteDataSet("select B.bitacora_id, bitacora_criticidad, BTM.bitacora_transaccion_desc, B.bitacora_fecha, B.bitacora_hora from bitacora B left join cuenta_usuario CU on B.cuenta_usuario_id = CU.cuenta_usuario_id left join bitacora_tipo_movimiento BTM on B.bitacora_transaccion_id = BTM.bitacora_transaccion_id  where bitacora_id = " + pId);
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                Bitacora mBitacora = new Bitacora(pId);
                ValorizarEntidad(mBitacora, mDs.Tables[0].Rows[0]);
                return mBitacora;
            }
            else return null;
        }

        public static List<Bitacora> ListarRango(DateTime pFechaDesde, DateTime pFechaHasta)
        {
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            List<Bitacora> mRegistros = new List<Bitacora>();
            mDs = mDAObject.ExecuteDataSet("select B.bitacora_id, bitacora_criticidad, BTM.bitacora_transaccion_desc, B.bitacora_fecha, B.bitacora_hora from bitacora B left join cuenta_usuario CU on B.cuenta_usuario_id = CU.cuenta_usuario_id left join bitacora_tipo_movimiento BTM on B.bitacora_transaccion_id = BTM.bitacora_transaccion_id  where bitacora_fecha between '" + pFechaDesde.ToString("yyyy-MM-dd") + "' and '" + pFechaHasta.ToString("yyyy-MM-dd") + "'");

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Bitacora mBitacora = new Bitacora(int.Parse(mDr["bitacora_id"].ToString()));
                    ValorizarEntidad(mBitacora, mDr);
                    mRegistros.Add(mBitacora);
                }
            }
            return mRegistros;
        }

        public static List<string> TiposMovimiento()
        {
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            List<String> mTipos = new List<string>();
            mDs = mDAObject.ExecuteDataSet("select bitacora_transaccion_desc from bitacora_tipo_movimiento");
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    string mTipo = mDr["bitacora_transaccion_desc"].ToString();
                    mTipos.Add(mTipo);
                }
            }
            return mTipos;
        }
    }
}
