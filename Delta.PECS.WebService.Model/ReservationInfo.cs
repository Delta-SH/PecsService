using System;
using System.Collections.Generic;

namespace Delta.PECS.WebService.Model {
    [Serializable]
    public class ReservationInfo {
        /// <summary>
        /// Lsc编号
        /// </summary>
        public int LscId { get; set; }

        /// <summary>
        /// 预约编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 预约名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 工程信息
        /// </summary>
        public ProjectInfo Project { get; set; }

        /// <summary>
        /// 预约节点
        /// </summary>
        public List<NodeInReservationInfo> Nodes { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
    }
}