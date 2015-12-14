using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.IDAL
{
    /// <summary>
    /// Interface for order
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// Method to retrieve orders information
        /// </summary>
        /// <returns>All orders</returns>
        List<OrderInfo> GetOrders();

        /// <summary>
        /// Method to delete orders information
        /// </summary>
        /// <param name="orders">orders</param>
        /// <returns>Affected rows</returns>
        int DeleteOrders(IList<OrderInfo> orders);

        /// <summary>
        /// delete all orders
        /// </summary>
        void Purge();

        /// <summary>
        /// Method to get system parameters
        /// </summary>
        /// <param name="paraCode">paraCode</param>
        List<SysParamInfo> GetSysParams(int paraCode);

        /// <summary>
        /// Method to save system parameters
        /// </summary>
        /// <param name="sysParms">sysParms</param>
        void SaveSysParams(List<SysParamInfo> sysParms);

        /// <summary>
        /// Method to delete system parameters
        /// </summary>
        void DeleteSysParams(int paraCode);
    }
}
