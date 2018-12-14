using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.PECS.WebService.Model {
    public class NodeInReservationInfo {
        /// <summary>
        /// 工程预约编号
        /// </summary>
        public string ReservationId { get; set; }

        /// <summary>
        /// 节点编号(Lsc、域、站点、机房、设备)
        /// </summary>
        public string NodeId { get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>
        public EnmResNode NodeType { get; set; }
    }
}
