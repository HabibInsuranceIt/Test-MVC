using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;

namespace TestMvcApp.Models
{
    public class DBHelper
    {
        
       
      
        protected OracleConnection GetConnection()
        {
            return new OracleConnection(ConfigurationManager.AppSettings["connString"]);
        }


       
        public DbActionResult SaveChanges(string Query, CommandType Type, OracleParameter[] parameter)
        {
            var message = 0;
            var dbar = new DbActionResult();
            try
            {
                OracleConnection con = GetConnection();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = Type;
                    cmd.CommandText = Query;
                    cmd.Parameters.AddRange(parameter);
                    con.Open();
                    message = cmd.ExecuteNonQuery();
                    con.Close();
                }
                dbar.Action = true;
                dbar.Message = message.ToString();
                return dbar;
            }
            catch (Exception ex)
            {
                dbar.Action = false;
                dbar.ErrorMessage = ex.Message;
                return dbar;
            }
        }

        public  DataTable ExecuteQueryData(string sPName, CommandType type)
        {
            DataTable dt = new DataTable();
            OracleConnection con = GetConnection();
            OracleCommand cmd = new OracleCommand();
            OracleDataAdapter da = new OracleDataAdapter(cmd);

            cmd.Connection = con;
            cmd.CommandType = type;
            cmd.CommandText = sPName;
            con.Open();
            da.Fill(dt);
            con.Close();

            return dt;
        }

        public DbActionResult SaveChangeswithTransaction(string Query, CommandType Type, OracleParameter[] parameter)
        {
            var dbar = new DbActionResult();
            OracleTransaction trans = null;
            try
            {
                OracleConnection con = GetConnection();
                trans = con.BeginTransaction();

                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = Type;
                    cmd.Transaction = trans;
                    cmd.CommandText = Query;
                    cmd.Parameters.AddRange(parameter);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                dbar.Action = true;
                trans.Commit();
                return dbar;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                dbar.Action = false;
                dbar.ErrorMessage = ex.Message;
                return dbar;
            }
        }

        public DataTable BindGrid(string Query, CommandType Type, OracleParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                OracleConnection con = GetConnection();
                OracleCommand cmd = new OracleCommand();
                OracleDataAdapter adp = new OracleDataAdapter(cmd);

                cmd.Connection = con;
                cmd.CommandType = Type;
                cmd.CommandText = Query;
                cmd.Parameters.AddRange(parameter);
                con.Open();
                adp.Fill(ds);
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds.Tables[0];
        }

        public bool getDataProcedureDatatable(OracleCommand cmd, DataTable dt) //all data from a dataset
        {

            OracleConnection con = GetConnection();
            cmd.Connection = con;
            OracleDataAdapter adp = new OracleDataAdapter(cmd);
            con.Open();
            adp.Fill(dt);
            con.Close();
            return true;
        }
        public DataSet ExecuteDataset(string Query, CommandType Type, OracleParameter[] parameter)
        {
            DataSet ds = new DataSet();
            OracleCommand cmd = null;
            OracleDataAdapter adp = null;

            try
            {
                OracleConnection con = GetConnection();
                cmd = new OracleCommand();
                adp = new OracleDataAdapter(cmd);

                cmd.Connection = con;
                cmd.CommandType = Type;
                cmd.CommandText = Query;
                cmd.Parameters.AddRange(parameter);
                con.Open();
                adp.Fill(ds);
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                adp.Dispose();
                cmd.Dispose();
            }
            return ds;
        }

        public DbActionResult GetColumn(string Query, CommandType Type, OracleParameter[] parameter)
        {
            var dbar = new DbActionResult();
            try
            {
                OracleConnection con = GetConnection();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = Type;
                    cmd.CommandText = Query;
                    cmd.Parameters.AddRange(parameter);
                    con.Open();
                    dbar.Value = cmd.ExecuteScalar();
                    con.Close();
                }
                dbar.Action = true;
            }
            catch (Exception ex)
            {
                dbar.ErrorMessage = ex.Message;
            }
            return dbar;
        }

        public int Duplicate(string Query, CommandType Type, OracleParameter[] parameter)
        {
            int count = 0;
            try
            {
                OracleConnection con = GetConnection();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = Type;
                    cmd.CommandText = Query;
                    cmd.Parameters.AddRange(parameter);
                    con.Open();
                    count = int.Parse(cmd.ExecuteScalar().ToString());
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }

        public void UpdateChanges(string Query, CommandType Type, OracleParameter[] parameter)
        {
            try
            {
                OracleConnection con = GetConnection();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = Type;
                    cmd.CommandText = Query;
                    cmd.Parameters.AddRange(parameter);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
    }
}