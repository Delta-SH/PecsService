using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.DALFactory;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.BLL
{
    /// <summary>
    /// A business componet to get alarms
    /// </summary>
    public class BAlarm
    {
        // Get an instance of the Alarm using the DALFactory
        private static readonly IAlarm alarmDal = DataAccess.CreateAlarm();

        /// <summary>
        /// Syn Alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>Alarms</returns>
        public List<AlarmInfo> SynAlarms(int lscId, string connectionString) {
            try {
                return alarmDal.SynAlarms(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to add alarm information
        /// </summary>
        /// <param name="alarm">alarm</param>
        /// <returns>Affected rows</returns>
        public int AddAlarm(AlarmInfo alarm) {
            try {
                IList<AlarmInfo> alarms = new List<AlarmInfo>();
                alarms.Add(alarm);
                return alarmDal.AddAlarms(alarms);
            }
            catch {
                throw;
            }
        }

        /// <summary>
        /// Method to add alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        /// <returns>Affected rows</returns>
        public int AddAlarms(IList<AlarmInfo> alarms) {
            try {
                return alarmDal.AddAlarms(alarms);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to update alarm information
        /// </summary>
        /// <param name="alarm">alarm</param>
        /// <returns>Affected rows</returns>
        public int UpdateAlarm(AlarmInfo alarm) {
            try {
                IList<AlarmInfo> alarms = new List<AlarmInfo>();
                alarms.Add(alarm);
                return alarmDal.UpdateAlarms(alarms);
            }
            catch {
                throw;
            }
        }

        /// <summary>
        /// Method to update alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        /// <returns>Affected rows</returns>
        public int UpdateAlarms(IList<AlarmInfo> alarms) {
            try {
                return alarmDal.UpdateAlarms(alarms);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to delete alarm information
        /// </summary>
        /// <param name="alarm">alarm</param>
        /// <returns>Affected rows</returns>
        public int DeleteAlarm(AlarmInfo alarm) {
            try {
                IList<AlarmInfo> alarms = new List<AlarmInfo>();
                alarms.Add(alarm);
                return alarmDal.DeleteAlarms(alarms);
            }
            catch {
                throw;
            }
        }

        /// <summary>
        /// Method to delete alarm information
        /// </summary>
        /// <param name="alarms">alarms</param>
        /// <returns>Affected rows</returns>
        public int DeleteAlarms(IList<AlarmInfo> alarms) {
            try {
                return alarmDal.DeleteAlarms(alarms);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete all alarms
        /// </summary>
        public void Purge() {
            try {
                alarmDal.Purge();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete lsc alarms
        /// </summary>
        /// <param name="lscId">lscId</param>
        public void Purge(int lscId) {
            try {
                alarmDal.Purge(lscId);
            }
            catch {
                throw;
            }
        }
    }
}
