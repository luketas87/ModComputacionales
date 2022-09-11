using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BE;
using Servicios;

namespace DAL
{
    public class DVHDAL
    {
        Encriptador mCripto = new Encriptador();
        public static List<DVH> ObtenerValoresDVH(string pTabla)
        {
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            string pCadena = "select * from " + pTabla;
            mDs = mDAObject.ExecuteDataSet(pCadena);
            List<DVH> mValores = new List<DVH>();
            List<string> mNombreCamposClave = ClavePrimaria(pTabla);
            List<string> mCamposEncriptados = CamposEncriptados(pTabla);
            int cantColumnas = mDs.Tables[0].Columns.Count - 1;
            if (mDs.Tables[0].Rows.Count > 0)
            {
                Encriptador mCripto = new Encriptador();
                List<int> mIndexEncriptado = new List<int>();
                foreach (DataColumn y in mDs.Tables[0].Columns)
                {
                    if (mCamposEncriptados.Contains(y.ColumnName))
                    {
                        mIndexEncriptado.Add(y.Ordinal);
                    }
                }
                foreach (DataRow x in mDs.Tables[0].Rows)
                {
                    DVH mDVH = new DVH();
                    int mValorAcumulado = 0;
                    for (int i = 0; i < cantColumnas; i++)
                    {
                        if (mIndexEncriptado.Contains(i))
                        {
                            mValorAcumulado += ConvertirValor(mCripto.Desencriptar(x[i].ToString()));
                        }
                        else mValorAcumulado += ConvertirValor(x[i].ToString());
                    }
                    mDVH.tabla = pTabla;
                    string NombrePK1 = mNombreCamposClave[0];
                    string NombrePK2;
                    if (mNombreCamposClave.Count == 2)
                    {
                        NombrePK2 = mNombreCamposClave[1];
                        mDVH.clavePrimaria2 = int.Parse(x[NombrePK2].ToString());
                    }
                    mDVH.clavePrimaria = int.Parse(x[NombrePK1].ToString());
                    mDVH.valorDVH = mValorAcumulado;
                    string campoDVH = pTabla + "_dvh";
                    if (x[campoDVH].ToString() != "" & x[campoDVH].ToString() != "0")
                    {
                        mDVH.valorDVHBase = long.Parse(mCripto.Desencriptar(x[campoDVH].ToString()));
                    }
                    mValores.Add(mDVH);
                }
            }
            return mValores;
        }

        public static int ActualizarDVH(string pTabla, DVH mDVH)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            List<string> mNombreCamposClave = ClavePrimaria(pTabla);
            if (mNombreCamposClave.Count == 2)
            {
                pCadenaComando = "update " + pTabla + " set " + pTabla + "_dvh = '" + mDVH.valorDVHEncriptado + "' where " + mNombreCamposClave[0] + " = " + mDVH.clavePrimaria + " and " + mNombreCamposClave[1] + " = " + mDVH.clavePrimaria2;
            }
            else
            {
                pCadenaComando = "update " + pTabla + " set " + pTabla + "_dvh = '" + mDVH.valorDVHEncriptado + "' where " + mNombreCamposClave[0] + " = " + mDVH.clavePrimaria;
            }
            return mDAObject.ExecuteNonQuery(pCadenaComando);
        }

        public static DVH ObtenerValorDVH(string pTabla, int PK)
        {
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            List<string> mNombreCamposClave = ClavePrimaria(pTabla);
            List<string> mCamposEncriptados = CamposEncriptados(pTabla);
            string pCadena = "select * from " + pTabla + " where " + mNombreCamposClave[0] + " = " + PK;
            mDs = mDAObject.ExecuteDataSet(pCadena);
            int cantColumnas = mDs.Tables[0].Columns.Count - 1;
            DVH mDVH = new DVH();
            if (mDs.Tables[0].Rows.Count > 0)
            {
                Encriptador mCripto = new Encriptador();
                List<int> mIndexEncriptado = new List<int>();
                foreach (DataColumn y in mDs.Tables[0].Columns)
                {
                    if (mCamposEncriptados.Contains(y.ColumnName))
                    {
                        mIndexEncriptado.Add(y.Ordinal);
                    }
                }
                DataRow x = mDs.Tables[0].Rows[0];
                int mValorAcumulado = 0;
                for (int i = 0; i < cantColumnas; i++)
                {
                    if (mIndexEncriptado.Contains(i))
                    {
                        mValorAcumulado += ConvertirValor(mCripto.Desencriptar(x[i].ToString()));
                    }
                    else mValorAcumulado += ConvertirValor(x[i].ToString());
                }
                mDVH.tabla = pTabla;
                string NombrePK1 = mNombreCamposClave[0];
                mDVH.clavePrimaria = int.Parse(x[NombrePK1].ToString());
                mDVH.valorDVH = mValorAcumulado;
                string campoDVH = pTabla + "_dvh";
                if (x[campoDVH].ToString() != "" & x[campoDVH].ToString() != "0")
                {
                    mDVH.valorDVHBase = long.Parse(mCripto.Desencriptar(x[campoDVH].ToString()));
                }
            }
            return mDVH;
        }

