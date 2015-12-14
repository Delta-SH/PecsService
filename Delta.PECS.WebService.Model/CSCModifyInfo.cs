using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.PECS.WebService.Model
{
    /// <summary>
    /// CSC Modify Information Class
    /// </summary>
    [Serializable]
    public class CSCModifyInfo
    {
        /// <summary>
        /// LscID
        /// </summary>
        public int LscID { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// NodeID
        /// </summary>
        public int NodeID { get; set; }

        /// <summary>
        /// NodeType
        /// </summary>
        public EnmNodeType NodeType { get; set; }

        /// <summary>
        /// ModifyType
        /// </summary>
        public EnmModifyType ModifyType { get; set; }

        /// <summary>
        /// ModifyTime
        /// </summary>
        public DateTime ModifyTime { get; set; }
    }
}
