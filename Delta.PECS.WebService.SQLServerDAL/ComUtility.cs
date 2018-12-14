using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.SQLServerDAL
{
    /// <summary>
    /// Collection of utility methods for DAL-tier
    /// </summary>
    public abstract class ComUtility
    {
        /// <summary>
        /// String Default Value
        /// </summary>
        public static readonly string DefaultString = String.Empty;

        /// <summary>
        /// Int32 Default Value
        /// </summary>
        public static readonly int DefaultInt32 = Int32.MinValue;

        /// <summary>
        /// Int16 Default Value
        /// </summary>
        public static readonly short DefaultInt16 = Int16.MinValue;

        /// <summary>
        /// Single Default Value
        /// </summary>
        public static readonly float DefaultFloat = Single.MinValue;

        /// <summary>
        /// DateTime Default Value
        /// </summary>
        public static readonly DateTime DefaultDateTime = DateTime.MinValue;

        /// <summary>
        /// Boolean Default Value
        /// </summary>
        public static readonly bool DefaultBoolean = false;

        /// <summary>
        /// DBNull String Handler
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>value</returns>
        public static string DBNullStringHandler(object val) {
            if(val == DBNull.Value)
                return DefaultString;

            return val.ToString();
        }

        /// <summary>
        /// DBNull String Checker
        /// </summary>
        /// <param name="val">val</param>
        public static object DBNullStringChecker(string val) {
            if (val == DefaultString || String.IsNullOrEmpty(val))
                return DBNull.Value;

            return val;
        }

        /// <summary>
        /// DBNull String Checker
        /// </summary>
        /// <param name="val">val</param>
        public static object DBNullString2Checker(string val) {
            if (val == null)
                return DBNull.Value;

            return val;
        }

        /// <summary>
        /// DBNull Int32 Handler
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>value</returns>
        public static int DBNullInt32Handler(object val) {
            if(val == DBNull.Value)
                return DefaultInt32;

            return Convert.ToInt32(val);
        }

        /// <summary>
        /// DBNull Int32 Checker
        /// </summary>
        /// <param name="val">val</param>
        public static object DBNullInt32Checker(int val) {
            if (val == DefaultInt32)
                return DBNull.Value;

            return val;
        }

        /// <summary>
        /// DBNull Int16 Handler
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>value</returns>
        public static int DBNullInt16Handler(object val) {
            if(val == DBNull.Value)
                return DefaultInt16;

            return Convert.ToInt16(val);
        }

        /// <summary>
        /// DBNull Int16 Checker
        /// </summary>
        /// <param name="val">val</param>
        public static object DBNullInt16Checker(int val) {
            if (val == DefaultInt16)
                return DBNull.Value;

            return val;
        }

        /// <summary>
        /// DBNull Int32 Handler
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>value</returns>
        public static float DBNullFloatHandler(object val) {
            if(val == DBNull.Value)
                return DefaultFloat;

            return Convert.ToSingle(val);
        }

        /// <summary>
        /// DBNull Float Checker
        /// </summary>
        /// <param name="val">val</param>
        public static object DBNullFloatChecker(float val) {
            if (val == DefaultFloat)
                return DBNull.Value;

            return val;
        }

        /// <summary>
        /// DBNull DateTime Handler
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>value</returns>
        public static DateTime DBNullDateTimeHandler(object val) {
            if(val == DBNull.Value)
                return DefaultDateTime;

            return Convert.ToDateTime(val);
        }

        /// <summary>
        /// DBNull DateTime Checker
        /// </summary>
        /// <param name="val">val</param>
        public static object DBNullDateTimeChecker(DateTime val) {
            if (val == DefaultDateTime)
                return DBNull.Value;

            return val;
        }

        /// <summary>
        /// DBNull Boolean Handler
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>value</returns>
        public static bool DBNullBooleanHandler(object val) {
            if(val == DBNull.Value)
                return DefaultBoolean;

            return Convert.ToBoolean(val);
        }

        /// <summary>
        /// DBNull NodeType Handler
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>value</returns>
        public static EnmNodeType DBNullNodeTypeHandler(object val) {
            if(val == DBNull.Value)
                return EnmNodeType.Null;

            var nodeType = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmNodeType), nodeType) ? (EnmNodeType)nodeType : EnmNodeType.Null;
        }

        /// <summary>
        /// DBNull AlarmLevel Handler
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>value</returns>
        public static EnmAlarmLevel DBNullAlarmLevelHandler(object val) {
            if(val == DBNull.Value)
                return EnmAlarmLevel.Null;

            var alarmLevel = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmAlarmLevel), alarmLevel) ? (EnmAlarmLevel)alarmLevel : EnmAlarmLevel.Null;
        }

        /// <summary>
        /// DBNull AlarmStatus Handler
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>value</returns>
        public static EnmAlarmStatus DBNullAlarmStatusHandler(object val) {
            if(val == DBNull.Value)
                return EnmAlarmStatus.Null;

            var alarmStatus = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmAlarmStatus), alarmStatus) ? (EnmAlarmStatus)alarmStatus : EnmAlarmStatus.Invalid;
        }

        /// <summary>
        /// DBNull State Handler
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>value</returns>
        public static EnmState DBNullStateHandler(object val) {
            if(val == DBNull.Value)
                return EnmState.Null;

            var state = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmState), state) ? (EnmState)state : EnmState.Invalid;
        }

        /// <summary>
        /// DBNull ConfirmMarking Handler
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>value</returns>
        public static EnmConfirmMarking DBNullConfirmMarkingHandler(object val) {
            if(val == DBNull.Value)
                return EnmConfirmMarking.Null;

            var confirmMarking = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmConfirmMarking), confirmMarking) ? (EnmConfirmMarking)confirmMarking : EnmConfirmMarking.Null;
        }

        /// <summary>
        /// DBNull ActType Handler
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>value</returns>
        public static EnmActType DBNullActTypeHandler(object val) {
            if(val == DBNull.Value)
                return EnmActType.Null;

            var action = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmActType), action) ? (EnmActType)action : EnmActType.Null;
        }

        /// <summary>
        /// DBNull ModifyType Handler
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>value</returns>
        public static EnmModifyType DBNullModifyTypeHandler(object val) {
            if(val == DBNull.Value)
                return EnmModifyType.Null;

            var modifyType = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmModifyType), modifyType) ? (EnmModifyType)modifyType : EnmModifyType.Null;
        }

        /// <summary>
        /// DBNull Table ID Handler
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>value</returns>
        public static EnmTableID DBNullTableIDHandler(object val) {
            if(val == DBNull.Value)
                return EnmTableID.Null;

            var tableID = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmTableID), tableID) ? (EnmTableID)tableID : EnmTableID.Null;
        }

        /// <summary>
        /// DBNull ResNode Handler
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>value</returns>
        public static EnmResNode DBNullResNodeHandler(object val) {
            if (val == DBNull.Value)
                return EnmResNode.Device;

            var _v = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmResNode), _v) ? (EnmResNode)_v : EnmResNode.Device;
        }
    }
}
