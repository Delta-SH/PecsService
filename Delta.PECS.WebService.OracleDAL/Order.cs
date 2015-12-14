using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.OracleDAL
{
    /// <summary>
    /// This class is an implementation for receiving order information from database
    /// </summary>
    public class Order : IOrder
    {
        /// <summary>
        /// Method to retrieve orders information
        /// </summary>
        /// <returns>All orders</returns>
        public List<OrderInfo> GetOrders() {
            return null;
        }

        /// <summary>
        /// Method to delete orders information
        /// </summary>
        /// <param name="orders">orders</param>
        /// <returns>Affected rows</returns>
        public int DeleteOrders(IList<OrderInfo> orders) {
            return 0;
        }

        /// <summary>
        /// delete all orders
        /// </summary>
        public void Purge() {
            
        }

        /// <summary>
        /// Method to get system parameters
        /// </summary>
        /// <param name="paraCode">paraCode</param>
        public List<SysParamInfo> GetSysParams(int paraCode) {
            return null;
        }

        /// <summary>
        /// Method to save system parameters
        /// </summary>
        /// <param name="sysParms">sysParms</param>
        public void SaveSysParams(List<SysParamInfo> sysParms) {

        }

        /// <summary>
        /// Method to delete system parameters
        /// </summary>
        public void DeleteSysParams(int paraCode) {

        }
    }
}
