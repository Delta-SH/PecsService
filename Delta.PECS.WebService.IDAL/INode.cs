using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.IDAL
{
    /// <summary>
    /// Interface for node
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Syn Nodes
        /// </summary>
        void SynNodes();

        /// <summary>
        /// Syn Lsc Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        void SynNodes(int lscId);

        /// <summary>
        /// Method to get the specified node
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="nodeId">nodeId</param>
        /// <param name="nodeType">nodeType</param>
        /// <returns>node information</returns>
        NodeInfo GetNode(int lscId, int nodeId, EnmNodeType nodeType);

        /// <summary>
        /// Method to add node information
        /// </summary>
        /// <param name="nodes">nodes</param>
        /// <returns>Affected rows</returns>
        int AddNodes(IList<NodeInfo> nodes);

        /// <summary>
        /// Method to update node information
        /// </summary>
        /// <param name="nodes">nodes</param>
        /// <returns>Affected rows</returns>
        int UpdateNodes(IList<NodeInfo> nodes);

        /// <summary>
        /// Method to delete node information
        /// </summary>
        /// <param name="nodes">nodes</param>
        /// <returns>Affected rows</returns>
        int DeleteNodes(IList<NodeInfo> nodes);

        /// <summary>
        /// Delete all nodes
        /// </summary>
        void Purge();

        /// <summary>
        /// Delete lsc nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        void Purge(int lscId);
    }
}
