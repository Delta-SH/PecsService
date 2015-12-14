using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.PECS.WebService.Model
{
    /// <summary>
    /// Change Log Information Class
    /// </summary>
    [Serializable]
    public class ChangeLogInfo
    {
        /// <summary>
        /// LscID
        /// </summary>
        public int LscID { get; set; }

        /// <summary>
        /// LogID
        /// </summary>
        public int LogID { get; set; }

        /// <summary>
        /// TableID
        /// </summary>
        public EnmTableID TableID { get; set; }

        /// <summary>
        /// OpType
        /// </summary>
        public EnmModifyType OpType { get; set; }

        /// <summary>
        /// OpSourceID
        /// </summary>
        public int OpSourceID { get; set; }

        /// <summary>
        /// OpDesc
        /// </summary>
        public string OpDesc { get; set; }

        /// <summary>
        /// OpState
        /// </summary>
        public bool OpState { get; set; }

        /// <summary>
        /// OpTime
        /// </summary>
        public DateTime OpTime { get; set; }

        /// <summary>
        /// OpCount
        /// </summary>
        public int OpCount { get; set; }
    }
}
