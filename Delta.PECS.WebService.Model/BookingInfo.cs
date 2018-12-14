using System;
using System.Collections.Generic;

namespace Delta.PECS.WebService.Model {
    [Serializable]
    public class BookingInfo {
        /// <summary>
        /// Lsc编号
        /// </summary>
        public int LscId { get; set; }

        /// <summary>
        /// 工程预约编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 工程预约信息
        /// </summary>
        public List<ProjBookingInfo> Projects { get; set; }
    }
}
