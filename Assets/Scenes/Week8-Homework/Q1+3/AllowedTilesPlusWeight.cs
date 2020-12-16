using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AllowedTilesPlusWeight : MonoBehaviour
{
    [Tooltip("Tile Base array of allowed tiles")]
    [SerializeField] TileBase[] allowedTiles = null;
    [Tooltip("Integer array of allowed tiles and their corresponding weight from allowed tiles")]
    [SerializeField] int[] weight = null;
    /// <summary>method <c>Contain</c> Checks if a TileBase exists in AllowedTiles.</summary>
    public bool Contain(TileBase tile)
    {
        return allowedTiles.Contains(tile);
    }
    /// <summary>method <c>Get</c> returns TileBase array</summary>
    public TileBase[] Get() { return allowedTiles; }
    /// <summary>method <c>getWeights</c> returns weights array</summary>
    public int[] getWeights()
    {
        return weight;
    }
    /// <summary>method <c>findTilePos</c> returns weights of specific tile </summary>
    public int findTilePos(TileBase t)
    {
        for(int i=0;i< allowedTiles.Length;i++)
        {
            if(t.Equals(allowedTiles[i]))
            {
                return i;
            }
        }
        return -1;
    }
}
