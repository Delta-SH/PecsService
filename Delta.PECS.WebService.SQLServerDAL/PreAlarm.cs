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
    public class PreAlarm : IPreAlarm
    {
        /// <summary>
        /// Syn Trend Alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>Trend Alarms</returns>
        public List<TrendAlarmInfo> SynTrendAlarms(int lscId, string connectionString) {
            SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
            parms[0].Value = lscId;

            var alarms = new List<TrendAlarmInfo>();
            SqlHelper.TestConnection(connectionString);
            using (var dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_ALARM_SYNTRENDALARMS, parms)) {
                if (dt != null && dt.Rows.Count > 0) {
                    foreach (DataRow dr in dt.Rows) {
                        var alarm = new TrendAlarmInfo();
                        alarm.LscID = ComUtility.DBNullInt32Handler(dr["LscID"]);
                        alarm.Area1Name = ComUtility.DBNullStringHandler(dr["Area1Name"]);
                        alarm.Area2Name = ComUtility.DBNullStringHandler(dr["Area2Name"]);
                        alarm.Area3Name = ComUtility.DBNullStringHandler(dr["Area3Name"]);
                        alarm.Area4Name = String.Empty;
                        alarm.StaName = ComUtility.DBNullStringHandler(dr["StaName"]);
                        alarm.DevName = ComUtility.DBNullStringHandler(dr["DevName"]);
                        alarm.NodeID = ComUtility.DBNullInt32Handler(dr["NodeID"]);
                        alarm.NodeType = EnmNodeType.Aic;
                        alarm.NodeName = ComUtility.DBNullStringHandler(dr["NodeName"]);
                        alarm.AlarmType = ComUtility.DBNullStringHandler(dr["AlarmType"]);
                        alarm.AlarmStatus = ComUtility.DBNullInt32Handler(dr["AlarmStatus"]);
                        alarm.AlarmLevel = ComUtility.DBNullInt32Handler(dr["AlarmLevel"]);
                        alarm.StartValue = ComUtility.DBNullFloatHandler(dr["StartValue"]);
                        alarm.AlarmValue = ComUtility.DBNullFloatHandler(dr["AlarmValue"]);
                        alarm.DiffValue = ComUtility.DBNullFloatHandler(dr["DiffValue"]);
                        alarm.StartTime = ComUtility.DBNullDateTimeHandler(dr["StartTime"]);
                        alarm.AlarmTime = ComUtility.DBNullDateTimeHandler(dr["AlarmTime"]);
                        alarm.EventTime = ComUtility.DBNullDateTimeHandler(dr["EventTime"]);
                        alarm.ConfirmName = ComUtility.DBNullStringHandler(dr["ConfirmName"]);
                        alarm.ConfirmTime = ComUtility.DBNullDateTimeHandler(dr["ConfirmTime"]);
                        alarm.EndName = ComUtility.DBNullStringHandler(dr["EndName"]);
                        alarm.EndTime = ComUtility.DBNullDateTimeHandler(dr["EndTime"]);
                        alarm.StartIsAddAlarmList = ComUtility.DBNullBooleanHandler(dr["StartIsAddAlarmList"]);
                        alarm.EndIsAddAlarmList = ComUtility.DBNullBooleanHandler(dr["EndIsAddAlarmList"]);
                        alarm.ConfirmIsAddAlarmList = ComUtility.DBNullBooleanHandler(dr["ConfirmIsAddAlarmList"]);
                        alarms.Add(alarm);
                    }

                    SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_TrendAlarm, dt);
                }
            }

            return alarms;
        }

        /// <summary>
        /// Method to save trend alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        public void SaveTrendAlarms(List<TrendAlarmInfo> alarms) {
            using (var conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = {new SqlParameter("@LscID", SqlDbType.Int),
		                                        new SqlParameter("@Area1Name", SqlDbType.NVarChar, 50),
		                                        new SqlParameter("@Area2Name", SqlDbType.NVarChar, 50),
		                                        new SqlParameter("@Area3Name", SqlDbType.NVarChar, 50),
		                                        new SqlParameter("@Area4Name", SqlDbType.NVarChar, 50),
		                                        new SqlParameter("@StaName", SqlDbType.NVarChar, 50),
		                                        new SqlParameter("@DevName", SqlDbType.NVarChar, 50),
                                                new SqlParameter("@NodeID", SqlDbType.Int),
		                                        new SqlParameter("@NodeType", SqlDbType.Int),
		                                        new SqlParameter("@NodeName", SqlDbType.NVarChar, 50),
		                                        new SqlParameter("@AlarmType", SqlDbType.NVarChar, 20),
                                                new SqlParameter("@AlarmStatus", SqlDbType.Int),
		                                        new SqlParameter("@AlarmLevel", SqlDbType.Int),
                                                new SqlParameter("@StartValue", SqlDbType.Real),
		                                        new SqlParameter("@AlarmValue", SqlDbType.Real),
                                                new SqlParameter("@DiffValue", SqlDbType.Real),
                                                new SqlParameter("@StartTime", SqlDbType.DateTime),
                                                new SqlParameter("@AlarmTime", SqlDbType.DateTime),
                                                new SqlParameter("@EventTime", SqlDbType.DateTime),
		                                        new SqlParameter("@ConfirmName", SqlDbType.NVarChar, 20),
		                                        new SqlParameter("@ConfirmTime", SqlDbType.DateTime),
                                                new SqlParameter("@EndName", SqlDbType.NVarChar, 20),
                                                new SqlParameter("@EndTime", SqlDbType.DateTime),
                                                new SqlParameter("@StartIsAddAlarmList", SqlDbType.Bit),
                                                new SqlParameter("@EndIsAddAlarmList", SqlDbType.Bit),
                                                new SqlParameter("@ConfirmIsAddAlarmList", SqlDbType.Bit) };

                        foreach (var alarm in alarms) {
                            parms[0].Value = alarm.LscID;
                            parms[1].Value = ComUtility.DBNullStringChecker(alarm.Area1Name);
                            parms[2].Value = ComUtility.DBNullStringChecker(alarm.Area2Name);
                            parms[3].Value = ComUtility.DBNullStringChecker(alarm.Area3Name);
                            parms[4].Value = ComUtility.DBNullStringChecker(alarm.Area4Name);
                            parms[5].Value = ComUtility.DBNullStringChecker(alarm.StaName);
                            parms[6].Value = ComUtility.DBNullStringChecker(alarm.DevName);
                            parms[7].Value = alarm.NodeID;
                            parms[8].Value = alarm.NodeType;
                            parms[9].Value = ComUtility.DBNullStringChecker(alarm.NodeName);
                            parms[10].Value = ComUtility.DBNullStringChecker(alarm.AlarmType);
                            parms[11].Value = ComUtility.DBNullInt32Checker(alarm.AlarmStatus);
                            parms[12].Value = ComUtility.DBNullInt32Checker(alarm.AlarmLevel);
                            parms[13].Value = ComUtility.DBNullFloatHandler(alarm.StartValue);
                            parms[14].Value = ComUtility.DBNullFloatHandler(alarm.AlarmValue);
                            parms[15].Value = ComUtility.DBNullFloatHandler(alarm.DiffValue);
                            parms[16].Value = ComUtility.DBNullDateTimeChecker(alarm.StartTime);
                            parms[17].Value = ComUtility.DBNullDateTimeChecker(alarm.AlarmTime);
                            parms[18].Value = ComUtility.DBNullDateTimeChecker(alarm.EventTime);
                            parms[19].Value = ComUtility.DBNullStringChecker(alarm.ConfirmName);
                            parms[20].Value = ComUtility.DBNullDateTimeChecker(alarm.ConfirmTime);
                            parms[21].Value = ComUtility.DBNullStringChecker(alarm.EndName);
                            parms[22].Value = ComUtility.DBNullDateTimeChecker(alarm.EndTime);
                            parms[23].Value = alarm.StartIsAddAlarmList;
                            parms[24].Value = alarm.EndIsAddAlarmList;
                            parms[25].Value = alarm.ConfirmIsAddAlarmList;

                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_INSERT_ALARM_SAVETRENDALARMS, parms);
                        }

                        trans.Commit();
                    } catch {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Method to delete trend alarms information
        /// </summary>
        /// <param name="alarms">alarms</param>
        public void DeleteTrendAlarms(List<TrendAlarmInfo> alarms) {
            using (var conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@NodeID", SqlDbType.Int)};

                        foreach (var alarm in alarms) {
                            parms[0].Value = alarm.LscID;
                            parms[1].Value = alarm.NodeID;
                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_ALARM_DELETETRENDALARMS, parms);
                        }

                        trans.Commit();
                    } catch {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Method to clear all trend alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        public void ClearTrendAlarms(int lscId) {
            using (var conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_ALARM_CLEARLSCTRENDALARMS, parms);
                        trans.Commit();
                    } catch {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Method to clear all trend alarms
        /// </summary>
        public void ClearTrendAlarms() {
            using (var conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_ALARM_CLEARTRENDALARMS, null);
                        trans.Commit();
                    } catch {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Syn Load Alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>Load Alarms</returns>
        public List<LoadAlarmInfo> SynLoadAlarms(int lscId, string connectionString) {
            SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
            parms[0].Value = lscId;

            var alarms = new List<LoadAlarmInfo>();
            SqlHelper.TestConnection(connectionString);
            using (var dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_ALARM_SYNLOADALARMS, parms)) {
                if (dt != null && dt.Rows.Count > 0) {
                    foreach (DataRow dr in dt.Rows) {
                        var alarm = new LoadAlarmInfo();
                        alarm.LscID = ComUtility.DBNullInt32Handler(dr["LscID"]);
                        alarm.Area1Name = ComUtility.DBNullStringHandler(dr["Area1Name"]);
                        alarm.Area2Name = ComUtility.DBNullStringHandler(dr["Area2Name"]);
                        alarm.Area3Name = ComUtility.DBNullStringHandler(dr["Area3Name"]);
                        alarm.Area4Name = String.Empty;
                        alarm.StaName = ComUtility.DBNullStringHandler(dr["StaName"]);
                        alarm.DevID = ComUtility.DBNullInt32Handler(dr["DevID"]);
                        alarm.DevName = ComUtility.DBNullStringHandler(dr["DevName"]);
                        alarm.DevTypeID = ComUtility.DBNullInt32Handler(dr["DevTypeID"]);
                        alarm.AlarmStatus = ComUtility.DBNullInt32Handler(dr["AlarmStatus"]);
                        alarm.AlarmLevel = ComUtility.DBNullInt32Handler(dr["AlarmLevel"]);
                        alarm.RateValue = ComUtility.DBNullFloatHandler(dr["RateValue"]);
                        alarm.LoadValue = ComUtility.DBNullFloatHandler(dr["LoadValue"]);
                        alarm.LoadPercent = ComUtility.DBNullFloatHandler(dr["LoadPercent"]);
                        alarm.RightPercent = ComUtility.DBNullFloatHandler(dr["RightPercent"]);
                        alarm.StartTime = ComUtility.DBNullDateTimeHandler(dr["StartTime"]);
                        alarm.EventTime = ComUtility.DBNullDateTimeHandler(dr["EventTime"]);
                        alarm.ConfirmName = ComUtility.DBNullStringHandler(dr["ConfirmName"]);
                        alarm.ConfirmTime = ComUtility.DBNullDateTimeHandler(dr["ConfirmTime"]);
                        alarm.EndName = ComUtility.DBNullStringHandler(dr["EndName"]);
                        alarm.EndTime = ComUtility.DBNullDateTimeHandler(dr["EndTime"]);
                        alarm.StartIsAddAlarmList = ComUtility.DBNullBooleanHandler(dr["StartIsAddAlarmList"]);
                        alarm.EndIsAddAlarmList = ComUtility.DBNullBooleanHandler(dr["EndIsAddAlarmList"]);
                        alarm.ConfirmIsAddAlarmList = ComUtility.DBNullBooleanHandler(dr["ConfirmIsAddAlarmList"]);
                        alarms.Add(alarm);
                    }

                    SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_LoadAlarm, dt);
                }
            }

            return alarms;
        }

        /// <summary>
        /// Method to save load alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        public void SaveLoadAlarms(List<LoadAlarmInfo> alarms) {
            using (var conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = {new SqlParameter("@LscID", SqlDbType.Int),
		                                        new SqlParameter("@Area1Name", SqlDbType.NVarChar, 50),
		                                        new SqlParameter("@Area2Name", SqlDbType.NVarChar, 50),
		                                        new SqlParameter("@Area3Name", SqlDbType.NVarChar, 50),
		                                        new SqlParameter("@Area4Name", SqlDbType.NVarChar, 50),
		                                        new SqlParameter("@StaName", SqlDbType.NVarChar, 50),
                                                new SqlParameter("@DevID", SqlDbType.Int),
		                                        new SqlParameter("@DevName", SqlDbType.NVarChar, 50),
		                                        new SqlParameter("@DevTypeID", SqlDbType.Int),
                                                new SqlParameter("@AlarmStatus", SqlDbType.Int),
		                                        new SqlParameter("@AlarmLevel", SqlDbType.Int),
                                                new SqlParameter("@RateValue", SqlDbType.Real),
		                                        new SqlParameter("@LoadValue", SqlDbType.Real),
                                                new SqlParameter("@LoadPercent", SqlDbType.Real),
                                                new SqlParameter("@RightPercent", SqlDbType.Real),
                                                new SqlParameter("@StartTime", SqlDbType.DateTime),
                                                new SqlParameter("@EventTime", SqlDbType.DateTime),
		                                        new SqlParameter("@ConfirmName", SqlDbType.NVarChar, 20),
		                                        new SqlParameter("@ConfirmTime", SqlDbType.DateTime),
                                                new SqlParameter("@EndName", SqlDbType.NVarChar, 20),
                                                new SqlParameter("@EndTime", SqlDbType.DateTime),
                                                new SqlParameter("@StartIsAddAlarmList", SqlDbType.Bit),
                                                new SqlParameter("@EndIsAddAlarmList", SqlDbType.Bit),
                                                new SqlParameter("@ConfirmIsAddAlarmList", SqlDbType.Bit) };

                        foreach (var alarm in alarms) {
                            parms[0].Value = alarm.LscID;
                            parms[1].Value = ComUtility.DBNullStringChecker(alarm.Area1Name);
                            parms[2].Value = ComUtility.DBNullStringChecker(alarm.Area2Name);
                            parms[3].Value = ComUtility.DBNullStringChecker(alarm.Area3Name);
                            parms[4].Value = ComUtility.DBNullStringChecker(alarm.Area4Name);
                            parms[5].Value = ComUtility.DBNullStringChecker(alarm.StaName);
                            parms[6].Value = alarm.DevID;
                            parms[7].Value = ComUtility.DBNullStringChecker(alarm.DevName);
                            parms[8].Value = ComUtility.DBNullInt32Checker(alarm.DevTypeID);
                            parms[9].Value = ComUtility.DBNullInt32Checker(alarm.AlarmStatus);
                            parms[10].Value = ComUtility.DBNullInt32Checker(alarm.AlarmLevel);
                            parms[11].Value = ComUtility.DBNullFloatHandler(alarm.RateValue);
                            parms[12].Value = ComUtility.DBNullFloatHandler(alarm.LoadValue);
                            parms[13].Value = ComUtility.DBNullFloatHandler(alarm.LoadPercent);
                            parms[14].Value = ComUtility.DBNullFloatHandler(alarm.RightPercent);
                            parms[15].Value = ComUtility.DBNullDateTimeChecker(alarm.StartTime);
                            parms[16].Value = ComUtility.DBNullDateTimeChecker(alarm.EventTime);
                            parms[17].Value = ComUtility.DBNullStringChecker(alarm.ConfirmName);
                            parms[18].Value = ComUtility.DBNullDateTimeChecker(alarm.ConfirmTime);
                            parms[19].Value = ComUtility.DBNullStringChecker(alarm.EndName);
                            parms[20].Value = ComUtility.DBNullDateTimeChecker(alarm.EndTime);
                            parms[21].Value = alarm.StartIsAddAlarmList;
                            parms[22].Value = alarm.EndIsAddAlarmList;
                            parms[23].Value = alarm.ConfirmIsAddAlarmList;

                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_INSERT_ALARM_SAVELOADALARMS, parms);
                        }

                        trans.Commit();
                    } catch {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Method to delete load alarms information
        /// </summary>
        /// <param name="alarms">alarms</param>
        public void DeleteLoadAlarms(List<LoadAlarmInfo> alarms) {
            using (var conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@DevID", SqlDbType.Int)};

                        foreach (var alarm in alarms) {
                            parms[0].Value = alarm.LscID;
                            parms[1].Value = alarm.DevID;
                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_ALARM_DELETELOADALARMS, parms);
                        }

                        trans.Commit();
                    } catch {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Method to clear all load alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        public void ClearLoadAlarms(int lscId) {
            using (var conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_ALARM_CLEARLSCLOADALARMS, parms);
                        trans.Commit();
                    } catch {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Method to clear all load alarms
        /// </summary>
        public void ClearLoadAlarms() {
            using (var conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_ALARM_CLEARLOADALARMS, null);
                        trans.Commit();
                    } catch {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Syn Frequency Alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>Frequency Alarms</returns>
        public List<FrequencyAlarmInfo> SynFrequencyAlarms(int lscId, string connectionString) {
            SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
            parms[0].Value = lscId;

            var alarms = new List<FrequencyAlarmInfo>();
            SqlHelper.TestConnection(connectionString);
            using (var dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_ALARM_SYNFREQUENCYALARMS, parms)) {
                if (dt != null && dt.Rows.Count > 0) {
                    foreach (DataRow dr in dt.Rows) {
                        var alarm = new FrequencyAlarmInfo();
                        alarm.LscID = ComUtility.DBNullInt32Handler(dr["LscID"]);
                        alarm.Area1Name = ComUtility.DBNullStringHandler(dr["Area1Name"]);
                        alarm.Area2Name = ComUtility.DBNullStringHandler(dr["Area2Name"]);
                        alarm.Area3Name = ComUtility.DBNullStringHandler(dr["Area3Name"]);
                        alarm.Area4Name = String.Empty;
                        alarm.StaName = ComUtility.DBNullStringHandler(dr["StaName"]);
                        alarm.DevName = ComUtility.DBNullStringHandler(dr["DevName"]);
                        alarm.NodeID = ComUtility.DBNullInt32Handler(dr["NodeID"]);
                        alarm.NodeType = ComUtility.DBNullNodeTypeHandler(dr["NodeType"]);
                        alarm.NodeName = ComUtility.DBNullStringHandler(dr["NodeName"]);
                        alarm.AlarmStatus = ComUtility.DBNullInt32Handler(dr["AlarmStatus"]);
                        alarm.AlarmLevel = ComUtility.DBNullInt32Handler(dr["AlarmLevel"]);
                        alarm.FreAlarmValue = ComUtility.DBNullInt32Handler(dr["FreAlarmValue"]);
                        alarm.FreRightValue = ComUtility.DBNullInt32Handler(dr["FreRightValue"]);
                        alarm.FreCompareValue = ComUtility.DBNullInt32Handler(dr["FreCompareValue"]);
                        alarm.StartTime = ComUtility.DBNullDateTimeHandler(dr["StartTime"]);
                        alarm.AlarmTime = ComUtility.DBNullDateTimeHandler(dr["AlarmTime"]);
                        alarm.EventTime = ComUtility.DBNullDateTimeHandler(dr["EventTime"]);
                        alarm.ConfirmName = ComUtility.DBNullStringHandler(dr["ConfirmName"]);
                        alarm.ConfirmTime = ComUtility.DBNullDateTimeHandler(dr["ConfirmTime"]);
                        alarm.EndName = ComUtility.DBNullStringHandler(dr["EndName"]);
                        alarm.EndTime = ComUtility.DBNullDateTimeHandler(dr["EndTime"]);
                        alarm.StartIsAddAlarmList = ComUtility.DBNullBooleanHandler(dr["StartIsAddAlarmList"]);
                        alarm.EndIsAddAlarmList = ComUtility.DBNullBooleanHandler(dr["EndIsAddAlarmList"]);
                        alarm.ConfirmIsAddAlarmList = ComUtility.DBNullBooleanHandler(dr["ConfirmIsAddAlarmList"]);
                        alarms.Add(alarm);
                    }

                    SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_FrequencyAlarm, dt);
                }
            }

            return alarms;
        }

        /// <summary>
        /// Method to save frequency alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        public void SaveFrequencyAlarms(List<FrequencyAlarmInfo> alarms) {
            using (var conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = {new SqlParameter("@LscID", SqlDbType.Int),
		                                        new SqlParameter("@Area1Name", SqlDbType.NVarChar, 50),
		                                        new SqlParameter("@Area2Name", SqlDbType.NVarChar, 50),
		                                        new SqlParameter("@Area3Name", SqlDbType.NVarChar, 50),
		                                        new SqlParameter("@Area4Name", SqlDbType.NVarChar, 50),
		                                        new SqlParameter("@StaName", SqlDbType.NVarChar, 50),
		                                        new SqlParameter("@DevName", SqlDbType.NVarChar, 50),
                                                new SqlParameter("@NodeID", SqlDbType.Int),
		                                        new SqlParameter("@NodeType", SqlDbType.Int),
		                                        new SqlParameter("@NodeName", SqlDbType.NVarChar, 50),
                                                new SqlParameter("@AlarmStatus", SqlDbType.Int),
		                                        new SqlParameter("@AlarmLevel", SqlDbType.Int),
                                                new SqlParameter("@FreAlarmValue", SqlDbType.Int),
		                                        new SqlParameter("@FreRightValue", SqlDbType.Int),
                                                new SqlParameter("@FreCompareValue", SqlDbType.Int),
                                                new SqlParameter("@StartTime", SqlDbType.DateTime),
                                                new SqlParameter("@AlarmTime", SqlDbType.DateTime),
                                                new SqlParameter("@EventTime", SqlDbType.DateTime),
		                                        new SqlParameter("@ConfirmName", SqlDbType.NVarChar, 20),
		                                        new SqlParameter("@ConfirmTime", SqlDbType.DateTime),
                                                new SqlParameter("@EndName", SqlDbType.NVarChar, 20),
                                                new SqlParameter("@EndTime", SqlDbType.DateTime),
                                                new SqlParameter("@StartIsAddAlarmList", SqlDbType.Bit),
                                                new SqlParameter("@EndIsAddAlarmList", SqlDbType.Bit),
                                                new SqlParameter("@ConfirmIsAddAlarmList", SqlDbType.Bit) };

                        foreach (var alarm in alarms) {
                            parms[0].Value = alarm.LscID;
                            parms[1].Value = ComUtility.DBNullStringChecker(alarm.Area1Name);
                            parms[2].Value = ComUtility.DBNullStringChecker(alarm.Area2Name);
                            parms[3].Value = ComUtility.DBNullStringChecker(alarm.Area3Name);
                            parms[4].Value = ComUtility.DBNullStringChecker(alarm.Area4Name);
                            parms[5].Value = ComUtility.DBNullStringChecker(alarm.StaName);
                            parms[6].Value = ComUtility.DBNullStringChecker(alarm.DevName);
                            parms[7].Value = alarm.NodeID;
                            parms[8].Value = alarm.NodeType;
                            parms[9].Value = ComUtility.DBNullStringChecker(alarm.NodeName);
                            parms[10].Value = ComUtility.DBNullInt32Checker(alarm.AlarmStatus);
                            parms[11].Value = ComUtility.DBNullInt32Checker(alarm.AlarmLevel);
                            parms[12].Value = ComUtility.DBNullInt32Checker(alarm.FreAlarmValue);
                            parms[13].Value = ComUtility.DBNullInt32Checker(alarm.FreRightValue);
                            parms[14].Value = ComUtility.DBNullInt32Checker(alarm.FreCompareValue);
                            parms[15].Value = ComUtility.DBNullDateTimeChecker(alarm.StartTime);
                            parms[16].Value = ComUtility.DBNullDateTimeChecker(alarm.AlarmTime);
                            parms[17].Value = ComUtility.DBNullDateTimeChecker(alarm.EventTime);
                            parms[18].Value = ComUtility.DBNullStringChecker(alarm.ConfirmName);
                            parms[19].Value = ComUtility.DBNullDateTimeChecker(alarm.ConfirmTime);
                            parms[20].Value = ComUtility.DBNullStringChecker(alarm.EndName);
                            parms[21].Value = ComUtility.DBNullDateTimeChecker(alarm.EndTime);
                            parms[22].Value = alarm.StartIsAddAlarmList;
                            parms[23].Value = alarm.EndIsAddAlarmList;
                            parms[24].Value = alarm.ConfirmIsAddAlarmList;

                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_INSERT_ALARM_SAVEFREQUENCYALARMS, parms);
                        }

                        trans.Commit();
                    } catch {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Method to delete frequency alarms information
        /// </summary>
        /// <param name="alarms">alarms</param>
        public void DeleteFrequencyAlarms(List<FrequencyAlarmInfo> alarms) {
            using (var conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@NodeID", SqlDbType.Int),
                                                 new SqlParameter("@NodeType", SqlDbType.Int)};

                        foreach (var alarm in alarms) {
                            parms[0].Value = alarm.LscID;
                            parms[1].Value = alarm.NodeID;
                            parms[2].Value = (Int32)alarm.NodeType;
                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_ALARM_DELETEFREQUENCYALARMS, parms);
                        }

                        trans.Commit();
                    } catch {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Method to clear all frequency alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        public void ClearFrequencyAlarms(int lscId) {
            using (var conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_ALARM_CLEARLSCFREQUENCYALARMS, parms);
                        trans.Commit();
                    } catch {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Method to clear all frequency alarms
        /// </summary>
        public void ClearFrequencyAlarms() {
            using (var conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_ALARM_CLEARFREQUENCYALARMS, null);
                        trans.Commit();
                    } catch {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
