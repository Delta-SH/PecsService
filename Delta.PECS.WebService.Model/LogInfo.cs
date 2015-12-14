using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.PECS.WebService.Model
{
    /// <summary>
    /// Log Information Class
    /// </summary>
    [Serializable]
    public class LogInfo
    {
        /// <summary>
        /// EventTime
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// EventType
        /// </summary>
        public EnmLogType EventType { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Operator
        /// </summary>
        public string Operator { get; set; }
    }
}
