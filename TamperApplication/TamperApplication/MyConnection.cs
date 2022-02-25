using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Collections.ObjectModel;
using Sha2;
using System.Security.Cryptography;
using System.Text;

namespace TamperApplication
{
    public class MyConnection
    {
        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlConnection contemp = null;
        MySqlDataAdapter adp = null;
        public MyConnection()
        {
            con = new MySqlConnection("server=localhost;user id=root;database=forensicdata;password=7777;port=3306;");
            con.Open();
        }
        public DataTable GetPoliceStation()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select * from policestationmaster");
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public DataTable GetCrime(int PoliceStationId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select * from crimemaster where PSId={0} and (Status='Pending' or Status='Process')", PoliceStationId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public DataTable GetFSReport(string TableName)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select * from {0} where LogDate<>'NA' order by SlNo desc", TableName);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string TamperData(int SlNo,string TableName)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sqlcd = string.Format("Select * from {0} where SlNo={1}",TableName, SlNo);
            cmd.CommandText = sqlcd;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            string logdate = DateTime.Now.ToString();
            string hashvalue = ShaKeyGeneration(tab.Rows[0]["PSId"].ToString(),tab.Rows[0]["CrimeId"].ToString(),tab.Rows[0]["FSId"].ToString(), logdate);
            
            string sqlulog = string.Format("update {0} set FSHV='{1}' where SlNo={2}", TableName, hashvalue, SlNo - 1);
            cmd.CommandText = sqlulog;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public string ShaKeyGeneration(string PSId, string CId,string FSId,string LogDate)
        {
            try
            {
                string data = PSId + "," + CId + "," + FSId + "," + LogDate;
                string strFilePath = HttpContext.Current.Server.MapPath("data.txt");
                if (File.Exists(strFilePath))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete(strFilePath);
                }
                FileStream fp = new FileStream(strFilePath, FileMode.Create);
                StreamWriter wr = new StreamWriter(fp);
                wr.WriteLine(data);
                wr.Close();
                fp.Close();

                ReadOnlyCollection<byte> hash = Sha384mManaged.HashFile(File.OpenRead(strFilePath));

                return Util.ArrayToString(hash);
            }
            catch
            {
                return null;
            }
        }
        public string DTamperData(int SlNo, string TableName)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sqlcd = string.Format("Select * from {0} where SlNo={1}", TableName, SlNo);
            cmd.CommandText = sqlcd;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            string logdate = DateTime.Now.ToString();
            string hashvalue = ShaKeyGeneration(tab.Rows[0]["PSId"].ToString(), tab.Rows[0]["CrimeId"].ToString(), tab.Rows[0]["DId"].ToString(), logdate);

            string sqlulog = string.Format("update {0} set DHV='{1}' where SlNo={2}", TableName, hashvalue, SlNo - 1);
            cmd.CommandText = sqlulog;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public string ShaKeyGeneration(string CId, string LogDate)
        {
            try
            {
                string data = CId + "," + LogDate;
                string strFilePath = HttpContext.Current.Server.MapPath("data.txt");
                if (File.Exists(strFilePath))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete(strFilePath);
                }
                FileStream fp = new FileStream(strFilePath, FileMode.Create);
                StreamWriter wr = new StreamWriter(fp);
                wr.WriteLine(data);
                wr.Close();
                fp.Close();

                ReadOnlyCollection<byte> hash = Sha384mManaged.HashFile(File.OpenRead(strFilePath));

                return Util.ArrayToString(hash);
            }
            catch
            {
                return null;
            }
        }
        public string CrimeTamperData(int SlNo, string TableName)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sqlcd = string.Format("Select * from {0} where SlNo={1}", TableName, SlNo);
            cmd.CommandText = sqlcd;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            string logdate = DateTime.Now.ToString();
            string hashvalue = ShaKeyGeneration(tab.Rows[0]["CrimeId"].ToString(), logdate);

            string sqlulog = string.Format("update {0} set CrimeHV='{1}' where SlNo={2}", TableName, hashvalue, SlNo - 1);
            cmd.CommandText = sqlulog;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
    }
}