using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DAL
{
    public class DAO
    {
        public SqlConnection mCon = new SqlConnection("Data Source=.;Initial Catalog=GlobalLogistics;Integrated Security=True");

        public DataSet ExecuteDataSet(string pCadenaComando)
        {
            DataSet mDs = new DataSet();
            SqlDataAdapter mDa = new SqlDataAdapter(pCadenaComando, mCon);
            mDa.Fill(mDs);
            if (mCon.State != ConnectionState.Closed) mCon.Close();
            return mDs;
        }

        public int ExecuteNonQuery(string pCommandText)
        {
            try
            {
                SqlCommand mCom = new SqlCommand(pCommandText, this.mCon);
                this.mCon.Open();
                int resultado = mCom.ExecuteNonQuery();
                SqlConnection mCon = new SqlConnection("Data Source=.;Initial Catalog=GlobalLogistics;Integrated Security=True");
                return resultado;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }

        public int ExecuteNonQuery(string pCommandText, string pDataBase)
        {
            try
            {
                SqlCommand mCom = new SqlCommand(pCommandText, mCon);
                mCon.Open();
                mCon.ChangeDatabase(pDataBase);
                return mCom.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }

        public int ObtenerId(string pTabla)
        {
            try
            {
                SqlCommand mCom = new SqlCommand("SELECT ISNULL(MAX(" + pTabla + "_Id),0) FROM " + pTabla, mCon);
                mCon.Open();
                return int.Parse(mCom.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }
    }
}
