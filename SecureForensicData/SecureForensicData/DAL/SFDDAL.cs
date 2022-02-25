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

namespace SecureForensicData.DAL
{
    
    public class SFDDAL
    {
        MySqlConnection con = null;
        MySqlConnection contemp = null;
        MySqlCommand cmd = null;
        MySqlDataAdapter adp = null;

        string con_temp = "server=localhost;database=forensicdatatemp;user id=root;password=7777;port=3306;";

        string databasename = "forensicdata";
        string databasenametemp = "forensicdatatemp";
        public SFDDAL()
        {
            con = new MySqlConnection("server=localhost;database=forensicdata;user id=root;password=7777;port=3306;");
            con.Open();
        }
        public int LoginVerify(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = "";
            if (objDTO.UserType == "ApplicationManager")
            {
                sql = string.Format("Select count(*) from applicationmanager where AMId={0} and Password='{1}'", objDTO.Id, objDTO.Password);
            }
            else if (objDTO.UserType == "Police")
            {
                sql = string.Format("Select count(*) from policestationmaster where PoliceStationId='{0}' and Password='{1}'", objDTO.Id, objDTO.Password);
            }
            else if (objDTO.UserType == "HigherOfficer")
            {
                sql = string.Format("Select count(*) from higherofficermaster where HOId='{0}' and Password='{1}'", objDTO.Id, objDTO.Password);
            }
            else if (objDTO.UserType == "ForensicStaff")
            {
                sql = string.Format("Select count(*) from forensicstaff where FSId='{0}' and Password='{1}'", objDTO.Id, objDTO.Password);
            }
            else if (objDTO.UserType == "Doctor")
            {
                sql = string.Format("Select count(*) from doctormaster where DoctorId='{0}' and Password='{1}'", objDTO.Id, objDTO.Password);
            }
            cmd.CommandText = sql;
            int result = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return result;
        }
        public int ChangePassword(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = "";
            if (objDTO.UserType == "ApplicationManager")
            {
                sql = string.Format("update applicationmanager set Password='{1}' where AMId={0}", objDTO.Id, objDTO.Password);
            }
            else if (objDTO.UserType == "Police")
            {
                sql = string.Format("update policestationmaster set Password='{1}' where PoliceStationId='{0}'", objDTO.Id, objDTO.Password);
            }
            else if (objDTO.UserType == "HigherOfficer")
            {
                sql = string.Format("update higherofficermaster set Password='{1}' where HOId='{0}'", objDTO.Id, objDTO.Password);
            }
            else if (objDTO.UserType == "ForensicStaff")
            {
                sql = string.Format("Update forensicstaff set Password='{1}' where FSId='{0}'", objDTO.Id, objDTO.Password);
            }
            else if (objDTO.UserType == "Doctor")
            {
                sql = string.Format("Update doctormaster set Password='{1}' where DoctorId='{0}'", objDTO.Id, objDTO.Password);
            }
            
            cmd.CommandText = sql;
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public string CreateArea(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string chksql = string.Format("Select count(*) from areamaster where AreaName='{0}'", objDTO.AreaName);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            string result = "";
            if (res == "0")
            {
                string sql = string.Format("insert into areamaster(AreaName)values('{0}')", objDTO.AreaName);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }
        public DataTable GetArea()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select * from areamaster");
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string CreatePoliceStation(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string chksql = string.Format("Select count(*) from policestationmaster where AreaId={0}",objDTO.AreaId);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            string result = "";
            if (res == "0")
            {
                string sql = string.Format("insert into policestationmaster(PoliceStationId,AreaId,Name,Password,MobileNo,EmailId,Address)values({0},{1},'{2}','{3}','{4}','{5}','{6}')", objDTO.PoliceStationId, objDTO.AreaId, objDTO.Name, objDTO.Password, objDTO.MobileNo, objDTO.EmailId, objDTO.Address);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
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
        public string CreateHigherOfficer(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string chksql = string.Format("Select count(*) from higherofficermaster where Role='{0}'", objDTO.Role);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            string result = "";
            if (res == "0")
            {
                string sql = string.Format("insert into higherofficermaster(HOId,Name,Password,Role,MobileNo,EmailId,Address)values({0},'{1}','{2}','{3}','{4}','{5}','{6}')", objDTO.HOId, objDTO.Name, objDTO.Password,objDTO.Role, objDTO.MobileNo, objDTO.EmailId, objDTO.Address);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }

        public string CreateForensicStaff(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into forensicstaff(FSId,Name,Password,MobileNo,EmailId,Address)values({0},'{1}','{2}','{3}','{4}','{5}')", objDTO.FSId, objDTO.Name, objDTO.Password, objDTO.MobileNo, objDTO.EmailId, objDTO.Address);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }

        public string CreateDoctor(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into doctormaster(DoctorId,Name,Password,MobileNo,EmailId,Address)values({0},'{1}','{2}','{3}','{4}','{5}')", objDTO.DoctorId, objDTO.Name, objDTO.Password,objDTO.MobileNo, objDTO.EmailId, objDTO.Address);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }

        public string AddCrime(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into crimemaster(PSId,CrimeName,CrimePlace,Description,CrimeDate,Status)values({0},'{1}','{2}','{3}','{4}','Pending')", objDTO.PoliceStationId, objDTO.CrimeName, objDTO.CrimePlace,objDTO.Description, DateTime.Now);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();

            con.Close();
            return result;
        }

        public DataTable GetCrime(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select * from crimemaster where PSId={0} and (Status='Pending' or Status='Process')",objDTO.PoliceStationId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string AddForensicDC(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into forensicdatacollect(FSId,CrimeId,Description,FSCDate)values({0},{1},'{2}','{3}')", objDTO.FSId, objDTO.CrimeId,objDTO.Description, DateTime.Now);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }

        public string CreateTable_FSRG(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sqlcnt = string.Format("SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{1}' AND table_name = '{0}'", objDTO.TableName,databasename);
            cmd.CommandText = sqlcnt;
            string cnt = cmd.ExecuteScalar().ToString();
            contemp = new MySqlConnection(con_temp);
            contemp.Open();
            if (cnt == "0") //If Table Not Found,Then Update crimemaster Table status & Create Dynamic Table
            {
                string sqlcu = string.Format("update crimemaster set Status='Process' where CrimeId={0}", objDTO.CrimeId);
                cmd.CommandText = sqlcu;
                result = cmd.ExecuteNonQuery().ToString();
                if (result == "1")
                {
                    string sql = string.Format(@"CREATE TABLE `{0}` (
                                    `SlNo` int(11) NOT NULL AUTO_INCREMENT,
                                    `PSId` int(11) DEFAULT NULL,
                                    `CrimeId` int(11) DEFAULT NULL,
                                    `FSId` int(11) DEFAULT NULL,
                                    `LogDate` varchar(200) DEFAULT NULL,
                                    `FSHV` varchar(4000) DEFAULT NULL,
                                    `FSReport` varchar(20000) DEFAULT NULL,
                                     PRIMARY KEY(`SlNo`)
                                    ) ENGINE = InnoDB AUTO_INCREMENT = 4 DEFAULT CHARSET = latin1; ", objDTO.TableName);
                    cmd.CommandText = sql;
                    result = cmd.ExecuteNonQuery().ToString();

                    //Temp Table Backup

                    cmd.Connection = contemp;
                    string resulttemp = "";
                    string sqlcnttemp = string.Format("SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{1}' AND table_name = '{0}'", objDTO.TableName + "_temp",databasenametemp);
                    cmd.CommandText = sqlcnttemp;
                    string cnttemp = cmd.ExecuteScalar().ToString();

                    if (cnttemp == "0") //If Table Not Found, Create Dynamic Table
                    {

                        string sqltemp = string.Format(@"CREATE TABLE `{0}` (
                                    `SlNo` int(11) NOT NULL AUTO_INCREMENT,
                                    `PSId` int(11) DEFAULT NULL,
                                    `CrimeId` int(11) DEFAULT NULL,
                                    `FSId` int(11) DEFAULT NULL,
                                    `LogDate` varchar(200) DEFAULT NULL,
                                    `FSHV` varchar(4000) DEFAULT NULL,
                                    `FSReport` varchar(20000) DEFAULT NULL,
                                     PRIMARY KEY(`SlNo`)
                                    ) ENGINE = InnoDB AUTO_INCREMENT = 4 DEFAULT CHARSET = latin1; ", objDTO.TableName + "_temp");
                        cmd.CommandText = sqltemp;
                        resulttemp = cmd.ExecuteNonQuery().ToString();



                        if (result == "0")
                        {
                            cmd.Connection = con;
                            string sqlclog = string.Format("insert into {0} (PSId,CrimeId,FSId,LogDate,FSHV,FSReport)values({1},{2},{3},'{4}','{5}','{6}')", objDTO.TableName, 0, 0, 0, "NA", "NA", "NA");
                            cmd.CommandText = sqlclog;
                            result = cmd.ExecuteNonQuery().ToString();


                        }
                        if (resulttemp == "0")
                        {
                            cmd.Connection = contemp;
                            string sqlclog = string.Format("insert into {0} (PSId,CrimeId,FSId,LogDate,FSHV,FSReport)values({1},{2},{3},'{4}','{5}','{6}')", objDTO.TableName + "_temp", 0, 0, 0, "NA", "NA", "NA");
                            cmd.CommandText = sqlclog;
                            result = cmd.ExecuteNonQuery().ToString();
                        }
                    }
                }
            }
            
            string logdate = DateTime.Now.ToString();
            string hashvalue = ShaKeyGeneration(objDTO.PoliceStationId.ToString(),objDTO.CrimeId.ToString(), objDTO.FSId.ToString(), logdate);

            byte[] passBytes = Encoding.UTF8.GetBytes(hashvalue.Substring(0, 2));

            string keyvalue = string.Join("", passBytes);

            string EncryptData = AESCryptoClass.EncryptData(objDTO.Description, keyvalue);

            cmd.Connection = con;
            string sqlclogcs = string.Format("insert into {0} (PSId,CrimeId,FSId,LogDate,FSHV,FSReport)values({1},{2},{3},'{4}','{5}','{6}')", objDTO.TableName,objDTO.PoliceStationId, objDTO.CrimeId, objDTO.FSId, logdate, "NA", "NA");
            cmd.CommandText = sqlclogcs;
            result = cmd.ExecuteNonQuery().ToString();

            string sqlcdlp = string.Format("SELECT * FROM {0} ORDER BY SlNo DESC LIMIT 1,1", objDTO.TableName);
            cmd.CommandText = sqlcdlp;
            adp = new MySqlDataAdapter(cmd);
            DataTable tablp = new DataTable();
            adp.Fill(tablp);

            string sqlulog = string.Format("update {0} set FSHV='{1}',FSReport='{2}' where SlNo={3}", objDTO.TableName, hashvalue, EncryptData, tablp.Rows[0]["SlNo"].ToString());
            cmd.CommandText = sqlulog;
            result = cmd.ExecuteNonQuery().ToString();
            

            //Temp Table
            cmd.Connection = contemp;
            string sqlclogcsTemp = string.Format("insert into {0} (PSId,CrimeId,FSId,LogDate,FSHV,FSReport)values({1},{2},{3},'{4}','{5}','{6}')", objDTO.TableName + "_temp", objDTO.PoliceStationId, objDTO.CrimeId, objDTO.FSId, logdate, "NA", "NA");
            cmd.CommandText = sqlclogcsTemp;
            result = cmd.ExecuteNonQuery().ToString();

            cmd.Connection = contemp;
            string sqlcdlptemp = string.Format("SELECT * FROM {0} ORDER BY SlNo DESC LIMIT 1,1", objDTO.TableName + "_temp");
            cmd.CommandText = sqlcdlptemp;
            adp = new MySqlDataAdapter(cmd);
            DataTable tablptemp = new DataTable();
            adp.Fill(tablptemp);

            cmd.Connection = contemp;
            string sqlulogtemp = string.Format("update {0} set FSHV='{1}',FSReport='{2}' where SlNo={3}", objDTO.TableName + "_temp", hashvalue, EncryptData, tablptemp.Rows[0]["SlNo"].ToString());
            cmd.CommandText = sqlulogtemp;
            result = cmd.ExecuteNonQuery().ToString();

            contemp.Close();
            con.Close();
            return result;
        }
        public string CreateTable_DRG(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sqlcnt = string.Format("SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{1}' AND table_name = '{0}'", objDTO.TableName,databasename);
            cmd.CommandText = sqlcnt;
            string cnt = cmd.ExecuteScalar().ToString();
            contemp = new MySqlConnection(con_temp);
            contemp.Open();
            if (cnt == "0") //If Table Not Found,Then Update crimemaster Table status & Create Dynamic Table
            {
                string sqlcu = string.Format("update crimemaster set Status='Process' where CrimeId={0}", objDTO.CrimeId);
                cmd.CommandText = sqlcu;
                result = cmd.ExecuteNonQuery().ToString();
                if (result == "1")
                {
                    string sql = string.Format(@"CREATE TABLE `{0}` (
                                    `SlNo` int(11) NOT NULL AUTO_INCREMENT,
                                    `PSId` int(11) DEFAULT NULL,
                                    `CrimeId` int(11) DEFAULT NULL,
                                    `DId` int(11) DEFAULT NULL,
                                    `LogDate` varchar(200) DEFAULT NULL,
                                    `DHV` varchar(4000) DEFAULT NULL,
                                    `DReport` varchar(20000) DEFAULT NULL,
                                     PRIMARY KEY(`SlNo`)
                                    ) ENGINE = InnoDB AUTO_INCREMENT = 4 DEFAULT CHARSET = latin1; ", objDTO.TableName);
                    cmd.CommandText = sql;
                    result = cmd.ExecuteNonQuery().ToString();

                    //Temp Table Backup

                    cmd.Connection = contemp;
                    string resulttemp = "";
                    string sqlcnttemp = string.Format("SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{1}' AND table_name = '{0}'", objDTO.TableName + "_temp",databasenametemp);
                    cmd.CommandText = sqlcnttemp;
                    string cnttemp = cmd.ExecuteScalar().ToString();

                    if (cnttemp == "0") //If Table Not Found, Create Dynamic Table
                    {

                        string sqltemp = string.Format(@"CREATE TABLE `{0}` (
                                    `SlNo` int(11) NOT NULL AUTO_INCREMENT,
                                    `PSId` int(11) DEFAULT NULL,
                                    `CrimeId` int(11) DEFAULT NULL,
                                    `DId` int(11) DEFAULT NULL,
                                    `LogDate` varchar(200) DEFAULT NULL,
                                    `DHV` varchar(4000) DEFAULT NULL,
                                    `DReport` varchar(20000) DEFAULT NULL,
                                     PRIMARY KEY(`SlNo`)
                                    ) ENGINE = InnoDB AUTO_INCREMENT = 4 DEFAULT CHARSET = latin1; ", objDTO.TableName + "_temp");
                        cmd.CommandText = sqltemp;
                        resulttemp = cmd.ExecuteNonQuery().ToString();



                        if (result == "0")
                        {
                            cmd.Connection = con;
                            string sqlclog = string.Format("insert into {0} (PSId,CrimeId,DId,LogDate,DHV,DReport)values({1},{2},{3},'{4}','{5}','{6}')", objDTO.TableName, 0, 0, 0, "NA", "NA", "NA");
                            cmd.CommandText = sqlclog;
                            result = cmd.ExecuteNonQuery().ToString();


                        }
                        if (resulttemp == "0")
                        {
                            cmd.Connection = contemp;
                            string sqlclog = string.Format("insert into {0} (PSId,CrimeId,DId,LogDate,DHV,DReport)values({1},{2},{3},'{4}','{5}','{6}')", objDTO.TableName + "_temp", 0, 0, 0, "NA", "NA", "NA");
                            cmd.CommandText = sqlclog;
                            result = cmd.ExecuteNonQuery().ToString();
                        }
                    }
                }
            }

            string logdate = DateTime.Now.ToString();
            string hashvalue = ShaKeyGeneration(objDTO.PoliceStationId.ToString(), objDTO.CrimeId.ToString(), objDTO.DoctorId.ToString(), logdate);

            byte[] passBytes = Encoding.UTF8.GetBytes(hashvalue.Substring(0, 2));

            string keyvalue = string.Join("", passBytes);

            string EncryptData = AESCryptoClass.EncryptData(objDTO.Description, keyvalue);

            cmd.Connection = con;
            string sqlclogcs = string.Format("insert into {0} (PSId,CrimeId,DId,LogDate,DHV,DReport)values({1},{2},{3},'{4}','{5}','{6}')", objDTO.TableName, objDTO.PoliceStationId, objDTO.CrimeId, objDTO.DoctorId, logdate, "NA", "NA");
            cmd.CommandText = sqlclogcs;
            result = cmd.ExecuteNonQuery().ToString();

            string sqlcdlp = string.Format("SELECT * FROM {0} ORDER BY SlNo DESC LIMIT 1,1", objDTO.TableName);
            cmd.CommandText = sqlcdlp;
            adp = new MySqlDataAdapter(cmd);
            DataTable tablp = new DataTable();
            adp.Fill(tablp);

            string sqlulog = string.Format("update {0} set DHV='{1}',DReport='{2}' where SlNo={3}", objDTO.TableName, hashvalue, EncryptData, tablp.Rows[0]["SlNo"].ToString());
            cmd.CommandText = sqlulog;
            result = cmd.ExecuteNonQuery().ToString();


            //Temp Table
            cmd.Connection = contemp;
            string sqlclogcsTemp = string.Format("insert into {0} (PSId,CrimeId,DId,LogDate,DHV,DReport)values({1},{2},{3},'{4}','{5}','{6}')", objDTO.TableName + "_temp", objDTO.PoliceStationId, objDTO.CrimeId, objDTO.DoctorId, logdate, "NA", "NA");
            cmd.CommandText = sqlclogcsTemp;
            result = cmd.ExecuteNonQuery().ToString();

            cmd.Connection = contemp;
            string sqlcdlptemp = string.Format("SELECT * FROM {0} ORDER BY SlNo DESC LIMIT 1,1", objDTO.TableName + "_temp");
            cmd.CommandText = sqlcdlptemp;
            adp = new MySqlDataAdapter(cmd);
            DataTable tablptemp = new DataTable();
            adp.Fill(tablptemp);

            cmd.Connection = contemp;
            string sqlulogtemp = string.Format("update {0} set DHV='{1}',DReport='{2}' where SlNo={3}", objDTO.TableName + "_temp", hashvalue, EncryptData, tablptemp.Rows[0]["SlNo"].ToString());
            cmd.CommandText = sqlulogtemp;
            result = cmd.ExecuteNonQuery().ToString();

            contemp.Close();
            con.Close();
            return result;
        }
        public string ShaKeyGeneration(string PSId, string CrimeId, string Id,string LogDate)
        {
            try
            {
                string data = PSId + "," + CrimeId + "," + Id +  "," + LogDate;
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

        public DataTable GetFSReport(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select * from {0} where LogDate<>'NA' order by SlNo desc", objDTO.TableName);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public string FSRequest(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into reportrequest(Id,CrimeId,UserType,RDate,AccessKey,Status)values({0},{1},'{2}','{3}','{4}','Accept')", objDTO.Id, objDTO.CrimeId,objDTO.UserType,  DateTime.Now.ToString("dd/MM/yyyy"),objDTO.AccessKey);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            if (result == "1")
            {
                string sqlemail = "";
                if (objDTO.UserType == "Police")
                {
                    sqlemail = string.Format("select EmailId from policestationmaster where PoliceStationId={0}", objDTO.Id);
                }
                else
                {
                    sqlemail = string.Format("select EmailId from higherofficermaster where HOId={0}", objDTO.Id);
                }
                cmd.CommandText = sqlemail;
                adp = new MySqlDataAdapter(cmd);
                DataTable tab = new DataTable();
                adp.Fill(tab);
                result = result + "&" + tab.Rows[0]["EmailId"].ToString();
            }

            con.Close();
            return result;
        }

        public string GetFSReportData(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqlfsd = string.Format("Select * from {0} where SlNo={1}", objDTO.TableName,objDTO.SlNo);
            cmd.CommandText = sqlfsd;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            string hashvalue = ShaKeyGeneration(tab.Rows[0]["PSId"].ToString(), tab.Rows[0]["CrimeId"].ToString(), tab.Rows[0]["FSId"].ToString(), tab.Rows[0]["LogDate"].ToString());
            string sql = string.Format("Select count(*) from {0} where FSHV='{1}'", objDTO.TableName, hashvalue);
            cmd.CommandText = sql;
            string result = cmd.ExecuteScalar().ToString();
            if (result == "1")
            {
                string sqlCS = string.Format("Select * from {0} where FSHV='{1}'", objDTO.TableName, hashvalue);
                cmd.CommandText = sqlCS;
                adp = new MySqlDataAdapter(cmd);
                DataTable tabfsd = new DataTable();
                adp.Fill(tabfsd);
                byte[] passBytes = Encoding.UTF8.GetBytes(hashvalue.Substring(0, 2));
                string keyvalue = string.Join("", passBytes);
                string data = AESCryptoClass.Decrypt(tabfsd.Rows[0]["FSReport"].ToString(), keyvalue);
                result = result + "$" + data;
            }
            else
            {
                result = result + "$0";
            }
            con.Close();
            return result;

        }

        public string GetMedicalReportData(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqlfsd = string.Format("Select * from {0} where SlNo={1}", objDTO.TableName, objDTO.SlNo);
            cmd.CommandText = sqlfsd;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            string hashvalue = ShaKeyGeneration(tab.Rows[0]["PSId"].ToString(), tab.Rows[0]["CrimeId"].ToString(), tab.Rows[0]["DId"].ToString(), tab.Rows[0]["LogDate"].ToString());
            string sql = string.Format("Select count(*) from {0} where DHV='{1}'", objDTO.TableName, hashvalue);
            cmd.CommandText = sql;
            string result = cmd.ExecuteScalar().ToString();
            if (result == "1")
            {
                string sqlCS = string.Format("Select * from {0} where DHV='{1}'", objDTO.TableName, hashvalue);
                cmd.CommandText = sqlCS;
                adp = new MySqlDataAdapter(cmd);
                DataTable tabfsd = new DataTable();
                adp.Fill(tabfsd);
                byte[] passBytes = Encoding.UTF8.GetBytes(hashvalue.Substring(0, 2));
                string keyvalue = string.Join("", passBytes);
                string data = AESCryptoClass.Decrypt(tabfsd.Rows[0]["DReport"].ToString(), keyvalue);
                result = result + "$" + data;
            }
            else
            {
                result = result + "$0";
            }
            con.Close();
            return result;

        }



        public DataTable GetCrimeLog_HO(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select * from {0} where LogDate<>'NA' order by SlNo desc", objDTO.TableName);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string CrimeRequest(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into crimerequest(SlNo,HOId,AccessKey,ReqDate)values({0},{1},{2},'{3}')", objDTO.SlNo, objDTO.HOId, objDTO.AccessKey, DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            if (result == "1")
            {
                string sqlHO = string.Format("select EmailId from higherofficermaster where HOId={0}", objDTO.HOId);
                cmd.CommandText = sqlHO;
                adp = new MySqlDataAdapter(cmd);
                DataTable tab = new DataTable();
                adp.Fill(tab);
                string sqlCLD = string.Format("select * from {0} where SlNo={1}", objDTO.TableName, objDTO.SlNo);
                cmd.CommandText = sqlCLD;
                adp = new MySqlDataAdapter(cmd);
                DataTable tabCLD = new DataTable();
                adp.Fill(tabCLD);
                string msg = tabCLD.Rows[0]["CrimeId"].ToString() + "-" + tabCLD.Rows[0]["CrimeName"].ToString() + "-" + tabCLD.Rows[0]["CrimePlace"].ToString() + "-" + tabCLD.Rows[0]["CrimeDate"].ToString() + "-" + tabCLD.Rows[0]["LogDate"].ToString();
                result = result + "&" + tab.Rows[0]["EmailId"].ToString() + "&" + msg;
            }

            con.Close();
            return result;
        }
       
        public string PostMessage(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into messagemaster(HOId,PSId,PostDate,Message,Status)values({0},{1},'{2}','{3}','Pending')",objDTO.HOId, objDTO.PoliceStationId, DateTime.Now.ToString("dd/MM/yyyy"),objDTO.Message);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();

            con.Close();
            return result;
        }
        public DataTable GetMessage_HOPSId(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select higherofficermaster.Name,higherofficermaster.Role,messagemaster.PostDate,messagemaster.Message from messagemaster inner join higherofficermaster on messagemaster.HOId=higherofficermaster.HOId where PSId={0} order by PId desc limit 20",objDTO.PoliceStationId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        
        public string UpdateCrimeStatus(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("update crimemaster set Status='{0}' where CrimeId={1}",objDTO.Status,objDTO.CrimeId);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();

            con.Close();
            return result;
        }
        public string CreateTable_CSL(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sqlcnt = string.Format("SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{1}' AND table_name = '{0}'", objDTO.TableName,databasename);
            cmd.CommandText = sqlcnt;
            string cnt = cmd.ExecuteScalar().ToString();

            contemp = new MySqlConnection(con_temp);
            contemp.Open();

            if (cnt == "0") //If Table Not Found,Then Update crimemaster Table status & Create Dynamic Table
            {
                string sqlcu = string.Format("update crimemaster set Status='Process' where CrimeId={0}", objDTO.CrimeId);
                cmd.CommandText = sqlcu;
                result = cmd.ExecuteNonQuery().ToString();
                if (result == "1")
                {
                    string sql = string.Format(@"CREATE TABLE `{0}` (
                                    `SlNo` int(11) NOT NULL AUTO_INCREMENT,
                                    `CrimeId` int(11) DEFAULT NULL,
                                    `LogDate` varchar(200) DEFAULT NULL,
                                    `CrimeHV` varchar(4000) DEFAULT NULL,
                                    `CED` varchar(20000) DEFAULT NULL,
                                     PRIMARY KEY(`SlNo`)
                                    ) ENGINE = InnoDB AUTO_INCREMENT = 4 DEFAULT CHARSET = latin1; ", objDTO.TableName);
                    cmd.CommandText = sql;
                    result = cmd.ExecuteNonQuery().ToString();

                    //Temp Table Backup

                    cmd.Connection = contemp;
                    string resulttemp = "";
                    string sqlcnttemp = string.Format("SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{1}' AND table_name = '{0}'", objDTO.TableName + "_temp",databasenametemp);
                    cmd.CommandText = sqlcnttemp;
                    string cnttemp = cmd.ExecuteScalar().ToString();
                    if (cnttemp == "0") //If Table Not Found, Create Dynamic Table
                    {
                        string sqltemp = string.Format(@"CREATE TABLE `{0}` (
                                    `SlNo` int(11) NOT NULL AUTO_INCREMENT,
                                    `CrimeId` int(11) DEFAULT NULL,
                                    `LogDate` varchar(200) DEFAULT NULL,
                                    `CrimeHV` varchar(4000) DEFAULT NULL,
                                    `CED` varchar(20000) DEFAULT NULL,
                                     PRIMARY KEY(`SlNo`)
                                    ) ENGINE = InnoDB AUTO_INCREMENT = 4 DEFAULT CHARSET = latin1; ", objDTO.TableName);
                        cmd.CommandText = sqltemp;
                        resulttemp = cmd.ExecuteNonQuery().ToString();



                        if (result == "0")
                        {
                            cmd.Connection = con;
                            string sqlclog = string.Format("insert into {0} (CrimeId,LogDate,CrimeHV,CED)values({1},'{2}','{3}','{4}')", objDTO.TableName, 0, "NA", "NA", "NA");
                            cmd.CommandText = sqlclog;
                            result = cmd.ExecuteNonQuery().ToString();


                        }
                        if (resulttemp == "0")
                        {
                            cmd.Connection = contemp;
                            string sqlclog = string.Format("insert into {0} (CrimeId,LogDate,CrimeHV,CED)values({1},'{2}','{3}','{4}')", objDTO.TableName, 0, "NA", "NA", "NA");
                            cmd.CommandText = sqlclog;
                            result = cmd.ExecuteNonQuery().ToString();


                        }

                    }
                }
            }
            
            string logdate = DateTime.Now.ToString();
            string hashvalue = ShaKeyGeneration(objDTO.CrimeId.ToString(), logdate);

            byte[] passBytes = Encoding.UTF8.GetBytes(hashvalue.Substring(0, 2));

            string keyvalue = string.Join("", passBytes);

            string EncryptData = AESCryptoClass.EncryptData(objDTO.CaseSummary, keyvalue);

            
            cmd.Connection = con;
            string sqlclogcs = string.Format("insert into {0} (CrimeId,LogDate,CrimeHV,CED)values({1},'{2}','{3}','{4}')", objDTO.TableName, objDTO.CrimeId, logdate, "NA", "NA");
            cmd.CommandText = sqlclogcs;
            result = cmd.ExecuteNonQuery().ToString();

            string sqlcdlp = string.Format("SELECT * FROM {0} ORDER BY SlNo DESC LIMIT 1,1", objDTO.TableName);
            cmd.CommandText = sqlcdlp;
            adp = new MySqlDataAdapter(cmd);
            DataTable tablp = new DataTable();
            adp.Fill(tablp);

            string sqlulog = string.Format("update {0} set CrimeHV='{1}',CED='{2}' where SlNo={3}", objDTO.TableName, hashvalue, EncryptData, tablp.Rows[0]["SlNo"].ToString());
            cmd.CommandText = sqlulog;
            result = cmd.ExecuteNonQuery().ToString();

            //Temp Table
            cmd.Connection = contemp;
            string sqlclogcstemp = string.Format("insert into {0} (CrimeId,LogDate,CrimeHV,CED)values({1},'{2}','{3}','{4}')", objDTO.TableName, objDTO.CrimeId, logdate, "NA", "NA");
            cmd.CommandText = sqlclogcstemp;
            result = cmd.ExecuteNonQuery().ToString();

            string sqlcdlptemp = string.Format("SELECT * FROM {0} ORDER BY SlNo DESC LIMIT 1,1", objDTO.TableName);
            cmd.CommandText = sqlcdlptemp;
            adp = new MySqlDataAdapter(cmd);
            DataTable tablptemp = new DataTable();
            adp.Fill(tablptemp);

            string sqlulogtemp = string.Format("update {0} set CrimeHV='{1}',CED='{2}' where SlNo={3}", objDTO.TableName, hashvalue, EncryptData, tablptemp.Rows[0]["SlNo"].ToString());
            cmd.CommandText = sqlulogtemp;
            result = cmd.ExecuteNonQuery().ToString();
            contemp.Close();
            con.Close();
            return result;
        }
        public string ShaKeyGeneration(string CrimeId, string LogDate)
        {
            try
            {
                string data = CrimeId + "," + LogDate;
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
        public string ChkFSCaseTamper(SecureForensicData.DTO.SFDDTO objDTO)
        {
            contemp = new MySqlConnection(con_temp);
            contemp.Open();
            cmd = new MySqlCommand();
            cmd.Connection = contemp;
            string sqltb = string.Format("Select * from {0} where SlNo={1}", objDTO.TableName+"_temp", objDTO.SlNo);
            cmd.CommandText = sqltb;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            string hashvalue = ShaKeyGeneration(tab.Rows[0]["PSId"].ToString(), tab.Rows[0]["CrimeId"].ToString(), tab.Rows[0]["FSId"].ToString(), tab.Rows[0]["LogDate"].ToString());
            cmd.Connection = con;
            string sql = string.Format("Select count(*) from {0} where FSHV='{1}'", objDTO.TableName, hashvalue);
            cmd.CommandText = sql;
            string result = cmd.ExecuteScalar().ToString();
            contemp.Close();
            con.Close();
            return result;
        }
        public string FSCaseRecover(SecureForensicData.DTO.SFDDTO objDTO)
        {
            contemp = new MySqlConnection(con_temp);
            contemp.Open();
            cmd = new MySqlCommand();
            cmd.Connection = contemp;
            string sqltb = string.Format("Select * from {0} where SlNo={1}", objDTO.TableName+"_temp", objDTO.SlNo - 1);
            cmd.CommandText = sqltb;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);

            cmd.Connection = con;
            string sql = string.Format("update {0} set FSHV='{1}' where SlNo={2}", objDTO.TableName, tab.Rows[0]["FSHV"].ToString(), objDTO.SlNo - 1);
            cmd.CommandText = sql;
            string result = cmd.ExecuteNonQuery().ToString();
            contemp.Close();
            con.Close();
            return result;

        }

        public string ChkDRCaseTamper(SecureForensicData.DTO.SFDDTO objDTO)
        {
            contemp = new MySqlConnection(con_temp);
            contemp.Open();
            cmd = new MySqlCommand();
            cmd.Connection = contemp;
            string sqltb = string.Format("Select * from {0} where SlNo={1}", objDTO.TableName + "_temp", objDTO.SlNo);
            cmd.CommandText = sqltb;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            string hashvalue = ShaKeyGeneration(tab.Rows[0]["PSId"].ToString(), tab.Rows[0]["CrimeId"].ToString(), tab.Rows[0]["DId"].ToString(), tab.Rows[0]["LogDate"].ToString());
            cmd.Connection = con;
            string sql = string.Format("Select count(*) from {0} where DHV='{1}'", objDTO.TableName, hashvalue);
            cmd.CommandText = sql;
            string result = cmd.ExecuteScalar().ToString();
            contemp.Close();
            con.Close();
            return result;
        }
        public string DRCaseRecover(SecureForensicData.DTO.SFDDTO objDTO)
        {
            contemp = new MySqlConnection(con_temp);
            contemp.Open();
            cmd = new MySqlCommand();
            cmd.Connection = contemp;
            string sqltb = string.Format("Select * from {0} where SlNo={1}", objDTO.TableName + "_temp", objDTO.SlNo - 1);
            cmd.CommandText = sqltb;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);

            cmd.Connection = con;
            string sql = string.Format("update {0} set DHV='{1}' where SlNo={2}", objDTO.TableName, tab.Rows[0]["DHV"].ToString(), objDTO.SlNo - 1);
            cmd.CommandText = sql;
            string result = cmd.ExecuteNonQuery().ToString();
            contemp.Close();
            con.Close();
            return result;

        }
        public string ChkCCaseTamper(SecureForensicData.DTO.SFDDTO objDTO)
        {
            contemp = new MySqlConnection(con_temp);
            contemp.Open();
            cmd = new MySqlCommand();
            cmd.Connection = contemp;
            string sqltb = string.Format("Select * from {0} where SlNo={1}", objDTO.TableName, objDTO.SlNo);
            cmd.CommandText = sqltb;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            string hashvalue = ShaKeyGeneration(tab.Rows[0]["CrimeId"].ToString(), tab.Rows[0]["LogDate"].ToString());
            cmd.Connection = con;
            string sql = string.Format("Select count(*) from {0} where CrimeHV='{1}'", objDTO.TableName, hashvalue);
            cmd.CommandText = sql;
            string result = cmd.ExecuteScalar().ToString();
            contemp.Close();
            con.Close();
            return result;
        }
        public string CCaseRecover(SecureForensicData.DTO.SFDDTO objDTO)
        {
            contemp = new MySqlConnection(con_temp);
            contemp.Open();
            cmd = new MySqlCommand();
            cmd.Connection = contemp;
            string sqltb = string.Format("Select * from {0} where SlNo={1}", objDTO.TableName, objDTO.SlNo - 1);
            cmd.CommandText = sqltb;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);

            cmd.Connection = con;
            string sql = string.Format("update {0} set CrimeHV='{1}' where SlNo={2}", objDTO.TableName, tab.Rows[0]["CrimeHV"].ToString(), objDTO.SlNo - 1);
            cmd.CommandText = sql;
            string result = cmd.ExecuteNonQuery().ToString();
            contemp.Close();
            con.Close();
            return result;

        }
        public string GetCrimeCS(SecureForensicData.DTO.SFDDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqlfsd = string.Format("Select * from {0} where SlNo={1}", objDTO.TableName, objDTO.SlNo);
            cmd.CommandText = sqlfsd;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            string hashvalue = ShaKeyGeneration(tab.Rows[0]["CrimeId"].ToString(), tab.Rows[0]["LogDate"].ToString());
            string sql = string.Format("Select count(*) from {0} where CrimeHV='{1}'", objDTO.TableName, hashvalue);
            cmd.CommandText = sql;
            string result = cmd.ExecuteScalar().ToString();
            if (result == "1")
            {
                string sqlCS = string.Format("Select * from {0} where CrimeHV='{1}'", objDTO.TableName, hashvalue);
                cmd.CommandText = sqlCS;
                adp = new MySqlDataAdapter(cmd);
                DataTable tabfsd = new DataTable();
                adp.Fill(tabfsd);
                byte[] passBytes = Encoding.UTF8.GetBytes(hashvalue.Substring(0, 2));
                string keyvalue = string.Join("", passBytes);
                string data = AESCryptoClass.Decrypt(tabfsd.Rows[0]["CED"].ToString(), keyvalue);
                result = result + "$" + data;
            }
            else
            {
                result = result + "$0";
            }
            con.Close();
            return result;


        }
    }
}