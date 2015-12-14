using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.IDAL
{
    /// <summary>
    /// Interface for log
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Method to add text log information
        /// </summary>
        /// <param name="logs">logs</param>
        /// <returns>Affected rows</returns>
        int WriteTxtLog(IList<LogInfo> logs);

        /// <summary>
        /// Method to add database log information
        /// </summary>
        /// <param name="logs">logs</param>
        /// <returns>Affected rows</returns>
        int WriteDBLog(IList<LogInfo> logs);
    }
}
