using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.Model;
using Delta.PECS.WebService.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Delta.PECS.WebService.SQLServerDAL
{
    /// <summary>
    /// This class is an implementation for receiving nodes information from database
    /// </summary>
    public class Node : INode
    {
        /// <summary>
        /// Syn Nodes
        /// </summary>
        public void SynNodes() {
            try {
                SqlParameter[] parms = { new SqlParameter("@AIType", SqlDbType.Int),
                                         new SqlParameter("@AOType", SqlDbType.Int),
                                         new SqlParameter("@DIType", SqlDbType.Int),
                                         new SqlParameter("@DOType", SqlDbType.Int),
                                         new SqlParameter("@DefaultValue", SqlDbType.Real),
                                         new SqlParameter("@DefaultStatus", SqlDbType.Int)};

                parms[0].Value = (int)EnmNodeType.Aic;
                parms[1].Value = (int)EnmNodeType.Aoc;
                parms[2].Value = (int)EnmNodeType.Dic;
                parms[3].Value = (int)EnmNodeType.Doc;
                parms[4].Value = 0;
                parms[5].Value = (int)EnmState.NoAlarm;

                using(DataTable dt = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SqlText.SQL_SELECT_NODE_SYNNODES, parms)) {
                    if(dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_Node, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Syn Lsc Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        public void SynNodes(int lscId) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@AIType", SqlDbType.Int),
                                         new SqlParameter("@AOType", SqlDbType.Int),
                                         new SqlParameter("@DIType", SqlDbType.Int),
                                         new SqlParameter("@DOType", SqlDbType.Int),
                                         new SqlParameter("@DefaultValue", SqlDbType.Real),
                                         new SqlParameter("@DefaultStatus", SqlDbType.Int)};

                parms[0].Value = lscId;
                parms[1].Value = (int)EnmNodeType.Aic;
                parms[2].Value = (int)EnmNodeType.Aoc;
                parms[3].Value = (int)EnmNodeType.Dic;
                parms[4].Value = (int)EnmNodeType.Doc;
                parms[5].Value = 0;
                parms[6].Value = (int)EnmState.NoAlarm;

                using (DataTable dt = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SqlText.SQL_SELECT_NODE_SYNLSCNODES, parms)) {
                    if (dt != null && dt.Rows.Count > 0) {
                        SqlHelper.ExecuteBulkCopy(SqlHelper.ConnectionStringLocalTransaction, SqlText.TN_Node, dt);
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to get the specified node
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="nodeId">nodeId</param>
        /// <param name="nodeType">nodeType</param>
        /// <returns>node information</returns>
        public NodeInfo GetNode(int lscId, int nodeId, EnmNodeType nodeType) {
            try {
                SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                         new SqlParameter("@NodeID", SqlDbType.Int),
                                         new SqlParameter("@NodeType", SqlDbType.Int)};
                parms[0].Value = lscId;
                parms[1].Value = nodeId;
                parms[2].Value = (int)nodeType;

                NodeInfo node = null;
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SqlText.SQL_SELECT_NODE_GETNODE, parms)) {
                    if (rdr.Read()) {
                        node = new NodeInfo();
                        node.LscID = ComUtility.DBNullInt32Handler(rdr["LscID"]);
                        node.NodeID = ComUtility.DBNullInt32Handler(rdr["NodeID"]);
                        node.NodeType = ComUtility.DBNullNodeTypeHandler(rdr["NodeType"]);
                        node.Value = ComUtility.DBNullFloatHandler(rdr["Value"]);
                        node.Status = ComUtility.DBNullStateHandler(rdr["Status"]);
                        node.DateTime = ComUtility.DBNullDateTimeHandler(rdr["DateTime"]);
                        node.UpdateTime = ComUtility.DBNullDateTimeHandler(rdr["UpdateTime"]);
                    }
                }

                return node;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to add node information
        /// </summary>
        /// <param name="nodes">nodes</param>
        /// <returns>Affected rows</returns>
        public int AddNodes(IList<NodeInfo> nodes) {
            try {
                int rowCnt = 0;
                using(SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = {
	                        new SqlParameter("@LscID", SqlDbType.Int),
			                new SqlParameter("@NodeID", SqlDbType.Int),
			                new SqlParameter("@NodeType", SqlDbType.Int),
			                new SqlParameter("@Value", SqlDbType.Real),
                            new SqlParameter("@Status", SqlDbType.Int),
			                new SqlParameter("@DateTime", SqlDbType.DateTime),
                            new SqlParameter("@UpdateTime", SqlDbType.DateTime)};

                        foreach(NodeInfo node in nodes) {
                            if(node.LscID != ComUtility.DefaultInt32)
                                parms[0].Value = node.LscID;
                            else
                                parms[0].Value = DBNull.Value;

                            if(node.NodeID != ComUtility.DefaultInt32)
                                parms[1].Value = node.NodeID;
                            else
                                parms[1].Value = DBNull.Value;

                            if(node.NodeType != EnmNodeType.Null)
                                parms[2].Value = (int)node.NodeType;
                            else
                                parms[2].Value = DBNull.Value;

                            if(node.Value != ComUtility.DefaultFloat)
                                parms[3].Value = node.Value;
                            else
                                parms[3].Value = DBNull.Value;

                            if(node.Status != EnmState.Null)
                                parms[4].Value = node.Status;
                            else
                                parms[4].Value = DBNull.Value;

                            if(node.DateTime != ComUtility.DefaultDateTime)
                                parms[5].Value = node.DateTime;
                            else
                                parms[5].Value = DBNull.Value;

                            if(node.UpdateTime != ComUtility.DefaultDateTime)
                                parms[6].Value = node.UpdateTime;
                            else
                                parms[6].Value = DBNull.Value;

                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_INSERT_NODE_ADDNODES, parms);
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
        /// Method to update node information
        /// </summary>
        /// <param name="nodes">nodes</param>
        /// <returns>Affected rows</returns>
        public int UpdateNodes(IList<NodeInfo> nodes) {
            try {
                int rowCnt = 0;
                using(SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = {
	                        new SqlParameter("@LscID", SqlDbType.Int),
			                new SqlParameter("@NodeID", SqlDbType.Int),
			                new SqlParameter("@NodeType", SqlDbType.Int),
			                new SqlParameter("@Value", SqlDbType.Real),
                            new SqlParameter("@Status", SqlDbType.Int),
			                new SqlParameter("@DateTime", SqlDbType.DateTime),
                            new SqlParameter("@UpdateTime", SqlDbType.DateTime)};

                        foreach(NodeInfo node in nodes) {
                            if(node.LscID != ComUtility.DefaultInt32)
                                parms[0].Value = node.LscID;
                            else
                                parms[0].Value = DBNull.Value;

                            if(node.NodeID != ComUtility.DefaultInt32)
                                parms[1].Value = node.NodeID;
                            else
                                parms[1].Value = DBNull.Value;

                            if(node.NodeType != EnmNodeType.Null)
                                parms[2].Value = (int)node.NodeType;
                            else
                                parms[2].Value = DBNull.Value;

                            if(node.Value != ComUtility.DefaultFloat)
                                parms[3].Value = node.Value;
                            else
                                parms[3].Value = DBNull.Value;

                            if(node.Status != EnmState.Null)
                                parms[4].Value = node.Status;
                            else
                                parms[4].Value = DBNull.Value;

                            if(node.DateTime != ComUtility.DefaultDateTime)
                                parms[5].Value = node.DateTime;
                            else
                                parms[5].Value = DBNull.Value;

                            if(node.UpdateTime != ComUtility.DefaultDateTime)
                                parms[6].Value = node.UpdateTime;
                            else
                                parms[6].Value = DBNull.Value;

                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_UPDATE_NODE_UPDATENODES, parms);
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
        /// Method to delete node information
        /// </summary>
        /// <param name="nodes">nodes</param>
        /// <returns>Affected rows</returns>
        public int DeleteNodes(IList<NodeInfo> nodes) {
            try {
                int rowCnt = 0;
                using(SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = {
	                        new SqlParameter("@LscID", SqlDbType.Int),
			                new SqlParameter("@NodeID", SqlDbType.Int),
                            new SqlParameter("@NodeType", SqlDbType.Int)};

                        foreach(NodeInfo node in nodes) {
                            parms[0].Value = node.LscID;
                            parms[1].Value = node.NodeID;
                            parms[2].Value = (int)node.NodeType;

                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_NODE_DELETENODES, parms);
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
        /// Delete all nodes
        /// </summary>
        public void Purge() {
            try {
                using(SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_NODE_PURGE, null);
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
        /// Delete lsc nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        public void Purge(int lscId) {
            try {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try {
                        SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int) };
                        parms[0].Value = lscId;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SqlText.SQL_DELETE_NODE_LSCPURGE, parms);
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
    }
}
