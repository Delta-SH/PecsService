using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.IDAL
{
    /// <summary>
    /// Interface for setting
    /// </summary>
    public interface ISetting
    {
        /// <summary>
        /// Sync Area Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncArea(int lscId, string connectionString);

        /// <summary>
        /// Sync Building Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncBuilding(int lscId, string connectionString);

        /// <summary>
        /// Sync NetGrid Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncNetGrid(int lscId, string connectionString);

        /// <summary>
        /// Sync Station Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncSta(int lscId, string connectionString);

        /// <summary>
        /// Sync Device Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncDev(int lscId, string connectionString);

        /// <summary>
        /// Sync AIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncAI(int lscId, string connectionString);

        /// <summary>
        /// Sync AOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncAO(int lscId, string connectionString);

        /// <summary>
        /// Sync DIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncDI(int lscId, string connectionString);

        /// <summary>
        /// Sync DOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncDO(int lscId, string connectionString);

        /// <summary>
        /// Sync Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncGroup(int lscId, string connectionString);

        /// <summary>
        /// Sync Group Tree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncGroupTree(int lscId, string connectionString);

        /// <summary>
        /// Sync User Defind Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncUDGroup(int lscId, string connectionString);

        /// <summary>
        /// Sync User Defind Group Tree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncUDGroupTree(int lscId, string connectionString);

        /// <summary>
        /// Sync User Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncUser(int lscId, string connectionString);

        /// <summary>
        /// Sync SS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncSS(int lscId, string connectionString);

        /// <summary>
        /// Sync RS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncRS(int lscId, string connectionString);

        /// <summary>
        /// Sync RTU Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncRTU(int lscId, string connectionString);

        /// <summary>
        /// Sync SIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncSIC(int lscId, string connectionString);

        /// <summary>
        /// Sync SubSic Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncSubSic(int lscId, string connectionString);

        /// <summary>
        /// Sync ProjBooking Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncProjBooking(int lscId, string connectionString);

        /// <summary>
        /// Sync SubDevCap Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncSubDevCap(int lscId, string connectionString);

        /// <summary>
        /// Purge Area Table
        /// </summary>
        void PurgeArea();

        /// <summary>
        /// Purge Building Table
        /// </summary>
        void PurgeBuilding();

        /// <summary>
        /// Purge NetGrid Table
        /// </summary>
        void PurgeNetGrid();

        /// <summary>
        /// Purge Station Table
        /// </summary>
        void PurgeSta();

        /// <summary>
        /// Purge Device Table
        /// </summary>
        void PurgeDev();

        /// <summary>
        /// Purge AIC Table
        /// </summary>
        void PurgeAI();

        /// <summary>
        /// Purge AOC Table
        /// </summary>
        void PurgeAO();

        /// <summary>
        /// Purge DIC Table
        /// </summary>
        void PurgeDI();

        /// <summary>
        /// Purge DOC Table
        /// </summary>
        void PurgeDO();

        /// <summary>
        /// Purge Group Table
        /// </summary>
        void PurgeGroup();

        /// <summary>
        /// Purge Group Tree Table
        /// </summary>
        void PurgeGroupTree();

        /// <summary>
        /// Purge User Defind Group Table
        /// </summary>
        void PurgeUDGroup();

        /// <summary>
        /// Purge User Defind Group Tree Table
        /// </summary>
        void PurgeUDGroupTree();

        /// <summary>
        /// Purge User Table
        /// </summary>
        void PurgeUser();

        /// <summary>
        /// Purge SS Table
        /// </summary>
        void PurgeSS();

        /// <summary>
        /// Purge RS Table
        /// </summary>
        void PurgeRS();

        /// <summary>
        /// Purge RTU Table
        /// </summary>
        void PurgeRTU();

        /// <summary>
        /// Purge SIC Table
        /// </summary>
        void PurgeSIC();

        /// <summary>
        /// Purge SubSic Table
        /// </summary>
        void PurgeSubSic();

        /// <summary>
        /// Purge ProjBooking Table
        /// </summary>
        void PurgeProjBooking();

        /// <summary>
        /// Purge SubDevCap Table
        /// </summary>
        void PurgeSubDevCap();

        /// <summary>
        /// Delete Area Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteArea(int lscId);

        /// <summary>
        /// Delete Building Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteBuilding(int lscId);

        /// <summary>
        /// Delete Station Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteSta(int lscId);

        /// <summary>
        /// Delete Device Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteDev(int lscId);

        /// <summary>
        /// Delete AIC Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteAI(int lscId);

        /// <summary>
        /// Delete AOC Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteAO(int lscId);

        /// <summary>
        /// Delete DIC Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteDI(int lscId);

        /// <summary>
        /// Delete DOC Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteDO(int lscId);

        /// <summary>
        /// Delete Group Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteGroup(int lscId);

        /// <summary>
        /// Delete Group Tree Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteGroupTree(int lscId);

        /// <summary>
        /// Delete User Defind Group Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteUDGroup(int lscId);

        /// <summary>
        /// Delete User Defind Group Tree Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteUDGroupTree(int lscId);

        /// <summary>
        /// Delete User Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteUser(int lscId);

        /// <summary>
        /// Delete SS Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteSS(int lscId);

        /// <summary>
        /// Delete RS Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteRS(int lscId);

        /// <summary>
        /// Delete RTU Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteRTU(int lscId);

        /// <summary>
        /// Delete SIC Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteSIC(int lscId);

        /// <summary>
        /// Delete SubSic Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteSubSic(int lscId);

        /// <summary>
        /// Delete ProjBooking Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteProjBooking(int lscId);

        /// <summary>
        /// Delete SubDevCap Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        void DeleteSubDevCap(int lscId);

        /// <summary>
        /// Purge AlarmDeviceType Table
        /// </summary>
        void PurgeAlarmDeviceType();

        /// <summary>
        /// Sync AlarmDeviceType Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncAlarmDeviceType(int lscId, string connectionString);

        /// <summary>
        /// Purge AlarmLogType Table
        /// </summary>
        void PurgeAlarmLogType();

        /// <summary>
        /// Sync AlarmLogType Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncAlarmLogType(int lscId, string connectionString);

        /// <summary>
        /// Purge AlarmName Table
        /// </summary>
        void PurgeAlarmName();

        /// <summary>
        /// Sync AlarmName Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncAlarmName(int lscId, string connectionString);

        /// <summary>
        /// Purge DeviceType Table
        /// </summary>
        void PurgeDeviceType();

        /// <summary>
        /// Sync DeviceType Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncDeviceType(int lscId, string connectionString);

        /// <summary>
        /// Purge Productor Table
        /// </summary>
        void PurgeProductor();

        /// <summary>
        /// Sync Productor Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncProductor(int lscId, string connectionString);

        /// <summary>
        /// Purge Protocol Table
        /// </summary>
        void PurgeProtocol();

        /// <summary>
        /// Sync Protocol Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncProtocol(int lscId, string connectionString);

        /// <summary>
        /// Purge StaFeatures Table
        /// </summary>
        void PurgeStaFeatures();

        /// <summary>
        /// Sync StaFeatures Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncStaFeatures(int lscId, string connectionString);

        /// <summary>
        /// Purge StationType Table
        /// </summary>
        void PurgeStationType();

        /// <summary>
        /// Sync StationType Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncStationType(int lscId, string connectionString);

        /// <summary>
        /// Purge SubAlarmLogType Table
        /// </summary>
        void PurgeSubAlarmLogType();

        /// <summary>
        /// Sync SubAlarmLogType Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        void SyncSubAlarmLogType(int lscId, string connectionString);
    }
}