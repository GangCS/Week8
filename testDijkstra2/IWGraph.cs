using System.Collections;
using System.Collections.Generic;
namespace testDijkstra2
{
public interface IWGraph<T> : IGraph<T>
{
    int Weight(T node);
}
    }
