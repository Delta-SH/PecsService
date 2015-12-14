using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.DALFactory;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.BLL
{
    /// <summary>
    /// A business componet to get order
    /// </summary>
    public class BOrder
    {
        // Get an instance of the User using the DALFactory
        private static readonly IOrder orderDal = DataAccess.CreateOrder();

        /// <summary>
        /// Method to retrieve orders information
        /// </summary>
        /// <returns>All orders</returns>
        public List<OrderInfo> GetOrders() {
            try {
                return orderDal.GetOrders();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to delete orders information
        /// </summary>
        /// <param name="orders">orders</param>
        /// <returns>Affected rows</returns>
        public int DeleteOrders(IList<OrderInfo> orders) {
            try {
                return orderDal.DeleteOrders(orders);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// delete all orders
        /// </summary>
        public void Purge() {
            try {
                orderDal.Purge();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to get system parameters
        /// </summary>
        /// <param name="paraCode">paraCode</param>
        public List<SysParamInfo> GetSysParams(int paraCode) {
            try {
                return orderDal.GetSysParams(paraCode);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to save system parameters
        /// </summary>
        /// <param name="sysParms">sysParms</param>
        public void SaveSysParams(List<SysParamInfo> sysParms) {
            try {
                orderDal.SaveSysParams(sysParms);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to delete system parameters
        /// </summary>
        public void DeleteSysParams(int paraCode) {
            try {
                orderDal.DeleteSysParams(paraCode);
            } catch {
                throw;
            }
        }
    }
}
