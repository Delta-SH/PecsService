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
    /// This class is an implementation for receiving common information from database
    /// </summary>
    public class Common : ICommon {
        /// <summary>
        /// Get devices from database.
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="devId">devId</param>
        /// <returns>devices list</returns>
        public List<DevInfo> GetDevices(Int32 lscId, Int32 devId) {
            SqlParameter[] parms = { new SqlParameter("@LscID", SqlDbType.Int),
                                     new SqlParameter("@DevID", SqlDbType.Int) };
            parms[0].Value = lscId;
            parms[1].Value = ComUtility.DBNullInt32Checker(devId);

            var devices = new List<DevInfo>();
            using (var rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SqlText.SQL_SELECT_COMMON_GETDEVICES, parms)) {
                while (rdr.Read()) {
                    var dev = new DevInfo();
                    dev.LscID = ComUtility.DBNullInt32Handler(rdr["LscID"]);
                    dev.DevID = ComUtility.DBNullInt32Handler(rdr["DevID"]);
                    dev.DevName = ComUtility.DBNullStringHandler(rdr["DevName"]);
                    dev.DevDesc = ComUtility.DBNullStringHandler(rdr["DevDesc"]);
                    dev.StaID = ComUtility.DBNullInt32Handler(rdr["StaID"]);
                    devices.Add(dev);
                }
            }

            return devices;
        }
    }
}
