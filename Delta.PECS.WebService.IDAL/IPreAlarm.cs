using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.IDAL
{
    /// <summary>
    /// Interface for PreAlarm
    /// </summary>
    public interface IPreAlarm
    {
        /// <summary>
        /// Syn Trend Alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>Trend Alarms</returns>
        List<TrendAlarmInfo> SynTrendAlarms(int lscId, string connectionString);

        /// <summary>
        /// Method to save trend alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        void SaveTrendAlarms(List<TrendAlarmInfo> alarms);

        /// <summary>
        /// Method to delete trend alarms information
        /// </summary>
        /// <param name="alarms">alarms</param>
        void DeleteTrendAlarms(List<TrendAlarmInfo> alarms);

        /// <summary>
        /// Method to clear all trend alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        void ClearTrendAlarms(int lscId);

        /// <summary>
        /// Method to clear all trend alarms
        /// </summary>
        void ClearTrendAlarms();

        /// <summary>
        /// Syn Load Alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>Load Alarms</returns>
        List<LoadAlarmInfo> SynLoadAlarms(int lscId, string connectionString);

        /// <summary>
        /// Method to save load alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        void SaveLoadAlarms(List<LoadAlarmInfo> alarms);

        /// <summary>
        /// Method to delete load alarms information
        /// </summary>
        /// <param name="alarms">alarms</param>
        void DeleteLoadAlarms(List<LoadAlarmInfo> alarms);

        /// <summary>
        /// Method to clear all load alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        void ClearLoadAlarms(int lscId);

        /// <summary>
        /// Method to clear all load alarms
        /// </summary>
        void ClearLoadAlarms();

        /// <summary>
        /// Syn Frequency Alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>Frequency Alarms</returns>
        List<FrequencyAlarmInfo> SynFrequencyAlarms(int lscId, string connectionString);

        /// <summary>
        /// Method to save frequency alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        void SaveFrequencyAlarms(List<FrequencyAlarmInfo> alarms);

        /// <summary>
        /// Method to delete frequency alarms information
        /// </summary>
        /// <param name="alarms">alarms</param>
        void DeleteFrequencyAlarms(List<FrequencyAlarmInfo> alarms);

        /// <summary>
        /// Method to clear all frequency alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        void ClearFrequencyAlarms(int lscId);

        /// <summary>
        /// Method to clear all frequency alarms
        /// </summary>
        void ClearFrequencyAlarms();
    }
}
