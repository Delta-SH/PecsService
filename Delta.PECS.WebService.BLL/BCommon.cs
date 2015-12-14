using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.Model;
using Delta.PECS.WebService.DALFactory;

namespace Delta.PECS.WebService.BLL {
    /// <summary>
    /// A business componet to exec common methods.
    /// </summary>
    public class BCommon {
        // Get an instance of the Common using the DALFactory
        private static readonly ICommon commonDal = DataAccess.CreateCommon();

        /// <summary>
        /// Get devices from database.
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="devId">devId</param>
        /// <returns>devices list</returns>
        public List<DevInfo> GetDevices(Int32 lscId, Int32 devId) {
            try {
                return commonDal.GetDevices(lscId, devId);
            } catch {
                throw;
            }
        }
    }
}
