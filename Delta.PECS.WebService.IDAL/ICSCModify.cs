using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.IDAL
{
    /// <summary>
    /// Interface for modify
    /// </summary>
    public interface ICSCModify
    {
        /// <summary>
        /// Get CSC Modifies
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="startIndex">startIndex</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>CSCModifyInfo</returns>
        List<CSCModifyInfo> GetCSCModifies(int lscId, int startIndex, string connectionString);

        /// <summary>
        /// Get The Max CSC Modify
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>CSCModifyInfo</returns>
        CSCModifyInfo GetMaxCSCModify(int lscId, string connectionString);

        /// <summary>
        /// Get Change Logs
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="startIndex">startIndex</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>ChangeLogInfo</returns>
        List<ChangeLogInfo> GetChangeLogs(int lscId, int startIndex, string connectionString);

        /// <summary>
        /// Get The Max Change Log
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>ChangeLogInfo</returns>
        ChangeLogInfo GetMaxChangeLog(int lscId, string connectionString);

        /// <summary>
        /// Add Area Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddArea(int lscId, int id, string connectionString);

        /// <summary>
        /// Update Area Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateArea(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete Area Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelArea(int lscId, int id, string connectionString);

        /// <summary>
        /// Add Building Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddBuilding(int lscId, int id, string connectionString);

        /// <summary>
        /// Update Building Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateBuilding(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete Building Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelBuilding(int lscId, int id, string connectionString);

        /// <summary>
        /// Add NetGrid Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddNetGrid(int lscId, int id, string connectionString);

        /// <summary>
        /// Update NetGrid Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateNetGrid(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete NetGrid Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelNetGrid(int lscId, int id, string connectionString);

        /// <summary>
        /// Add Station Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddSta(int lscId, int id, string connectionString);

        /// <summary>
        /// Update Station Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateSta(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete Station Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelSta(int lscId, int id, string connectionString);

        /// <summary>
        /// Add Device Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddDev(int lscId, int id, string connectionString);

        /// <summary>
        /// Update Device Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateDev(int lscId, int id, string connectionString);

        /// <summary>
        /// Add Device Table With Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddDevWithNodes(int lscId, int id, string connectionString);

        /// <summary>
        /// Update Device Table With Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateDevWithNodes(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete Device Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelDev(int lscId, int id, string connectionString);

        /// <summary>
        /// Add AIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddAI(int lscId, int id, string connectionString);

        /// <summary>
        /// Update AIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateAI(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete AIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelAI(int lscId, int id, string connectionString);

        /// <summary>
        /// Add AOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddAO(int lscId, int id, string connectionString);

        /// <summary>
        /// Update AOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateAO(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete AOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelAO(int lscId, int id, string connectionString);

        /// <summary>
        /// Add DIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddDI(int lscId, int id, string connectionString);

        /// <summary>
        /// Update DIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateDI(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete DIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelDI(int lscId, int id, string connectionString);

        /// <summary>
        /// Add DOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddDO(int lscId, int id, string connectionString);

        /// <summary>
        /// Update DOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateDO(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete DOC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelDO(int lscId, int id, string connectionString);

        /// <summary>
        /// Add SS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddSS(int lscId, int id, string connectionString);

        /// <summary>
        /// Update SS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateSS(int lscId, int id, string connectionString);

        /// <summary>
        /// Del SS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelSS(int lscId, int id, string connectionString);

        /// <summary>
        /// Add RS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddRS(int lscId, int id, string connectionString);

        /// <summary>
        /// Update RS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateRS(int lscId, int id, string connectionString);

        /// <summary>
        /// Del RS Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelRS(int lscId, int id, string connectionString);

        /// <summary>
        /// Add RTU Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddRTU(int lscId, int id, string connectionString);

        /// <summary>
        /// Update RTU Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateRTU(int lscId, int id, string connectionString);

        /// <summary>
        /// Add RTU Table With Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddRTUWithNodes(int lscId, int id, string connectionString);

        /// <summary>
        /// Update RTU Table With Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateRTUWithNodes(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete RTU Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelRTU(int lscId, int id, string connectionString);

        /// <summary>
        /// Add SIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddSIC(int lscId, int id, string connectionString);

        /// <summary>
        /// Update SIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateSIC(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete SIC Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelSIC(int lscId, int id, string connectionString);

        /// <summary>
        /// Add SubSic Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddSubSic(int lscId, int id, string connectionString);

        /// <summary>
        /// Update SubSic Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateSubSic(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete SubSic Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelSubSic(int lscId, int id, string connectionString);

        /// <summary>
        /// Add User Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddUser(int lscId, int id, string connectionString);

        /// <summary>
        /// Update User Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateUser(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete User Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelUser(int lscId, int id, string connectionString);

        /// <summary>
        /// Add Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddGroup(int lscId, int id, string connectionString);

        /// <summary>
        /// Update Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateGroup(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelGroup(int lscId, int id, string connectionString);

        /// <summary>
        /// Add GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddGroupTree(int lscId, int id, string connectionString);

        /// <summary>
        /// Update GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateGroupTree(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelGroupTree(int lscId, int id, string connectionString);

        /// <summary>
        /// Add User Defind Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddUDGroup(int lscId, int userId, int id, string connectionString);

        /// <summary>
        /// Update User Defind Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateUDGroup(int lscId, int userId, int id, string connectionString);

        /// <summary>
        /// Delete User Defind Group Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelUDGroup(int lscId, int userId, int id, string connectionString);

        /// <summary>
        /// Add User Defind GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddUDGroupTree(int lscId, int userId, int id, string connectionString);

        /// <summary>
        /// Update User Defind GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateUDGroupTree(int lscId, int userId, int id, string connectionString);

        /// <summary>
        /// Delete User Defind GroupTree Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="userId">userId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelUDGroupTree(int lscId, int userId, int id, string connectionString);

        /// <summary>
        /// Add ProjBooking Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddProjBooking(int lscId, int id, string connectionString);

        /// <summary>
        /// Update ProjBooking Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateProjBooking(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete ProjBooking Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelProjBooking(int lscId, int id, string connectionString);

        /// <summary>
        /// Add SubDevCap Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void AddSubDevCap(int lscId, int id, string connectionString);

        /// <summary>
        /// Update SubDevCap Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void UpdateSubDevCap(int lscId, int id, string connectionString);

        /// <summary>
        /// Delete SubDevCap Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="id">id</param>
        /// <param name="connectionString">connectionString</param>
        void DelSubDevCap(int lscId, int id, string connectionString);

        /// <summary>
        /// Get LscParam Table
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="connectionString">connectionString</param>
        LscParamInfo GetLscParam(int lscId, string connectionString);

        /// <summary>
        /// Update Lsc Params.
        /// </summary>
        /// <param name="lParams">lsc params</param>
        void UpdateLscParam(List<LscParamInfo> lParams);
    }
}
