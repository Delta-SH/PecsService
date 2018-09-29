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
    /// This class is an implementation for receiving setting information from database
    /// </summary>
    public class Setting : ISetting {
        /// <summary>
        /// Sync Area Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncArea(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCAREA, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_Area, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync Building Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncBuilding(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCBUILDING, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_Building, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync NetGrid Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncNetGrid(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCNETGRID, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_NetGrid, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync Station Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncSta(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCSTA, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_Sta, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync Device Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncDev(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCDEV, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_Dev, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync AIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncAI(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCAI, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_AI, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync AOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncAO(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCAO, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_AO, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync DIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncDI(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCDI, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_DI, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync DOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncDO(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCDO, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_DO, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncGroup(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCGROUP, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_Group, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync Group Tree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncGroupTree(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCGROUPTREEE, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_GroupTree, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync User Defind Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncUDGroup(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCUDGROUP, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_UDGroup, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync User Defind Group Tree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncUDGroupTree(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCUDGROUPTREEE, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_UDGroupTree, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync User Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncUser(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCUSER, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_User, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync SS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncSS(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCSS, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_SS, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync RS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncRS(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCRS, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_RS, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync RTU Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncRTU(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCRTU, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_RTU, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync SIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncSIC(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCSIC, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_SIC, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync SubSic Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncSubSic(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCSUBSIC, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_SubSic, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync ProjBooking Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncProjBooking(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCPROJBOOKING, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_ProjBooking, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync SubDevCap Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncSubDevCap(int lscId, string connectionString) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                parms[0].Value = lscId;

                SqlHelper.TestConnection(connectionString);
                using (DataTable dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SYNCSUBDEVCAP, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_SubDevCap, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge Area Table
        /// </summary>
        public void PurgeArea() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGEAREA, null);
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
        /// Purge Building Table
        /// </summary>
        public void PurgeBuilding() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGEBUILDING, null);
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
        /// Purge Station Table
        /// </summary>
        public void PurgeSta() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGESTA, null);
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
        /// Purge Device Table
        /// </summary>
        public void PurgeDev() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGEDEV, null);
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
        /// Purge AIC Table
        /// </summary>
        public void PurgeAI() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGEAI, null);
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
        /// Purge AOC Table
        /// </summary>
        public void PurgeAO() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGEAO, null);
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
        /// Purge DIC Table
        /// </summary>
        public void PurgeDI() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGEDI, null);
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
        /// Purge DOC Table
        /// </summary>
        public void PurgeDO() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGEDO, null);
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
        /// Purge Group Table
        /// </summary>
        public void PurgeGroup() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGEGROUP, null);
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
        /// Purge Group Tree Table
        /// </summary>
        public void PurgeGroupTree() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGEGROUPTREE, null);
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
        /// Purge User Defind Group Table
        /// </summary>
        public void PurgeUDGroup() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGEUDGROUP, null);
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
        /// Purge User Defind Group Tree Table
        /// </summary>
        public void PurgeUDGroupTree() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGEUDGROUPTREE, null);
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
        /// Purge User Table
        /// </summary>
        public void PurgeUser() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGEUSER, null);
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
        /// Purge SS Table
        /// </summary>
        public void PurgeSS() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGESS, null);
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
        /// Purge RS Table
        /// </summary>
        public void PurgeRS() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGERS, null);
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
        /// Purge RTU Table
        /// </summary>
        public void PurgeRTU() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGERTU, null);
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
        /// Purge SIC Table
        /// </summary>
        public void PurgeSIC() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGESIC, null);
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
        /// Purge SubSic Table
        /// </summary>
        public void PurgeSubSic() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGESUBSIC, null);
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
        /// Purge ProjBooking Table
        /// </summary>
        public void PurgeProjBooking() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGEPROJBOOKING, null);
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
        /// Purge SubDevCap Table
        /// </summary>
        public void PurgeSubDevCap() {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PURGESUBDEVCAP, null);
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
        /// Delete Area Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteArea(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETEAREA, parms);
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
        /// Delete Building Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteBuilding(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETEBUILDING, parms);
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
        /// Delete Station Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteSta(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETESTA, parms);
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
        /// Delete Device Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteDev(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETEDEV, parms);
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
        /// Delete AIC Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteAI(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETEAI, parms);
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
        /// Delete AOC Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteAO(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETEAO, parms);
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
        /// Delete DIC Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteDI(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETEDI, parms);
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
        /// Delete DOC Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteDO(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETEDO, parms);
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
        /// Delete Group Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteGroup(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETEGROUP, parms);
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
        /// Delete Group Tree Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteGroupTree(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETEGROUPTREE, parms);
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
        /// Delete User Defind Group Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteUDGroup(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETEUDGROUP, parms);
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
        /// Delete User Defind Group Tree Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteUDGroupTree(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETEUDGROUPTREE, parms);
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
        /// Delete User Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteUser(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETEUSER, parms);
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
        /// Delete SS Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteSS(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETESS, parms);
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
        /// Delete RS Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteRS(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETERS, parms);
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
        /// Delete RTU Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteRTU(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETERTU, parms);
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
        /// Delete SIC Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteSIC(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETESIC, parms);
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
        /// Delete SubSic Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteSubSic(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETESUBSIC, parms);
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
        /// Delete ProjBooking Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteProjBooking(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETEPROJBOOKING, parms);
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
        /// Delete SubDevCap Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteSubDevCap(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_DELETESUBDEVCAP, parms);
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
        /// Purge AlarmDeviceType Table
        /// </summary>
        public void PurgeAlarmDeviceType() {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                try {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PurgeAlarmDeviceType, null);
                    trans.Commit();
                } catch {
                    trans.Rollback();
                    throw;
                } finally {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Sync AlarmDeviceType Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncAlarmDeviceType(int lscId, string connectionString) {
            SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
            parms[0].Value = lscId;

            SqlHelper.TestConnection(connectionString);
            using (var dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SyncAlarmDeviceType, parms)) {
                if (dt != null && dt.Rows.Count > 0) {
                    SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TC_AlarmDeviceType, dt);
                }
            }
        }

        /// <summary>
        /// Purge AlarmLogType Table
        /// </summary>
        public void PurgeAlarmLogType() {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                try {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PurgeAlarmLogType, null);
                    trans.Commit();
                } catch {
                    trans.Rollback();
                    throw;
                } finally {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Sync AlarmLogType Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncAlarmLogType(int lscId, string connectionString) {
            SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
            parms[0].Value = lscId;

            SqlHelper.TestConnection(connectionString);
            using (var dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SyncAlarmLogType, parms)) {
                if (dt != null && dt.Rows.Count > 0) {
                    SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TC_AlarmLogType, dt);
                }
            }
        }

        /// <summary>
        /// Purge AlarmName Table
        /// </summary>
        public void PurgeAlarmName() {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                try {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PurgeAlarmName, null);
                    trans.Commit();
                } catch {
                    trans.Rollback();
                    throw;
                } finally {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Sync AlarmName Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncAlarmName(int lscId, string connectionString) {
            SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
            parms[0].Value = lscId;

            SqlHelper.TestConnection(connectionString);
            using (var dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SyncAlarmName, parms)) {
                if (dt != null && dt.Rows.Count > 0) {
                    SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TC_AlarmName, dt);
                }
            }
        }

        /// <summary>
        /// Purge DeviceType Table
        /// </summary>
        public void PurgeDeviceType() {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                try {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PurgeDeviceType, null);
                    trans.Commit();
                } catch {
                    trans.Rollback();
                    throw;
                } finally {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Sync DeviceType Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncDeviceType(int lscId, string connectionString) {
            SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
            parms[0].Value = lscId;

            SqlHelper.TestConnection(connectionString);
            using (var dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SyncDeviceType, parms)) {
                if (dt != null && dt.Rows.Count > 0) {
                    SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TC_DeviceType, dt);
                }
            }
        }

        /// <summary>
        /// Purge Productor Table
        /// </summary>
        public void PurgeProductor() {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                try {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PurgeProductor, null);
                    trans.Commit();
                } catch {
                    trans.Rollback();
                    throw;
                } finally {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Sync Productor Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncProductor(int lscId, string connectionString) {
            SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
            parms[0].Value = lscId;

            SqlHelper.TestConnection(connectionString);
            using (var dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SyncProductor, parms)) {
                if (dt != null && dt.Rows.Count > 0) {
                    SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TC_Productor, dt);
                }
            }
        }

        /// <summary>
        /// Purge Protocol Table
        /// </summary>
        public void PurgeProtocol() {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                try {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PurgeProtocol, null);
                    trans.Commit();
                } catch {
                    trans.Rollback();
                    throw;
                } finally {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Sync Protocol Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncProtocol(int lscId, string connectionString) {
            SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
            parms[0].Value = lscId;

            SqlHelper.TestConnection(connectionString);
            using (var dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SyncProtocol, parms)) {
                if (dt != null && dt.Rows.Count > 0) {
                    SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TC_Protocol, dt);
                }
            }
        }

        /// <summary>
        /// Purge StaFeatures Table
        /// </summary>
        public void PurgeStaFeatures() {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                try {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PurgeStaFeatures, null);
                    trans.Commit();
                } catch {
                    trans.Rollback();
                    throw;
                } finally {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Sync StaFeatures Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncStaFeatures(int lscId, string connectionString) {
            SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
            parms[0].Value = lscId;

            SqlHelper.TestConnection(connectionString);
            using (var dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SyncStaFeatures, parms)) {
                if (dt != null && dt.Rows.Count > 0) {
                    SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TC_StaFeatures, dt);
                }
            }
        }

        /// <summary>
        /// Purge StationType Table
        /// </summary>
        public void PurgeStationType() {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                try {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PurgeStationType, null);
                    trans.Commit();
                } catch {
                    trans.Rollback();
                    throw;
                } finally {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Sync StationType Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncStationType(int lscId, string connectionString) {
            SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
            parms[0].Value = lscId;

            SqlHelper.TestConnection(connectionString);
            using (var dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SyncStationType, parms)) {
                if (dt != null && dt.Rows.Count > 0) {
                    SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TC_StationType, dt);
                }
            }
        }

        /// <summary>
        /// Purge SubAlarmLogType Table
        /// </summary>
        public void PurgeSubAlarmLogType() {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                try {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_SETTING_PurgeSubAlarmLogType, null);
                    trans.Commit();
                } catch {
                    trans.Rollback();
                    throw;
                } finally {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Sync SubAlarmLogType Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncSubAlarmLogType(int lscId, string connectionString) {
            SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
            parms[0].Value = lscId;

            SqlHelper.TestConnection(connectionString);
            using (var dt = SqlHelper.ExecuteTable(connectionString, CommandType.Text, SqlText.SQL_SELECT_SETTING_SyncSubAlarmLogType, parms)) {
                if (dt != null && dt.Rows.Count > 0) {
                    SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TC_SubAlarmLogType, dt);
                }
            }
        }
    }
}