using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomWalk {

    /// <summary>
    /// Graph node interface
    /// </summary>
    public interface ILocationNode {

        /// <summary>
        /// The length of visiting this location
        /// </summary>
        TimeSpan Price { get; set; }

        /// <summary>
        /// Node's geographic location
        /// </summary>
        DbGeography Location { get; set; }

        /// <summary>
        /// Returns the time of walking between this location and the specified location
        /// </summary>
        /// <typeparam name="L">ILocationNode implementation</typeparam>
        /// <param name="node">Node towards which the walking time is calculated</param>
        /// <returns>Duration of walking between this node and the node </returns>
        TimeSpan GetRoadDistance<L>(L node) where L : ILocationNode;

    }

}
