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

        /// <summary>
        /// Method to get all the reservations information
        /// </summary>
        public List<ReservationInfo> GetReservations() {
            var entities = new List<ReservationInfo>();
            using (var rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SqlText.SQL_SELECT_LSC_GETRESERVATIONS, null)) {
                while (rdr.Read()) {
                    var entity = new ReservationInfo {
                        LscId = ComUtility.DBNullInt32Handler(rdr["LscId"]),
                        Id = ComUtility.DBNullStringHandler(rdr["Id"]),
                        Name = ComUtility.DBNullStringHandler(rdr["Name"]),
                        StartTime = ComUtility.DBNullDateTimeHandler(rdr["StartTime"]),
                        EndTime = ComUtility.DBNullDateTimeHandler(rdr["EndTime"]),
                        Comment = ComUtility.DBNullStringHandler(rdr["Comment"]),
                        CreatedTime = ComUtility.DBNullDateTimeHandler(rdr["CreatedTime"]),
                        Project = new ProjectInfo {
                            Id = ComUtility.DBNullStringHandler(rdr["PId"]),
                            Name = ComUtility.DBNullStringHandler(rdr["PName"]),
                            StartTime = ComUtility.DBNullDateTimeHandler(rdr["PStartTime"]),
                            EndTime = ComUtility.DBNullDateTimeHandler(rdr["PEndTime"]),
                            Responsible = ComUtility.DBNullStringHandler(rdr["PResponsible"]),
                            ContactPhone = ComUtility.DBNullStringHandler(rdr["PContactPhone"]),
                            Company = ComUtility.DBNullStringHandler(rdr["PCompany"]),
                            Comment = ComUtility.DBNullStringHandler(rdr["PComment"]),
                            CreatedTime = ComUtility.DBNullDateTimeHandler(rdr["PCreatedTime"])
                        }
                    };

                    entities.Add(entity);
                }
            }

            foreach (var entity in entities) {
                entity.Nodes = GetReservationNodes(entity.Id);
            }

            return entities;
        }

        /// <summary>
        /// Method to get all the reservation nodes information
        /// </summary>
        public List<NodeInReservationInfo> GetReservationNodes(string id) {
            SqlParameter[] parms = { new SqlParameter("@ReservationId", SqlDbType.VarChar, 100) };
            parms[0].Value = id;

            var entities = new List<NodeInReservationInfo>();
            using (var rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SqlText.SQL_SELECT_LSC_GETRESERVATIONODES, parms)) {
                while (rdr.Read()) {
                    var entity = new NodeInReservationInfo {
                        ReservationId = ComUtility.DBNullStringHandler(rdr["ReservationId"]),
                        NodeId = ComUtility.DBNullStringHandler(rdr["NodeId"]),
                        NodeType = ComUtility.DBNullResNodeHandler(rdr["NodeType"])
                    };

                    entities.Add(entity);
                }
            }

            return entities;
        }

        /// <summary>
        /// Update the reservations
        /// </summary>
        public void UpdateReservations(IEnumerable<string> ids, bool isSended) {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                try {
                    SqlParameter[] parms = { new SqlParameter("@Id", SqlDbType.VarChar, 100),
                                             new SqlParameter("@IsSended", SqlDbType.Bit)};

                    foreach(var id in ids) {
                        parms[0].Value = ComUtility.DBNullString2Checker(id);
                        parms[1].Value = isSended;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_LSC_UPDATERESERVATION, parms);
                    }
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
        /// Method to add all the reservation information
        /// </summary>
        public void AddReservations(string connectionString, List<BookingInfo> bookings) {
            SqlParameter[] parms1 = { new SqlParameter("@LscID", SqlDbType.Int),
                                      new SqlParameter("@ProjID", SqlDbType.VarChar, 50)};
            SqlParameter[] parms2 = { new SqlParameter("@BookingUserID", SqlDbType.Int),
                                      new SqlParameter("@ProjID", SqlDbType.VarChar, 50),
                                      new SqlParameter("@ProjName", SqlDbType.VarChar, 100),
                                      new SqlParameter("@ProjDesc", SqlDbType.VarChar, 200),
                                      new SqlParameter("@LscIncluded", SqlDbType.Int),
                                      new SqlParameter("@StaIncluded", SqlDbType.VarChar),
                                      new SqlParameter("@DevIncluded", SqlDbType.VarChar),
                                      new SqlParameter("@StartTime", SqlDbType.DateTime),
                                      new SqlParameter("@EndTime", SqlDbType.DateTime),
                                      new SqlParameter("@ProjStatus", SqlDbType.Int),
                                      new SqlParameter("@IsComfirmed", SqlDbType.Bit),
                                      new SqlParameter("@ComfirmedUserID", SqlDbType.Int),
                                      new SqlParameter("@ComfirmedTime", SqlDbType.DateTime),
                                      new SqlParameter("@IsChanged", SqlDbType.Bit),
                                      new SqlParameter("@BookingTime", SqlDbType.DateTime)};

            SqlHelper.TestConnection(connectionString);
            using (var conn = new SqlConnection(connectionString)) {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                try {
                    foreach(var booking in bookings) {
                        parms1[0].Value = ComUtility.DBNullInt32Checker(booking.LscId);
                        parms1[1].Value = ComUtility.DBNullString2Checker(booking.Id);
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_LSC_DELETERESERVATION, parms1);

                        foreach(var project in booking.Projects) {
                            parms2[0].Value = ComUtility.DBNullInt32Checker(project.BookingUserID);
                            parms2[1].Value = ComUtility.DBNullString2Checker(project.ProjID);
                            parms2[2].Value = ComUtility.DBNullString2Checker(project.ProjName);
                            parms2[3].Value = ComUtility.DBNullString2Checker(project.ProjDesc);
                            parms2[4].Value = ComUtility.DBNullInt32Checker(project.LscIncluded);
                            parms2[5].Value = ComUtility.DBNullString2Checker(project.StaIncluded);
                            parms2[6].Value = ComUtility.DBNullString2Checker(project.DevIncluded);
                            parms2[7].Value = ComUtility.DBNullDateTimeChecker(project.StartTime);
                            parms2[8].Value = ComUtility.DBNullDateTimeChecker(project.EndTime);
                            parms2[9].Value = ComUtility.DBNullInt32Checker(project.ProjStatus);
                            parms2[10].Value = project.IsComfirmed;
                            parms2[11].Value = ComUtility.DBNullInt32Checker(project.ComfirmedUserID);
                            parms2[12].Value = ComUtility.DBNullDateTimeChecker(project.ComfirmedTime);
                            parms2[13].Value = project.IsChanged;
                            parms2[14].Value = ComUtility.DBNullDateTimeChecker(project.BookingTime);

                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_SELECT_LSC_ADDRESERVATION, parms2);
                        }
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
