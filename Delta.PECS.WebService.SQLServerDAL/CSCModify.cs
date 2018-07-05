using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.Model;
using Delta.PECS.WebService.DBUtility;

namespace Delta.PECS.WebService.SQLServerDAL {
    /// <summary>
    /// This class is an implementation for receiving modify information from database
    /// </summary>
    public class CSCModify : ICSCModify {
        /// <summary>
        /// Get CSC Modifies
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="startIndex">startIndex</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>CSCModifyInfo</returns>
        public List<CSCModifyInfo> GetCSCModifies(int lscId, int startIndex, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@StartIndex", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = startIndex;

                List<CSCModifyInfo> modifies = new List<CSCModifyInfo>();
                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETCSCMODIFIES, parms)) {
                    while (rdr.Read()) {
                        CSCModifyInfo modify = new CSCModifyInfo();
                        modify.LscID = ComUtility.DBNullInt32Handler(rdr["LscID"]);
                        modify.ID = ComUtility.DBNullInt32Handler(rdr["ID"]);
                        modify.NodeID = ComUtility.DBNullInt32Handler(rdr["NodeID"]);
                        modify.NodeType = ComUtility.DBNullNodeTypeHandler(rdr["NodeType"]);
                        modify.ModifyType = ComUtility.DBNullModifyTypeHandler(rdr["ModifyType"]);
                        modify.ModifyTime = ComUtility.DBNullDateTimeHandler(rdr["ModifyTime"]);

                        modifies.Add(modify);
                    }
                }

