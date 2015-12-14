using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.DALFactory;

namespace Delta.PECS.WebService.BLL
{
    /// <summary>
    /// A business componet to get setting
    /// </summary>
    public class BSetting
    {
        // Get an instance of the Setting using the DALFactory
        private static readonly ISetting settingDal = DataAccess.CreateSetting();

        /// <summary>
        /// Sync Area Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncArea(int lscId, string connectionString) {
            try {
                settingDal.SyncArea(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync Building Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncBuilding(int lscId, string connectionString) {
            try {
                settingDal.SyncBuilding(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync Station Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncSta(int lscId, string connectionString) {
            try {
                settingDal.SyncSta(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync Device Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncDev(int lscId, string connectionString) {
            try {
                settingDal.SyncDev(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync AIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncAI(int lscId, string connectionString) {
            try {
                settingDal.SyncAI(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync AOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncAO(int lscId, string connectionString) {
            try {
                settingDal.SyncAO(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync DIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncDI(int lscId, string connectionString) {
            try {
                settingDal.SyncDI(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync DOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncDO(int lscId, string connectionString) {
            try {
                settingDal.SyncDO(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncGroup(int lscId, string connectionString) {
            try {
                settingDal.SyncGroup(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync Group Tree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncGroupTree(int lscId, string connectionString) {
            try {
                settingDal.SyncGroupTree(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync User Defind Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncUDGroup(int lscId, string connectionString) {
            try {
                settingDal.SyncUDGroup(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync User Defind Group Tree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncUDGroupTree(int lscId, string connectionString) {
            try {
                settingDal.SyncUDGroupTree(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync User Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncUser(int lscId, string connectionString) {
            try {
                settingDal.SyncUser(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync SS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncSS(int lscId, string connectionString) {
            try {
                settingDal.SyncSS(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync RS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncRS(int lscId, string connectionString) {
            try {
                settingDal.SyncRS(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync RTU Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncRTU(int lscId, string connectionString) {
            try {
                settingDal.SyncRTU(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync SIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncSIC(int lscId, string connectionString) {
            try {
                settingDal.SyncSIC(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync SubSic Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncSubSic(int lscId, string connectionString) {
            try {
                settingDal.SyncSubSic(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync ProjBooking Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncProjBooking(int lscId, string connectionString) {
            try {
                settingDal.SyncProjBooking(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync SubDevCap Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncSubDevCap(int lscId, string connectionString) {
            try {
                settingDal.SyncSubDevCap(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge Area Table
        /// </summary>
        public void PurgeArea() {
            try {
                settingDal.PurgeArea();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge Building Table
        /// </summary>
        public void PurgeBuilding() {
            try {
                settingDal.PurgeBuilding();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge Station Table
        /// </summary>
        public void PurgeSta() {
            try {
                settingDal.PurgeSta();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge Device Table
        /// </summary>
        public void PurgeDev() {
            try {
                settingDal.PurgeDev();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge AIC Table
        /// </summary>
        public void PurgeAI() {
            try {
                settingDal.PurgeAI();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge AOC Table
        /// </summary>
        public void PurgeAO() {
            try {
                settingDal.PurgeAO();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge DIC Table
        /// </summary>
        public void PurgeDI() {
            try {
                settingDal.PurgeDI();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge DOC Table
        /// </summary>
        public void PurgeDO() {
            try {
                settingDal.PurgeDO();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge Group Table
        /// </summary>
        public void PurgeGroup() {
            try {
                settingDal.PurgeGroup();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge Group Tree Table
        /// </summary>
        public void PurgeGroupTree() {
            try {
                settingDal.PurgeGroupTree();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge User Defind Group Table
        /// </summary>
        public void PurgeUDGroup() {
            try {
                settingDal.PurgeUDGroup();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge User Defind Group Tree Table
        /// </summary>
        public void PurgeUDGroupTree() {
            try {
                settingDal.PurgeUDGroupTree();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge User Table
        /// </summary>
        public void PurgeUser() {
            try {
                settingDal.PurgeUser();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge SS Table
        /// </summary>
        public void PurgeSS() {
            try {
                settingDal.PurgeSS();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge RS Table
        /// </summary>
        public void PurgeRS() {
            try {
                settingDal.PurgeRS();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge RTU Table
        /// </summary>
        public void PurgeRTU() {
            try {
                settingDal.PurgeRTU();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge SIC Table
        /// </summary>
        public void PurgeSIC() {
            try {
                settingDal.PurgeSIC();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge SubSic Table
        /// </summary>
        public void PurgeSubSic() {
            try {
                settingDal.PurgeSubSic();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge ProjBooking Table
        /// </summary>
        public void PurgeProjBooking() {
            try {
                settingDal.PurgeProjBooking();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge SubDevCap Table
        /// </summary>
        public void PurgeSubDevCap() {
            try {
                settingDal.PurgeSubDevCap();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete Area Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteArea(int lscId) {
            try {
                settingDal.DeleteArea(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete Building Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteBuilding(int lscId) {
            try {
                settingDal.DeleteBuilding(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete Station Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteSta(int lscId) {
            try {
                settingDal.DeleteSta(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete Device Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteDev(int lscId) {
            try {
                settingDal.DeleteDev(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete AIC Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteAI(int lscId) {
            try {
                settingDal.DeleteAI(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete AOC Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteAO(int lscId) {
            try {
                settingDal.DeleteAO(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete DIC Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteDI(int lscId) {
            try {
                settingDal.DeleteDI(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete DOC Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteDO(int lscId) {
            try {
                settingDal.DeleteDO(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete Group Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteGroup(int lscId) {
            try {
                settingDal.DeleteGroup(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete Group Tree Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteGroupTree(int lscId) {
            try {
                settingDal.DeleteGroupTree(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete User Defind Group Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteUDGroup(int lscId) {
            try {
                settingDal.DeleteUDGroup(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete User Defind Group Tree Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteUDGroupTree(int lscId) {
            try {
                settingDal.DeleteUDGroupTree(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete User Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteUser(int lscId) {
            try {
                settingDal.DeleteUser(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete SS Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteSS(int lscId) {
            try {
                settingDal.DeleteSS(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete RS Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteRS(int lscId) {
            try {
                settingDal.DeleteRS(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete RTU Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteRTU(int lscId) {
            try {
                settingDal.DeleteRTU(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete SIC Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteSIC(int lscId) {
            try {
                settingDal.DeleteSIC(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete SubSic Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteSubSic(int lscId) {
            try {
                settingDal.DeleteSubSic(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete ProjBooking Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteProjBooking(int lscId) {
            try {
                settingDal.DeleteProjBooking(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete SubDevCap Table
        /// </summary>
        /// <param name="lsc">lsc</param>
        public void DeleteSubDevCap(int lscId) {
            try {
                settingDal.DeleteSubDevCap(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge AlarmDeviceType Table
        /// </summary>
        public void PurgeAlarmDeviceType() {
            try {
                settingDal.PurgeAlarmDeviceType();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync AlarmDeviceType Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncAlarmDeviceType(int lscId, string connectionString) {
            try {
                settingDal.SyncAlarmDeviceType(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge AlarmLogType Table
        /// </summary>
        public void PurgeAlarmLogType() {
            try {
                settingDal.PurgeAlarmLogType();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync AlarmLogType Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncAlarmLogType(int lscId, string connectionString) {
            try {
                settingDal.SyncAlarmLogType(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge AlarmName Table
        /// </summary>
        public void PurgeAlarmName() {
            try {
                settingDal.PurgeAlarmName();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync AlarmName Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncAlarmName(int lscId, string connectionString) {
            try {
                settingDal.SyncAlarmName(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge DeviceType Table
        /// </summary>
        public void PurgeDeviceType() {
            try {
                settingDal.PurgeDeviceType();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync DeviceType Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncDeviceType(int lscId, string connectionString) {
            try {
                settingDal.SyncDeviceType(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge Productor Table
        /// </summary>
        public void PurgeProductor() {
            try {
                settingDal.PurgeProductor();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync Productor Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncProductor(int lscId, string connectionString) {
            try {
                settingDal.SyncProductor(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge Protocol Table
        /// </summary>
        public void PurgeProtocol() {
            try {
                settingDal.PurgeProtocol();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync Protocol Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncProtocol(int lscId, string connectionString) {
            try {
                settingDal.SyncProtocol(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge StaFeatures Table
        /// </summary>
        public void PurgeStaFeatures() {
            try {
                settingDal.PurgeStaFeatures();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync StaFeatures Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncStaFeatures(int lscId, string connectionString) {
            try {
                settingDal.SyncStaFeatures(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge StationType Table
        /// </summary>
        public void PurgeStationType() {
            try {
                settingDal.PurgeStationType();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync StationType Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncStationType(int lscId, string connectionString) {
            try {
                settingDal.SyncStationType(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Purge SubAlarmLogType Table
        /// </summary>
        public void PurgeSubAlarmLogType() {
            try {
                settingDal.PurgeSubAlarmLogType();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Sync SubAlarmLogType Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public void SyncSubAlarmLogType(int lscId, string connectionString) {
            try {
                settingDal.SyncSubAlarmLogType(lscId, connectionString);
            } catch {
                throw;
            }
        }
    }
}