using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWGraph<T> : IGraph<T>
{
    int Weight(T node);
}
