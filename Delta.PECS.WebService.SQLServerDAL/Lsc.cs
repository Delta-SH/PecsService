using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Delta.PECS.WebService.DBUtility;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.SQLServerDAL
{
    /// <summary>
    /// This class is an implementation for receiving lsc information from database
    /// </summary>
    public class Lsc : ILsc
    {
        /// <summary>
        /// Method to get all lscs information
        /// </summary>
        /// <returns>all lscs information</returns>
        public List<LscInfo> GetLscs() {
            try {
                List<LscInfo> lscList = new List<LscInfo>();
                using(SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SqlText.SQL_SELECT_LSC_GETLSCS, null)) {
                    while(rdr.Read()) {
                        LscInfo lsc = new LscInfo();
                        lsc.LscID = ComUtility.DBNullInt32Handler(rdr["LscID"]);
                        lsc.LscName = ComUtility.DBNullStringHandler(rdr["LscName"]);
                        lsc.LscIP = ComUtility.DBNullStringHandler(rdr["LscIP"]);
                        lsc.LscPort = ComUtility.DBNullInt32Handler(rdr["LscPort"]);
                        lsc.LscUID = ComUtility.DBNullStringHandler(rdr["LscUID"]);
                        lsc.LscPwd = ComUtility.DBNullStringHandler(rdr["LscPwd"]);
                        lsc.BeatInterval = ComUtility.DBNullInt32Handler(rdr["BeatInterval"]);
                        lsc.BeatDelay = ComUtility.DBNullInt32Handler(rdr["BeatDelay"]);
                        lsc.DBServer = ComUtility.DBNullStringHandler(rdr["DBServer"]);
                        lsc.DBPort = ComUtility.DBNullInt32Handler(rdr["DBPort"]);
                        lsc.DBName = ComUtility.DBNullStringHandler(rdr["DBName"]);
                        lsc.DBUID = ComUtility.DBNullStringHandler(rdr["DBUID"]);
                        lsc.DBPwd = ComUtility.DBNullStringHandler(rdr["DBPwd"]);
                        lsc.HisDBServer = ComUtility.DBNullStringHandler(rdr["HisDBServer"]);
                        lsc.HisDBPort = ComUtility.DBNullInt32Handler(rdr["HisDBPort"]);
                        lsc.HisDBName = ComUtility.DBNullStringHandler(rdr["HisDBName"]);
                        lsc.HisDBUID = ComUtility.DBNullStringHandler(rdr["HisDBUID"]);
                        lsc.HisDBPwd = ComUtility.DBNullStringHandler(rdr["HisDBPwd"]);
                        lsc.Connected = ComUtility.DBNullBooleanHandler(rdr["Connected"]);
                        lsc.ChangeTime = ComUtility.DBNullDateTimeHandler(rdr["ChangedTime"]);
                        lsc.MaxNodeModify = null;
                        lsc.MaxChangeLog = null;
                        lsc.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);

                        lscList.Add(lsc);
                    }
                }

                return lscList;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to get lsc information
        /// </summary>
        /// <returns>lsc information</returns>
        public LscInfo GetLsc(int lscId) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                LscInfo lsc = null;
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SqlText.SQL_SELECT_LSC_GETLSC, parms)) {
                    if (rdr.Read()) {
                        lsc = new LscInfo();
                        lsc.LscID = ComUtility.DBNullInt32Handler(rdr["LscID"]);
                        lsc.LscName = ComUtility.DBNullStringHandler(rdr["LscName"]);
                        lsc.LscIP = ComUtility.DBNullStringHandler(rdr["LscIP"]);
                        lsc.LscPort = ComUtility.DBNullInt32Handler(rdr["LscPort"]);
                        lsc.LscUID = ComUtility.DBNullStringHandler(rdr["LscUID"]);
                        lsc.LscPwd = ComUtility.DBNullStringHandler(rdr["LscPwd"]);
                        lsc.BeatInterval = ComUtility.DBNullInt32Handler(rdr["BeatInterval"]);
                        lsc.BeatDelay = ComUtility.DBNullInt32Handler(rdr["BeatDelay"]);
                        lsc.DBServer = ComUtility.DBNullStringHandler(rdr["DBServer"]);
                        lsc.DBPort = ComUtility.DBNullInt32Handler(rdr["DBPort"]);
                        lsc.DBName = ComUtility.DBNullStringHandler(rdr["DBName"]);
                        lsc.DBUID = ComUtility.DBNullStringHandler(rdr["DBUID"]);
                        lsc.DBPwd = ComUtility.DBNullStringHandler(rdr["DBPwd"]);
                        lsc.HisDBServer = ComUtility.DBNullStringHandler(rdr["HisDBServer"]);
                        lsc.HisDBPort = ComUtility.DBNullInt32Handler(rdr["HisDBPort"]);
                        lsc.HisDBName = ComUtility.DBNullStringHandler(rdr["HisDBName"]);
                        lsc.HisDBUID = ComUtility.DBNullStringHandler(rdr["HisDBUID"]);
                        lsc.HisDBPwd = ComUtility.DBNullStringHandler(rdr["HisDBPwd"]);
                        lsc.Connected = ComUtility.DBNullBooleanHandler(rdr["Connected"]);
                        lsc.ChangeTime = ComUtility.DBNullDateTimeHandler(rdr["ChangedTime"]);
                        lsc.MaxNodeModify = null;
                        lsc.MaxChangeLog = null;
                        lsc.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    }
                }

                return lsc;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update the Lsc Attributes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="isConnected">isConnected</param>
        /// <param name="changeTime">changeTime</param>
        /// <returns>Affected rows</returns>
        public int UpdateAttributes(int lscId, bool isConnected, DateTime changeTime) {
            try {
                using(SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = {					   
			                new SqlParameter("@LscID", SqlDbType.Int),
			                new SqlParameter("@Connected", SqlDbType.Bit),
			                new SqlParameter("@ChangedTime", SqlDbType.DateTime)};

                        parms[0].Value = lscId;
                        parms[1].Value = isConnected;
                        parms[2].Value = changeTime;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_LSC_UPDATEATTRIBUTES, parms);
                        trans.Commit();
                    } catch {
                        trans.Rollback();
                        throw;
                    } finally {
                        conn.Close();
                    }
                }

                return 1;
            } catch {
                throw;
            }
        }
    }
}
