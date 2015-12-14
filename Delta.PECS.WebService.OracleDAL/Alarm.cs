using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.OracleDAL
{
    /// <summary>
    /// This class is an implementation for receiving alarm information from database
    /// </summary>
    public class Alarm : IAlarm
    {
        /// <summary>
        /// Syn Alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>Alarms</returns>
        public List<AlarmInfo> SynAlarms(int lscId, string connectionString) {
            return null;
        }

        /// <summary>
        /// Method to add alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        /// <returns>Affected rows</returns>
        public int AddAlarms(IList<AlarmInfo> alarms) {
            return 0;
        }

        /// <summary>
        /// Method to update alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        /// <returns>Affected rows</returns>
        public int UpdateAlarms(IList<AlarmInfo> alarms) {
            return 0;
        }

        /// <summary>
        /// Method to delete alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        /// <returns>Affected rows</returns>
        public int DeleteAlarms(IList<AlarmInfo> alarms) {
            return 0;
        }

        /// <summary>
        /// Delete all alarms
        /// </summary>
        public void Purge() {

        }

        /// <summary>
        /// Delete lsc alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        public void Purge(int lscId) {

        }
    }
}
