using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.OracleDAL {
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
            return null;
        }
    }
}
