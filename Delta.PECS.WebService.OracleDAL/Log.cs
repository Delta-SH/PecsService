using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.IDAL;
using System.IO;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.OracleDAL
{
    /// <summary>
    /// Operate Log Class
    /// </summary>
    public class Log : ILog
    {
        /// <summary>
        /// Method to add text log information
        /// </summary>
        /// <param name="logs">logs</param>
        /// <returns>Affected rows</returns>
        public int WriteTxtLog(IList<LogInfo> logs) {
            return 0;
        }

        /// <summary>
        /// Method to add database log information
        /// </summary>
        /// <param name="logs">logs</param>
        /// <returns>Affected rows</returns>
        public int WriteDBLog(IList<LogInfo> logs) {
            return 0;
        }
    }
}
