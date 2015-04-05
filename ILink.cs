using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomWalk {

    /// <summary>
    /// Graph link interface
    /// </summary>
    /// <typeparam name="T">Implementation of INode to be used as graph node</typeparam>
    public interface ILink<T> where T : ILocationNode {

        TimeSpan AerialDistance { get; set; }

        TimeSpan RoadDistance { get; set; }

        T First { get; set; }

        T Second { get; set; }

    }

}
