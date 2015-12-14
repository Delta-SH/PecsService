using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Delta.PECS.WebService.Model;
using Delta.PECS.WebService.IDAL;
using System.Data.SqlClient;
using Delta.PECS.WebService.DBUtility;
using System.Data;

namespace Delta.PECS.WebService.SQLServerDAL
{
    /// <summary>
    /// Operate Log Class
    /// </summary>
    public class Log : ILog
    {
        /// <summary>
        /// Method to add text log information
        /// </summary>
        /// <param name="logs">logs</param>
        /// <returns>Affected rows</returns>
        public int WriteTxtLog(IList<LogInfo> logs) {
            var rowCnt = 0;
            try {
                string fullPath = String.Format(@"{0}Log", AppDomain.CurrentDomain.BaseDirectory);
                string fullName = String.Format(@"{0}\RUN{1}.log", fullPath, DateTime.Today.ToString("yyyy-MM-dd"));
                if (!Directory.Exists(fullPath)) { Directory.CreateDirectory(fullPath); }

                foreach (var log in logs) {
                    if (log.EventType == EnmLogType.Off)
                        continue;

                    var fi = new FileInfo(fullName);
                    if (fi.Exists) {
                        using (var sw = fi.AppendText()) {
                            sw.WriteLine(String.Format("{0} {1}", log.EventTime.ToString("MM-dd HH:mm:ss"), log.Message));
                            sw.Close();
                            rowCnt++;
                        }
                    } else {
                        using (var sw = fi.CreateText()) {
                            sw.WriteLine(String.Format("{0} {1}", log.EventTime.ToString("MM-dd HH:mm:ss"), log.Message));
                            sw.Close();
                            rowCnt++;
                        }
                    }
                }

                return rowCnt;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to add database log information
        /// </summary>
        /// <param name="logs">logs</param>
        /// <returns>Affected rows</returns>
        public int WriteDBLog(IList<LogInfo> logs) {
            var rowCnt = 0;
            try {
                using (var conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = {					   
			                new SqlParameter("@EventTime", SqlDbType.DateTime),
			                new SqlParameter("@EventType", SqlDbType.SmallInt),
			                new SqlParameter("@Message", SqlDbType.NVarChar, 2048),
			                new SqlParameter("@Operator", SqlDbType.NVarChar,50)};

                        foreach (var log in logs) {
                            parms[0].Value = log.EventTime;
                            parms[1].Value = (int)log.EventType;
                            parms[2].Value = log.Message;
                            parms[3].Value = log.Operator;

                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_INSERT_LOG_WRITEDBLOG, parms);
                            rowCnt++;
                        }

                        trans.Commit();
                    } catch {
                        trans.Rollback();
                        throw;
                    } finally {
                        conn.Close();
                    }
                }

                return rowCnt;
            } catch {
                throw;
            }
        }
    }
}