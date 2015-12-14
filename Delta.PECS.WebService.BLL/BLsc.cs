using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.DALFactory;
using Delta.PECS.WebService.IDAL;
using System.Data;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.BLL
{
    /// <summary>
    /// A business componet to get lsc
    /// </summary>
    public class BLsc
    {
        // Get an instance of the Lsc using the DALFactory
        private static readonly ILsc lscDal = DataAccess.CreateLsc();

        /// <summary>
        /// Method to get all lscs information
        /// </summary>
        /// <returns>all lscs information</returns>
        public List<LscInfo> GetLscs() {
            try {
                return lscDal.GetLscs();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to get lsc information
        /// </summary>
        /// <returns>lsc information</returns>
        public LscInfo GetLsc(int lscId) {
            try {
                return lscDal.GetLsc(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update the Lsc Attributes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="isConnected">isConnected</param>
        /// <param name="changeTime">changeTime</param>
        /// <returns>Affected rows</returns>
        public int UpdateAttributes(int lscId, bool isConnected, DateTime changeTime) {
            try {
                return lscDal.UpdateAttributes(lscId, isConnected, changeTime);
            } catch {
                throw;
            }
        }
    }
}
