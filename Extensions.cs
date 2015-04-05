using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomWalk {
    
    /// <summary>
    /// Contains extensions for ILink and IRoute implementations
    /// </summary>
    public static class Extensions {

        /// <summary>
        /// Speed of walking in m/s
        /// </summary>
        public const double speed = 4 / 3.6;

        /// <summary>
        /// Returns the list of links between nodes shorter or equal  treshold
        /// </summary>
        /// <param name="nodes">List of nodes</param>
        /// <param name="treshold">Maximal distance between nodes for which a link will be created</param>
        /// <param name="NodeDistance">Function which returns the calculated node distance</param>
        /// <param name="CreateLink">Function which creates and returns the link of the chosen type between two nodes</param>
        /// <returns>List of links which are shorter than treshold</returns>
        public static IEnumerable<L> GenerateLinks<L, N>(this IEnumerable<N> nodes, TimeSpan treshold) where N : ILocationNode where L : class, ILink<N>, new() {
            return nodes.SelectMany(n => nodes.Except(new List<N>() { n }).Select(m => (n.GetAerialDistance(m) < treshold) ? (new L() { First = n, Second = m, AerialDistance = n.GetAerialDistance(m), RoadDistance = n.GetRoadDistance<N>(m) }) : (L)null).Where(l => l != null)).Distinct(new LinkComparer<L, N>());
        }

        /// <summary>
        /// Returns the walking time between the current node and selected node
        /// </summary>
        /// <param name="me">Current node</param>
        /// <param name="node">Node to which the distance is calculated</param>
        /// <returns>Distance between this node and the selected node</returns>
        public static TimeSpan GetAerialDistance(this ILocationNode me,  ILocationNode node) {
            return TimeSpan.FromSeconds((int)((me.Location.Distance(node.Location) ?? 0) / speed));
        }

    }

}
