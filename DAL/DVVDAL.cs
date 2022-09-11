using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BE;


namespace DAL
{
    public class DVVDAL
    {
        public static DVV Obtener(string pTabla)
        {
            Encriptador mCripto = new Encriptador();
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            string pCadena = "select * from DVV where tabla = '" + pTabla + "'";
            mDs = mDAObject.ExecuteDataSet(pCadena);
            DVV mDVV = new DVV();
            if (mDs.Tables[0].Rows.Count > 0)
            {
                mDVV.tabla = pTabla;
                DataRow mDr = mDs.Tables[0].Rows[0];
                mDVV.valorDVVBase = int.Parse(mCripto.Desencriptar(mDr["dvv_valor"].ToString()));
            }
            else { mDVV.tabla = pTabla; }
            return mDVV;
        }

        public static List<DVV> Obtener()
        {
            Encriptador mCripto = new Encriptador();
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            string pCadena = "select * from DVV";
            mDs = mDAObject.ExecuteDataSet(pCadena);
            List<DVV> mValores = new List<DVV>();
            if (mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {

                    DVV mDVV = new DVV();
                    mDVV.tabla = mDr["tabla"].ToString();
                    mDVV.valorDVVBase = long.Parse(mCripto.Desencriptar(mDr["dvv_valor"].ToString()));
                    mValores.Add(mDVV);
                }
            }
            return mValores;
        }

        public static long CalcularDVV(string pTabla)
        {
            Encriptador mCripto = new Encriptador();
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            string mNombreCampo = pTabla + "_dvh";
            string pCadena = "select " + mNombreCampo + " from " + pTabla;
            mDs = mDAObject.ExecuteDataSet(pCadena);
            string mNombre = pTabla + "_dvh";
            long mSuma = 0;
            if (mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow x in mDs.Tables[0].Rows)
                {
                    if (x[0].ToString() != "0")
                    {
                        string mValorEncriptado = x[0].ToString();
                        string mValorDesencriptado = mCripto.Desencriptar(mValorEncriptado);
                        long mValorFinal = long.Parse(mValorDesencriptado);
                        mSuma += mValorFinal;
                    }
                }
            }
            return mSuma;
        }

        public static int ActualizarDVV(DVV pDVV)
        {
            Encriptador mCripto = new Encriptador();
            DAO mDAObject = new DAO();
            string pCadenaComando;
            DVV mDVV = Obtener(pDVV.tabla);
            if (pDVV.valorDVVBase !=0)
            {
                 pCadenaComando = "update DVV set dvv_valor = '" + mCripto.EncriptarReversible(pDVV.valorDVV.ToString()) + "' where tabla = '" + pDVV.tabla + "'";
            }
            else
            {
                 pCadenaComando = "insert into DVV(tabla, dvv_valor) values ('" + pDVV.tabla + "', '" + mCripto.EncriptarReversible(pDVV.valorDVV.ToString()) + "')";
            }
            return mDAObject.ExecuteNonQuery(pCadenaComando);
        }
    }
}

