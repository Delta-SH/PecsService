using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.IDAL
{
    /// <summary>
    /// Interface for Lsc
    /// </summary>
    public interface ILsc
    {
        /// <summary>
        /// Method to get all lscs information
        /// </summary>
        /// <returns>all lscs information</returns>
        List<LscInfo> GetLscs();

        /// <summary>
        /// Method to get lsc information
        /// </summary>
        /// <returns>lsc information</returns>
        LscInfo GetLsc(int lscId);

        /// <summary>
        /// Update the Lsc Attributes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="isConnected">isConnected</param>
        /// <param name="changeTime">changeTime</param>
        /// <returns>Affected rows</returns>
        int UpdateAttributes(int lscId, bool isConnected, DateTime changeTime);

        /// <summary>
        /// Method to get all the reservations information
        /// </summary>
        List<ReservationInfo> GetReservations();

        /// <summary>
        /// Method to get all the reservation nodes information
        /// </summary>
        List<NodeInReservationInfo> GetReservationNodes(string id);

        /// <summary>
        /// Update the reservations
        /// </summary>
        void UpdateReservations(IEnumerable<string> ids, bool isSended);

        /// <summary>
        /// Method to add all the reservation information
        /// </summary>
        void AddReservations(string connectionString, List<BookingInfo> bookings);
    }
}
