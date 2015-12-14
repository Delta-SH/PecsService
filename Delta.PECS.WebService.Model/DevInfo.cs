using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.PECS.WebService.Model {
    /// <summary>
    /// Device Information Class
    /// </summary>
    [Serializable]
    public class DevInfo {
        /// <summary>
        /// LscID
        /// </summary>
        public int LscID { get; set; }

        /// <summary>
        /// DevID
        /// </summary>
        public int DevID { get; set; }

        /// <summary>
        /// DevName
        /// </summary>
        public string DevName { get; set; }

        /// <summary>
        /// DevDesc
        /// </summary>
        public string DevDesc { get; set; }

        /// <summary>
        /// StaID
        /// </summary>
        public int StaID { get; set; }
    }
}
