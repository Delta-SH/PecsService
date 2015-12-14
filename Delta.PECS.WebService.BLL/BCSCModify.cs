using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.Model;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.DALFactory;

namespace Delta.PECS.WebService.BLL
{
    /// <summary>
    /// A business componet to get CSC modify
    /// </summary>
    public class BCSCModify
    {
        // Get an instance of the CSCModify using the DALFactory
        private static readonly ICSCModify modifyDal = DataAccess.CreateCSCModify();

        /// <summary>
        /// Get CSC Modifies
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="startIndex">startIndex</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>CSCModifyInfo</returns>
        public List<CSCModifyInfo> GetCSCModifies(int lscId, int startIndex, string connectionString) {
            try {
                return modifyDal.GetCSCModifies(lscId, startIndex, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Get The Max CSC Modify
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>CSCModifyInfo</returns>
        public CSCModifyInfo GetMaxCSCModify(int lscId, string connectionString) {
            try {
                return modifyDal.GetMaxCSCModify(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Get Change Logs
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="startIndex">startIndex</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>ChangeLogInfo</returns>
        public List<ChangeLogInfo> GetChangeLogs(int lscId, int startIndex, string connectionString) {
            try {
                return modifyDal.GetChangeLogs(lscId, startIndex, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Get The Max Change Log
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>ChangeLogInfo</returns>
        public ChangeLogInfo GetMaxChangeLog(int lscId, string connectionString) {
            try {
                return modifyDal.GetMaxChangeLog(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add Area Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddArea(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddArea(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update Area Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateArea(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateArea(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete Area Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelArea(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelArea(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add Building Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddBuilding(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddBuilding(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update Building Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateBuilding(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateBuilding(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete Building Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelBuilding(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelBuilding(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add Station Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddSta(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddSta(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update Station Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateSta(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateSta(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete Station Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelSta(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelSta(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add Device Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddDev(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddDev(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update Device Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateDev(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateDev(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add Device Table With Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddDevWithNodes(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddDevWithNodes(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update Device Table With Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateDevWithNodes(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateDevWithNodes(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete Device Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelDev(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelDev(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add AIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddAI(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddAI(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update AIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateAI(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateAI(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete AIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelAI(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelAI(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add AOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddAO(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddAO(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update AOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateAO(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateAO(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete AOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelAO(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelAO(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add DIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddDI(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddDI(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update DIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateDI(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateDI(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete DIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelDI(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelDI(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add DOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddDO(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddDO(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update DOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateDO(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateDO(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete DOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelDO(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelDO(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add SS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddSS(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddSS(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update SS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateSS(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateSS(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Del SS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelSS(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelSS(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add RS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddRS(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddRS(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update RS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateRS(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateRS(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Del RS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelRS(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelRS(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add RTU Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddRTU(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddRTU(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update RTU Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateRTU(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateRTU(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add RTU Table With Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddRTUWithNodes(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddRTUWithNodes(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update RTU Table With Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateRTUWithNodes(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateRTUWithNodes(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete RTU Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelRTU(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelRTU(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add SIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddSIC(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddSIC(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update SIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateSIC(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateSIC(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete SIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelSIC(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelSIC(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add SubSic Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddSubSic(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddSubSic(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update SubSic Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateSubSic(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateSubSic(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete SubSic Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelSubSic(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelSubSic(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add User Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddUser(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddUser(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update User Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateUser(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateUser(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete User Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelUser(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelUser(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddGroup(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddGroup(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateGroup(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateGroup(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelGroup(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelGroup(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddGroupTree(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddGroupTree(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateGroupTree(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateGroupTree(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelGroupTree(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelGroupTree(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add User Defind Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddUDGroup(int lscId, int userId, int id, string connectionString) {
            try {
                modifyDal.AddUDGroup(lscId, userId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update User Defind Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateUDGroup(int lscId, int userId, int id, string connectionString) {
            try {
                modifyDal.UpdateUDGroup(lscId, userId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete User Defind Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelUDGroup(int lscId, int userId, int id, string connectionString) {
            try {
                modifyDal.DelUDGroup(lscId, userId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add User Defind GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddUDGroupTree(int lscId, int userId, int id, string connectionString) {
            try {
                modifyDal.AddUDGroupTree(lscId, userId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update User Defind GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateUDGroupTree(int lscId, int userId, int id, string connectionString) {
            try {
                modifyDal.UpdateUDGroupTree(lscId, userId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete User Defind GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelUDGroupTree(int lscId, int userId, int id, string connectionString) {
            try {
                modifyDal.DelUDGroupTree(lscId, userId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add ProjBooking Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddProjBooking(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddProjBooking(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update ProjBooking Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateProjBooking(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateProjBooking(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete ProjBooking Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelProjBooking(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelProjBooking(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Add SubDevCap Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddSubDevCap(int lscId, int id, string connectionString) {
            try {
                modifyDal.AddSubDevCap(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update SubDevCap Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateSubDevCap(int lscId, int id, string connectionString) {
            try {
                modifyDal.UpdateSubDevCap(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete SubDevCap Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelSubDevCap(int lscId, int id, string connectionString) {
            try {
                modifyDal.DelSubDevCap(lscId, id, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Get LscParam Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public LscParamInfo GetLscParam(int lscId, string connectionString) {
            try {
                return modifyDal.GetLscParam(lscId, connectionString);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Update Lsc Params.
        /// </summary>
        /// <param name="lParams">lsc params</param>
        public void UpdateLscParam(List<LscParamInfo> lParams) {
            try {
                modifyDal.UpdateLscParam(lParams);
            } catch {
                throw;
            }
        }
    }
}
