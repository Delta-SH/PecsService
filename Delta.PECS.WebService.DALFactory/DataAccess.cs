using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.IDAL;

namespace Delta.PECS.WebService.DALFactory
{
    /// <summary>
    /// DAL Factory
    /// </summary>
    public sealed class DataAccess
    {
        /// <summary>
        /// Create Lsc Class for ILsc Interface
        /// </summary>
        /// <returns>ILsc</returns>
        public static ILsc CreateLsc()
        {
            return (ILsc)ServiceLocator.LocateDALObject("Lsc");
        }

        /// <summary>
        /// Create Setting Class for ISetting Interface
        /// </summary>
        /// <returns>ISetting</returns>
        public static ISetting CreateSetting() {
            return (ISetting)ServiceLocator.LocateDALObject("Setting");
        }

        /// <summary>
        /// Create Alarm Class for IAlarm Interface
        /// </summary>
        /// <returns>IAlarm</returns>
        public static IAlarm CreateAlarm() {
            return (IAlarm)ServiceLocator.LocateDALObject("Alarm");
        }

        /// <summary>
        /// Create Node Class for INode Interface
        /// </summary>
        /// <returns>INode</returns>
        public static INode CreateNode() {
            return (INode)ServiceLocator.LocateDALObject("Node");
        }

        /// <summary>
        /// Create Order Class for IOrder Interface
        /// </summary>
        /// <returns>IOrder</returns>
        public static IOrder CreateOrder() {
            return (IOrder)ServiceLocator.LocateDALObject("Order");
        }

        /// <summary>
        /// Create CSCModify Class for ICSCModify Interface
        /// </summary>
        /// <returns>ICSCModify</returns>
        public static ICSCModify CreateCSCModify() {
            return (ICSCModify)ServiceLocator.LocateDALObject("CSCModify");
        }

        /// <summary>
        /// Create Log Class for ILog Interface
        /// </summary>
        /// <returns>ILog</returns>
        public static ILog CreateLog() {
            return (ILog)ServiceLocator.LocateDALObject("Log");
        }

        /// <summary>
        /// Create PreAlarm Class for IPreAlarm Interface
        /// </summary>
        /// <returns>ILog</returns>
        public static IPreAlarm CreatePreAlarm() {
            return (IPreAlarm)ServiceLocator.LocateDALObject("PreAlarm");
        }

        /// <summary>
        /// Create Common Class for ICommon Interface
        /// </summary>
        /// <returns>ICommon</returns>
        public static ICommon CreateCommon() {
            return (ICommon)ServiceLocator.LocateDALObject("Common");
        }
    }
}
