using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
public class AllowedTilesQ6 : MonoBehaviour
{

    [SerializeField] TileBase[] allowedTiles = null;
    public bool Contain(TileBase tile)
    {
        return allowedTiles.Contains(tile);
    }

    public TileBase[] Get() 
    {
        return allowedTiles; 
    }
}
