using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.IDAL
{
    /// <summary>
    /// Interface for Lsc
    /// </summary>
    public interface ILsc
    {
        /// <summary>
        /// Method to get all lscs information
        /// </summary>
        /// <returns>all lscs information</returns>
        List<LscInfo> GetLscs();

        /// <summary>
        /// Method to get lsc information
        /// </summary>
        /// <returns>lsc information</returns>
        LscInfo GetLsc(int lscId);

        /// <summary>
        /// Update the Lsc Attributes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="isConnected">isConnected</param>
        /// <param name="changeTime">changeTime</param>
        /// <returns>Affected rows</returns>
        int UpdateAttributes(int lscId, bool isConnected, DateTime changeTime);
    }
}
