using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.Model;
using Delta.PECS.WebService.IDAL;

namespace Delta.PECS.WebService.OracleDAL
{
    /// <summary>
    /// This class is an implementation for receiving modify information from database
    /// </summary>
    public class CSCModify : ICSCModify
    {
        /// <summary>
        /// Get CSC Modifies
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="startIndex">startIndex</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>CSCModifyInfo</returns>
        public List<CSCModifyInfo> GetCSCModifies(int lscId, int startIndex, string connectionString) {
            return null;
        }

        /// <summary>
        /// Get The Max CSC Modify
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>CSCModifyInfo</returns>
        public CSCModifyInfo GetMaxCSCModify(int lscId, string connectionString) {
            return null;
        }

        /// <summary>
        /// Get Change Logs
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="startIndex">startIndex</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>ChangeLogInfo</returns>
        public List<ChangeLogInfo> GetChangeLogs(int lscId, int startIndex, string connectionString) {
            return null;
        }

        /// <summary>
        /// Get The Max Change Log
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>ChangeLogInfo</returns>
        public ChangeLogInfo GetMaxChangeLog(int lscId, string connectionString) {
            return null;
        }

        /// <summary>
        /// Add Area Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddArea(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update Area Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateArea(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete Area Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelArea(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add Building Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddBuilding(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update Building Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateBuilding(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete Building Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelBuilding(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add NetGrid Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddNetGrid(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update NetGrid Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateNetGrid(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete NetGrid Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelNetGrid(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add Station Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddSta(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update Station Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateSta(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete Station Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelSta(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add Device Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddDev(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update Device Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateDev(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add Device Table With Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddDevWithNodes(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update Device Table With Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateDevWithNodes(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete Device Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelDev(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add AIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddAI(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update AIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateAI(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete AIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelAI(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add AOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddAO(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update AOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateAO(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete AOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelAO(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add DIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddDI(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update DIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateDI(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete DIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelDI(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add DOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddDO(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update DOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateDO(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete DOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelDO(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add SS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddSS(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update SS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateSS(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Del SS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelSS(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add RS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddRS(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update RS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateRS(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Del RS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelRS(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add RTU Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddRTU(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update RTU Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateRTU(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add RTU Table With Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddRTUWithNodes(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update RTU Table With Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateRTUWithNodes(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete RTU Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelRTU(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add SIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddSIC(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update SIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateSIC(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete SIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelSIC(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add SubSic Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddSubSic(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update SubSic Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateSubSic(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete SubSic Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelSubSic(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add User Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddUser(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update User Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateUser(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete User Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelUser(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddGroup(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateGroup(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelGroup(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddGroupTree(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateGroupTree(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelGroupTree(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add User Defind Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddUDGroup(int lscId, int userId, int id, string connectionString) {
        }

        /// <summary>
        /// Update User Defind Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateUDGroup(int lscId, int userId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete User Defind Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelUDGroup(int lscId, int userId, int id, string connectionString) {
        }

        /// <summary>
        /// Add User Defind GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddUDGroupTree(int lscId, int userId, int id, string connectionString) {
        }

        /// <summary>
        /// Update User Defind GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateUDGroupTree(int lscId, int userId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete User Defind GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelUDGroupTree(int lscId, int userId, int id, string connectionString) {
        }

        /// <summary>
        /// Add ProjBooking Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddProjBooking(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update ProjBooking Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateProjBooking(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete ProjBooking Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelProjBooking(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Add SubDevCap Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void AddSubDevCap(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Update SubDevCap Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void UpdateSubDevCap(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Delete SubDevCap Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        public void DelSubDevCap(int lscId, int id, string connectionString) {
        }

        /// <summary>
        /// Get LscParam Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        public LscParamInfo GetLscParam(int lscId, string connectionString) {
            return null;
        }

        /// <summary>
        /// Update Lsc Params.
        /// </summary>
        /// <param name="lParams">lsc params</param>
        public void UpdateLscParam(List<LscParamInfo> lParams) {
        }

        
    }
}
