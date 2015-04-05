using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomWalk {
    
    /// <summary>
    /// Route representation
    /// </summary>
    /// <typeparam name="T">ILocationNode implementation</typeparam>
    public interface IRoute<L, N> where N : ILocationNode where L : ILink<N> {

        /// <summary>
        /// Ordered list of locations contained within the route
        /// </summary>
        IList<N> Locations { get; set; }

        /// <summary>
        /// Ordered list of links contained within the route
        /// </summary>
        IList<L> Links { get; set; }

        DbGeography StartLocation { get; set; }

        

    }

}
