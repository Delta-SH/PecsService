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
        public List<LscInfo> GetLscs() {
            return lscDal.GetLscs();
        }

        /// <summary>
        /// Method to get lsc information
        /// </summary>
        public LscInfo GetLsc(int lscId) {
            return lscDal.GetLsc(lscId);
        }

        /// <summary>
        /// Method to update the Lsc Attributes
        /// </summary>
        public int UpdateAttributes(int lscId, bool isConnected, DateTime changeTime) {
            return lscDal.UpdateAttributes(lscId, isConnected, changeTime);
        }

        /// <summary>
        /// Method to get the reservation information
        /// </summary>
        public List<ReservationInfo> GetReservations() {
            return lscDal.GetReservations();
        }

        /// <summary>
        /// Method to get the reservation nodes information
        /// </summary>
        public List<NodeInReservationInfo> GetReservationNodes(string id) {
            return lscDal.GetReservationNodes(id);
        }

        /// <summary>
        /// Method to update the reservation status information
        /// </summary>
        public void UpdateSended(IEnumerable<string> ids, bool isSended = true) {
            lscDal.UpdateReservations(ids, isSended);
        }

        /// <summary>
        /// Method to add the reservation information
        /// </summary>
        public void AddReservations(string connectionString, List<BookingInfo> bookings) {
            lscDal.AddReservations(connectionString, bookings);
        }
    }
}
