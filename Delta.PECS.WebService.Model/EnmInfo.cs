using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.PECS.WebService.Model
{
    /// <summary>
    /// Action type
    /// </summary>
    public enum EnmActType
    {
        Null,
        RequestNode,
        ConfirmAlarm,
        SetDoc,
        SetAoc,
        SynData,
        DeleteLsc,
        Restart,
        TrendConfirm,
        TrendComplete,
        LoadConfirm,
        LoadComplete,
        FrequencyConfirm,
        FrequencyComplete
    }

    /// <summary>
    /// Database type
    /// </summary>
    public enum EnmDBType
    {
        SQLServer,
        Oracle
    }

    /// <summary>
    /// Node type
    /// </summary>
    public enum EnmNodeType
    {
        Null = -3,
        LSC = -2,
        Area = -1,
        Sta = 0,
        Dev = 1,
        Dic = 2,
        Aic = 3,
        Doc = 4,
        Aoc = 5,
        Str = 6,
        Img = 7,
        Sic = 9,
        SS = 10,
        RS = 11,
        RTU = 12
    }

    /// <summary>
    /// Alarm level
    /// </summary>
    public enum EnmAlarmLevel
    {
        Null = -1,
        NoAlarm,
        Critical,
        Major,
        Minor,
        Hint
    }

    /// <summary>
    /// Alarm status
    /// </summary>
    public enum EnmAlarmStatus
    {
        Null = -1,
        Start,
        Confirm,
        Ended,
        Truning = 5,
        Invalid
    }

    /// <summary>
    /// Alarm confirm marking
    /// </summary>
    public enum EnmConfirmMarking
    {
        Null = -1,
        NotConfirm,
        NotDispatch,
        Dispatched,
        Processing,
        Processed,
        FileOff,
        Cancel
    }

    /// <summary>
    /// Node state
    /// </summary>
    public enum EnmState
    {
        Null = -1,
        NoAlarm,
        Critical,
        Major,
        Minor,
        Hint,
        Opevent,
        Invalid
    }

    /// <summary>
    /// Log Type
    /// </summary>
    public enum EnmLogType
    {
        Info,
        Warning,
        Error,
        Trace,
        Off 
    }

    /// <summary>
    /// User Level
    /// </summary>
    public enum EnmUserLevel
    {
        Ordinary,
        Maintenance,
        Attendant,
        Administrator
    }

    /// <summary>
    /// EnmRunState
    /// </summary>
    public enum EnmRunState
    {
        Start,
        Init,
        Run,
        Pause,
        Stop
    }

    /// <summary>
    /// TCP Link State
    /// </summary>
    public enum EnmLinkState
    {
        Disconnect,
        Connected,
        Authentication
    }

    /// <summary>
    /// Msg Type
    /// </summary>
    public enum EnmMsgType
    {
        Pack = 0,
        packLogin = 101,
        packLoginAck = 102,
        packLogout = 103,
        packLogoutAck = 104,
        packSetAcceMode = 401,
        packSetAcceModeAck = 402,
        packSetAcceModeAck2 = 4012,
        packSetAlarmMode = 501,
        packSetAlarmModeAck = 502,
        packSendAlarm = 503,
        packSendAlarmAck = 504,
        packReqSyncAlarm = 505,
        packSyncAllAlarm = 506,
        packSetPoint = 1001,
        packSetPointAck = 1002,
        packReqModifyPassword = 1101,
        packReqModifyPasswordAck = 1102,
        packHeartbeat = 1201,
        packHeartbeatAck = 1202,
        packTimeCheck = 1301,
        packTimeCheckAck = 1302,
        packPropertyModify = 1501,
        packPropertyModifyAck = 1502,
        packGetServerTimeAck = 5302,
        packDirectSendAlarm = 5011,
        packDirectSendAlarmAck = 5012,
        packSetTask = 5601,
        packSendSheetSetMsg = 5603,
        packSendPunch = 6001,
        packSendTrendAlarm = 7501,
        packConfirmTrendAlarm = 7503,
        packEndTrendAlarm = 7505,
        packSendLoadAlarm = 7601,
        packConfirmLoadAlarm = 7603,
        packEndLoadAlarm = 7605,
        packSendFrequencyAlarm = 7701,
        packConfirmFrequencyAlarm = 7703,
        packEndFrequencyAlarm = 7705
    }

    /// <summary>
    /// Right Mode
    /// </summary>
    public enum EnmRightMode
    {
        Invalid,
        Level1,
        Level2,
        Level3
    }

    /// <summary>
    /// Result
    /// </summary>
    public enum EnmResult
    {
        Failure,
        Success      
    }

    /// <summary>
    /// EnmAcceMode
    /// </summary>
    public enum EnmAcceMode
    {
        Ask_Answer,
        Change_Trigger,
        Time_Trigger,
        Stoped
    }

    /// <summary>
    /// EnmModifyType
    /// </summary>
    public enum EnmModifyType
    {
        Null = -1,
        AddNoNodes,
        AddInNodes,
        Delete,
        ModifyNoNodes,
        ModifyInNodes
    }

    /// <summary>
    /// EnmTableID
    /// </summary>
    public enum EnmTableID
    {
        Null = -1,
        TU_User,
        TU_Group,
        TU_GroupTree,
        TU_UDGroup,
        TU_UDGroupTree,
        TM_ProjBooking,
        TM_Building
    }

    /// <summary>
    /// Reservation Node Type
    /// </summary>
    public enum EnmResNode {
        Lsc = 110,
        Area = 120,
        Station = 130,
        Room = 140,
        Device = 150
    }
}
