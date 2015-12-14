using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.Model;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.DALFactory;

namespace Delta.PECS.WebService.BLL
{
    /// <summary>
    /// A business componet to operate prealarms.
    /// </summary>
    public class BPreAlarm
    {
        // Get an instance of the PreAlarm using the DALFactory
        private static readonly IPreAlarm preAlarmDal = DataAccess.CreatePreAlarm();

        /// <summary>
        /// Syn Trend Alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>Trend Alarms</returns>
        public List<TrendAlarmInfo> SynTrendAlarms(int lscId, string connectionString) {
            return preAlarmDal.SynTrendAlarms(lscId, connectionString);
        }

        /// <summary>
        /// Method to save trend alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        public void SaveTrendAlarms(List<TrendAlarmInfo> alarms) {
            preAlarmDal.SaveTrendAlarms(alarms);
        }

        /// <summary>
        /// Method to delete trend alarms information
        /// </summary>
        /// <param name="alarms">alarms</param>
        public void DeleteTrendAlarms(List<TrendAlarmInfo> alarms) {
            preAlarmDal.DeleteTrendAlarms(alarms);
        }

        /// <summary>
        /// Method to clear all trend alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        public void ClearTrendAlarms(int lscId) {
            preAlarmDal.ClearTrendAlarms(lscId);
        }

        /// <summary>
        /// Method to clear all trend alarms
        /// </summary>
        public void ClearTrendAlarms() {
            preAlarmDal.ClearTrendAlarms();
        }

        /// <summary>
        /// Syn Load Alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>Load Alarms</returns>
        public List<LoadAlarmInfo> SynLoadAlarms(int lscId, string connectionString) {
            return preAlarmDal.SynLoadAlarms(lscId, connectionString);
        }

        /// <summary>
        /// Method to save load alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        public void SaveLoadAlarms(List<LoadAlarmInfo> alarms) {
            preAlarmDal.SaveLoadAlarms(alarms);
        }

        /// <summary>
        /// Method to delete load alarms information
        /// </summary>
        /// <param name="alarms">alarms</param>
        public void DeleteLoadAlarms(List<LoadAlarmInfo> alarms) {
            preAlarmDal.DeleteLoadAlarms(alarms);
        }

        /// <summary>
        /// Method to clear all load alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        public void ClearLoadAlarms(int lscId) {
            preAlarmDal.ClearLoadAlarms(lscId);
        }

        /// <summary>
        /// Method to clear all load alarms
        /// </summary>
        public void ClearLoadAlarms() {
            preAlarmDal.ClearLoadAlarms();
        }

        /// <summary>
        /// Syn Frequency Alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>Frequency Alarms</returns>
        public List<FrequencyAlarmInfo> SynFrequencyAlarms(int lscId, string connectionString) {
            return preAlarmDal.SynFrequencyAlarms(lscId, connectionString);
        }

        /// <summary>
        /// Method to save frequency alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        public void SaveFrequencyAlarms(List<FrequencyAlarmInfo> alarms) {
            preAlarmDal.SaveFrequencyAlarms(alarms);
        }

        /// <summary>
        /// Method to delete frequency alarms information
        /// </summary>
        /// <param name="alarms">alarms</param>
        public void DeleteFrequencyAlarms(List<FrequencyAlarmInfo> alarms) {
            preAlarmDal.DeleteFrequencyAlarms(alarms);
        }

        /// <summary>
        /// Method to clear all frequency alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        public void ClearFrequencyAlarms(int lscId) {
            preAlarmDal.ClearFrequencyAlarms(lscId);
        }

        /// <summary>
        /// Method to clear all frequency alarms
        /// </summary>
        public void ClearFrequencyAlarms() {
            preAlarmDal.ClearFrequencyAlarms();
        }
    }
}
