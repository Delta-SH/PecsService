using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.PECS.WebService.Model
{
    /// <summary>
    /// Node Information Class
    /// </summary>
    [Serializable]
    public class NodeInfo
    {
        /// <summary>
        /// LscID
        /// </summary>
        public int LscID { get; set; }

        /// <summary>
        /// NodeID
        /// </summary>
        public int NodeID { get; set; }

        /// <summary>
        /// NodeType
        /// </summary>
        public EnmNodeType NodeType { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public float Value { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public EnmState Status { get; set; }

        /// <summary>
        /// DateTime
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// UpdateTime
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
