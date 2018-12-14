using System;

namespace Delta.PECS.WebService.Model {
    [Serializable]
    public class ProjBookingInfo {
        /// <summary>
        /// BookingUserID
        /// </summary>
        public int BookingUserID { get; set; }

        /// <summary>
        /// ProjID
        /// </summary>
        public string ProjID { get; set; }

        /// <summary>
        /// ProjName
        /// </summary>
        public string ProjName { get; set; }

        /// <summary>
        /// ProjDesc
        /// </summary>
        public string ProjDesc { get; set; }

        /// <summary>
        /// LscIncluded
        /// </summary>
        public int LscIncluded { get; set; }

        /// <summary>
        /// StaIncluded
        /// </summary>
        public string StaIncluded { get; set; }

        /// <summary>
        /// DevIncluded
        /// </summary>
        public string DevIncluded { get; set; }

        /// <summary>
        /// StartTime
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// EndTime
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// ProjStatus
        /// </summary>
        public int ProjStatus { get; set; }

        /// <summary>
        /// IsComfirmed
        /// </summary>
        public bool IsComfirmed { get; set; }

        /// <summary>
        /// ComfirmedUserID
        /// </summary>
        public int ComfirmedUserID { get; set; }

        /// <summary>
        /// ComfirmedTime
        /// </summary>
        public DateTime ComfirmedTime { get; set; }

        /// <summary>
        /// IsChanged
        /// </summary>
        public bool IsChanged { get; set; }

        /// <summary>
        /// BookingTime
        /// </summary>
        public DateTime BookingTime { get; set; }
    }
}
