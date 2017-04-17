using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.PECS.WebService.DBUtility
{
    /// <summary>
    /// The SqlText class is intended to encapsulate high performance, 
    /// scalable best practices for common uses of SqlClient.
    /// </summary>
    public static class SqlText
    {
        //Table Name
        public const string TN_Alarm = "[dbo].[TA_Alarm]";
        public const string TN_Node = "[dbo].[TA_Node]";
        public const string TN_FrequencyAlarm = "[dbo].[TA_FrequencyAlarm]";
        public const string TN_LoadAlarm = "[dbo].[TA_LoadAlarm]";
        public const string TN_TrendAlarm = "[dbo].[TA_TrendAlarm]";
        public const string TN_Area = "[dbo].[TM_AREA]";
        public const string TN_Building = "[dbo].[TM_Building]";
        public const string TN_Sta = "[dbo].[TM_STA]";
        public const string TN_Dev = "[dbo].[TM_DEV]";
        public const string TN_AI = "[dbo].[TM_AIC]";
        public const string TN_AO = "[dbo].[TM_AOC]";
        public const string TN_DI = "[dbo].[TM_DIC]";
        public const string TN_DO = "[dbo].[TM_DOC]";
        public const string TN_Group = "[dbo].[TU_Group]";
        public const string TN_GroupTree = "[dbo].[TU_GroupTree]";
        public const string TN_UDGroup = "[dbo].[TU_UDGroup]";
        public const string TN_UDGroupTree = "[dbo].[TU_UDGroupTree]";
        public const string TN_User = "[dbo].[TU_User]";
        public const string TN_SS = "[dbo].[TR_SS]";
        public const string TN_RS = "[dbo].[TR_RS]";
        public const string TN_RTU = "[dbo].[TR_RTU]";
        public const string TN_SIC = "[dbo].[TM_SIC]";
        public const string TN_SubSic = "[dbo].[TM_SubSic]";
        public const string TN_ProjBooking = "[dbo].[TM_ProjBooking]";
        public const string TN_SubDevCap = "[dbo].[TM_SubDevCap]";
        public const string TC_AlarmDeviceType = "[dbo].[TC_AlarmDeviceType]";
        public const string TC_AlarmLogType = "[dbo].[TC_AlarmLogType]";
        public const string TC_AlarmName = "[dbo].[TC_AlarmName]";
        public const string TC_DeviceType = "[dbo].[TC_DeviceType]";
        public const string TC_Productor = "[dbo].[TC_Productor]";
        public const string TC_Protocol = "[dbo].[TC_Protocol]";
        public const string TC_StaFeatures = "[dbo].[TC_StaFeatures]";
        public const string TC_StationType = "[dbo].[TC_StationType]";
        public const string TC_SubAlarmLogType = "[dbo].[TC_SubAlarmLogType]";
        //Lsc SQL Text
        public const string SQL_SELECT_LSC_GETLSCS = @"SELECT [LscID],[LscName],[LscIP],[LscPort],[LscUID],[LscPwd],[BeatInterval],[BeatDelay],[DBServer],[DBPort],[DBUID],[DBPwd],[DBName],[HisDBServer],[HisDBPort],[HisDBUID],[HisDBPwd],[HisDBName],[Connected],[ChangedTime],[Enabled] FROM [dbo].[TM_LSC];";
        public const string SQL_SELECT_LSC_GETLSC = @"SELECT [LscID],[LscName],[LscIP],[LscPort],[LscUID],[LscPwd],[BeatInterval],[BeatDelay],[DBServer],[DBPort],[DBUID],[DBPwd],[DBName],[HisDBServer],[HisDBPort],[HisDBUID],[HisDBPwd],[HisDBName],[Connected],[ChangedTime],[Enabled] FROM [dbo].[TM_LSC] WHERE [LscID] = @LscID;";
        public const string SQL_SELECT_LSC_UPDATEATTRIBUTES = @"UPDATE [dbo].[TM_LSC] SET [Connected] = @Connected,[ChangedTime] = @ChangedTime WHERE [LscID] = @LscID;";
        //Alarm SQL Text
        public const string SQL_SELECT_ALARM_SYNALARMS = @"
        ;WITH Nodes AS
        (
	        SELECT AI.[AicID] AS [NodeID],@AIType AS [NodeType],DE.[DevID],DE.[DevDesc] FROM [dbo].[TM_AIC] AI INNER JOIN [dbo].[TM_DEV] DE ON AI.[DevID] = DE.[DevID]
	        UNION ALL
	        SELECT DI.[DicID] AS [NodeID],@DIType AS [NodeType],DE.[DevID],DE.[DevDesc] FROM [dbo].[TM_DIC] DI INNER JOIN [dbo].[TM_DEV] DE ON DI.[DevID] = DE.[DevID]
        )
        SELECT @LscID AS [LscID],AL.[SerialNO],AL.[Area1Name],AL.[Area2Name],AL.[Area3Name],AL.[Area4Name],AL.[StaName],AL.[DevName],N.[DevDesc],AL.[NodeID],AL.[NodeType],
        AL.[NodeName],AL.[AlarmID],AL.[AlarmValue],AL.[AlarmLevel],AL.[AlarmStatus],AL.[AlarmDesc],AL.[AuxAlarmDesc],AL.[StartTime],AL.[EndTime],AL.[ConfirmName],
        AL.[ConfirmMarking],AL.[ConfirmTime],AL.[AuxSet],AL.[TaskID],AL.[ProjStr] AS [ProjName],0 AS [TurnCount],GETDATE() AS [UpdateTime] FROM [dbo].[TA_Alarm] AL
        LEFT OUTER JOIN Nodes N ON AL.[NodeID] = N.[NodeID] AND AL.[NodeType] = N.[NodeType];";
        public const string SQL_INSERT_ALARM_ADDALARMS = @"DELETE FROM [dbo].[TA_Alarm] WHERE [LscID] = @LscID AND [SerialNO] = @SerialNO;INSERT INTO [dbo].[TA_Alarm]([LscID],[SerialNO],[Area1Name],[Area2Name],[Area3Name],[Area4Name],[StaName],[DevName],[DevDesc],[NodeID],[NodeType],[NodeName],[AlarmID],[AlarmValue],[AlarmLevel],[AlarmStatus],[AlarmDesc],[AuxAlarmDesc],[StartTime],[EndTime],[ConfirmName],[ConfirmMarking],[ConfirmTime],[AuxSet],[TaskID],[ProjName],[TurnCount],[UpdateTime]) VALUES(@LscID,@SerialNO,@Area1Name,@Area2Name,@Area3Name,@Area4Name,@StaName,@DevName,@DevDesc,@NodeID,@NodeType,@NodeName,@AlarmID,@AlarmValue,@AlarmLevel,@AlarmStatus,@AlarmDesc,@AuxAlarmDesc,@StartTime,@EndTime,@ConfirmName,@ConfirmMarking,@ConfirmTime,@AuxSet,@TaskID,@ProjName,@TurnCount,@UpdateTime);";
        public const string SQL_UPDATE_ALARM_UPDATEALARMS = @"UPDATE [dbo].[TA_Alarm] SET [Area1Name] = @Area1Name,[Area2Name] = @Area2Name,[Area3Name] = @Area3Name,[Area4Name] = @Area4Name,[StaName] = @StaName,[DevName] = @DevName,[DevDesc] = @DevDesc,[NodeID] = @NodeID,[NodeType] = @NodeType,[NodeName] = @NodeName,[AlarmID] = @AlarmID,[AlarmValue] = @AlarmValue,[AlarmLevel] = @AlarmLevel,[AlarmStatus] = @AlarmStatus,[AlarmDesc] = @AlarmDesc,[AuxAlarmDesc] = @AuxAlarmDesc,[StartTime] = @StartTime,[EndTime] = @EndTime,[ConfirmName] = @ConfirmName,[ConfirmMarking] = @ConfirmMarking,[ConfirmTime] = @ConfirmTime,[AuxSet] = @AuxSet,[TaskID] = @TaskID,[ProjName] = @ProjName,[TurnCount] = @TurnCount,[UpdateTime] = @UpdateTime WHERE [LscID] = @LscID AND [SerialNO] = @SerialNO;";
        public const string SQL_DELETE_ALARM_DELETEALARMS = @"DELETE FROM [dbo].[TA_Alarm] WHERE [LscID] = @LscID AND [SerialNO] = @SerialNO;";
        public const string SQL_DELETE_ALARM_LSCPURGE = @"DELETE FROM [dbo].[TA_Alarm] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_ALARM_PURGE = @"TRUNCATE TABLE [dbo].[TA_Alarm];";
        //PreAlarm SQL Text
        public const string SQL_SELECT_ALARM_SYNTRENDALARMS = @"SELECT @LscID AS [LscID],[Area1Name],[Area2Name],[Area3Name],[StaName],[DevName],[NodeID],[NodeName],[AlarmType],[AlarmStatus],[AlarmLevel],[StartValue],[AlarmValue],[DiffValue],[StartTime],[AlarmTime],[EventTime],[ConfirmName],[ConfirmTime],[EndName],[EndTime],[StartIsAddAlarmList],[EndIsAddAlarmList],[ConfirmIsAddAlarmList] FROM [dbo].[TA_TrendAlarm];";
        public const string SQL_INSERT_ALARM_SAVETRENDALARMS = @"
        UPDATE [dbo].[TA_TrendAlarm] SET [Area1Name] = @Area1Name,[Area2Name] = @Area2Name,[Area3Name] = @Area3Name,[StaName] = @StaName,[DevName] = @DevName,[NodeName] = @NodeName,[AlarmType] = @AlarmType,[AlarmStatus] = @AlarmStatus,[AlarmLevel] = @AlarmLevel,[StartValue] = @StartValue,[AlarmValue] = @AlarmValue,[DiffValue] = @DiffValue,[StartTime] = @StartTime,[AlarmTime] = @AlarmTime,[EventTime] = @EventTime,[ConfirmName] = @ConfirmName,[ConfirmTime] = @ConfirmTime,[EndName] = @EndName,[EndTime] = @EndTime,[StartIsAddAlarmList] = @StartIsAddAlarmList,[EndIsAddAlarmList] = @EndIsAddAlarmList,[ConfirmIsAddAlarmList] = @ConfirmIsAddAlarmList WHERE [LscID] = @LscID AND [NodeID] = @NodeID;
        IF(@@ROWCOUNT = 0)
        BEGIN
	        INSERT INTO [dbo].[TA_TrendAlarm]([LscID],[Area1Name],[Area2Name],[Area3Name],[StaName],[DevName],[NodeID],[NodeName],[AlarmType],[AlarmStatus],[AlarmLevel],[StartValue],[AlarmValue],[DiffValue],[StartTime],[AlarmTime],[EventTime],[ConfirmName],[ConfirmTime],[EndName],[EndTime],[StartIsAddAlarmList],[EndIsAddAlarmList],[ConfirmIsAddAlarmList]) VALUES(@LscID,@Area1Name,@Area2Name,@Area3Name,@StaName,@DevName,@NodeID,@NodeName,@AlarmType,@AlarmStatus,@AlarmLevel,@StartValue,@AlarmValue,@DiffValue,@StartTime,@AlarmTime,@EventTime,@ConfirmName,@ConfirmTime,@EndName,@EndTime,@StartIsAddAlarmList,@EndIsAddAlarmList,@ConfirmIsAddAlarmList);
        END";
        public const string SQL_DELETE_ALARM_DELETETRENDALARMS = @"DELETE FROM [dbo].[TA_TrendAlarm] WHERE [LscID] = @LscID AND [NodeID] = @NodeID;";
        public const string SQL_DELETE_ALARM_CLEARLSCTRENDALARMS = @"DELETE FROM [dbo].[TA_TrendAlarm] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_ALARM_CLEARTRENDALARMS = @"TRUNCATE TABLE [dbo].[TA_TrendAlarm];";
        public const string SQL_SELECT_ALARM_SYNLOADALARMS = @"SELECT @LscID AS [LscID],[Area1Name],[Area2Name],[Area3Name],[StaName],[DevID],[DevName],[DevTypeID],[AlarmStatus],[AlarmLevel],[RateValue],[LoadValue],[LoadPercent],[RightPercent],[StartTime],[EventTime],[ConfirmName],[ConfirmTime],[EndName],[EndTime],[StartIsAddAlarmList],[EndIsAddAlarmList],[ConfirmIsAddAlarmList] FROM [dbo].[TA_LoadAlarm];";
        public const string SQL_INSERT_ALARM_SAVELOADALARMS = @"
        UPDATE [dbo].[TA_LoadAlarm] SET [Area1Name] = @Area1Name,[Area2Name] = @Area2Name,[Area3Name] = @Area3Name,[StaName] = @StaName,[DevName] = @DevName,[DevTypeID] = @DevTypeID,[AlarmStatus] = @AlarmStatus,[AlarmLevel] = @AlarmLevel,[RateValue] = @RateValue,[LoadValue] = @LoadValue,[LoadPercent] = @LoadPercent,[RightPercent] = @RightPercent,[StartTime] = @StartTime,[EventTime] = @EventTime,[ConfirmName] = @ConfirmName,[ConfirmTime] = @ConfirmTime,[EndName] = @EndName,[EndTime] = @EndTime,[StartIsAddAlarmList] = @StartIsAddAlarmList,[EndIsAddAlarmList] = @EndIsAddAlarmList,[ConfirmIsAddAlarmList] = @ConfirmIsAddAlarmList WHERE [LscID] = @LscID AND [DevID] = @DevID;
        IF(@@ROWCOUNT = 0)
        BEGIN
	        INSERT INTO [dbo].[TA_LoadAlarm]([LscID],[Area1Name],[Area2Name],[Area3Name],[StaName],[DevID],[DevName],[DevTypeID],[AlarmStatus],[AlarmLevel],[RateValue],[LoadValue],[LoadPercent],[RightPercent],[StartTime],[EventTime],[ConfirmName],[ConfirmTime],[EndName],[EndTime],[StartIsAddAlarmList],[EndIsAddAlarmList],[ConfirmIsAddAlarmList])
	        VALUES(@LscID,@Area1Name,@Area2Name,@Area3Name,@StaName,@DevID,@DevName,@DevTypeID,@AlarmStatus,@AlarmLevel,@RateValue,@LoadValue,@LoadPercent,@RightPercent,@StartTime,@EventTime,@ConfirmName,@ConfirmTime,@EndName,@EndTime,@StartIsAddAlarmList,@EndIsAddAlarmList,@ConfirmIsAddAlarmList);
        END";
        public const string SQL_DELETE_ALARM_DELETELOADALARMS = @"DELETE FROM [dbo].[TA_LoadAlarm] WHERE [LscID] = @LscID AND [DevID] = @DevID;";
        public const string SQL_DELETE_ALARM_CLEARLSCLOADALARMS = @"DELETE FROM [dbo].[TA_LoadAlarm] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_ALARM_CLEARLOADALARMS = @"TRUNCATE TABLE [dbo].[TA_LoadAlarm];";
        public const string SQL_SELECT_ALARM_SYNFREQUENCYALARMS = @"SELECT @LscID AS [LscID],[Area1Name],[Area2Name],[Area3Name],[StaName],[DevName],[NodeID],[NodeType],[NodeName],[AlarmStatus],[AlarmLevel],[FreAlarmValue],[FreRightValue],[FreCompareValue],[StartTime],[AlarmTime],[EventTime],[ConfirmName],[ConfirmTime],[EndName],[EndTime],[StartIsAddAlarmList],[EndIsAddAlarmList],[ConfirmIsAddAlarmList] FROM [dbo].[TA_FrequencyAlarm];";
        public const string SQL_INSERT_ALARM_SAVEFREQUENCYALARMS = @"
        UPDATE [dbo].[TA_FrequencyAlarm] SET [Area1Name] = @Area1Name,[Area2Name] = @Area2Name,[Area3Name] = @Area3Name,[StaName] = @StaName,[DevName] = @DevName,[NodeType] = @NodeType,[NodeName] = @NodeName,[AlarmStatus] = @AlarmStatus,[AlarmLevel] = @AlarmLevel,[FreAlarmValue] = @FreAlarmValue,[FreRightValue] = @FreRightValue,[FreCompareValue] = @FreCompareValue,[StartTime] = @StartTime,[AlarmTime] = @AlarmTime,[EventTime] = @EventTime,[ConfirmName] = @ConfirmName,[ConfirmTime] = @ConfirmTime,[EndName] = @EndName,[EndTime] = @EndTime,[StartIsAddAlarmList] = @StartIsAddAlarmList,[EndIsAddAlarmList] = @EndIsAddAlarmList,[ConfirmIsAddAlarmList] = @ConfirmIsAddAlarmList WHERE [LscID] = @LscID AND [NodeID] = @NodeID AND [NodeType] = @NodeType;
        IF(@@ROWCOUNT=0)
        BEGIN
	        INSERT INTO [dbo].[TA_FrequencyAlarm]([LscID],[Area1Name],[Area2Name],[Area3Name],[StaName],[DevName],[NodeID],[NodeType],[NodeName],[AlarmStatus],[AlarmLevel],[FreAlarmValue],[FreRightValue],[FreCompareValue],[StartTime],[AlarmTime],[EventTime],[ConfirmName],[ConfirmTime],[EndName],[EndTime],[StartIsAddAlarmList],[EndIsAddAlarmList],[ConfirmIsAddAlarmList])
	        VALUES(@LscID,@Area1Name,@Area2Name,@Area3Name,@StaName,@DevName,@NodeID,@NodeType,@NodeName,@AlarmStatus,@AlarmLevel,@FreAlarmValue,@FreRightValue,@FreCompareValue,@StartTime,@AlarmTime,@EventTime,@ConfirmName,@ConfirmTime,@EndName,@EndTime,@StartIsAddAlarmList,@EndIsAddAlarmList,@ConfirmIsAddAlarmList);
        END";
        public const string SQL_DELETE_ALARM_DELETEFREQUENCYALARMS = @"DELETE FROM [dbo].[TA_FrequencyAlarm] WHERE [LscID] = @LscID AND [NodeID] = @NodeID AND [NodeType] = @NodeType;";
        public const string SQL_DELETE_ALARM_CLEARLSCFREQUENCYALARMS = @"DELETE FROM [dbo].[TA_FrequencyAlarm] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_ALARM_CLEARFREQUENCYALARMS = @"TRUNCATE TABLE [dbo].[TA_FrequencyAlarm];";

        //Node SQL Text
        public const string SQL_SELECT_NODE_SYNNODES = @"
        ;WITH Nodes AS
        (
            SELECT [LscID],[AicID] AS [NodeID],@AIType AS [NodeType] FROM [dbo].[TM_AIC]
            UNION ALL
            SELECT [LscID],[AocID] AS [NodeID],@AOType AS [NodeType] FROM [dbo].[TM_AOC]
            UNION ALL
            SELECT [LscID],[DicID] AS [NodeID],@DIType AS [NodeType] FROM [dbo].[TM_DIC]
            UNION ALL
            SELECT [LscID],[DocID] AS [NodeID],@DOType AS [NodeType] FROM [dbo].[TM_DOC]
        )
        SELECT [LscID],[NodeID],[NodeType],@DefaultValue AS [Value],@DefaultStatus AS [Status],NULL AS [DateTime],GETDATE() AS [UpdateTime] FROM Nodes;";
        public const string SQL_SELECT_NODE_SYNLSCNODES = @"
        ;WITH Nodes AS
        (
            SELECT [LscID],[AicID] AS [NodeID],@AIType AS [NodeType] FROM [dbo].[TM_AIC] WHERE [LscID] = @LscID
            UNION ALL
            SELECT [LscID],[AocID] AS [NodeID],@AOType AS [NodeType] FROM [dbo].[TM_AOC] WHERE [LscID] = @LscID
            UNION ALL
            SELECT [LscID],[DicID] AS [NodeID],@DIType AS [NodeType] FROM [dbo].[TM_DIC] WHERE [LscID] = @LscID
            UNION ALL
            SELECT [LscID],[DocID] AS [NodeID],@DOType AS [NodeType] FROM [dbo].[TM_DOC] WHERE [LscID] = @LscID
        )
        SELECT [LscID],[NodeID],[NodeType],@DefaultValue AS [Value],@DefaultStatus AS [Status],NULL AS [DateTime],GETDATE() AS [UpdateTime] FROM Nodes;";

        public const string SQL_SELECT_NODE_GETNODE = @"SELECT [LscID],[NodeID],[NodeType],[Value],[Status],[DateTime],[UpdateTime] FROM [dbo].[TA_Node] WHERE [LscID] = @LscID AND [NodeID] = @NodeID AND [NodeType] = @NodeType;";
        public const string SQL_INSERT_NODE_ADDNODES = @"DELETE FROM [dbo].[TA_Node] WHERE [LscID] = @LscID AND [NodeID] = @NodeID AND [NodeType] = @NodeType;INSERT INTO [dbo].[TA_Node]([LscID],[NodeID],[NodeType],[Value],[Status],[DateTime],[UpdateTime]) VALUES(@LscID, @NodeID, @NodeType, @Value, @Status, @DateTime, @UpdateTime);";
        public const string SQL_UPDATE_NODE_UPDATENODES = @"UPDATE [dbo].[TA_Node] SET [Value] = @Value,[Status] = @Status,[DateTime] = @DateTime,[UpdateTime] = @UpdateTime WHERE [LscID] = @LscID AND [NodeID] = @NodeID AND [NodeType] = @NodeType;";
        public const string SQL_DELETE_NODE_DELETENODES = @"DELETE FROM [dbo].[TA_Node] WHERE [LscID] = @LscID AND [NodeID] = @NodeID AND [NodeType] = @NodeType;";
        public const string SQL_DELETE_NODE_PURGE = @"TRUNCATE TABLE [dbo].[TA_Node];";
        public const string SQL_DELETE_NODE_LSCPURGE = @"DELETE FROM [dbo].[TA_Node] WHERE [LscID] = @LscID;";
        //Order SQL Text
        public const string SQL_SELECT_ORDER_GETORDERS = @"SELECT TOP 4000 [LscID],[TargetID],[TargetType],[OrderType],[RelValue1],[RelValue2],[RelValue3],[RelValue4],[RelValue5],[UpdateTime] FROM [dbo].[TA_Order] ORDER BY [UpdateTime];";
        public const string SQL_DELETE_ORDER_DELETEORDERS = @"DELETE FROM [dbo].[TA_Order] WHERE [LscID]=@LscID AND [TargetID]=@TargetID AND [TargetType]=@TargetType AND [OrderType]=@OrderType;";
        public const string SQL_DELETE_ORDER_PURGE = @"TRUNCATE TABLE [dbo].[TA_Order];";
        public const string SQL_SELECT_ORDER_GETSYSPARAMS = @"SELECT [ID],[ParaCode],[ParaData],[ParaDisplay],[Note] FROM [dbo].[TM_SysParam] WHERE [ParaCode] = @ParaCode ORDER BY [ID];";
        public const string SQL_UPDATE_ORDER_SAVESYSPARAMS = @"
        UPDATE [dbo].[TM_SysParam] SET [ParaCode] = @ParaCode,[ParaData] = @ParaData,[ParaDisplay] = @ParaDisplay,[Note] = @Note WHERE [ID] = @ID;
        IF(@@ROWCOUNT = 0)
        BEGIN
	        INSERT INTO [dbo].[TM_SysParam]([ID],[ParaCode],[ParaData],[ParaDisplay],[Note]) VALUES(@ID, @ParaCode, @ParaData, @ParaDisplay, @Note);
        END";
        public const string SQL_DELETE_ORDER_DELETESYSPARAMS = @"DELETE FROM [dbo].[TM_SysParam] WHERE [ParaCode] = @ParaCode;";
        //Log SQL Text
        public const string SQL_INSERT_LOG_WRITEDBLOG = @"INSERT INTO [dbo].[TH_SvcLog]([EventTime],[EventType],[Message],[Operator]) VALUES(@EventTime,@EventType,@Message,@Operator);";
        //Setting SQL Text
        public const string SQL_SELECT_SETTING_SYNCAREA = @"SELECT @LscID AS [LscID],[AreaID],[LastAreaID],[AreaName],[Enabled],[NodeLevel],[MID] FROM [dbo].[TM_AREA];";
        public const string SQL_SELECT_SETTING_SYNCBUILDING = @"SELECT @LscID AS [LscID],[BuildingID],[BuildingName],[BuildingDesc] FROM [dbo].[TC_Building];";
        public const string SQL_SELECT_SETTING_SYNCSTA = @"SELECT @LscID AS [LscID],[StaID],[StaName],[StaDesc],[StaAddress],[LinkMan],[LinkManPhone],[StaTypeID],[LocationWay],[Longitude],[Latitude],[MapDesc],[STDStationID],[NodeFeatures],[AreaID],[DeptID],[MID],[DevCount],[StaPFACount],[NetGridID],[BuildingID],[Enabled] FROM [dbo].[TM_STA];";
        public const string SQL_SELECT_SETTING_SYNCDEV = @"SELECT @LscID AS [LscID],[DevID],[StaID],[Enabled],[DevName],[DevDesc],[DevTypeID],[ProductorID],[AlarmDevTypeID],[Version],[DevModel],[BeginRunTime],[MID],[TDevID],[InstallPosition],[ContextDevName],[Capacity] FROM [dbo].[TM_DEV];";
        public const string SQL_SELECT_SETTING_SYNCAI = @"SELECT @LscID AS [LscID],[AicID],[AicName],[AicDesc],[DevID],[Unit],[AuxSet],[AlarmIdHL1],[AlarmIdLL1],[AlarmIdHL2],[AlarmIdLL2],[AlarmIdHL3],[AlarmIdLL3],[AlarmIdHL4],[AlarmIdLL4],[AlarmID],[AlarmLevel],[RtuID],[DotID],[Enabled] FROM [dbo].[TM_AIC];";
        public const string SQL_SELECT_SETTING_SYNCAO = @"SELECT @LscID AS [LscID],[AocID],[AocName],[AocDesc],[DevID],[Unit],[AuxSet],[AlarmID],[RtuID],[DotID],[Enabled] FROM [dbo].[TM_AOC];";
        public const string SQL_SELECT_SETTING_SYNCDI = @"SELECT @LscID AS [LscID],[DicID],[DicName],[DicDesc],[Describe],[DevID],[AuxSet],[AlarmID],[AlarmLevel],[RtuID],[DotID],[Enabled] FROM [dbo].[TM_DIC];";
        public const string SQL_SELECT_SETTING_SYNCDO = @"SELECT @LscID AS [LscID],[DocID],[DocName],[DocDesc],[Describe],[DevID],[AuxSet],[AlarmID],[RtuID],[DotID],[Enabled] FROM [dbo].[TM_DOC];";
        public const string SQL_SELECT_SETTING_SYNCGROUP = @"SELECT @LscID AS [LscID],[GroupID],[GroupName],[GroupType],[Enabled] FROM [dbo].[TU_Group];";
        public const string SQL_SELECT_SETTING_SYNCGROUPTREEE = @"SELECT @LscID AS [LscID],[NodeID],[GroupID],[NodeType],[LastNodeID],[TreeIndex] FROM [dbo].[TU_GroupTree];";
        public const string SQL_SELECT_SETTING_SYNCUDGROUP = @"SELECT @LscID AS [LscID],[UserID],[UDGroupID],[GroupName] AS [UDGroupName],[Enabled] FROM [dbo].[TU_UDGroup];";
        public const string SQL_SELECT_SETTING_SYNCUDGROUPTREEE = @"SELECT @LscID AS [LscID],[UserID],[UDGroupID],[NodeID],[NodeType],[LastNodeID],[TreeIndex] FROM [dbo].[TU_UDGroupTree];";
        public const string SQL_SELECT_SETTING_SYNCUSER = @"SELECT @LscID AS [LscID],[UserID],[GroupID],[Enabled],[UID],[PWD],[UserName],[EmpNO],[OpLevel],[Sex],[DeptID],[DutyID],[TelePhone],[MobilePhone],[Email],[Address],[PostalCode],[Remark],[OnlineATime],[SendMSG],[SMSLevel],[SMSFilter],[LimitTime],[VoiceLevel],[VoiceFilter],[VoiceType],[SendVoice],[EOMSUserName],[EOMSUserPWD],[IsAutoTaskObj],[LastTaskUserID],[AlarmSoundFiterItem],[AlarmStaticFiterItem],[ActiveValuesFiterItem] FROM [dbo].[TU_User];";
        public const string SQL_SELECT_SETTING_SYNCSS = @"SELECT @LscID AS [LscID],[SSID],[SSName] FROM [dbo].[TR_SS];";
        public const string SQL_SELECT_SETTING_SYNCRS = @"SELECT @LscID AS [LscID],[RSID],[SSID],[RSName] FROM [dbo].[TR_RS];";
        public const string SQL_SELECT_SETTING_SYNCRTU = @"SELECT @LscID AS [LscID],[RtuID],[SSID],[RID],[DevName],[FileName],[Port],[StaName],[RSID],[Protocol] FROM [dbo].[TR_RTU];";
        public const string SQL_SELECT_SETTING_SYNCSIC = @"SELECT @LscID AS [LscID],[SicID],[SSID],[DicID],[Masking],[SicType],[SicDesc],[AlarmLevel],[AlarmID] FROM [dbo].[TM_SIC];";
        public const string SQL_SELECT_SETTING_SYNCSUBSIC = @"SELECT @LscID AS [LscID],[SicID],[LscNodeID] FROM [dbo].[TM_SubSic];";
        public const string SQL_SELECT_SETTING_SYNCPROJBOOKING = @"SELECT @LscID AS [LscID],[BookingID],[BookingUserID],[ProjName],[ProjDesc],[StaIncluded],[DevIncluded],[ProjStatus],[StartTime],[EndTime],[ProjID],[IsComfirmed],[ComfirmedUserID],[ComfirmedTime],[IsChanged],[BookingTime] FROM [dbo].[TM_ProjBooking];";
        public const string SQL_SELECT_SETTING_SYNCSUBDEVCAP = @"SELECT @LscID AS [LscID],[DevID],[BuildingID],[ModuleCount],[DevDesignCapacity],[SingleRatedCapacity],[TotalRatedCapacity],[RedundantCapacity] FROM [dbo].[TM_SubDevCap];";
        public const string SQL_DELETE_SETTING_PURGEAREA = @"TRUNCATE TABLE [dbo].[TM_AREA];";
        public const string SQL_DELETE_SETTING_PURGEBUILDING = @"TRUNCATE TABLE [dbo].[TM_Building];";
        public const string SQL_DELETE_SETTING_PURGESTA = @"TRUNCATE TABLE [dbo].[TM_STA];";
        public const string SQL_DELETE_SETTING_PURGEDEV = @"TRUNCATE TABLE [dbo].[TM_DEV];";
        public const string SQL_DELETE_SETTING_PURGEAI = @"TRUNCATE TABLE [dbo].[TM_AIC];";
        public const string SQL_DELETE_SETTING_PURGEAO = @"TRUNCATE TABLE [dbo].[TM_AOC];";
        public const string SQL_DELETE_SETTING_PURGEDI = @"TRUNCATE TABLE [dbo].[TM_DIC];";
        public const string SQL_DELETE_SETTING_PURGEDO = @"TRUNCATE TABLE [dbo].[TM_DOC];";
        public const string SQL_DELETE_SETTING_PURGEGROUP = @"TRUNCATE TABLE [dbo].[TU_Group];";
        public const string SQL_DELETE_SETTING_PURGEGROUPTREE = @"TRUNCATE TABLE [dbo].[TU_GroupTree];";
        public const string SQL_DELETE_SETTING_PURGEUDGROUP = @"TRUNCATE TABLE [dbo].[TU_UDGroup];";
        public const string SQL_DELETE_SETTING_PURGEUDGROUPTREE = @"TRUNCATE TABLE [dbo].[TU_UDGroupTree];";
        public const string SQL_DELETE_SETTING_PURGEUSER = @"TRUNCATE TABLE [dbo].[TU_User];";
        public const string SQL_DELETE_SETTING_PURGESS = @"TRUNCATE TABLE [dbo].[TR_SS];";
        public const string SQL_DELETE_SETTING_PURGERS = @"TRUNCATE TABLE [dbo].[TR_RS];";
        public const string SQL_DELETE_SETTING_PURGERTU = @"TRUNCATE TABLE [dbo].[TR_RTU];";
        public const string SQL_DELETE_SETTING_PURGESIC = @"TRUNCATE TABLE [dbo].[TM_SIC];";
        public const string SQL_DELETE_SETTING_PURGESUBSIC = @"TRUNCATE TABLE [dbo].[TM_SubSic];";
        public const string SQL_DELETE_SETTING_PURGEPROJBOOKING = @"TRUNCATE TABLE [dbo].[TM_ProjBooking];";
        public const string SQL_DELETE_SETTING_PURGESUBDEVCAP = @"TRUNCATE TABLE [dbo].[TM_SubDevCap];";
        public const string SQL_DELETE_SETTING_DELETEAREA = @"DELETE FROM [dbo].[TM_AREA] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETEBUILDING = @"DELETE FROM [dbo].[TM_Building] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETESTA = @"DELETE FROM [dbo].[TM_STA] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETEDEV = @"DELETE FROM [dbo].[TM_DEV] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETEAI = @"DELETE FROM [dbo].[TM_AIC] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETEAO = @"DELETE FROM [dbo].[TM_AOC] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETEDI = @"DELETE FROM [dbo].[TM_DIC] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETEDO = @"DELETE FROM [dbo].[TM_DOC] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETEGROUP = @"DELETE FROM [dbo].[TU_Group] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETEGROUPTREE = @"DELETE FROM [dbo].[TU_GroupTree] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETEUDGROUP = @"DELETE FROM [dbo].[TU_UDGroup] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETEUDGROUPTREE = @"DELETE FROM [dbo].[TU_UDGroupTree] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETEUSER = @"DELETE FROM [dbo].[TU_User] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETESS = @"DELETE FROM [dbo].[TR_SS] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETERS = @"DELETE FROM [dbo].[TR_RS] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETERTU = @"DELETE FROM [dbo].[TR_RTU] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETESIC = @"DELETE FROM [dbo].[TM_SIC] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETESUBSIC = @"DELETE FROM [dbo].[TM_SubSic] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETEPROJBOOKING = @"DELETE FROM [dbo].[TM_ProjBooking] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_DELETESUBDEVCAP = @"DELETE FROM [dbo].[TM_SubDevCap] WHERE [LscID] = @LscID;";
        public const string SQL_DELETE_SETTING_PurgeAlarmDeviceType = @"TRUNCATE TABLE [dbo].[TC_AlarmDeviceType];";
        public const string SQL_SELECT_SETTING_SyncAlarmDeviceType = @"SELECT [TypeID],[TypeDesc],[DeviceTypeID],[NetClassID] FROM [dbo].[TC_AlarmDeviceType];";
        public const string SQL_DELETE_SETTING_PurgeAlarmLogType = @"TRUNCATE TABLE [dbo].[TC_AlarmLogType];";
        public const string SQL_SELECT_SETTING_SyncAlarmLogType = @"SELECT [TypeID],[AlarmDeviceTypeID],[TypeDesc] FROM [dbo].[TC_AlarmLogType];";
        public const string SQL_DELETE_SETTING_PurgeAlarmName = @"TRUNCATE TABLE [dbo].[TC_AlarmName];";
        public const string SQL_SELECT_SETTING_SyncAlarmName = @"SELECT [ID],[SubAlarmLogTypeID],[AlarmName],[AlarmInterpret],[AlarmVer],[AlarmLevel],[DevEffect],[OperEffect],[NMAlarmID],[AlarmClass] FROM [dbo].[TC_AlarmName];";
        public const string SQL_DELETE_SETTING_PurgeDeviceType = @"TRUNCATE TABLE [dbo].[TC_DeviceType];";
        public const string SQL_SELECT_SETTING_SyncDeviceType = @"SELECT [TypeID],[TypeName] FROM [dbo].[TC_DeviceType];";
        public const string SQL_DELETE_SETTING_PurgeProductor = @"TRUNCATE TABLE [dbo].[TC_Productor];";
        public const string SQL_SELECT_SETTING_SyncProductor = @"SELECT [RecordID],[ProdName],[Phone],[Fax],[Address],[PostalCode],[DeviceTypeName],[Remark] FROM [dbo].[TC_Productor];";
        public const string SQL_DELETE_SETTING_PurgeProtocol = @"TRUNCATE TABLE [dbo].[TC_Protocol];";
        public const string SQL_SELECT_SETTING_SyncProtocol = @"SELECT [TypeID],[TypeName],[TypeDesc] FROM [dbo].[TC_Protocol];";
        public const string SQL_DELETE_SETTING_PurgeStaFeatures = @"TRUNCATE TABLE [dbo].[TC_StaFeatures];";
        public const string SQL_SELECT_SETTING_SyncStaFeatures = @"SELECT [TypeID],[TypeDesc] FROM [dbo].[TC_StaFeatures];";
        public const string SQL_DELETE_SETTING_PurgeStationType = @"TRUNCATE TABLE [dbo].[TC_StationType];";
        public const string SQL_SELECT_SETTING_SyncStationType = @"SELECT [TypeID],[TypeName] FROM [dbo].[TC_StationType];";
        public const string SQL_DELETE_SETTING_PurgeSubAlarmLogType = @"TRUNCATE TABLE [dbo].[TC_SubAlarmLogType];";
        public const string SQL_SELECT_SETTING_SyncSubAlarmLogType = @"SELECT [TypeID],[AlarmLogTypeID],[TypeDesc] FROM [dbo].[TC_SubAlarmLogType];";
        //CSCModify SQL Text
        public const string SQL_SELECT_CSCMODIFY_GETCSCMODIFIES = @"SELECT @LscID AS [LscID],[ID],[NodeID],[NodeType],[ModifyType],[ModifyTime] FROM [dbo].[TH_NodeModify] WHERE [ID] > @StartIndex ORDER BY [ID]; ";
        public const string SQL_SELECT_CSCMODIFY_GETMAXCSCMODIFY = @"SELECT TOP 1 @LscID AS [LscID],[ID],[NodeID],[NodeType],[ModifyType],[ModifyTime] FROM [dbo].[TH_NodeModify] ORDER BY [ID] DESC;";
        public const string SQL_SELECT_CSCMODIFY_GETCHANGELOGS = @"SELECT @LscID AS [LscID],[LogID],[TableID],[OpType],[OpSourceID],[OpDesc],[OpState],[OpTime],[OpCount] FROM [dbo].[TH_ChangeLog] WHERE [LogID] > @StartIndex ORDER BY [LogID];";
        public const string SQL_SELECT_CSCMODIFY_GETMAXCHANGELOG = @"SELECT TOP 1 @LscID AS [LscID],[LogID],[TableID],[OpType],[OpSourceID],[OpDesc],[OpState],[OpTime],[OpCount] FROM [dbo].[TH_ChangeLog] ORDER BY [LogID] DESC;";
        public const string SQL_SELECT_CSCMODIFY_UPDATEALARMDEVTYPE = @"
        ;WITH GADT AS
        (
	        SELECT [TypeID],ROW_NUMBER() OVER(PARTITION BY [DeviceTypeID] ORDER BY [TypeID]) AS ID 
	        FROM [dbo].[TC_AlarmDeviceType]
        ),
        SADT AS
        (
	        SELECT TA.* FROM [dbo].[TC_AlarmDeviceType] TA 
	        INNER JOIN GADT ON TA.[TypeID] = GADT.[TypeID] AND GADT.[ID] = 1
        )
        UPDATE TD SET TD.[AlarmDevTypeID] = SADT.[TypeID] FROM [dbo].[TM_DEV] TD 
        INNER JOIN SADT ON TD.[DevTypeID] = SADT.[DeviceTypeID]
        WHERE TD.[LscID] = @LscID AND (@DevID IS NULL OR TD.[DevID] = @DevID);";
        public const string SQL_SELECT_CSCMODIFY_GETAREA = @"SELECT @LscID AS [LscID],[AreaID],[LastAreaID],[AreaName],[Enabled],[NodeLevel],[MID] FROM [dbo].[TM_AREA] WHERE [AreaID] = @AreaID;";
        public const string SQL_SELECT_CSCMODIFY_ADDAREA = @"DELETE FROM [dbo].[TM_AREA] WHERE [LscID] = @LscID AND [AreaID] = @AreaID;INSERT INTO [dbo].[TM_AREA]([LscID],[AreaID],[LastAreaID],[AreaName],[Enabled],[NodeLevel],[MID]) VALUES(@LscID,@AreaID,@LastAreaID,@AreaName,@Enabled,@NodeLevel,@MID);";
        public const string SQL_SELECT_CSCMODIFY_UPDATEAREA = @"UPDATE [dbo].[TM_AREA] SET [LastAreaID] = @LastAreaID,[AreaName] = @AreaName,[Enabled] = @Enabled,[NodeLevel] = @NodeLevel,[MID] = @MID WHERE [LscID] = @LscID AND [AreaID] = @AreaID;";
        public const string SQL_SELECT_CSCMODIFY_DELAREA = @"
        DELETE FROM [dbo].[TM_AREA] WHERE [LscID] = @LscID AND [AreaID] = @AreaID;
        DELETE [dbo].[TM_AIC] FROM [dbo].[TM_AIC] TAI 
        INNER JOIN [dbo].[TM_DEV] TD ON TAI.[DevID] = TD.[DevID]
        INNER JOIN [dbo].[TM_STA] TS ON TS.[LscID] = @LscID AND TS.[AreaID] = @AreaID AND TD.[StaID] = TS.[StaID];
        DELETE [dbo].[TM_AOC] FROM [dbo].[TM_AOC] TAO 
        INNER JOIN [dbo].[TM_DEV] TD ON TAO.[DevID] = TD.[DevID]
        INNER JOIN [dbo].[TM_STA] TS ON TS.[LscID] = @LscID AND TS.[AreaID] = @AreaID AND TD.[StaID] = TS.[StaID];
        DELETE [dbo].[TM_DIC] FROM [dbo].[TM_DIC] TDI 
        INNER JOIN [dbo].[TM_DEV] TD ON TDI.[DevID] = TD.[DevID]
        INNER JOIN [dbo].[TM_STA] TS ON TS.[LscID] = @LscID AND TS.[AreaID] = @AreaID AND TD.[StaID] = TS.[StaID];
        DELETE [dbo].[TM_DOC] FROM [dbo].[TM_DOC] TDO 
        INNER JOIN [dbo].[TM_DEV] TD ON TDO.[DevID] = TD.[DevID]
        INNER JOIN [dbo].[TM_STA] TS ON TS.[LscID] = @LscID AND TS.[AreaID] = @AreaID AND TD.[StaID] = TS.[StaID];
        DELETE [dbo].[TM_DEV] FROM [dbo].[TM_DEV] TD
        INNER JOIN [dbo].[TM_STA] TS ON TS.[LscID] = @LscID AND TS.[AreaID] = @AreaID AND TD.[StaID] = TS.[StaID];
        DELETE FROM [dbo].[TM_STA] WHERE [LscID] = @LscID AND [AreaID] = @AreaID;";
        public const string SQL_SELECT_CSCMODIFY_GETBUILDING = @"SELECT @LscID AS [LscID],[BuildingID],[BuildingName],[BuildingDesc] FROM [dbo].[TC_Building] WHERE [BuildingID] = @BuildingID;";
        public const string SQL_SELECT_CSCMODIFY_ADDBUILDING = @"DELETE FROM [dbo].[TM_Building] WHERE [LscID] = @LscID AND [BuildingID] = @BuildingID;INSERT INTO [dbo].[TM_Building]([LscID],[BuildingID],[BuildingName],[BuildingDesc]) VALUES(@LscID,@BuildingID,@BuildingName,@BuildingDesc);";
        public const string SQL_SELECT_CSCMODIFY_UPDATEBUILDING = @"UPDATE [dbo].[TM_Building] SET [BuildingName] = @BuildingName,[BuildingDesc] = @BuildingDesc WHERE [LscID] = @LscID AND [BuildingID] = @BuildingID;";
        public const string SQL_SELECT_CSCMODIFY_DELBUILDING = @"DELETE FROM [dbo].[TM_Building] WHERE [LscID] = @LscID AND [BuildingID] = @BuildingID;";
        public const string SQL_SELECT_CSCMODIFY_GETSTA = @"SELECT @LscID AS [LscID],[StaID],[StaName],[StaDesc],[StaAddress],[LinkMan],[LinkManPhone],[StaTypeID],[LocationWay],[Longitude],[Latitude],[MapDesc],[STDStationID],[NodeFeatures],[AreaID],[DeptID],[MID],[DevCount],[StaPFACount],[NetGridID],[BuildingID],[Enabled] FROM [dbo].[TM_STA] WHERE [StaID] = @StaID;";
        public const string SQL_SELECT_CSCMODIFY_ADDSTA = @"DELETE FROM [dbo].[TM_STA] WHERE [LscID] = @LscID AND [StaID] = @StaID;INSERT INTO [dbo].[TM_STA]([LscID],[StaID],[StaName],[StaDesc],[StaAddress],[LinkMan],[LinkManPhone],[StaTypeID],[LocationWay],[Longitude],[Latitude],[MapDesc],[STDStationID],[NodeFeatures],[AreaID],[DeptID],[MID],[DevCount],[StaPFACount],[NetGridID],[BuildingID],[Enabled]) VALUES(@LscID,@StaID,@StaName,@StaDesc,@StaAddress,@LinkMan,@LinkManPhone,@StaTypeID,@LocationWay,@Longitude,@Latitude,@MapDesc,@STDStationID,@NodeFeatures,@AreaID,@DeptID,@MID,@DevCount,@StaPFACount,@NetGridID,@BuildingID,@Enabled);";
        public const string SQL_SELECT_CSCMODIFY_UPDATESTA = @"UPDATE [dbo].[TM_STA] SET [LscID]=@LscID,[StaID]=@StaID,[StaName]=@StaName,[StaDesc]=@StaDesc,[StaAddress]=@StaAddress,[LinkMan]=@LinkMan,[LinkManPhone]=@LinkManPhone,[StaTypeID]=@StaTypeID,[LocationWay]=@LocationWay,[Longitude]=@Longitude,[Latitude]=@Latitude,[MapDesc]=@MapDesc,[STDStationID]=@STDStationID,[NodeFeatures]=@NodeFeatures,[AreaID]=@AreaID,[DeptID]=@DeptID,[MID]=@MID,[DevCount]=@DevCount,[StaPFACount]=@StaPFACount,[NetGridID]=@NetGridID,[BuildingID]=@BuildingID,[Enabled]=@Enabled WHERE [LscID] = @LscID AND [StaID] = @StaID;";
        public const string SQL_SELECT_CSCMODIFY_DELSTA = @"
        DELETE FROM [dbo].[TM_STA] WHERE [LscID] = @LscID AND [StaID] = @StaID;
        DELETE [dbo].[TM_AIC] FROM [dbo].[TM_AIC] TAI 
        INNER JOIN [dbo].[TM_DEV] TD ON TD.[LscID] = @LscID AND TD.[StaID] = @StaID AND TAI.[DevID]  = TD.[DevID];
        DELETE [dbo].[TM_AOC] FROM [dbo].[TM_AOC] TAO 
        INNER JOIN [dbo].[TM_DEV] TD ON TD.[LscID] = @LscID AND TD.[StaID] = @StaID AND TAO.[DevID] = TD.[DevID];
        DELETE [dbo].[TM_DIC] FROM [dbo].[TM_DIC] TDI 
        INNER JOIN [dbo].[TM_DEV] TD ON TD.[LscID] = @LscID AND TD.[StaID] = @StaID AND TDI.[DevID] = TD.[DevID];
        DELETE [dbo].[TM_DOC] FROM [dbo].[TM_DOC] TDO 
        INNER JOIN [dbo].[TM_DEV] TD ON TD.[LscID] = @LscID AND TD.[StaID] = @StaID AND TDO.[DevID] = TD.[DevID];
        DELETE FROM [dbo].[TM_DEV] WHERE [LscID] = @LscID AND [StaID] = @StaID;";
        public const string SQL_SELECT_CSCMODIFY_GETDEV = @"SELECT @LscID AS [LscID],[DevID],[StaID],[Enabled],[DevName],[DevDesc],[DevTypeID],[ProductorID],[AlarmDevTypeID],[Version],[DevModel],[BeginRunTime],[MID],[TDevID],[InstallPosition],[ContextDevName],[Capacity] FROM [dbo].[TM_DEV] WHERE [DevID] = @DevID;";
        public const string SQL_SELECT_CSCMODIFY_GETDEVAI = @"SELECT @LscID AS [LscID],[AicID],[AicName],[AicDesc],[DevID],[Unit],[AuxSet],[AlarmIdHL1],[AlarmIdLL1],[AlarmIdHL2],[AlarmIdLL2],[AlarmIdHL3],[AlarmIdLL3],[AlarmIdHL4],[AlarmIdLL4],[AlarmID],[AlarmLevel],[RtuID],[DotID],[Enabled] FROM [dbo].[TM_AIC] WHERE [DevID] = @DevID;";
        public const string SQL_SELECT_CSCMODIFY_GETDEVAO = @"SELECT @LscID AS [LscID],[AocID],[AocName],[AocDesc],[DevID],[Unit],[AuxSet],[AlarmID],[RtuID],[DotID],[Enabled] FROM [dbo].[TM_AOC] WHERE [DevID] = @DevID;";
        public const string SQL_SELECT_CSCMODIFY_GETDEVDI = @"SELECT @LscID AS [LscID],[DicID],[DicName],[DicDesc],[Describe],[DevID],[AuxSet],[AlarmID],[AlarmLevel],[RtuID],[DotID],[Enabled] FROM [dbo].[TM_DIC] WHERE [DevID] = @DevID;";
        public const string SQL_SELECT_CSCMODIFY_GETDEVDO = @"SELECT @LscID AS [LscID],[DocID],[DocName],[DocDesc],[Describe],[DevID],[AuxSet],[AlarmID],[RtuID],[DotID],[Enabled] FROM [dbo].[TM_DOC] WHERE [DevID] = @DevID;";
        public const string SQL_SELECT_CSCMODIFY_ADDDEV = @"DELETE FROM [dbo].[TM_DEV] WHERE [LscID] = @LscID AND [DevID] = @DevID;INSERT INTO [dbo].[TM_DEV]([LscID],[DevID],[StaID],[Enabled],[DevName],[DevDesc],[DevTypeID],[ProductorID],[AlarmDevTypeID],[Version],[DevModel],[BeginRunTime],[MID],[TDevID],[InstallPosition],[ContextDevName],[Capacity]) VALUES(@LscID,@DevID,@StaID,@Enabled,@DevName,@DevDesc,@DevTypeID,@ProductorID,@AlarmDevTypeID,@Version,@DevModel,@BeginRunTime,@MID,@TDevID,@InstallPosition,@ContextDevName,@Capacity);";
        public const string SQL_SELECT_CSCMODIFY_UPDATEDEV = @"UPDATE [dbo].[TM_DEV] SET [StaID] = @StaID,[Enabled] = @Enabled,[DevName] = @DevName,[DevDesc] = @DevDesc,[DevTypeID] = @DevTypeID,[ProductorID] = @ProductorID,[AlarmDevTypeID] = @AlarmDevTypeID,[Version] = @Version,[DevModel] = @DevModel,[BeginRunTime] = @BeginRunTime,[MID] = @MID,[TDevID]=@TDevID,[InstallPosition]=@InstallPosition,[ContextDevName]=@ContextDevName,[Capacity]=@Capacity WHERE [LscID] = @LscID AND [DevID] = @DevID;";
        public const string SQL_SELECT_CSCMODIFY_DELDEV = @"
        DELETE FROM [dbo].[TM_DEV] WHERE [LscID] = @LscID AND [DevID] = @DevID;
        DELETE FROM [dbo].[TM_SubDevCap] WHERE [LscID] = @LscID AND [DevID] = @DevID;
        DELETE FROM [dbo].[TM_AIC] WHERE [LscID] = @LscID AND [DevID] = @DevID;
        DELETE FROM [dbo].[TM_AOC] WHERE [LscID] = @LscID AND [DevID] = @DevID;
        DELETE FROM [dbo].[TM_DIC] WHERE [LscID] = @LscID AND [DevID] = @DevID;
        DELETE FROM [dbo].[TM_DOC] WHERE [LscID] = @LscID AND [DevID] = @DevID;";
        public const string SQL_SELECT_CSCMODIFY_GETAI = @"SELECT @LscID AS [LscID],[AicID],[AicName],[AicDesc],[DevID],[Unit],[AuxSet],[AlarmIdHL1],[AlarmIdLL1],[AlarmIdHL2],[AlarmIdLL2],[AlarmIdHL3],[AlarmIdLL3],[AlarmIdHL4],[AlarmIdLL4],[AlarmID],[AlarmLevel],[RtuID],[DotID],[Enabled] FROM [dbo].[TM_AIC] WHERE [AicID] = @AicID;";
        public const string SQL_SELECT_CSCMODIFY_ADDAI = @"DELETE FROM [dbo].[TM_AIC] WHERE [LscID] = @LscID AND [AicID] = @AicID;INSERT INTO [dbo].[TM_AIC]([LscID],[AicID],[AicName],[AicDesc],[DevID],[Unit],[AuxSet],[AlarmIdHL1],[AlarmIdLL1],[AlarmIdHL2],[AlarmIdLL2],[AlarmIdHL3],[AlarmIdLL3],[AlarmIdHL4],[AlarmIdLL4],[AlarmID],[AlarmLevel],[RtuID],[DotID],[Enabled]) VALUES(@LscID,@AicID,@AicName,@AicDesc,@DevID,@Unit,@AuxSet,@AlarmIdHL1,@AlarmIdLL1,@AlarmIdHL2,@AlarmIdLL2,@AlarmIdHL3,@AlarmIdLL3,@AlarmIdHL4,@AlarmIdLL4,@AlarmID,@AlarmLevel,@RtuID,@DotID,@Enabled);";
        public const string SQL_SELECT_CSCMODIFY_UPDATEAI = @"UPDATE [dbo].[TM_AIC] SET [AicName]=@AicName,[AicDesc]=@AicDesc,[DevID]=@DevID,[Unit]=@Unit,[AuxSet]=@AuxSet,[AlarmIdHL1]=@AlarmIdHL1,[AlarmIdLL1]=@AlarmIdLL1,[AlarmIdHL2]=@AlarmIdHL2,[AlarmIdLL2]=@AlarmIdLL2,[AlarmIdHL3]=@AlarmIdHL3,[AlarmIdLL3]=@AlarmIdLL3,[AlarmIdHL4]=@AlarmIdHL4,[AlarmIdLL4]=@AlarmIdLL4,[AlarmID]=@AlarmID,[AlarmLevel]=@AlarmLevel,[RtuID]=@RtuID,[DotID]=@DotID,[Enabled]=@Enabled WHERE [LscID] = @LscID AND [AicID] = @AicID;";
        public const string SQL_SELECT_CSCMODIFY_DELAI = @"DELETE FROM [dbo].[TM_AIC] WHERE [LscID] = @LscID AND [AicID] = @AicID;";
        public const string SQL_SELECT_CSCMODIFY_GETAO = @"SELECT @LscID AS [LscID],[AocID],[AocName],[AocDesc],[DevID],[Unit],[AuxSet],[AlarmID],[RtuID],[DotID],[Enabled] FROM [dbo].[TM_AOC] WHERE [AocID] = @AocID;";
        public const string SQL_SELECT_CSCMODIFY_ADDAO = @"DELETE FROM [dbo].[TM_AOC] WHERE [LscID] = @LscID AND [AocID] = @AocID;INSERT INTO [dbo].[TM_AOC]([LscID],[AocID],[AocName],[AocDesc],[DevID],[Unit],[AuxSet],[AlarmID],[RtuID],[DotID],[Enabled]) VALUES(@LscID,@AocID,@AocName,@AocDesc,@DevID,@Unit,@AuxSet,@AlarmID,@RtuID,@DotID,@Enabled);";
        public const string SQL_SELECT_CSCMODIFY_UPDATEAO = @"UPDATE [dbo].[TM_AOC] SET [AocName] = @AocName,[AocDesc] = @AocDesc,[DevID] = @DevID,[Unit] = @Unit,[AuxSet] = @AuxSet,[AlarmID] = @AlarmID,[RtuID] = @RtuID,[DotID] = @DotID,[Enabled] = @Enabled WHERE [LscID] = @LscID AND [AocID] = @AocID;";
        public const string SQL_SELECT_CSCMODIFY_DELAO = @"DELETE FROM [dbo].[TM_AOC] WHERE [LscID] = @LscID AND [AocID] = @AocID;";
        public const string SQL_SELECT_CSCMODIFY_GETDI = @"SELECT @LscID AS [LscID],[DicID],[DicName],[DicDesc],[Describe],[DevID],[AuxSet],[AlarmID],[AlarmLevel],[RtuID],[DotID],[Enabled] FROM [dbo].[TM_DIC] WHERE [DicID] = @DicID;";
        public const string SQL_SELECT_CSCMODIFY_ADDDI = @"DELETE FROM [dbo].[TM_DIC] WHERE [LscID] = @LscID AND [DicID] = @DicID;INSERT INTO [dbo].[TM_DIC]([LscID],[DicID],[DicName],[DicDesc],[Describe],[DevID],[AuxSet],[AlarmID],[AlarmLevel],[RtuID],[DotID],[Enabled]) VALUES(@LscID,@DicID,@DicName,@DicDesc,@Describe,@DevID,@AuxSet,@AlarmID,@AlarmLevel,@RtuID,@DotID,@Enabled);";
        public const string SQL_SELECT_CSCMODIFY_UPDATEDI = @"UPDATE [dbo].[TM_DIC] SET [DicName] = @DicName,[DicDesc] = @DicDesc,[Describe] = @Describe,[DevID] = @DevID,[AuxSet] = @AuxSet,[AlarmID] = @AlarmID,[AlarmLevel] = @AlarmLevel,[RtuID] = @RtuID,[DotID] = @DotID,[Enabled] = @Enabled WHERE [LscID] = @LscID AND [DicID] = @DicID;";
        public const string SQL_SELECT_CSCMODIFY_DELDI = @"DELETE FROM [dbo].[TM_DIC] WHERE [LscID] = @LscID AND [DicID] = @DicID;";
        public const string SQL_SELECT_CSCMODIFY_GETDO = @"SELECT @LscID AS [LscID],[DocID],[DocName],[DocDesc],[Describe],[DevID],[AuxSet],[AlarmID],[RtuID],[DotID],[Enabled] FROM [dbo].[TM_DOC] WHERE [DocID] = @DocID;";
        public const string SQL_SELECT_CSCMODIFY_ADDDO = @"DELETE FROM [dbo].[TM_DOC] WHERE [LscID] = @LscID AND [DocID] = @DocID;INSERT INTO [dbo].[TM_DOC]([LscID],[DocID],[DocName],[DocDesc],[Describe],[DevID],[AuxSet],[AlarmID],[RtuID],[DotID],[Enabled]) VALUES(@LscID,@DocID,@DocName,@DocDesc,@Describe,@DevID,@AuxSet,@AlarmID,@RtuID,@DotID,@Enabled);";
        public const string SQL_SELECT_CSCMODIFY_UPDATEDO = @"UPDATE [dbo].[TM_DOC] SET [DocName] = @DocName,[DocDesc] = @DocDesc,[Describe] = @Describe,[DevID] = @DevID,[AuxSet] = @AuxSet,[AlarmID] = @AlarmID,[RtuID] = @RtuID,[DotID] = @DotID,[Enabled] = @Enabled WHERE [LscID] = @LscID AND [DocID] = @DocID;";
        public const string SQL_SELECT_CSCMODIFY_DELDO = @"DELETE FROM [dbo].[TM_DOC] WHERE [LscID] = @LscID AND [DocID] = @DocID;";
        public const string SQL_SELECT_CSCMODIFY_GETGROUP = @"SELECT @LscID AS [LscID],[GroupID],[Enabled],[GroupName],[GroupType] FROM [dbo].[TU_Group] WHERE [GroupID] = @GroupID;";
        public const string SQL_SELECT_CSCMODIFY_ADDGROUP = @"DELETE FROM [dbo].[TU_Group] WHERE [LscID] = @LscID AND [GroupID] = @GroupID;INSERT INTO [dbo].[TU_Group]([LscID],[GroupID],[GroupName],[GroupType],[Enabled]) VALUES(@LscID,@GroupID,@GroupName,@GroupType,@Enabled);";
        public const string SQL_SELECT_CSCMODIFY_UPDATEGROUP = @"UPDATE [dbo].[TU_Group] SET [GroupName] = @GroupName,[GroupType] = @GroupType,[Enabled] = @Enabled WHERE [LscID] = @LscID AND [GroupID] = @GroupID;";
        public const string SQL_SELECT_CSCMODIFY_DELGROUP = @"DELETE FROM [dbo].[TU_Group] WHERE [LscID] = @LscID AND [GroupID] = @GroupID;DELETE FROM [dbo].[TU_GroupTree] WHERE [LscID] = @LscID AND [GroupID] = @GroupID;";
        public const string SQL_SELECT_CSCMODIFY_GETGROUPTREE = @"SELECT @LscID AS [LscID],[NodeID],[GroupID],[NodeType],[LastNodeID],[TreeIndex] FROM [dbo].[TU_GroupTree] WHERE [GroupID] = @GroupID;";
        public const string SQL_SELECT_CSCMODIFY_DELGROUPTREE = @"DELETE FROM [dbo].[TU_GroupTree] WHERE [LscID] = @LscID AND [GroupID] = @GroupID;";
        public const string SQL_SELECT_CSCMODIFY_GETUDGROUP = @"SELECT @LscID AS [LscID],[UserID],[UDGroupID],[GroupName] AS [UDGroupName],[Enabled] FROM [dbo].[TU_UDGroup] WHERE [UserID] = @UserID AND [UDGroupID] = @UDGroupID;";
        public const string SQL_SELECT_CSCMODIFY_ADDUDGROUP = @"DELETE FROM [dbo].[TU_UDGroup] WHERE [LscID] = @LscID AND [UserID] = @UserID AND [UDGroupID] = @UDGroupID;INSERT INTO [dbo].[TU_UDGroup]([LscID],[UserID],[UDGroupID],[UDGroupName],[Enabled]) VALUES(@LscID,@UserID,@UDGroupID,@UDGroupName,@Enabled);";
        public const string SQL_SELECT_CSCMODIFY_UPDATEUDGROUP = @"UPDATE [dbo].[TU_UDGroup] SET [UDGroupName] = @UDGroupName,[Enabled] = @Enabled WHERE [LscID] = @LscID AND [UserID] = @UserID AND [UDGroupID] = @UDGroupID;";
        public const string SQL_SELECT_CSCMODIFY_DELUDGROUP = @"DELETE FROM [dbo].[TU_UDGroup] WHERE [LscID] = @LscID AND [UserID] = @UserID AND [UDGroupID] = @UDGroupID;DELETE FROM [dbo].[TU_UDGroupTree] WHERE [LscID] = @LscID AND [UserID] = @UserID AND [UDGroupID] = @UDGroupID;";
        public const string SQL_SELECT_CSCMODIFY_GETUDGROUPTREE = @"SELECT @LscID AS [LscID],[UserID],[UDGroupID],[NodeID],[NodeType],[LastNodeID],[TreeIndex] FROM [dbo].[TU_UDGroupTree] WHERE [UserID] = @UserID AND [UDGroupID] = @UDGroupID;";
        public const string SQL_SELECT_CSCMODIFY_DELUDGROUPTREE = @"DELETE FROM [dbo].[TU_UDGroupTree] WHERE [LscID] = @LscID AND [UserID] = @UserID AND [UDGroupID] = @UDGroupID;";
        public const string SQL_SELECT_CSCMODIFY_GETUSER = @"SELECT @LscID AS [LscID],[UserID],[GroupID],[Enabled],[UID],[PWD],[UserName],[EmpNO],[OpLevel],[Sex],[DeptID],[DutyID],[TelePhone],[MobilePhone],[Email],[Address],[PostalCode],[Remark],[OnlineATime],[SendMSG],[SMSLevel],[SMSFilter],[LimitTime],[VoiceLevel],[VoiceFilter],[VoiceType],[SendVoice],[EOMSUserName],[EOMSUserPWD],[IsAutoTaskObj],[LastTaskUserID],[AlarmSoundFiterItem],[AlarmStaticFiterItem],[ActiveValuesFiterItem] FROM [dbo].[TU_User] WHERE [UserID] = @UserID;";
        public const string SQL_SELECT_CSCMODIFY_ADDUSER = @"DELETE FROM [dbo].[TU_User] WHERE [LscID] = @LscID AND [UserID] = @UserID;INSERT INTO [dbo].[TU_User]([LscID],[UserID],[GroupID],[Enabled],[UID],[PWD],[UserName],[EmpNO],[OpLevel],[Sex],[DeptID],[DutyID],[TelePhone],[MobilePhone],[Email],[Address],[PostalCode],[Remark],[OnlineATime],[SendMSG],[SMSLevel],[SMSFilter],[LimitTime],[VoiceLevel],[VoiceFilter],[VoiceType],[SendVoice],[EOMSUserName],[EOMSUserPWD],[IsAutoTaskObj],[LastTaskUserID],[AlarmSoundFiterItem],[AlarmStaticFiterItem],[ActiveValuesFiterItem]) VALUES(@LscID,@UserID,@GroupID,@Enabled,@UID,@PWD,@UserName,@EmpNO,@OpLevel,@Sex,@DeptID,@DutyID,@TelePhone,@MobilePhone,@Email,@Address,@PostalCode,@Remark,@OnlineATime,@SendMSG,@SMSLevel,@SMSFilter,@LimitTime,@VoiceLevel,@VoiceFilter,@VoiceType,@SendVoice,@EOMSUserName,@EOMSUserPWD,@IsAutoTaskObj,@LastTaskUserID,@AlarmSoundFiterItem,@AlarmStaticFiterItem,@ActiveValuesFiterItem);";
        public const string SQL_SELECT_CSCMODIFY_UPDATEUSER = @"UPDATE [dbo].[TU_User] SET [GroupID] = @GroupID,[Enabled] = @Enabled,[UID] = @UID,[PWD] = @PWD,[UserName] = @UserName,[EmpNO] = @EmpNO,[OpLevel] = @OpLevel,[Sex] = @Sex,[DeptID] = @DeptID,[DutyID] = @DutyID,[TelePhone] = @TelePhone,[MobilePhone] = @MobilePhone,[Email] = @Email,[Address] = @Address,[PostalCode] = @PostalCode,[Remark] = @Remark,[OnlineATime] = @OnlineATime,[SendMSG] = @SendMSG,[SMSLevel] = @SMSLevel,[SMSFilter] = @SMSFilter,[LimitTime] = @LimitTime,[VoiceLevel] = @VoiceLevel,[VoiceFilter] = @VoiceFilter,[VoiceType] = @VoiceType,[SendVoice] = @SendVoice,[EOMSUserName] = @EOMSUserName,[EOMSUserPWD] = @EOMSUserPWD,[IsAutoTaskObj] = @IsAutoTaskObj,[LastTaskUserID] = @LastTaskUserID,[AlarmSoundFiterItem] = @AlarmSoundFiterItem,[AlarmStaticFiterItem] = @AlarmStaticFiterItem,[ActiveValuesFiterItem] = @ActiveValuesFiterItem WHERE [LscID] = @LscID AND [UserID] = @UserID;";
        public const string SQL_SELECT_CSCMODIFY_DELUSER = @"DELETE FROM [dbo].[TU_User] WHERE [LscID] = @LscID AND [UserID] = @UserID;DELETE FROM [dbo].[TU_UDGroupTree] WHERE [LscID] = @LscID AND [UserID] = @UserID;";
        public const string SQL_SELECT_CSCMODIFY_GETSS = @"SELECT @LscID AS [LscID],[SSID],[SSName] FROM [dbo].[TR_SS] WHERE [SSID] = @SSID;";
        public const string SQL_SELECT_CSCMODIFY_ADDSS = @"DELETE FROM [dbo].[TR_SS] WHERE [LscID] = @LscID AND [SSID] = @SSID;INSERT INTO [dbo].[TR_SS]([LscID],[SSID],[SSName]) VALUES(@LscID,@SSID,@SSName);";
        public const string SQL_SELECT_CSCMODIFY_UPDATESS = @"UPDATE [dbo].[TR_SS] SET [SSName] = @SSName WHERE [LscID] = @LscID AND [SSID] = @SSID;";
        public const string SQL_SELECT_CSCMODIFY_DELSS = @"
        DELETE FROM [dbo].[TR_SS] WHERE [LscID] = @LscID AND [SSID] = @SSID;
        DELETE [dbo].[TM_SubSic] FROM [dbo].[TM_SubSic] TSS INNER JOIN [dbo].[TM_SIC] TS ON TSS.[LscID] = @LscID AND TSS.[SicID] = TS.[SicID];
        DELETE FROM [dbo].[TM_SIC] WHERE [LscID] = @LscID AND [SSID] = @SSID;
        DELETE FROM [dbo].[TR_RTU] WHERE [LscID] = @LscID AND [SSID] = @SSID;
        DELETE FROM [dbo].[TR_RS] WHERE [LscID] = @LscID AND [SSID] = @SSID;";
        public const string SQL_SELECT_CSCMODIFY_GETRS = @"SELECT @LscID AS [LscID],[RSID],[SSID],[RSName] FROM [dbo].[TR_RS] WHERE [RSID] = @RSID;";
        public const string SQL_SELECT_CSCMODIFY_ADDRS = @"DELETE FROM [dbo].[TR_RS] WHERE [LscID] = @LscID AND [RSID] = @RSID;INSERT INTO [dbo].[TR_RS]([LscID],[RSID],[SSID],[RSName]) VALUES(@LscID,@RSID,@SSID,@RSName);";
        public const string SQL_SELECT_CSCMODIFY_UPDATERS = @"UPDATE [dbo].[TR_RS] SET [SSID] = @SSID,[RSName] = @RSName WHERE [LscID] = @LscID AND [RSID] = @RSID;";
        public const string SQL_SELECT_CSCMODIFY_DELRS = @"DELETE FROM [dbo].[TR_RS] WHERE [LscID] = @LscID AND [RSID] = @RSID;";
        public const string SQL_SELECT_CSCMODIFY_GETRTU = @"SELECT @LscID AS [LscID],[RtuID],[SSID],[RID],[DevName],[FileName],[Port],[StaName],[RSID],[Protocol] FROM [dbo].[TR_RTU] WHERE [RtuID] = @RtuID;";
        public const string SQL_SELECT_CSCMODIFY_ADDRTU = @"DELETE FROM [dbo].[TR_RTU] WHERE [LscID] = @LscID AND [RtuID] = @RtuID;INSERT INTO [dbo].[TR_RTU]([LscID],[RtuID],[SSID],[RID],[DevName],[FileName],[Port],[StaName],[RSID],[Protocol]) VALUES(@LscID,@RtuID,@SSID,@RID,@DevName,@FileName,@Port,@StaName,@RSID,@Protocol);";
        public const string SQL_SELECT_CSCMODIFY_UPDATERTU = @"UPDATE [dbo].[TR_RTU] SET [SSID] = @SSID,[RID] = @RID,[DevName] = @DevName,[FileName] = @FileName,[Port] = @Port,[StaName] = @StaName,[RSID] = @RSID,[Protocol] = @Protocol WHERE [LscID] = @LscID AND [RtuID] = @RtuID;";
        public const string SQL_SELECT_CSCMODIFY_DELRTU = @"DELETE FROM [dbo].[TR_RTU] WHERE [LscID] = @LscID AND [RtuID] = @RtuID;";
        public const string SQL_SELECT_CSCMODIFY_GETSIC = @"SELECT @LscID AS [LscID],[SicID],[SSID],[DicID],[Masking],[SicType],[SicDesc],[AlarmLevel],[AlarmID] FROM [dbo].[TM_SIC] WHERE [SicID] = @SicID;";
        public const string SQL_SELECT_CSCMODIFY_ADDSIC = @"DELETE FROM [dbo].[TM_SIC] WHERE [LscID] = @LscID AND [SicID] = @SicID;INSERT INTO [dbo].[TM_SIC]([LscID],[SicID],[SSID],[DicID],[Masking],[SicType],[SicDesc],[AlarmLevel],[AlarmID]) VALUES(@LscID,@SicID,@SSID,@DicID,@Masking,@SicType,@SicDesc,@AlarmLevel,@AlarmID);";
        public const string SQL_SELECT_CSCMODIFY_UPDATESIC = @"UPDATE [dbo].[TM_SIC] SET [SSID] = @SSID,[DicID] = @DicID,[Masking] = @Masking,[SicType] = @SicType,[SicDesc] = @SicDesc,[AlarmLevel] = @AlarmLevel,[AlarmID] = @AlarmID WHERE [LscID] = @LscID AND [SicID] = @SicID;";
        public const string SQL_SELECT_CSCMODIFY_DELSIC = @"DELETE FROM [dbo].[TM_SIC] WHERE [LscID] = @LscID AND [SicID] = @SicID;DELETE FROM [dbo].[TM_SubSic] WHERE [LscID] = @LscID AND [SicID] = @SicID;";
        public const string SQL_SELECT_CSCMODIFY_GETSUBSIC = @"SELECT @LscID AS [LscID],[SicID],[LscNodeID] FROM [dbo].[TM_SubSic] WHERE [SicID] = @SicID;";
        public const string SQL_SELECT_CSCMODIFY_DELSUBSIC = @"DELETE FROM [dbo].[TM_SubSic] WHERE [LscID] = @LscID AND [SicID] = @SicID;";
        public const string SQL_SELECT_CSCMODIFY_GETPROJBOOKING = @"SELECT @LscID AS [LscID],[BookingID],[BookingUserID],[ProjName],[ProjDesc],[StaIncluded],[DevIncluded],[ProjStatus],[StartTime],[EndTime],[ProjID],[IsComfirmed],[ComfirmedUserID],[ComfirmedTime],[IsChanged],[BookingTime] FROM [dbo].[TM_ProjBooking] WHERE [BookingID] = @BookingID;";
        public const string SQL_SELECT_CSCMODIFY_ADDPROJBOOKING = @"DELETE FROM [dbo].[TM_ProjBooking] WHERE [LscID] = @LscID AND [BookingID] = @BookingID;INSERT INTO [dbo].[TM_ProjBooking]([LscID],[BookingID],[BookingUserID],[ProjName],[ProjDesc],[StaIncluded],[DevIncluded],[ProjStatus],[StartTime],[EndTime],[ProjID],[IsComfirmed],[ComfirmedUserID],[ComfirmedTime],[IsChanged],[BookingTime]) VALUES(@LscID,@BookingID,@BookingUserID,@ProjName,@ProjDesc,@StaIncluded,@DevIncluded,@ProjStatus,@StartTime,@EndTime,@ProjID,@IsComfirmed,@ComfirmedUserID,@ComfirmedTime,@IsChanged,@BookingTime);";
        public const string SQL_SELECT_CSCMODIFY_UPDATEPROJBOOKING = @"UPDATE [dbo].[TM_ProjBooking] SET [BookingUserID] = @BookingUserID,[ProjName] = @ProjName,[ProjDesc] = @ProjDesc,[StaIncluded] = @StaIncluded,[DevIncluded] = @DevIncluded,[ProjStatus] = @ProjStatus,[StartTime] = @StartTime,[EndTime] = @EndTime,[ProjID] = @ProjID,[IsComfirmed] = @IsComfirmed,[ComfirmedUserID] = @ComfirmedUserID,[ComfirmedTime] = @ComfirmedTime,[IsChanged] = @IsChanged,[BookingTime] = @BookingTime WHERE [LscID] = @LscID AND [BookingID] = @BookingID;";
        public const string SQL_SELECT_CSCMODIFY_DELPROJBOOKING = @"DELETE FROM [dbo].[TM_ProjBooking] WHERE [LscID] = @LscID AND [BookingID] = @BookingID;";
        public const string SQL_SELECT_CSCMODIFY_GETSUBDEVCAP = @"SELECT @LscID AS [LscID],[DevID],[BuildingID],[ModuleCount],[DevDesignCapacity],[SingleRatedCapacity],[TotalRatedCapacity],[RedundantCapacity] FROM [dbo].[TM_SubDevCap] WHERE [DevID] = @DevID;";
        public const string SQL_SELECT_CSCMODIFY_ADDSUBDEVCAP = @"DELETE FROM [dbo].[TM_SubDevCap] WHERE [LscID] = @LscID AND [DevID] = @DevID;INSERT INTO [dbo].[TM_SubDevCap]([LscID],[DevID],[BuildingID],[ModuleCount],[DevDesignCapacity],[SingleRatedCapacity],[TotalRatedCapacity],[RedundantCapacity]) VALUES(@LscID,@DevID,@BuildingID,@ModuleCount,@DevDesignCapacity,@SingleRatedCapacity,@TotalRatedCapacity,@RedundantCapacity);";
        public const string SQL_SELECT_CSCMODIFY_UPDATESUBDEVCAP = @"UPDATE [dbo].[TM_SubDevCap] SET [LscID]=@LscID,[DevID]=@DevID,[BuildingID]=@BuildingID,[ModuleCount]=@ModuleCount,[DevDesignCapacity]=@DevDesignCapacity,[SingleRatedCapacity]=@SingleRatedCapacity,[TotalRatedCapacity]=@TotalRatedCapacity,[RedundantCapacity]=@RedundantCapacity WHERE [LscID] = @LscID AND [DevID] = @DevID;";
        public const string SQL_SELECT_CSCMODIFY_DELSUBDEVCAP = @"DELETE FROM [dbo].[TM_SubDevCap] WHERE [LscID] = @LscID AND [DevID] = @DevID;";
        public const string SQL_SELECT_CSCMODIFY_GETLSCPARAM = @"SELECT @LscID AS [LscID],[StaTNumber],[ElecDevTNumber] FROM [dbo].[TM_LSC];";
        public const string SQL_UPDATE_CSCMODIFY_UPDATELSCPARAM = @"
        UPDATE [dbo].[TM_LscParam] SET [StaTNumber] = @StaTNumber,[ElecDevTNumber] = @ElecDevTNumber WHERE [LscID] = @LscID;
        IF(@@ROWCOUNT=0)
        BEGIN
	        INSERT INTO [dbo].[TM_LscParam]([LscID],[StaTNumber],[ElecDevTNumber])
            VALUES (@LscID,@StaTNumber,@ElecDevTNumber);
        END";

        //Common SQL Text
        public const string SQL_SELECT_COMMON_GETDEVICES = @"SELECT [LscID],[DevID],[DevName],[DevDesc],[StaID] FROM [dbo].[TM_DEV] WHERE [LscID] = @LscID AND (@DevID IS NULL OR [DevID] = @DevID);";
    }
}
