using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.IDAL
{
    /// <summary>
    /// Interface for alarm
    /// </summary>
    public interface IAlarm
    {
        /// <summary>
        /// Syn Alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>Alarms</returns>
        List<AlarmInfo> SynAlarms(int lscId, string connectionString);

        /// <summary>
        /// Method to add alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        /// <returns>Affected rows</returns>
        int AddAlarms(IList<AlarmInfo> alarms);

        /// <summary>
        /// Method to update alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        /// <returns>Affected rows</returns>
        int UpdateAlarms(IList<AlarmInfo> alarms);

        /// <summary>
        /// Method to delete alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        /// <returns>Affected rows</returns>
        int DeleteAlarms(IList<AlarmInfo> alarms);

        /// <summary>
        /// Delete all alarms
        /// </summary>
        void Purge();

        /// <summary>
        /// Delete lsc alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        void Purge(int lscId);
    }
}
