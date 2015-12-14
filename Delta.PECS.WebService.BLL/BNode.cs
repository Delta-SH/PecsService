using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.PECS.WebService.DALFactory;
using Delta.PECS.WebService.IDAL;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.BLL
{
    /// <summary>
    /// A business componet to get nodes
    /// </summary>
    public class BNode
    {
        // Get an instance of the Node using the DALFactory
        private static readonly INode nodeDal = DataAccess.CreateNode();

        /// <summary>
        /// Syn Nodes
        /// </summary>
        public void SynNodes() {
            try {
                nodeDal.SynNodes();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Syn Lsc Nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        public void SynNodes(int lscId) {
            try {
                nodeDal.SynNodes(lscId);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to get the specified node
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="nodeId">nodeId</param>
        /// <param name="nodeType">nodeType</param>
        /// <returns>node information</returns>
        public NodeInfo GetNode(int lscId, int nodeId, EnmNodeType nodeType) {
            try {
                return nodeDal.GetNode(lscId, nodeId, nodeType);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to add node information
        /// </summary>
        /// <param name="node">node</param>
        /// <returns>Affected rows</returns>
        public int AddNode(NodeInfo node) {
            try {
                IList<NodeInfo> nodes = new List<NodeInfo>();
                nodes.Add(node);
                return nodeDal.AddNodes(nodes);
            }
            catch {
                throw;
            }
        }

        /// <summary>
        /// Method to add node information
        /// </summary>
        /// <param name="nodes">nodes</param>
        /// <returns>Affected rows</returns>
        public int AddNodes(IList<NodeInfo> nodes) {
            try {
                return nodeDal.AddNodes(nodes);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to update node information
        /// </summary>
        /// <param name="node">node</param>
        /// <returns>Affected rows</returns>
        public int UpdateNode(NodeInfo node) {
            try {
                IList<NodeInfo> nodes = new List<NodeInfo>();
                nodes.Add(node);
                return nodeDal.UpdateNodes(nodes);
            }
            catch {
                throw;
            }
        }

        /// <summary>
        /// Method to update node information
        /// </summary>
        /// <param name="nodes">nodes</param>
        /// <returns>Affected rows</returns>
        public int UpdateNodes(IList<NodeInfo> nodes) {
            try {
                return nodeDal.UpdateNodes(nodes);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Method to delete node information
        /// </summary>
        /// <param name="node">node</param>
        /// <returns>Affected rows</returns>
        public int DeleteNode(NodeInfo node) {
            try {
                IList<NodeInfo> nodes = new List<NodeInfo>();
                nodes.Add(node);
                return nodeDal.DeleteNodes(nodes);
            }
            catch {
                throw;
            }
        }

        /// <summary>
        /// Method to delete node information
        /// </summary>
        /// <param name="nodes">nodes</param>
        /// <returns>Affected rows</returns>
        public int DeleteNodes(IList<NodeInfo> nodes) {
            try {
                return nodeDal.DeleteNodes(nodes);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete all nodes
        /// </summary>
        public void Purge() {
            try {
                nodeDal.Purge();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete lsc nodes
        /// </summary>
        /// <param name="lscId">lscId</param>
        public void Purge(int lscId) {
            try {
                nodeDal.Purge(lscId);
            } catch {
                throw;
            }
        }
    }
}
