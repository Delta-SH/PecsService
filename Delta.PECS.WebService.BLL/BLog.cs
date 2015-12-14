using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.DALFactory;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.BLL
{
    /// <summary>
    /// A business componet to operate log
    /// </summary>
    public class BLog
    {
        // Get an instance of the Log using the DALFactory
        private static readonly ILog logDal = DataAccess.CreateLog();

        /// <summary>
        /// Method to add text log information
        /// </summary>
        /// <param name="log">log</param>
        /// <returns>Affected rows</returns>
        public int WriteTxtLog(LogInfo log) {
            try {
                IList<LogInfo> temp = new List<LogInfo>();
                temp.Add(log);
                return logDal.WriteTxtLog(temp);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to add text log information
        /// </summary>
        /// <param name="logs">logs</param>
        /// <returns>Affected rows</returns>
        public int WriteTxtLog(IList<LogInfo> logs) {
            try {
                return logDal.WriteTxtLog(logs);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to add database log information
        /// </summary>
        /// <param name="log">log</param>
        /// <returns>Affected rows</returns>
        public int WriteDBLog(LogInfo log) {
            try {
                IList<LogInfo> temp = new List<LogInfo>();
                temp.Add(log);
                return logDal.WriteDBLog(temp);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to add database log information
        /// </summary>
        /// <param name="logs">logs</param>
        /// <returns>Affected rows</returns>
        public int WriteDBLog(IList<LogInfo> logs) {
            try {
                return logDal.WriteDBLog(logs);
            } catch {
                throw;
            }
        }
    }
}
