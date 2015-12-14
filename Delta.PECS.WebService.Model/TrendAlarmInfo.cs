using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.PECS.WebService.Model
{
    /// <summary>
    /// Trend Alarm Information Class
    /// </summary>
    [Serializable]
    public class TrendAlarmInfo
    {
        /// <summary>
        /// LscID
        /// </summary>
        public int LscID { get; set; }

        /// <summary>
        /// Area1Name
        /// </summary>
        public string Area1Name { get; set; }

        /// <summary>
        /// Area2Name
        /// </summary>
        public string Area2Name { get; set; }

        /// <summary>
        /// Area3Name
        /// </summary>
        public string Area3Name { get; set; }

        /// <summary>
        /// Area4Name
        /// </summary>
        public string Area4Name { get; set; }

        /// <summary>
        /// StaName
        /// </summary>
        public string StaName { get; set; }

        /// <summary>
        /// DevName
        /// </summary>
        public string DevName { get; set; }

        /// <summary>
        /// NodeID
        /// </summary>
        public int NodeID { get; set; }

        /// <summary>
        /// NodeType
        /// </summary>
        public EnmNodeType NodeType { get; set; }

        /// <summary>
        /// NodeName
        /// </summary>
        public string NodeName { get; set; }

        /// <summary>
        /// AlarmType
        /// </summary>
        public string AlarmType { get; set; }

        /// <summary>
        /// AlarmStatus
        /// </summary>
        public int AlarmStatus { get; set; }

        /// <summary>
        /// AlarmLevel
        /// </summary>
        public int AlarmLevel { get; set; }

        /// <summary>
        /// StartValue
        /// </summary>
        public float StartValue { get; set; }

        /// <summary>
        /// AlarmValue
        /// </summary>
        public float AlarmValue { get; set; }

        /// <summary>
        /// DiffValue
        /// </summary>
        public float DiffValue { get; set; }

        /// <summary>
        /// StartTime
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// AlarmTime
        /// </summary>
        public DateTime AlarmTime { get; set; }

        /// <summary>
        /// EventTime
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// ConfirmName
        /// </summary>
        public string ConfirmName { get; set; }

        /// <summary>
        /// ConfirmTime
        /// </summary>
        public DateTime ConfirmTime { get; set; }

        /// <summary>
        /// EndName
        /// </summary>
        public string EndName { get; set; }

        /// <summary>
        /// EndTime
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// StartIsAddAlarmList
        /// </summary>
        public Boolean StartIsAddAlarmList { get; set; }

        /// <summary>
        /// EndIsAddAlarmList
        /// </summary>
        public Boolean EndIsAddAlarmList { get; set; }

        /// <summary>
        /// ConfirmIsAddAlarmList
        /// </summary>
        public Boolean ConfirmIsAddAlarmList { get; set; }
    }
}
