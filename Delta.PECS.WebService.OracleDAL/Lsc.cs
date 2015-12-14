using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.OracleDAL
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
            return null;
        }

        /// <summary>
        /// Method to get lsc information
        /// </summary>
        /// <returns>lsc information</returns>
        public LscInfo GetLsc(int lscId) {
            return null;
        }

        /// <summary>
        /// Update the Lsc Attributes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="isConnected">isConnected</param>
        /// <param name="changeTime">changeTime</param>
        /// <returns>Affected rows</returns>
        public int UpdateAttributes(int lscId, bool isConnected, DateTime changeTime) {
            return 0;
        }
    }
}