        public static List<int> ObtenerValorDVHTotal(string pTabla, int PK, int PK2)
        {
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            List<string> mNombreCamposClave = ClavePrimaria(pTabla);
            List<string> mCamposEncriptados = CamposEncriptados(pTabla);
            string pCadena = "select * from " + pTabla + " where " + mNombreCamposClave[0] + " = " + PK + " and " + mNombreCamposClave[1] + " = " + PK2;
            mDs = mDAObject.ExecuteDataSet(pCadena);
            int cantColumnas = mDs.Tables[0].Columns.Count - 1;
            List<int> mValores = new List<int>();
            DVH mDVH = new DVH();
            if (mDs.Tables[0].Rows.Count > 0)
            {
                Encriptador mCripto = new Encriptador();
                List<int> mIndexEncriptado = new List<int>();
                foreach (DataColumn y in mDs.Tables[0].Columns)
                {
                    if (mCamposEncriptados.Contains(y.ColumnName))
                    {
                        mIndexEncriptado.Add(y.Ordinal);
                    }
                }
                DataRow x = mDs.Tables[0].Rows[0];
                int mValorAcumulado = 0;
                for (int i = 0; i < cantColumnas; i++)
                {
                    if (mIndexEncriptado.Contains(i))
                    {
                        mValorAcumulado += ConvertirValor(mCripto.Desencriptar(x[i].ToString()));
                    }
                    else mValorAcumulado += ConvertirValor(x[i].ToString());
                }
                mDVH.tabla = pTabla;
                string NombrePK1 = mNombreCamposClave[0];
                string NombrePK2 = mNombreCamposClave[1];
                mDVH.clavePrimaria = int.Parse(x[NombrePK1].ToString());
                mDVH.clavePrimaria2 = int.Parse(x[NombrePK2].ToString());
                mDVH.valorDVH = mValorAcumulado;
                string campoDVH = pTabla + "_dvh";
                if (x[campoDVH].ToString() != "" & x[campoDVH].ToString() != "0")
                {
                    mDVH.valorDVHBase = long.Parse(mCripto.Desencriptar(x[campoDVH].ToString()));
                }
            }
            return mValores;
        }

        public static DVH ObtenerValorDVH(string pTabla, int PK, int PK2)
        {
            DAO mDAObject = new DAO();
            DataSet mDs = new DataSet();
            List<string> mNombreCamposClave = ClavePrimaria(pTabla);
            List<string> mCamposEncriptados = CamposEncriptados(pTabla);
            string pCadena = "select * from " + pTabla + " where " + mNombreCamposClave[0] + " = " + PK + " and " + mNombreCamposClave[1] + " = " + PK2;
            mDs = mDAObject.ExecuteDataSet(pCadena);
            List<DVH> mValores = new List<DVH>();
            int cantColumnas = mDs.Tables[0].Columns.Count - 1;
            DVH mDVH = new DVH();

            if (mDs.Tables[0].Rows.Count > 0)
            {
                Encriptador mCripto = new Encriptador();
                List<int> mIndexEncriptado = new List<int>();
                foreach (DataColumn y in mDs.Tables[0].Columns)
                {
                    if (mCamposEncriptados.Contains(y.ColumnName))
                    {
                        mIndexEncriptado.Add(y.Ordinal);
                    }
                }
                DataRow x = mDs.Tables[0].Rows[0];
                int mValorAcumulado = 0;
                for (int i = 0; i < cantColumnas; i++)
                {
                    if (mIndexEncriptado.Contains(i))
                    {
                        mValorAcumulado += ConvertirValor(mCripto.Desencriptar(x[i].ToString()));
                    }
                    else mValorAcumulado += ConvertirValor(x[i].ToString());
                }
                mDVH.tabla = pTabla;
                string NombrePK1 = mNombreCamposClave[0];
                string NombrePK2 = mNombreCamposClave[1];
                mDVH.clavePrimaria = int.Parse(x[NombrePK1].ToString());
                mDVH.clavePrimaria2 = int.Parse(x[NombrePK2].ToString());
                mDVH.valorDVH = mValorAcumulado;
                string campoDVH = pTabla + "_dvh";
                if (x[campoDVH].ToString() != "" & x[campoDVH].ToString() != "0")
                {
                    mDVH.valorDVHBase = long.Parse(mCripto.Desencriptar(x[campoDVH].ToString()));
                }
            }
            return mDVH;
        }

        public static List<string> ClavePrimaria(string pTabla)
        {
            List<string> PK = new List<string>();
            if (pTabla == "cliente") PK.Add("cliente_id");
            if (pTabla == "familia_patente") { PK.Add("familia_id"); PK.Add("patente_id"); }
            if (pTabla == "cuenta_usuario_patente") { PK.Add("cuenta_usuario_id"); PK.Add("patente_id"); }
            if (pTabla == "cuenta") PK.Add("cuenta_id");
            if (pTabla == "bitacora") PK.Add("bitacora_id");
            if (pTabla == "cuenta_usuario_familia") { PK.Add("cuenta_usuario_id"); PK.Add("familia_id"); }
            if (pTabla == "cuenta_usuario") PK.Add("cuenta_usuario_id");
            return PK;
        }

        public static List<string> CamposEncriptados(string pTabla)
        {
            List<string> mCampos = new List<string>();
            if (pTabla == "bitacora") mCampos.Add("bitacora_dvh");
            if (pTabla == "bitacora_tipo_movimiento") mCampos.Add("bitacora_tipo_movimiento_desc");
            if (pTabla == "cliente") { mCampos.Add("cliente_dvh"); mCampos.Add("cliente_doc_tipo"); mCampos.Add("cliente_doc_numero"); }
            return mCampos;
        }

        public static int ConvertirValor(string pCadena)
        {
            string textoOriginal = pCadena;
            List<int> valores = new List<int>();
            foreach (char c in textoOriginal)
            {
                int valor = System.Convert.ToInt32(c);
                valores.Add(valor);
            }
            return valores.Sum();
        }
    }
}
