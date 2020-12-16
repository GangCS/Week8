using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Extending the IGraph interface and adding a Weight function
public interface IWGraph<T> : IGraph<T>
{
    int Weight(T node);
}