                return modifies;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Get The Max CSC Modify
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>CSCModifyInfo</returns>
        public CSCModifyInfo GetMaxCSCModify(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                CSCModifyInfo modify = null;
                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETMAXCSCMODIFY, parms)) {
                    if (rdr.Read()) {
                        modify = new CSCModifyInfo();
                        modify.LscID = ComUtility.DBNullInt32Handler(rdr["LscID"]);
                        modify.ID = ComUtility.DBNullInt32Handler(rdr["ID"]);
                        modify.NodeID = ComUtility.DBNullInt32Handler(rdr["NodeID"]);
                        modify.NodeType = ComUtility.DBNullNodeTypeHandler(rdr["NodeType"]);
                        modify.ModifyType = ComUtility.DBNullModifyTypeHandler(rdr["ModifyType"]);
                        modify.ModifyTime = ComUtility.DBNullDateTimeHandler(rdr["ModifyTime"]);
                    }
                }

                return modify;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Get Change Logs
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="startIndex">startIndex</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>ChangeLogInfo</returns>
        public List<ChangeLogInfo> GetChangeLogs(int lscId, int startIndex, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@StartIndex", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = startIndex;

                List<ChangeLogInfo> logs = new List<ChangeLogInfo>();
                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETCHANGELOGS, parms)) {
                    while (rdr.Read()) {
                        ChangeLogInfo log = new ChangeLogInfo();
                        log.LscID = ComUtility.DBNullInt32Handler(rdr["LscID"]);
                        log.LogID = ComUtility.DBNullInt32Handler(rdr["LogID"]);
                        log.TableID = ComUtility.DBNullTableIDHandler(rdr["TableID"]);
                        log.OpType = ComUtility.DBNullModifyTypeHandler(rdr["OpType"]);
                        log.OpSourceID = ComUtility.DBNullInt32Handler(rdr["OpSourceID"]);
                        log.OpDesc = ComUtility.DBNullStringHandler(rdr["OpDesc"]);
                        log.OpState = ComUtility.DBNullBooleanHandler(rdr["OpState"]);
                        log.OpTime = ComUtility.DBNullDateTimeHandler(rdr["OpTime"]);
                        log.OpCount = ComUtility.DBNullInt32Handler(rdr["OpCount"]);

                        logs.Add(log);
                    }
                }

                return logs;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Get The Max Change Log
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>ChangeLogInfo</returns>
        public ChangeLogInfo GetMaxChangeLog(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                ChangeLogInfo log = null;
                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETMAXCHANGELOG, parms)) {
                    if (rdr.Read()) {
                        log = new ChangeLogInfo();
                        log.LscID = ComUtility.DBNullInt32Handler(rdr["LscID"]);
                        log.LogID = ComUtility.DBNullInt32Handler(rdr["LogID"]);
                        log.TableID = ComUtility.DBNullTableIDHandler(rdr["TableID"]);
                        log.OpType = ComUtility.DBNullModifyTypeHandler(rdr["OpType"]);
                        log.OpSourceID = ComUtility.DBNullInt32Handler(rdr["OpSourceID"]);
                        log.OpDesc = ComUtility.DBNullStringHandler(rdr["OpDesc"]);
                        log.OpState = ComUtility.DBNullBooleanHandler(rdr["OpState"]);
                        log.OpTime = ComUtility.DBNullDateTimeHandler(rdr["OpTime"]);
                        log.OpCount = ComUtility.DBNullInt32Handler(rdr["OpCount"]);
                    }
                }

                return log;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add Area Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddArea(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@AreaID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETAREA, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@AreaID", SqlDbType.Int),
                                                            new SqlParameter("@LastAreaID", SqlDbType.Int),
                                                            new SqlParameter("@AreaName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit),
                                                            new SqlParameter("@NodeLevel", SqlDbType.Int),
                                                            new SqlParameter("@MID", SqlDbType.VarChar,100)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["AreaID"];
                                parms[2].Value = rdr["LastAreaID"];
                                parms[3].Value = rdr["AreaName"];
                                parms[4].Value = rdr["Enabled"];
                                parms[5].Value = rdr["NodeLevel"];
                                parms[6].Value = rdr["MID"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDAREA, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update Area Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateArea(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@AreaID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETAREA, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@AreaID", SqlDbType.Int),
                                                            new SqlParameter("@LastAreaID", SqlDbType.Int),
                                                            new SqlParameter("@AreaName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit),
                                                            new SqlParameter("@NodeLevel", SqlDbType.Int),
                                                            new SqlParameter("@MID", SqlDbType.VarChar,100)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["AreaID"];
                                parms[2].Value = rdr["LastAreaID"];
                                parms[3].Value = rdr["AreaName"];
                                parms[4].Value = rdr["Enabled"];
                                parms[5].Value = rdr["NodeLevel"];
                                parms[6].Value = rdr["MID"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATEAREA, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete Area Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelArea(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@AreaID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELAREA, parms);
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
        /// Add Building Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddBuilding(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@BuildingID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETBUILDING, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@BuildingID", SqlDbType.Int),
                                                            new SqlParameter("@BuildingName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@BuildingDesc", SqlDbType.VarChar,40)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["BuildingID"];
                                parms[2].Value = rdr["BuildingName"];
                                parms[3].Value = rdr["BuildingDesc"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDBUILDING, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update Building Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateBuilding(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@BuildingID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETBUILDING, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@BuildingID", SqlDbType.Int),
                                                            new SqlParameter("@BuildingName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@BuildingDesc", SqlDbType.VarChar,40)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["BuildingID"];
                                parms[2].Value = rdr["BuildingName"];
                                parms[3].Value = rdr["BuildingDesc"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATEBUILDING, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete Building Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelBuilding(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@BuildingID", SqlDbType.Int) };
                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELBUILDING, parms);
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
        /// Add Station Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddSta(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@StaID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETSTA, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@StaID", SqlDbType.Int),
                                                            new SqlParameter("@StaName", SqlDbType.VarChar,100),
                                                            new SqlParameter("@StaDesc", SqlDbType.VarChar,512),
                                                            new SqlParameter("@StaAddress", SqlDbType.VarChar,80),
                                                            new SqlParameter("@LinkMan", SqlDbType.VarChar,40),
                                                            new SqlParameter("@LinkManPhone", SqlDbType.VarChar,20),
                                                            new SqlParameter("@StaTypeID", SqlDbType.Int),
                                                            new SqlParameter("@LocationWay", SqlDbType.Int),
                                                            new SqlParameter("@Longitude", SqlDbType.Real),
                                                            new SqlParameter("@Latitude", SqlDbType.Real),
                                                            new SqlParameter("@MapDesc", SqlDbType.VarChar,400),
                                                            new SqlParameter("@STDStationID", SqlDbType.VarChar,40),
                                                            new SqlParameter("@NodeFeatures", SqlDbType.Int),
                                                            new SqlParameter("@AreaID", SqlDbType.Int),
                                                            new SqlParameter("@DeptID", SqlDbType.Int),
                                                            new SqlParameter("@MID", SqlDbType.VarChar,100),
                                                            new SqlParameter("@DevCount", SqlDbType.Int),
                                                            new SqlParameter("@StaPFACount", SqlDbType.Int),
                                                            new SqlParameter("@NetGridID", SqlDbType.Int),
                                                            new SqlParameter("@BuildingID", SqlDbType.Int),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["StaID"];
                                parms[2].Value = rdr["StaName"];
                                parms[3].Value = rdr["StaDesc"];
                                parms[4].Value = rdr["StaAddress"];
                                parms[5].Value = rdr["LinkMan"];
                                parms[6].Value = rdr["LinkManPhone"];
                                parms[7].Value = rdr["StaTypeID"];
                                parms[8].Value = rdr["LocationWay"];
                                parms[9].Value = rdr["Longitude"];
                                parms[10].Value = rdr["Latitude"];
                                parms[11].Value = rdr["MapDesc"];
                                parms[12].Value = rdr["STDStationID"];
                                parms[13].Value = rdr["NodeFeatures"];
                                parms[14].Value = rdr["AreaID"];
                                parms[15].Value = rdr["DeptID"];
                                parms[16].Value = rdr["MID"];
                                parms[17].Value = rdr["DevCount"];
                                parms[18].Value = rdr["StaPFACount"];
                                parms[19].Value = rdr["NetGridID"];
                                parms[20].Value = rdr["BuildingID"];
                                parms[21].Value = rdr["Enabled"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDSTA, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update Station Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateSta(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@StaID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETSTA, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@StaID", SqlDbType.Int),
                                                            new SqlParameter("@StaName", SqlDbType.VarChar,100),
                                                            new SqlParameter("@StaDesc", SqlDbType.VarChar,512),
                                                            new SqlParameter("@StaAddress", SqlDbType.VarChar,80),
                                                            new SqlParameter("@LinkMan", SqlDbType.VarChar,40),
                                                            new SqlParameter("@LinkManPhone", SqlDbType.VarChar,20),
                                                            new SqlParameter("@StaTypeID", SqlDbType.Int),
                                                            new SqlParameter("@LocationWay", SqlDbType.Int),
                                                            new SqlParameter("@Longitude", SqlDbType.Real),
                                                            new SqlParameter("@Latitude", SqlDbType.Real),
                                                            new SqlParameter("@MapDesc", SqlDbType.VarChar,400),
                                                            new SqlParameter("@STDStationID", SqlDbType.VarChar,40),
                                                            new SqlParameter("@NodeFeatures", SqlDbType.Int),
                                                            new SqlParameter("@AreaID", SqlDbType.Int),
                                                            new SqlParameter("@DeptID", SqlDbType.Int),
                                                            new SqlParameter("@MID", SqlDbType.VarChar,100),
                                                            new SqlParameter("@DevCount", SqlDbType.Int),
                                                            new SqlParameter("@StaPFACount", SqlDbType.Int),
                                                            new SqlParameter("@NetGridID", SqlDbType.Int),
                                                            new SqlParameter("@BuildingID", SqlDbType.Int),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["StaID"];
                                parms[2].Value = rdr["StaName"];
                                parms[3].Value = rdr["StaDesc"];
                                parms[4].Value = rdr["StaAddress"];
                                parms[5].Value = rdr["LinkMan"];
                                parms[6].Value = rdr["LinkManPhone"];
                                parms[7].Value = rdr["StaTypeID"];
                                parms[8].Value = rdr["LocationWay"];
                                parms[9].Value = rdr["Longitude"];
                                parms[10].Value = rdr["Latitude"];
                                parms[11].Value = rdr["MapDesc"];
                                parms[12].Value = rdr["STDStationID"];
                                parms[13].Value = rdr["NodeFeatures"];
                                parms[14].Value = rdr["AreaID"];
                                parms[15].Value = rdr["DeptID"];
                                parms[16].Value = rdr["MID"];
                                parms[17].Value = rdr["DevCount"];
                                parms[18].Value = rdr["StaPFACount"];
                                parms[19].Value = rdr["NetGridID"];
                                parms[20].Value = rdr["BuildingID"];
                                parms[21].Value = rdr["Enabled"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATESTA, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete Station Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelSta(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@StaID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELSTA, parms);
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
        /// Add Device Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddDev(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@DevID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETDEV, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@DevID", SqlDbType.Int),
                                                            new SqlParameter("@StaID", SqlDbType.Int),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit),
                                                            new SqlParameter("@DevName", SqlDbType.VarChar,100),
                                                            new SqlParameter("@DevDesc", SqlDbType.VarChar,512),
                                                            new SqlParameter("@DevTypeID", SqlDbType.Int),
                                                            new SqlParameter("@ProductorID", SqlDbType.Int),
                                                            new SqlParameter("@AlarmDevTypeID", SqlDbType.Int),
                                                            new SqlParameter("@Version", SqlDbType.VarChar,20),
                                                            new SqlParameter("@DevModel", SqlDbType.VarChar,40),
                                                            new SqlParameter("@BeginRunTime", SqlDbType.DateTime),
                                                            new SqlParameter("@MID", SqlDbType.VarChar,100),
                                                            new SqlParameter("@TDevID", SqlDbType.Int),
                                                            new SqlParameter("@InstallPosition", SqlDbType.VarChar,80),
                                                            new SqlParameter("@ContextDevName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@Capacity", SqlDbType.Real)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["DevID"];
                                parms[2].Value = rdr["StaID"];
                                parms[3].Value = rdr["Enabled"];
                                parms[4].Value = rdr["DevName"];
                                parms[5].Value = rdr["DevDesc"];
                                parms[6].Value = rdr["DevTypeID"];
                                parms[7].Value = rdr["ProductorID"];
                                parms[8].Value = rdr["AlarmDevTypeID"];
                                parms[9].Value = rdr["Version"];
                                parms[10].Value = rdr["DevModel"];
                                parms[11].Value = rdr["BeginRunTime"];
                                parms[12].Value = rdr["MID"];
                                parms[13].Value = rdr["TDevID"];
                                parms[14].Value = rdr["InstallPosition"];
                                parms[15].Value = rdr["ContextDevName"];
                                parms[16].Value = rdr["Capacity"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDDEV, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }

                this.AddSubDevCap(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update Device Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateDev(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@DevID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETDEV, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@DevID", SqlDbType.Int),
                                                            new SqlParameter("@StaID", SqlDbType.Int),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit),
                                                            new SqlParameter("@DevName", SqlDbType.VarChar,100),
                                                            new SqlParameter("@DevDesc", SqlDbType.VarChar,512),
                                                            new SqlParameter("@DevTypeID", SqlDbType.Int),
                                                            new SqlParameter("@ProductorID", SqlDbType.Int),
                                                            new SqlParameter("@AlarmDevTypeID", SqlDbType.Int),
                                                            new SqlParameter("@Version", SqlDbType.VarChar,20),
                                                            new SqlParameter("@DevModel", SqlDbType.VarChar,40),
                                                            new SqlParameter("@BeginRunTime", SqlDbType.DateTime),
                                                            new SqlParameter("@MID", SqlDbType.VarChar,100),
                                                            new SqlParameter("@TDevID", SqlDbType.Int),
                                                            new SqlParameter("@InstallPosition", SqlDbType.VarChar,80),
                                                            new SqlParameter("@ContextDevName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@Capacity", SqlDbType.Real)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["DevID"];
                                parms[2].Value = rdr["StaID"];
                                parms[3].Value = rdr["Enabled"];
                                parms[4].Value = rdr["DevName"];
                                parms[5].Value = rdr["DevDesc"];
                                parms[6].Value = rdr["DevTypeID"];
                                parms[7].Value = rdr["ProductorID"];
                                parms[8].Value = rdr["AlarmDevTypeID"];
                                parms[9].Value = rdr["Version"];
                                parms[10].Value = rdr["DevModel"];
                                parms[11].Value = rdr["BeginRunTime"];
                                parms[12].Value = rdr["MID"];
                                parms[13].Value = rdr["TDevID"];
                                parms[14].Value = rdr["InstallPosition"];
                                parms[15].Value = rdr["ContextDevName"];
                                parms[16].Value = rdr["Capacity"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATEDEV, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }

                this.UpdateSubDevCap(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add Device Table With Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddDevWithNodes(int lscId, int id, string connectionString) {
            try {
                this.DelDev(lscId, id, connectionString);
                this.AddDev(lscId, id, connectionString);

                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@DevID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETDEVAI, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_AI, dt);
                    }
                }

                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETDEVAO, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_AO, dt);
                    }
                }

                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETDEVDI, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_DI, dt);
                    }
                }

                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETDEVDO, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_DO, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update Device Table With Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateDevWithNodes(int lscId, int id, string connectionString) {
            try {
                this.DelDev(lscId, id, connectionString);
                this.AddDev(lscId, id, connectionString);

                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@DevID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETDEVAI, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_AI, dt);
                    }
                }

                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETDEVAO, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_AO, dt);
                    }
                }

                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETDEVDI, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_DI, dt);
                    }
                }

                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETDEVDO, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_DO, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete Device Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelDev(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@DevID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELDEV, parms);
                        trans.Commit();
                    } catch {
                        trans.Rollback();
                        throw;
                    } finally {
                        conn.Close();
                    }
                }

                this.DelSubDevCap(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add AIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddAI(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@AicID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETAI, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@AicID", SqlDbType.Int),
                                                            new SqlParameter("@AicName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@AicDesc", SqlDbType.VarChar,40),
                                                            new SqlParameter("@DevID", SqlDbType.Int),
                                                            new SqlParameter("@Unit", SqlDbType.VarChar,8),
                                                            new SqlParameter("@AuxSet", SqlDbType.VarChar,80),
                                                            new SqlParameter("@AlarmIdHL1", SqlDbType.Int),
                                                            new SqlParameter("@AlarmIdLL1", SqlDbType.Int),
                                                            new SqlParameter("@AlarmIdHL2", SqlDbType.Int),
                                                            new SqlParameter("@AlarmIdLL2", SqlDbType.Int),
                                                            new SqlParameter("@AlarmIdHL3", SqlDbType.Int),
                                                            new SqlParameter("@AlarmIdLL3", SqlDbType.Int),
                                                            new SqlParameter("@AlarmIdHL4", SqlDbType.Int),
                                                            new SqlParameter("@AlarmIdLL4", SqlDbType.Int),
                                                            new SqlParameter("@AlarmID", SqlDbType.Int),
                                                            new SqlParameter("@AlarmLevel", SqlDbType.Int),
                                                            new SqlParameter("@RtuID", SqlDbType.Int),
                                                            new SqlParameter("@DotID", SqlDbType.Int),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["AicID"];
                                parms[2].Value = rdr["AicName"];
                                parms[3].Value = rdr["AicDesc"];
                                parms[4].Value = rdr["DevID"];
                                parms[5].Value = rdr["Unit"];
                                parms[6].Value = rdr["AuxSet"];
                                parms[7].Value = rdr["AlarmIdHL1"];
                                parms[8].Value = rdr["AlarmIdLL1"];
                                parms[9].Value = rdr["AlarmIdHL2"];
                                parms[10].Value = rdr["AlarmIdLL2"];
                                parms[11].Value = rdr["AlarmIdHL3"];
                                parms[12].Value = rdr["AlarmIdLL3"];
                                parms[13].Value = rdr["AlarmIdHL4"];
                                parms[14].Value = rdr["AlarmIdLL4"];
                                parms[15].Value = rdr["AlarmID"];
                                parms[16].Value = rdr["AlarmLevel"];
                                parms[17].Value = rdr["RtuID"];
                                parms[18].Value = rdr["DotID"];
                                parms[19].Value = rdr["Enabled"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDAI, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update AIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateAI(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@AicID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETAI, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@AicID", SqlDbType.Int),
                                                            new SqlParameter("@AicName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@AicDesc", SqlDbType.VarChar,40),
                                                            new SqlParameter("@DevID", SqlDbType.Int),
                                                            new SqlParameter("@Unit", SqlDbType.VarChar,8),
                                                            new SqlParameter("@AuxSet", SqlDbType.VarChar,80),
                                                            new SqlParameter("@AlarmIdHL1", SqlDbType.Int),
                                                            new SqlParameter("@AlarmIdLL1", SqlDbType.Int),
                                                            new SqlParameter("@AlarmIdHL2", SqlDbType.Int),
                                                            new SqlParameter("@AlarmIdLL2", SqlDbType.Int),
                                                            new SqlParameter("@AlarmIdHL3", SqlDbType.Int),
                                                            new SqlParameter("@AlarmIdLL3", SqlDbType.Int),
                                                            new SqlParameter("@AlarmIdHL4", SqlDbType.Int),
                                                            new SqlParameter("@AlarmIdLL4", SqlDbType.Int),
                                                            new SqlParameter("@AlarmID", SqlDbType.Int),
                                                            new SqlParameter("@AlarmLevel", SqlDbType.Int),
                                                            new SqlParameter("@RtuID", SqlDbType.Int),
                                                            new SqlParameter("@DotID", SqlDbType.Int),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["AicID"];
                                parms[2].Value = rdr["AicName"];
                                parms[3].Value = rdr["AicDesc"];
                                parms[4].Value = rdr["DevID"];
                                parms[5].Value = rdr["Unit"];
                                parms[6].Value = rdr["AuxSet"];
                                parms[7].Value = rdr["AlarmIdHL1"];
                                parms[8].Value = rdr["AlarmIdLL1"];
                                parms[9].Value = rdr["AlarmIdHL2"];
                                parms[10].Value = rdr["AlarmIdLL2"];
                                parms[11].Value = rdr["AlarmIdHL3"];
                                parms[12].Value = rdr["AlarmIdLL3"];
                                parms[13].Value = rdr["AlarmIdHL4"];
                                parms[14].Value = rdr["AlarmIdLL4"];
                                parms[15].Value = rdr["AlarmID"];
                                parms[16].Value = rdr["AlarmLevel"];
                                parms[17].Value = rdr["RtuID"];
                                parms[18].Value = rdr["DotID"];
                                parms[19].Value = rdr["Enabled"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATEAI, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete AIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelAI(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@AicID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELAI, parms);
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
        /// Add AOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddAO(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@AocID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETAO, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@AocID", SqlDbType.Int),
                                                            new SqlParameter("@AocName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@AocDesc", SqlDbType.VarChar,40),
                                                            new SqlParameter("@DevID", SqlDbType.Int),
                                                            new SqlParameter("@Unit", SqlDbType.VarChar,8),
                                                            new SqlParameter("@AuxSet", SqlDbType.VarChar,80),
                                                            new SqlParameter("@AlarmID", SqlDbType.Int),
                                                            new SqlParameter("@RtuID", SqlDbType.Int),
                                                            new SqlParameter("@DotID", SqlDbType.Int),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["AocID"];
                                parms[2].Value = rdr["AocName"];
                                parms[3].Value = rdr["AocDesc"];
                                parms[4].Value = rdr["DevID"];
                                parms[5].Value = rdr["Unit"];
                                parms[6].Value = rdr["AuxSet"];
                                parms[7].Value = rdr["AlarmID"];
                                parms[8].Value = rdr["RtuID"];
                                parms[9].Value = rdr["DotID"];
                                parms[10].Value = rdr["Enabled"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDAO, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update AOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateAO(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@AocID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETAO, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@AocID", SqlDbType.Int),
                                                            new SqlParameter("@AocName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@AocDesc", SqlDbType.VarChar,40),
                                                            new SqlParameter("@DevID", SqlDbType.Int),
                                                            new SqlParameter("@Unit", SqlDbType.VarChar,8),
                                                            new SqlParameter("@AuxSet", SqlDbType.VarChar,80),
                                                            new SqlParameter("@AlarmID", SqlDbType.Int),
                                                            new SqlParameter("@RtuID", SqlDbType.Int),
                                                            new SqlParameter("@DotID", SqlDbType.Int),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["AocID"];
                                parms[2].Value = rdr["AocName"];
                                parms[3].Value = rdr["AocDesc"];
                                parms[4].Value = rdr["DevID"];
                                parms[5].Value = rdr["Unit"];
                                parms[6].Value = rdr["AuxSet"];
                                parms[7].Value = rdr["AlarmID"];
                                parms[8].Value = rdr["RtuID"];
                                parms[9].Value = rdr["DotID"];
                                parms[10].Value = rdr["Enabled"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATEAO, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete AOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelAO(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@AocID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELAO, parms);
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
        /// Add DIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddDI(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@DicID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETDI, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@DicID", SqlDbType.Int),
                                                            new SqlParameter("@DicName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@DicDesc", SqlDbType.VarChar,40),
                                                            new SqlParameter("@Describe", SqlDbType.VarChar,160),
                                                            new SqlParameter("@DevID", SqlDbType.Int),
                                                            new SqlParameter("@AuxSet", SqlDbType.VarChar,80),
                                                            new SqlParameter("@AlarmID", SqlDbType.Int),
                                                            new SqlParameter("@AlarmLevel", SqlDbType.Int),
                                                            new SqlParameter("@RtuID", SqlDbType.Int),
                                                            new SqlParameter("@DotID", SqlDbType.Int),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["DicID"];
                                parms[2].Value = rdr["DicName"];
                                parms[3].Value = rdr["DicDesc"];
                                parms[4].Value = rdr["Describe"];
                                parms[5].Value = rdr["DevID"];
                                parms[6].Value = rdr["AuxSet"];
                                parms[7].Value = rdr["AlarmID"];
                                parms[8].Value = rdr["AlarmLevel"];
                                parms[9].Value = rdr["RtuID"];
                                parms[10].Value = rdr["DotID"];
                                parms[11].Value = rdr["Enabled"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDDI, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update DIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateDI(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@DicID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETDI, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@DicID", SqlDbType.Int),
                                                            new SqlParameter("@DicName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@DicDesc", SqlDbType.VarChar,40),
                                                            new SqlParameter("@Describe", SqlDbType.VarChar,160),
                                                            new SqlParameter("@DevID", SqlDbType.Int),
                                                            new SqlParameter("@AuxSet", SqlDbType.VarChar,80),
                                                            new SqlParameter("@AlarmID", SqlDbType.Int),
                                                            new SqlParameter("@AlarmLevel", SqlDbType.Int),
                                                            new SqlParameter("@RtuID", SqlDbType.Int),
                                                            new SqlParameter("@DotID", SqlDbType.Int),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["DicID"];
                                parms[2].Value = rdr["DicName"];
                                parms[3].Value = rdr["DicDesc"];
                                parms[4].Value = rdr["Describe"];
                                parms[5].Value = rdr["DevID"];
                                parms[6].Value = rdr["AuxSet"];
                                parms[7].Value = rdr["AlarmID"];
                                parms[8].Value = rdr["AlarmLevel"];
                                parms[9].Value = rdr["RtuID"];
                                parms[10].Value = rdr["DotID"];
                                parms[11].Value = rdr["Enabled"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATEDI, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete DIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelDI(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@DicID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELDI, parms);
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
        /// Add DOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddDO(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@DocID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETDO, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@DocID", SqlDbType.Int),
                                                            new SqlParameter("@DocName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@DocDesc", SqlDbType.VarChar,40),
                                                            new SqlParameter("@Describe", SqlDbType.VarChar,160),
                                                            new SqlParameter("@DevID", SqlDbType.Int),
                                                            new SqlParameter("@AuxSet", SqlDbType.VarChar,80),
                                                            new SqlParameter("@AlarmID", SqlDbType.Int),
                                                            new SqlParameter("@RtuID", SqlDbType.Int),
                                                            new SqlParameter("@DotID", SqlDbType.Int),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["DocID"];
                                parms[2].Value = rdr["DocName"];
                                parms[3].Value = rdr["DocDesc"];
                                parms[4].Value = rdr["Describe"];
                                parms[5].Value = rdr["DevID"];
                                parms[6].Value = rdr["AuxSet"];
                                parms[7].Value = rdr["AlarmID"];
                                parms[8].Value = rdr["RtuID"];
                                parms[9].Value = rdr["DotID"];
                                parms[10].Value = rdr["Enabled"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDDO, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update DOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateDO(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@DocID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETDO, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@DocID", SqlDbType.Int),
                                                            new SqlParameter("@DocName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@DocDesc", SqlDbType.VarChar,40),
                                                            new SqlParameter("@Describe", SqlDbType.VarChar,160),
                                                            new SqlParameter("@DevID", SqlDbType.Int),
                                                            new SqlParameter("@AuxSet", SqlDbType.VarChar,80),
                                                            new SqlParameter("@AlarmID", SqlDbType.Int),
                                                            new SqlParameter("@RtuID", SqlDbType.Int),
                                                            new SqlParameter("@DotID", SqlDbType.Int),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["DocID"];
                                parms[2].Value = rdr["DocName"];
                                parms[3].Value = rdr["DocDesc"];
                                parms[4].Value = rdr["Describe"];
                                parms[5].Value = rdr["DevID"];
                                parms[6].Value = rdr["AuxSet"];
                                parms[7].Value = rdr["AlarmID"];
                                parms[8].Value = rdr["RtuID"];
                                parms[9].Value = rdr["DotID"];
                                parms[10].Value = rdr["Enabled"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATEDO, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete DOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelDO(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@DocID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELDO, parms);
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
        /// Add SS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddSS(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@SSID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETSS, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@SSID", SqlDbType.Int),
                                                            new SqlParameter("@SSName", SqlDbType.VarChar,40)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["SSID"];
                                parms[2].Value = rdr["SSName"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDSS, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update SS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateSS(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@SSID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETSS, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@SSID", SqlDbType.Int),
                                                            new SqlParameter("@SSName", SqlDbType.VarChar,40)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["SSID"];
                                parms[2].Value = rdr["SSName"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATESS, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Del SS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelSS(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@SSID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELSS, parms);
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
        /// Add RS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddRS(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@RSID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETRS, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@RSID", SqlDbType.Int),
                                                            new SqlParameter("@SSID", SqlDbType.Int),
                                                            new SqlParameter("@RSName", SqlDbType.VarChar,40)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["RSID"];
                                parms[2].Value = rdr["SSID"];
                                parms[3].Value = rdr["RSName"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDRS, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update RS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateRS(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@RSID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETRS, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@RSID", SqlDbType.Int),
                                                            new SqlParameter("@SSID", SqlDbType.Int),
                                                            new SqlParameter("@RSName", SqlDbType.VarChar,40)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["RSID"];
                                parms[2].Value = rdr["SSID"];
                                parms[3].Value = rdr["RSName"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATERS, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Del RS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelRS(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@RSID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELRS, parms);
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
        /// Add RTU Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddRTU(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@RtuID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETRTU, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@RtuID", SqlDbType.Int),
                                                            new SqlParameter("@SSID", SqlDbType.Int),
                                                            new SqlParameter("@RID", SqlDbType.Int),
                                                            new SqlParameter("@DevName", SqlDbType.VarChar,100),
                                                            new SqlParameter("@FileName", SqlDbType.VarChar,100),
                                                            new SqlParameter("@Port", SqlDbType.VarChar,20),
                                                            new SqlParameter("@StaName", SqlDbType.VarChar,100),
                                                            new SqlParameter("@RSID", SqlDbType.Int),
                                                            new SqlParameter("@Protocol", SqlDbType.VarChar,10)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["RtuID"];
                                parms[2].Value = rdr["SSID"];
                                parms[3].Value = rdr["RID"];
                                parms[4].Value = rdr["DevName"];
                                parms[5].Value = rdr["FileName"];
                                parms[6].Value = rdr["Port"];
                                parms[7].Value = rdr["StaName"];
                                parms[8].Value = rdr["RSID"];
                                parms[9].Value = rdr["Protocol"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDRTU, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update RTU Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateRTU(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@RtuID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETRTU, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@RtuID", SqlDbType.Int),
                                                            new SqlParameter("@SSID", SqlDbType.Int),
                                                            new SqlParameter("@RID", SqlDbType.Int),
                                                            new SqlParameter("@DevName", SqlDbType.VarChar,100),
                                                            new SqlParameter("@FileName", SqlDbType.VarChar,100),
                                                            new SqlParameter("@Port", SqlDbType.VarChar,20),
                                                            new SqlParameter("@StaName", SqlDbType.VarChar,100),
                                                            new SqlParameter("@RSID", SqlDbType.Int),
                                                            new SqlParameter("@Protocol", SqlDbType.VarChar,10)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["RtuID"];
                                parms[2].Value = rdr["SSID"];
                                parms[3].Value = rdr["RID"];
                                parms[4].Value = rdr["DevName"];
                                parms[5].Value = rdr["FileName"];
                                parms[6].Value = rdr["Port"];
                                parms[7].Value = rdr["StaName"];
                                parms[8].Value = rdr["RSID"];
                                parms[9].Value = rdr["Protocol"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATERTU, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add RTU Table With Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddRTUWithNodes(int lscId, int id, string connectionString) {
            try {
                this.AddRTU(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update RTU Table With Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateRTUWithNodes(int lscId, int id, string connectionString) {
            try {
                this.UpdateRTU(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete RTU Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelRTU(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@RtuID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELRTU, parms);
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
        /// Add SIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddSIC(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@SicID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETSIC, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@SicID", SqlDbType.Int),
                                                            new SqlParameter("@SSID", SqlDbType.Int),
                                                            new SqlParameter("@DicID", SqlDbType.Int),
                                                            new SqlParameter("@Masking", SqlDbType.Bit),
                                                            new SqlParameter("@SicType", SqlDbType.Int),
                                                            new SqlParameter("@SicDesc", SqlDbType.VarChar,40),
                                                            new SqlParameter("@AlarmLevel", SqlDbType.Int),
                                                            new SqlParameter("@AlarmID", SqlDbType.Int)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["SicID"];
                                parms[2].Value = rdr["SSID"];
                                parms[3].Value = rdr["DicID"];
                                parms[4].Value = rdr["Masking"];
                                parms[5].Value = rdr["SicType"];
                                parms[6].Value = rdr["SicDesc"];
                                parms[7].Value = rdr["AlarmLevel"];
                                parms[8].Value = rdr["AlarmID"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDSIC, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update SIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateSIC(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@SicID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETSIC, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@SicID", SqlDbType.Int),
                                                            new SqlParameter("@SSID", SqlDbType.Int),
                                                            new SqlParameter("@DicID", SqlDbType.Int),
                                                            new SqlParameter("@Masking", SqlDbType.Bit),
                                                            new SqlParameter("@SicType", SqlDbType.Int),
                                                            new SqlParameter("@SicDesc", SqlDbType.VarChar,40),
                                                            new SqlParameter("@AlarmLevel", SqlDbType.Int),
                                                            new SqlParameter("@AlarmID", SqlDbType.Int)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["SicID"];
                                parms[2].Value = rdr["SSID"];
                                parms[3].Value = rdr["DicID"];
                                parms[4].Value = rdr["Masking"];
                                parms[5].Value = rdr["SicType"];
                                parms[6].Value = rdr["SicDesc"];
                                parms[7].Value = rdr["AlarmLevel"];
                                parms[8].Value = rdr["AlarmID"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATESIC, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete SIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelSIC(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@SicID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELSIC, parms);
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
        /// Add SubSic Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddSubSic(int lscId, int id, string connectionString) {
            try {
                this.DelSubSic(lscId, id, connectionString);

                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@SicID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETSUBSIC, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_SubSic, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update SubSic Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateSubSic(int lscId, int id, string connectionString) {
            try {
                this.AddSubSic(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete SubSic Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelSubSic(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@SicID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELSUBSIC, parms);
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
        /// Add User Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddUser(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@UserID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETUSER, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@UserID", SqlDbType.Int),
                                                            new SqlParameter("@GroupID", SqlDbType.Int),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit),
                                                            new SqlParameter("@UID", SqlDbType.VarChar,20),
                                                            new SqlParameter("@PWD", SqlDbType.VarChar,20),
                                                            new SqlParameter("@UserName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@EmpNO", SqlDbType.VarChar,20),
                                                            new SqlParameter("@OpLevel", SqlDbType.Int),
                                                            new SqlParameter("@Sex", SqlDbType.Int),
                                                            new SqlParameter("@DeptID", SqlDbType.Int),
                                                            new SqlParameter("@DutyID", SqlDbType.Int),
                                                            new SqlParameter("@TelePhone", SqlDbType.VarChar,20),
                                                            new SqlParameter("@MobilePhone", SqlDbType.VarChar,20),
                                                            new SqlParameter("@Email", SqlDbType.VarChar,250),
                                                            new SqlParameter("@Address", SqlDbType.VarChar,250),
                                                            new SqlParameter("@PostalCode", SqlDbType.VarChar,6),
                                                            new SqlParameter("@Remark", SqlDbType.VarChar,250),
                                                            new SqlParameter("@OnlineATime", SqlDbType.DateTime),
                                                            new SqlParameter("@SendMSG", SqlDbType.Bit),
                                                            new SqlParameter("@SMSLevel", SqlDbType.Binary,4),
                                                            new SqlParameter("@SMSFilter", SqlDbType.VarChar,100),
                                                            new SqlParameter("@LimitTime", SqlDbType.DateTime),
                                                            new SqlParameter("@VoiceLevel", SqlDbType.Binary,4),
                                                            new SqlParameter("@VoiceFilter", SqlDbType.VarChar,100),
                                                            new SqlParameter("@VoiceType", SqlDbType.Int),
                                                            new SqlParameter("@SendVoice", SqlDbType.Bit),
                                                            new SqlParameter("@EOMSUserName", SqlDbType.VarChar,20),
                                                            new SqlParameter("@EOMSUserPWD", SqlDbType.VarChar,20),
                                                            new SqlParameter("@IsAutoTaskObj", SqlDbType.Bit),
                                                            new SqlParameter("@LastTaskUserID", SqlDbType.Int),
                                                            new SqlParameter("@AlarmSoundFiterItem", SqlDbType.Image),
                                                            new SqlParameter("@AlarmStaticFiterItem", SqlDbType.Image),
                                                            new SqlParameter("@ActiveValuesFiterItem", SqlDbType.Image)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["UserID"];
                                parms[2].Value = rdr["GroupID"];
                                parms[3].Value = rdr["Enabled"];
                                parms[4].Value = rdr["UID"];
                                parms[5].Value = rdr["PWD"];
                                parms[6].Value = rdr["UserName"];
                                parms[7].Value = rdr["EmpNO"];
                                parms[8].Value = rdr["OpLevel"];
                                parms[9].Value = rdr["Sex"];
                                parms[10].Value = rdr["DeptID"];
                                parms[11].Value = rdr["DutyID"];
                                parms[12].Value = rdr["TelePhone"];
                                parms[13].Value = rdr["MobilePhone"];
                                parms[14].Value = rdr["Email"];
                                parms[15].Value = rdr["Address"];
                                parms[16].Value = rdr["PostalCode"];
                                parms[17].Value = rdr["Remark"];
                                parms[18].Value = rdr["OnlineATime"];
                                parms[19].Value = rdr["SendMSG"];
                                parms[20].Value = rdr["SMSLevel"];
                                parms[21].Value = rdr["SMSFilter"];
                                parms[22].Value = rdr["LimitTime"];
                                parms[23].Value = rdr["VoiceLevel"];
                                parms[24].Value = rdr["VoiceFilter"];
                                parms[25].Value = rdr["VoiceType"];
                                parms[26].Value = rdr["SendVoice"];
                                parms[27].Value = rdr["EOMSUserName"];
                                parms[28].Value = rdr["EOMSUserPWD"];
                                parms[29].Value = rdr["IsAutoTaskObj"];
                                parms[30].Value = rdr["LastTaskUserID"];
                                parms[31].Value = rdr["AlarmSoundFiterItem"];
                                parms[32].Value = rdr["AlarmStaticFiterItem"];
                                parms[33].Value = rdr["ActiveValuesFiterItem"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDUSER, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update User Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateUser(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@UserID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETUSER, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@UserID", SqlDbType.Int),
                                                            new SqlParameter("@GroupID", SqlDbType.Int),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit),
                                                            new SqlParameter("@UID", SqlDbType.VarChar,20),
                                                            new SqlParameter("@PWD", SqlDbType.VarChar,20),
                                                            new SqlParameter("@UserName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@EmpNO", SqlDbType.VarChar,20),
                                                            new SqlParameter("@OpLevel", SqlDbType.Int),
                                                            new SqlParameter("@Sex", SqlDbType.Int),
                                                            new SqlParameter("@DeptID", SqlDbType.Int),
                                                            new SqlParameter("@DutyID", SqlDbType.Int),
                                                            new SqlParameter("@TelePhone", SqlDbType.VarChar,20),
                                                            new SqlParameter("@MobilePhone", SqlDbType.VarChar,20),
                                                            new SqlParameter("@Email", SqlDbType.VarChar,250),
                                                            new SqlParameter("@Address", SqlDbType.VarChar,250),
                                                            new SqlParameter("@PostalCode", SqlDbType.VarChar,6),
                                                            new SqlParameter("@Remark", SqlDbType.VarChar,250),
                                                            new SqlParameter("@OnlineATime", SqlDbType.DateTime),
                                                            new SqlParameter("@SendMSG", SqlDbType.Bit),
                                                            new SqlParameter("@SMSLevel", SqlDbType.Binary,4),
                                                            new SqlParameter("@SMSFilter", SqlDbType.VarChar,100),
                                                            new SqlParameter("@LimitTime", SqlDbType.DateTime),
                                                            new SqlParameter("@VoiceLevel", SqlDbType.Binary,4),
                                                            new SqlParameter("@VoiceFilter", SqlDbType.VarChar,100),
                                                            new SqlParameter("@VoiceType", SqlDbType.Int),
                                                            new SqlParameter("@SendVoice", SqlDbType.Bit),
                                                            new SqlParameter("@EOMSUserName", SqlDbType.VarChar,20),
                                                            new SqlParameter("@EOMSUserPWD", SqlDbType.VarChar,20),
                                                            new SqlParameter("@IsAutoTaskObj", SqlDbType.Bit),
                                                            new SqlParameter("@LastTaskUserID", SqlDbType.Int),
                                                            new SqlParameter("@AlarmSoundFiterItem", SqlDbType.Image),
                                                            new SqlParameter("@AlarmStaticFiterItem", SqlDbType.Image),
                                                            new SqlParameter("@ActiveValuesFiterItem", SqlDbType.Image)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["UserID"];
                                parms[2].Value = rdr["GroupID"];
                                parms[3].Value = rdr["Enabled"];
                                parms[4].Value = rdr["UID"];
                                parms[5].Value = rdr["PWD"];
                                parms[6].Value = rdr["UserName"];
                                parms[7].Value = rdr["EmpNO"];
                                parms[8].Value = rdr["OpLevel"];
                                parms[9].Value = rdr["Sex"];
                                parms[10].Value = rdr["DeptID"];
                                parms[11].Value = rdr["DutyID"];
                                parms[12].Value = rdr["TelePhone"];
                                parms[13].Value = rdr["MobilePhone"];
                                parms[14].Value = rdr["Email"];
                                parms[15].Value = rdr["Address"];
                                parms[16].Value = rdr["PostalCode"];
                                parms[17].Value = rdr["Remark"];
                                parms[18].Value = rdr["OnlineATime"];
                                parms[19].Value = rdr["SendMSG"];
                                parms[20].Value = rdr["SMSLevel"];
                                parms[21].Value = rdr["SMSFilter"];
                                parms[22].Value = rdr["LimitTime"];
                                parms[23].Value = rdr["VoiceLevel"];
                                parms[24].Value = rdr["VoiceFilter"];
                                parms[25].Value = rdr["VoiceType"];
                                parms[26].Value = rdr["SendVoice"];
                                parms[27].Value = rdr["EOMSUserName"];
                                parms[28].Value = rdr["EOMSUserPWD"];
                                parms[29].Value = rdr["IsAutoTaskObj"];
                                parms[30].Value = rdr["LastTaskUserID"];
                                parms[31].Value = rdr["AlarmSoundFiterItem"];
                                parms[32].Value = rdr["AlarmStaticFiterItem"];
                                parms[33].Value = rdr["ActiveValuesFiterItem"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATEUSER, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete User Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelUser(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@UserID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELUSER, parms);
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
        /// Add Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddGroup(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@GroupID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETGROUP, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@GroupID", SqlDbType.Int),
                                                            new SqlParameter("@GroupName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@GroupType", SqlDbType.Int),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["GroupID"];
                                parms[2].Value = rdr["GroupName"];
                                parms[3].Value = rdr["GroupType"];
                                parms[4].Value = rdr["Enabled"];


                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDGROUP, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateGroup(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@GroupID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETGROUP, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@GroupID", SqlDbType.Int),
                                                            new SqlParameter("@GroupName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@GroupType", SqlDbType.Int),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["GroupID"];
                                parms[2].Value = rdr["GroupName"];
                                parms[3].Value = rdr["GroupType"];
                                parms[4].Value = rdr["Enabled"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATEGROUP, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelGroup(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@GroupID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELGROUP, parms);
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
        /// Add GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddGroupTree(int lscId, int id, string connectionString) {
            try {
                this.DelGroupTree(lscId, id, connectionString);

                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@GroupID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETGROUPTREE, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_GroupTree, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateGroupTree(int lscId, int id, string connectionString) {
            try {
                this.AddGroupTree(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelGroupTree(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@GroupID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELGROUPTREE, parms);
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
        /// Add User Defind Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddUDGroup(int lscId, int userId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@UserID", SqlDbType.Int),
                                         new SqlParameter("@UDGroupID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = userId;
                parms[2].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETUDGROUP, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@UserID", SqlDbType.Int),
                                                            new SqlParameter("@UDGroupID", SqlDbType.Int),
                                                            new SqlParameter("@UDGroupName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["UserID"];
                                parms[2].Value = rdr["UDGroupID"];
                                parms[3].Value = rdr["UDGroupName"];
                                parms[4].Value = rdr["Enabled"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDUDGROUP, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update User Defind Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateUDGroup(int lscId, int userId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@UserID", SqlDbType.Int),
                                         new SqlParameter("@UDGroupID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = userId;
                parms[2].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETUDGROUP, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@UserID", SqlDbType.Int),
                                                            new SqlParameter("@UDGroupID", SqlDbType.Int),
                                                            new SqlParameter("@UDGroupName", SqlDbType.VarChar,40),
                                                            new SqlParameter("@Enabled", SqlDbType.Bit)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["UserID"];
                                parms[2].Value = rdr["UDGroupID"];
                                parms[3].Value = rdr["UDGroupName"];
                                parms[4].Value = rdr["Enabled"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATEUDGROUP, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete User Defind Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelUDGroup(int lscId, int userId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@UserID", SqlDbType.Int),
                                                 new SqlParameter("@UDGroupID", SqlDbType.Int) };
                        parms[0].Value = lscId;
                        parms[1].Value = userId;
                        parms[2].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELUDGROUP, parms);
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
        /// Add User Defind GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddUDGroupTree(int lscId, int userId, int id, string connectionString) {
            try {
                this.DelUDGroupTree(lscId, userId, id, connectionString);

                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@UserID", SqlDbType.Int),
                                         new SqlParameter("@UDGroupID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = userId;
                parms[2].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETUDGROUPTREE, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_UDGroupTree, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update User Defind GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateUDGroupTree(int lscId, int userId, int id, string connectionString) {
            try {
                this.AddUDGroupTree(lscId, userId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete User Defind GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelUDGroupTree(int lscId, int userId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@UserID", SqlDbType.Int),
                                                 new SqlParameter("@UDGroupID", SqlDbType.Int) };
                        parms[0].Value = lscId;
                        parms[1].Value = userId;
                        parms[2].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELUDGROUPTREE, parms);
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
        /// Add ProjBooking Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddProjBooking(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@BookingID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETPROJBOOKING, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@BookingID", SqlDbType.Int),
                                                            new SqlParameter("@BookingUserID", SqlDbType.Int),
                                                            new SqlParameter("@ProjName", SqlDbType.VarChar,100),
                                                            new SqlParameter("@ProjDesc", SqlDbType.VarChar,200),
                                                            new SqlParameter("@StaIncluded", SqlDbType.VarChar,200),
                                                            new SqlParameter("@DevIncluded", SqlDbType.VarChar,200),
                                                            new SqlParameter("@ProjStatus", SqlDbType.Int),
                                                            new SqlParameter("@StartTime", SqlDbType.DateTime),
                                                            new SqlParameter("@EndTime", SqlDbType.DateTime),
                                                            new SqlParameter("@ProjID", SqlDbType.VarChar,50),
                                                            new SqlParameter("@IsComfirmed", SqlDbType.Bit),
                                                            new SqlParameter("@ComfirmedUserID", SqlDbType.Int),
                                                            new SqlParameter("@ComfirmedTime", SqlDbType.DateTime),
                                                            new SqlParameter("@IsChanged", SqlDbType.Bit),
                                                            new SqlParameter("@BookingTime", SqlDbType.DateTime)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["BookingID"];
                                parms[2].Value = rdr["BookingUserID"];
                                parms[3].Value = rdr["ProjName"];
                                parms[4].Value = rdr["ProjDesc"];
                                parms[5].Value = rdr["StaIncluded"];
                                parms[6].Value = rdr["DevIncluded"];
                                parms[7].Value = rdr["ProjStatus"];
                                parms[8].Value = rdr["StartTime"];
                                parms[9].Value = rdr["EndTime"];
                                parms[10].Value = rdr["ProjID"];
                                parms[11].Value = rdr["IsComfirmed"];
                                parms[12].Value = rdr["ComfirmedUserID"];
                                parms[13].Value = rdr["ComfirmedTime"];
                                parms[14].Value = rdr["IsChanged"];
                                parms[15].Value = rdr["BookingTime"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDPROJBOOKING, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update ProjBooking Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateProjBooking(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@BookingID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETPROJBOOKING, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@BookingID", SqlDbType.Int),
                                                            new SqlParameter("@BookingUserID", SqlDbType.Int),
                                                            new SqlParameter("@ProjName", SqlDbType.VarChar,100),
                                                            new SqlParameter("@ProjDesc", SqlDbType.VarChar,200),
                                                            new SqlParameter("@StaIncluded", SqlDbType.VarChar,200),
                                                            new SqlParameter("@DevIncluded", SqlDbType.VarChar,200),
                                                            new SqlParameter("@ProjStatus", SqlDbType.Int),
                                                            new SqlParameter("@StartTime", SqlDbType.DateTime),
                                                            new SqlParameter("@EndTime", SqlDbType.DateTime),
                                                            new SqlParameter("@ProjID", SqlDbType.VarChar,50),
                                                            new SqlParameter("@IsComfirmed", SqlDbType.Bit),
                                                            new SqlParameter("@ComfirmedUserID", SqlDbType.Int),
                                                            new SqlParameter("@ComfirmedTime", SqlDbType.DateTime),
                                                            new SqlParameter("@IsChanged", SqlDbType.Bit),
                                                            new SqlParameter("@BookingTime", SqlDbType.DateTime)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["BookingID"];
                                parms[2].Value = rdr["BookingUserID"];
                                parms[3].Value = rdr["ProjName"];
                                parms[4].Value = rdr["ProjDesc"];
                                parms[5].Value = rdr["StaIncluded"];
                                parms[6].Value = rdr["DevIncluded"];
                                parms[7].Value = rdr["ProjStatus"];
                                parms[8].Value = rdr["StartTime"];
                                parms[9].Value = rdr["EndTime"];
                                parms[10].Value = rdr["ProjID"];
                                parms[11].Value = rdr["IsComfirmed"];
                                parms[12].Value = rdr["ComfirmedUserID"];
                                parms[13].Value = rdr["ComfirmedTime"];
                                parms[14].Value = rdr["IsChanged"];
                                parms[15].Value = rdr["BookingTime"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATEPROJBOOKING, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete ProjBooking Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelProjBooking(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@BookingID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELPROJBOOKING, parms);
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
        /// Add SubDevCap Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddSubDevCap(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@DevID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETSUBDEVCAP, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@DevID", SqlDbType.Int),
                                                            new SqlParameter("@BuildingID", SqlDbType.Int),
                                                            new SqlParameter("@ModuleCount", SqlDbType.Int),
                                                            new SqlParameter("@DevDesignCapacity", SqlDbType.Real),
                                                            new SqlParameter("@SingleRatedCapacity", SqlDbType.Real),
                                                            new SqlParameter("@TotalRatedCapacity", SqlDbType.Real),
                                                            new SqlParameter("@RedundantCapacity", SqlDbType.Real)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["DevID"];
                                parms[2].Value = rdr["BuildingID"];
                                parms[3].Value = rdr["ModuleCount"];
                                parms[4].Value = rdr["DevDesignCapacity"];
                                parms[5].Value = rdr["SingleRatedCapacity"];
                                parms[6].Value = rdr["TotalRatedCapacity"];
                                parms[7].Value = rdr["RedundantCapacity"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_ADDSUBDEVCAP, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update SubDevCap Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateSubDevCap(int lscId, int id, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@DevID", SqlDbType.Int) };
                parms[0].Value = lscId;
                parms[1].Value = id;

                SqlHelper.TestConnection(connectionString);
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETSUBDEVCAP, parms)) {
                    while (rdr.Read()) {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                            conn.Open();
                            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            try {
                                parms = new SqlParameter[] {new SqlParameter("@LscID", SqlDbType.Int),
                                                            new SqlParameter("@DevID", SqlDbType.Int),
                                                            new SqlParameter("@BuildingID", SqlDbType.Int),
                                                            new SqlParameter("@ModuleCount", SqlDbType.Int),
                                                            new SqlParameter("@DevDesignCapacity", SqlDbType.Real),
                                                            new SqlParameter("@SingleRatedCapacity", SqlDbType.Real),
                                                            new SqlParameter("@TotalRatedCapacity", SqlDbType.Real),
                                                            new SqlParameter("@RedundantCapacity", SqlDbType.Real)};

                                parms[0].Value = rdr["LscID"];
                                parms[1].Value = rdr["DevID"];
                                parms[2].Value = rdr["BuildingID"];
                                parms[3].Value = rdr["ModuleCount"];
                                parms[4].Value = rdr["DevDesignCapacity"];
                                parms[5].Value = rdr["SingleRatedCapacity"];
                                parms[6].Value = rdr["TotalRatedCapacity"];
                                parms[7].Value = rdr["RedundantCapacity"];

                                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_UPDATESUBDEVCAP, parms);
                                trans.Commit();
                            } catch {
                                trans.Rollback();
                                throw;
                            } finally {
                                conn.Close();
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete SubDevCap Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelSubDevCap(int lscId, int id, string connectionString) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms =  {new SqlParameter("@LscID", SqlDbType.Int),
                                                 new SqlParameter("@DevID", SqlDbType.Int)};

                        parms[0].Value = lscId;
                        parms[1].Value = id;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_DELSUBDEVCAP, parms);
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
        /// Get LscParam Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public LscParamInfo GetLscParam(int lscId, string connectionString) {
            LscParamInfo param = null;
            SqlParameter[] parms = { new SqlParameter("@LscID", lscId) };
            SqlHelper.TestConnection(connectionString);
            using (var rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SqlText.SQL_SELECT_CSCMODIFY_GETLSCPARAM, parms)) {
                if (rdr.Read()) {
                    param = new LscParamInfo();
                    param.LscID = ComUtility.DBNullInt32Handler(rdr["LscID"]);
                    param.StaTNumber = ComUtility.DBNullInt32Handler(rdr["StaTNumber"]);
                    param.ElecDevTNumber = ComUtility.DBNullInt32Handler(rdr["ElecDevTNumber"]);
                }
            }

            return param;
        }

        /// <summary>
        /// Update Lsc Params.
        /// </summary>
        /// <param name="lParams">lsc params</param>
        public void UpdateLscParam(List<LscParamInfo> lParams) {
            SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                     new SqlParameter("@StaTNumber", SqlDbType.Int),
                                     new SqlParameter("@ElecDevTNumber", SqlDbType.Int) };

            using (var conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                try {
                    foreach (var parm in lParams) {
                        parms[0].Value = parm.LscID;
                        parms[1].Value = ComUtility.DBNullInt32Checker(parm.StaTNumber);
                        parms[2].Value = ComUtility.DBNullInt32Checker(parm.ElecDevTNumber);
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_UPDATE_CSCMODIFY_UPDATELSCPARAM, parms);
                    }
                    trans.Commit();
                } catch {
                    trans.Rollback();
                    throw;
                }
            }
        }
    }
}