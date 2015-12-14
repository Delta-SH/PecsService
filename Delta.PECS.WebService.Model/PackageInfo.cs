using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.PECS.WebService.Model
{
    /// <summary>
    /// Package Class
    /// </summary>
    [Serializable]
    public class PackageInfo
    {
        /// <summary>
        /// LscID
        /// </summary>
        public int LscID { get; set; }

        /// <summary>
        /// Bytes
        /// </summary>
        public byte[] Bytes { get; set; }
    }
}
