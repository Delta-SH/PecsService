using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.Model;
using System.Data.SqlClient;
using Delta.PECS.WebService.DBUtility;
using System.Data;

namespace Delta.PECS.WebService.SQLServerDAL
{
    /// <summary>
    /// This class is an implementation for receiving order information from database
    /// </summary>
    public class Order : IOrder
    {
        /// <summary>
        /// Method to retrieve orders information
        /// </summary>
        /// <returns>All orders</returns>
        public List<OrderInfo> GetOrders() {
            List<OrderInfo> orders = new List<OrderInfo>();

            try {
                //Execute a query to read the orders
                using(SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SqlText.SQL_SELECT_ORDER_GETORDERS, null)) {
                    while(rdr.Read()) {
                        OrderInfo order = new OrderInfo();
                        order.LscID = ComUtility.DBNullInt32Handler(rdr["LscID"]);
                        order.TargetID = ComUtility.DBNullInt32Handler(rdr["TargetID"]);
                        order.TargetType = ComUtility.DBNullNodeTypeHandler(rdr["TargetType"]);
                        order.OrderType = ComUtility.DBNullActTypeHandler(rdr["OrderType"]);
                        order.RelValue1 = ComUtility.DBNullStringHandler(rdr["RelValue1"]);
                        order.RelValue2 = ComUtility.DBNullStringHandler(rdr["RelValue2"]);
                        order.RelValue3 = ComUtility.DBNullStringHandler(rdr["RelValue3"]);
                        order.RelValue4 = ComUtility.DBNullStringHandler(rdr["RelValue4"]);
                        order.RelValue5 = ComUtility.DBNullStringHandler(rdr["RelValue5"]);
                        order.UpdateTime = ComUtility.DBNullDateTimeHandler(rdr["UpdateTime"]);

                        orders.Add(order);
                    }
                }

                return orders;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to delete orders information
        /// </summary>
        /// <param name="orders">orders</param>
        /// <returns>Affected rows</returns>
        public int DeleteOrders(IList<OrderInfo> orders) {
            try {
                int rowCnt = 0;
                using(SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = {   new SqlParameter("@LscID", SqlDbType.Int),
                                                   new SqlParameter("@TargetID", SqlDbType.Int),
                                                   new SqlParameter("@TargetType", SqlDbType.Int),
                                                   new SqlParameter("@OrderType", SqlDbType.Int)};

                        foreach(OrderInfo order in orders) {
                            parms[0].Value = order.LscID;
                            parms[1].Value = order.TargetID;
                            parms[2].Value = (int)order.TargetType;
                            parms[3].Value = (int)order.OrderType;

                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_ORDER_DELETEORDERS, parms);
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
        /// delete all orders
        /// </summary>
        public void Purge() {
            try {
                using(SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_ORDER_PURGE, null);
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
        /// Method to get system parameters
        /// </summary>
        /// <param name="paraCode">paraCode</param>
        public List<SysParamInfo> GetSysParams(int paraCode) {
            try {
                SqlParameter[] parms = { new SqlParameter("@ParaCode", SqlDbType.Int) };
                parms[0].Value = paraCode;

                var sysParms = new List<SysParamInfo>();
                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SqlText.SQL_SELECT_ORDER_GETSYSPARAMS, parms)) {
                    while (rdr.Read()) {
                        var parm = new SysParamInfo();
                        parm.ID = ComUtility.DBNullInt32Handler(rdr["ID"]);
                        parm.ParaCode = ComUtility.DBNullInt32Handler(rdr["ParaCode"]);
                        parm.ParaData = ComUtility.DBNullInt32Handler(rdr["ParaData"]);
                        parm.ParaDisplay = ComUtility.DBNullStringHandler(rdr["ParaDisplay"]);
                        parm.Note = ComUtility.DBNullStringHandler(rdr["Note"]);
                        sysParms.Add(parm);
                    }
                }
                return sysParms;
            } catch { throw; }
        }

        /// <summary>
        /// Method to save system parameters
        /// </summary>
        /// <param name="sysParms">sysParms</param>
        public void SaveSysParams(List<SysParamInfo> sysParms) {
            try {
                SqlParameter[] parms = { new SqlParameter("@ID", SqlDbType.Int),
                                         new SqlParameter("@ParaCode", SqlDbType.Int),
                                         new SqlParameter("@ParaData", SqlDbType.Int),
                                         new SqlParameter("@ParaDisplay", SqlDbType.NVarChar,50),
                                         new SqlParameter("@Note", SqlDbType.NText) };

                using (var conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                    try {
                        foreach (var parm in sysParms) {
                            if (parm.ID != ComUtility.DefaultInt32)
                                parms[0].Value = parm.ID;
                            else
                                parms[0].Value = DBNull.Value;

                            if (parm.ParaCode != ComUtility.DefaultInt32)
                                parms[1].Value = parm.ParaCode;
                            else
                                parms[1].Value = DBNull.Value;

                            if (parm.ParaData != ComUtility.DefaultInt32)
                                parms[2].Value = parm.ParaData;
                            else
                                parms[2].Value = DBNull.Value;

                            if (parm.ParaDisplay != ComUtility.DefaultString)
                                parms[3].Value = parm.ParaDisplay;
                            else
                                parms[3].Value = DBNull.Value;

                            if (parm.Note != ComUtility.DefaultString)
                                parms[4].Value = parm.Note;
                            else
                                parms[4].Value = DBNull.Value;

                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_UPDATE_ORDER_SAVESYSPARAMS, parms);
                        }
                        trans.Commit();
                    } catch { trans.Rollback(); throw; }
                }
            } catch { throw; }
        }

        /// <summary>
        /// Method to delete system parameters
        /// </summary>
        public void DeleteSysParams(int paraCode) {
            try {
                SqlParameter[] parms = { new SqlParameter("@ParaCode", SqlDbType.Int) };
                parms[0].Value = paraCode;

                using (var conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_ORDER_DELETESYSPARAMS, parms);
                        trans.Commit();
                    } catch { trans.Rollback(); throw; }
                }
            } catch { throw; }
        }
    }
}
