using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomWalk {
    
    public class LinkComparer<L, N>: IEqualityComparer<L> where N : ILocationNode where L : ILink<N> {

        public bool Equals(L x, L y) {
            return x.AerialDistance == y.AerialDistance && ((ILocationNode)x.First == (ILocationNode)y.First && (ILocationNode)x.Second == (ILocationNode)y.Second || (ILocationNode)x.First == (ILocationNode)y.Second && (ILocationNode)x.Second == (ILocationNode)y.First);
        }

        public int GetHashCode(L obj) {
            return 0;
        }

    }

}
