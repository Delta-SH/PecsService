using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.Model;
using Delta.PECS.WebService.DBUtility;

namespace Delta.PECS.WebService.SQLServerDAL
{
    /// <summary>
    /// This class is an implementation for receiving alarm information from database
    /// </summary>
    public class Alarm : IAlarm
    {
        /// <summary>
        /// Syn Alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>Alarms</returns>
        public List<AlarmInfo> SynAlarms(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                           new SqlParameter("@AIType", SqlDbType.Int),
                                           new SqlParameter("@DIType", SqlDbType.Int)};
                parms[0].Value = lscId;
                parms[1].Value = (int)EnmNodeType.Aic;
                parms[2].Value = (int)EnmNodeType.Dic;

                List<AlarmInfo> alarms = new List<AlarmInfo>();
                SqlHelper.TestConnection(connectionString);
                using(DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_ALARM_SYNALARMS, parms)) {
                    if(dt != null && dt.Rows.Count > 0) {
                        foreach(DataRow dr in dt.Rows) {
                            AlarmInfo alarm = new AlarmInfo();
                            alarm.LscID = ComUtility.DBNullInt32Handler(dr["LscID"]);
                            alarm.SerialNO = ComUtility.DBNullInt32Handler(dr["SerialNO"]);
                            alarm.Area1Name = ComUtility.DBNullStringHandler(dr["Area1Name"]);
                            alarm.Area2Name = ComUtility.DBNullStringHandler(dr["Area2Name"]);
                            alarm.Area3Name = ComUtility.DBNullStringHandler(dr["Area3Name"]);
                            alarm.Area4Name = ComUtility.DBNullStringHandler(dr["Area4Name"]);
                            alarm.StaName = ComUtility.DBNullStringHandler(dr["StaName"]);
                            alarm.DevName = ComUtility.DBNullStringHandler(dr["DevName"]);
                            alarm.DevDesc = ComUtility.DBNullStringHandler(dr["DevDesc"]);
                            alarm.NodeID = ComUtility.DBNullInt32Handler(dr["NodeID"]);
                            alarm.NodeType = ComUtility.DBNullNodeTypeHandler(dr["NodeType"]);
                            alarm.NodeName = ComUtility.DBNullStringHandler(dr["NodeName"]);
                            alarm.AlarmID = ComUtility.DBNullInt32Handler(dr["AlarmID"]);
                            alarm.AlarmValue = ComUtility.DBNullFloatHandler(dr["AlarmValue"]);
                            alarm.AlarmLevel = ComUtility.DBNullAlarmLevelHandler(dr["AlarmLevel"]);
                            alarm.AlarmStatus = ComUtility.DBNullAlarmStatusHandler(dr["AlarmStatus"]);
                            alarm.AlarmDesc = ComUtility.DBNullStringHandler(dr["AlarmDesc"]);
                            alarm.AuxAlarmDesc = ComUtility.DBNullStringHandler(dr["AuxAlarmDesc"]);
                            alarm.StartTime = ComUtility.DBNullDateTimeHandler(dr["StartTime"]);
                            alarm.EndTime = ComUtility.DBNullDateTimeHandler(dr["EndTime"]);
                            alarm.ConfirmName = ComUtility.DBNullStringHandler(dr["ConfirmName"]);
                            alarm.ConfirmMarking = ComUtility.DBNullConfirmMarkingHandler(dr["ConfirmMarking"]);
                            alarm.ConfirmTime = ComUtility.DBNullDateTimeHandler(dr["ConfirmTime"]);
                            alarm.AuxSet = ComUtility.DBNullStringHandler(dr["AuxSet"]);
                            alarm.TaskID = ComUtility.DBNullStringHandler(dr["TaskID"]);
                            alarm.ProjName = ComUtility.DBNullStringHandler(dr["ProjName"]);
                            alarm.TurnCount = ComUtility.DBNullInt32Handler(dr["TurnCount"]);
                            alarm.UpdateTime = ComUtility.DBNullDateTimeHandler(dr["UpdateTime"]);

                            alarms.Add(alarm);
                        }

                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_Alarm, dt);
                    }
                }

                return alarms;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to add alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        /// <returns>Affected rows</returns>
        public int AddAlarms(IList<AlarmInfo> alarms) {
            int rowCnt = 0;
            try {
                using(SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = {					   
			                new SqlParameter("@LscID", SqlDbType.Int),
			                new SqlParameter("@SerialNO", SqlDbType.Int),
			                new SqlParameter("@Area1Name", SqlDbType.NVarChar, 50),
			                new SqlParameter("@Area2Name", SqlDbType.NVarChar, 50),
			                new SqlParameter("@Area3Name", SqlDbType.NVarChar, 50),
			                new SqlParameter("@Area4Name", SqlDbType.NVarChar, 50),
			                new SqlParameter("@StaName", SqlDbType.NVarChar, 50),
			                new SqlParameter("@DevName", SqlDbType.NVarChar, 50),
                            new SqlParameter("@DevDesc", SqlDbType.NVarChar, 50),
                            new SqlParameter("@NodeID", SqlDbType.Int),
			                new SqlParameter("@NodeType", SqlDbType.Int),
			                new SqlParameter("@NodeName", SqlDbType.NVarChar, 50),
			                new SqlParameter("@AlarmID", SqlDbType.Int),
                            new SqlParameter("@AlarmValue", SqlDbType.Real),
			                new SqlParameter("@AlarmLevel", SqlDbType.Int),
                            new SqlParameter("@AlarmStatus", SqlDbType.Int),
			                new SqlParameter("@AlarmDesc", SqlDbType.NVarChar, 50),
                            new SqlParameter("@AuxAlarmDesc", SqlDbType.NVarChar, 500),
                            new SqlParameter("@StartTime", SqlDbType.DateTime),
			                new SqlParameter("@EndTime", SqlDbType.DateTime),
			                new SqlParameter("@ConfirmName", SqlDbType.NVarChar, 50),
			                new SqlParameter("@ConfirmMarking", SqlDbType.Int),
			                new SqlParameter("@ConfirmTime", SqlDbType.DateTime),
                            new SqlParameter("@AuxSet", SqlDbType.NVarChar, 100),
                            new SqlParameter("@TaskID", SqlDbType.NVarChar, 100),
                            new SqlParameter("@ProjName", SqlDbType.NVarChar, 50),
                            new SqlParameter("@TurnCount", SqlDbType.Int),
                            new SqlParameter("@UpdateTime", SqlDbType.DateTime)};

                        foreach(AlarmInfo alarm in alarms) {
                            parms[0].Value = alarm.LscID;

                            if(alarm.SerialNO != ComUtility.DefaultInt32)
                                parms[1].Value = alarm.SerialNO;
                            else
                                parms[1].Value = DBNull.Value;

                            if(alarm.Area1Name != ComUtility.DefaultString)
                                parms[2].Value = alarm.Area1Name;
                            else
                                parms[2].Value = DBNull.Value;

                            if(alarm.Area2Name != ComUtility.DefaultString)
                                parms[3].Value = alarm.Area2Name;
                            else
                                parms[3].Value = DBNull.Value;

                            if(alarm.Area3Name != ComUtility.DefaultString)
                                parms[4].Value = alarm.Area3Name;
                            else
                                parms[4].Value = DBNull.Value;

                            if(alarm.Area4Name != ComUtility.DefaultString)
                                parms[5].Value = alarm.Area4Name;
                            else
                                parms[5].Value = DBNull.Value;

                            if(alarm.StaName != ComUtility.DefaultString)
                                parms[6].Value = alarm.StaName;
                            else
                                parms[6].Value = DBNull.Value;

                            if(alarm.DevName != ComUtility.DefaultString)
                                parms[7].Value = alarm.DevName;
                            else
                                parms[7].Value = DBNull.Value;

                            if(alarm.DevDesc != ComUtility.DefaultString)
                                parms[8].Value = alarm.DevDesc;
                            else
                                parms[8].Value = DBNull.Value;

                            if(alarm.NodeID != ComUtility.DefaultInt32)
                                parms[9].Value = alarm.NodeID;
                            else
                                parms[9].Value = DBNull.Value;

                            if(alarm.NodeType != EnmNodeType.Null)
                                parms[10].Value = (int)alarm.NodeType;
                            else
                                parms[10].Value = DBNull.Value;

                            if(alarm.NodeName != ComUtility.DefaultString)
                                parms[11].Value = alarm.NodeName;
                            else
                                parms[11].Value = DBNull.Value;

                            if(alarm.AlarmID != ComUtility.DefaultInt32)
                                parms[12].Value = alarm.AlarmID;
                            else
                                parms[12].Value = DBNull.Value;

                            if(alarm.AlarmValue != ComUtility.DefaultFloat)
                                parms[13].Value = alarm.AlarmValue;
                            else
                                parms[13].Value = DBNull.Value;

                            if(alarm.AlarmLevel != EnmAlarmLevel.Null)
                                parms[14].Value = (int)alarm.AlarmLevel;
                            else
                                parms[14].Value = DBNull.Value;

                            if(alarm.AlarmStatus != EnmAlarmStatus.Null)
                                parms[15].Value = (int)alarm.AlarmStatus;
                            else
                                parms[15].Value = DBNull.Value;

                            if(alarm.AlarmDesc != ComUtility.DefaultString)
                                parms[16].Value = alarm.AlarmDesc;
                            else
                                parms[16].Value = DBNull.Value;

                            if(alarm.AuxAlarmDesc != ComUtility.DefaultString)
                                parms[17].Value = alarm.AuxAlarmDesc;
                            else
                                parms[17].Value = DBNull.Value;

                            if(alarm.StartTime != ComUtility.DefaultDateTime)
                                parms[18].Value = alarm.StartTime;
                            else
                                parms[18].Value = DBNull.Value;

                            if(alarm.EndTime != ComUtility.DefaultDateTime)
                                parms[19].Value = alarm.EndTime;
                            else
                                parms[19].Value = DBNull.Value;

                            if(alarm.ConfirmName != ComUtility.DefaultString)
                                parms[20].Value = alarm.ConfirmName;
                            else
                                parms[20].Value = DBNull.Value;

                            if(alarm.ConfirmMarking != EnmConfirmMarking.Null)
                                parms[21].Value = (short)alarm.ConfirmMarking;
                            else
                                parms[21].Value = DBNull.Value;

                            if(alarm.ConfirmTime != ComUtility.DefaultDateTime)
                                parms[22].Value = alarm.ConfirmTime;
                            else
                                parms[22].Value = DBNull.Value;

                            if(alarm.AuxSet != ComUtility.DefaultString)
                                parms[23].Value = alarm.AuxSet;
                            else
                                parms[23].Value = DBNull.Value;

                            if(alarm.TaskID != ComUtility.DefaultString)
                                parms[24].Value = alarm.TaskID;
                            else
                                parms[24].Value = DBNull.Value;

                            if(alarm.ProjName != ComUtility.DefaultString)
                                parms[25].Value = alarm.ProjName;
                            else
                                parms[25].Value = DBNull.Value;

                            if(alarm.TurnCount != ComUtility.DefaultInt32)
                                parms[26].Value = alarm.TurnCount;
                            else
                                parms[26].Value = DBNull.Value;

                            if(alarm.UpdateTime != ComUtility.DefaultDateTime)
                                parms[27].Value = alarm.UpdateTime;
                            else
                                parms[27].Value = DBNull.Value;

                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_INSERT_ALARM_ADDALARMS, parms);
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

        /// <summary>
        /// Method to update alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        /// <returns>Affected rows</returns>
        public int UpdateAlarms(IList<AlarmInfo> alarms) {
            int rowCnt = 0;
            try {
                using(SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = {					   
			                new SqlParameter("@LscID", SqlDbType.Int),
			                new SqlParameter("@SerialNO", SqlDbType.Int),
			                new SqlParameter("@Area1Name", SqlDbType.NVarChar, 50),
			                new SqlParameter("@Area2Name", SqlDbType.NVarChar, 50),
			                new SqlParameter("@Area3Name", SqlDbType.NVarChar, 50),
			                new SqlParameter("@Area4Name", SqlDbType.NVarChar, 50),
			                new SqlParameter("@StaName", SqlDbType.NVarChar, 50),
			                new SqlParameter("@DevName", SqlDbType.NVarChar, 50),
                            new SqlParameter("@DevDesc", SqlDbType.NVarChar, 50),
                            new SqlParameter("@NodeID", SqlDbType.Int),
			                new SqlParameter("@NodeType", SqlDbType.Int),
			                new SqlParameter("@NodeName", SqlDbType.NVarChar, 50),
			                new SqlParameter("@AlarmID", SqlDbType.Int),
                            new SqlParameter("@AlarmValue", SqlDbType.Real),
			                new SqlParameter("@AlarmLevel", SqlDbType.Int),
                            new SqlParameter("@AlarmStatus", SqlDbType.Int),
			                new SqlParameter("@AlarmDesc", SqlDbType.NVarChar, 50),
                            new SqlParameter("@AuxAlarmDesc", SqlDbType.NVarChar, 500),
                            new SqlParameter("@StartTime", SqlDbType.DateTime),
			                new SqlParameter("@EndTime", SqlDbType.DateTime),
			                new SqlParameter("@ConfirmName", SqlDbType.NVarChar, 50),
			                new SqlParameter("@ConfirmMarking", SqlDbType.Int),
			                new SqlParameter("@ConfirmTime", SqlDbType.DateTime),
                            new SqlParameter("@AuxSet", SqlDbType.NVarChar, 100),
                            new SqlParameter("@TaskID", SqlDbType.NVarChar, 100),
                            new SqlParameter("@ProjName", SqlDbType.NVarChar, 50),
                            new SqlParameter("@TurnCount", SqlDbType.Int),
                            new SqlParameter("@UpdateTime", SqlDbType.DateTime)};

                        foreach(AlarmInfo alarm in alarms) {
                            parms[0].Value = alarm.LscID;

                            if(alarm.SerialNO != ComUtility.DefaultInt32)
                                parms[1].Value = alarm.SerialNO;
                            else
                                parms[1].Value = DBNull.Value;

                            if(alarm.Area1Name != ComUtility.DefaultString)
                                parms[2].Value = alarm.Area1Name;
                            else
                                parms[2].Value = DBNull.Value;

                            if(alarm.Area2Name != ComUtility.DefaultString)
                                parms[3].Value = alarm.Area2Name;
                            else
                                parms[3].Value = DBNull.Value;

                            if(alarm.Area3Name != ComUtility.DefaultString)
                                parms[4].Value = alarm.Area3Name;
                            else
                                parms[4].Value = DBNull.Value;

                            if(alarm.Area4Name != ComUtility.DefaultString)
                                parms[5].Value = alarm.Area4Name;
                            else
                                parms[5].Value = DBNull.Value;

                            if(alarm.StaName != ComUtility.DefaultString)
                                parms[6].Value = alarm.StaName;
                            else
                                parms[6].Value = DBNull.Value;

                            if(alarm.DevName != ComUtility.DefaultString)
                                parms[7].Value = alarm.DevName;
                            else
                                parms[7].Value = DBNull.Value;

                            if(alarm.DevDesc != ComUtility.DefaultString)
                                parms[8].Value = alarm.DevDesc;
                            else
                                parms[8].Value = DBNull.Value;

                            if(alarm.NodeID != ComUtility.DefaultInt32)
                                parms[9].Value = alarm.NodeID;
                            else
                                parms[9].Value = DBNull.Value;

                            if(alarm.NodeType != EnmNodeType.Null)
                                parms[10].Value = (int)alarm.NodeType;
                            else
                                parms[10].Value = DBNull.Value;

                            if(alarm.NodeName != ComUtility.DefaultString)
                                parms[11].Value = alarm.NodeName;
                            else
                                parms[11].Value = DBNull.Value;

                            if(alarm.AlarmID != ComUtility.DefaultInt32)
                                parms[12].Value = alarm.AlarmID;
                            else
                                parms[12].Value = DBNull.Value;

                            if(alarm.AlarmValue != ComUtility.DefaultFloat)
                                parms[13].Value = alarm.AlarmValue;
                            else
                                parms[13].Value = DBNull.Value;

                            if(alarm.AlarmLevel != EnmAlarmLevel.Null)
                                parms[14].Value = (int)alarm.AlarmLevel;
                            else
                                parms[14].Value = DBNull.Value;

                            if(alarm.AlarmStatus != EnmAlarmStatus.Null)
                                parms[15].Value = (int)alarm.AlarmStatus;
                            else
                                parms[15].Value = DBNull.Value;

                            if(alarm.AlarmDesc != ComUtility.DefaultString)
                                parms[16].Value = alarm.AlarmDesc;
                            else
                                parms[16].Value = DBNull.Value;

                            if(alarm.AuxAlarmDesc != ComUtility.DefaultString)
                                parms[17].Value = alarm.AuxAlarmDesc;
                            else
                                parms[17].Value = DBNull.Value;

                            if(alarm.StartTime != ComUtility.DefaultDateTime)
                                parms[18].Value = alarm.StartTime;
                            else
                                parms[18].Value = DBNull.Value;

                            if(alarm.EndTime != ComUtility.DefaultDateTime)
                                parms[19].Value = alarm.EndTime;
                            else
                                parms[19].Value = DBNull.Value;

                            if(alarm.ConfirmName != ComUtility.DefaultString)
                                parms[20].Value = alarm.ConfirmName;
                            else
                                parms[20].Value = DBNull.Value;

                            if(alarm.ConfirmMarking != EnmConfirmMarking.Null)
                                parms[21].Value = (short)alarm.ConfirmMarking;
                            else
                                parms[21].Value = DBNull.Value;

                            if(alarm.ConfirmTime != ComUtility.DefaultDateTime)
                                parms[22].Value = alarm.ConfirmTime;
                            else
                                parms[22].Value = DBNull.Value;

                            if(alarm.AuxSet != ComUtility.DefaultString)
                                parms[23].Value = alarm.AuxSet;
                            else
                                parms[23].Value = DBNull.Value;

                            if(alarm.TaskID != ComUtility.DefaultString)
                                parms[24].Value = alarm.TaskID;
                            else
                                parms[24].Value = DBNull.Value;

                            if(alarm.ProjName != ComUtility.DefaultString)
                                parms[25].Value = alarm.ProjName;
                            else
                                parms[25].Value = DBNull.Value;

                            if(alarm.TurnCount != ComUtility.DefaultInt32)
                                parms[26].Value = alarm.TurnCount;
                            else
                                parms[26].Value = DBNull.Value;

                            if(alarm.UpdateTime != ComUtility.DefaultDateTime)
                                parms[27].Value = alarm.UpdateTime;
                            else
                                parms[27].Value = DBNull.Value;

                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_UPDATE_ALARM_UPDATEALARMS, parms);
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

        /// <summary>
        /// Method to delete alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        /// <returns>Affected rows</returns>
        public int DeleteAlarms(IList<AlarmInfo> alarms) {
            int rowCnt = 0;
            try {
                using(SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = {					   
			                new SqlParameter("@LscID", SqlDbType.Int),
			                new SqlParameter("@SerialNO", SqlDbType.Int)};

                        foreach(AlarmInfo alarm in alarms) {
                            parms[0].Value = alarm.LscID;
                            if(alarm.SerialNO != ComUtility.DefaultInt32)
                                parms[1].Value = alarm.SerialNO;
                            else
                                parms[1].Value = DBNull.Value;

                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_ALARM_DELETEALARMS, parms);
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

        /// <summary>
        /// Delete all alarms
        /// </summary>
        public void Purge() {
            try {
                using(SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_ALARM_PURGE, null);
                        trans.Commit();
                    } catch {
                        trans.Rollback();
                        throw;
                    } finally {
                        conn.Close();
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete lsc alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        public void Purge(int lscId) {
            try {
                using(SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_ALARM_LSCPURGE, parms);
                        trans.Commit();
                    }
                    catch {
                        trans.Rollback();
                        throw;
                    }
                    finally {
                        conn.Close();
                    }
                }
            }
            catch {
                throw;
            }
        }
    }
}
