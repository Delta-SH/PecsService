using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.IDAL {
    /// <summary>
    /// Interface for common methods.
    /// </summary>
    public interface ICommon {
        /// <summary>
        /// Get devices from database.
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="devId">devId</param>
        /// <returns>devices list</returns>
        List<DevInfo> GetDevices(Int32 lscId, Int32 devId);
    }
}
