using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.OracleDAL
{
    /// <summary>
    /// This class is an implementation for receiving alarm information from database
    /// </summary>
    public class Node : INode
    {
        /// <summary>
        /// Syn Nodes
        /// </summary>
        public void SynNodes() {

        }

        /// <summary>
        /// Syn Lsc Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        public void SynNodes(int lscId) {
        }

        /// <summary>
        /// Method to get the specified node
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="nodeId">nodeId</param>
        /// <param name="nodeType">nodeType</param>
        /// <returns>node information</returns>
        public NodeInfo GetNode(int lscId, int nodeId, EnmNodeType nodeType) {
            return null;
        }

        /// <summary>
        /// Method to add node information
        /// </summary>
        /// <param name="nodes">nodes</param>
        /// <returns>Affected rows</returns>
        public int AddNodes(IList<NodeInfo> nodes) {
            return 0;
        }

        /// <summary>
        /// Method to update node information
        /// </summary>
        /// <param name="nodes">nodes</param>
        /// <returns>Affected rows</returns>
        public int UpdateNodes(IList<NodeInfo> nodes) {
            return 0;
        }

        /// <summary>
        /// Method to delete node information
        /// </summary>
        /// <param name="nodes">nodes</param>
        /// <returns>Affected rows</returns>
        public int DeleteNodes(IList<NodeInfo> nodes) {
            return 0;
        }

        /// <summary>
        /// Delete all nodes
        /// </summary>
        public void Purge() {
            
        }

        /// <summary>
        /// Delete lsc nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        public void Purge(int lscId) {
        }
    }
}
