using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * A weighted graph that represents a tilemap, using only the allowed tiles.
 */
public class TilemapWGraph : IWGraph<Vector3Int>
{
    
    private Tilemap tilemap;
    //A dictionary representing TileBase and its weight
    private Dictionary<TileBase, int> WforEachBase;
    //Array of allowed weights
    private TileBase[] allowedTiles;

    public TilemapWGraph(Tilemap tilemap, TileBase[] allowedTiles,int[] weights)
    {
        this.tilemap = tilemap;
        this.allowedTiles = allowedTiles;
        WforEachBase = new Dictionary<TileBase, int>();
        //Creating the weights Dictionary
        for (int i = 0; i < allowedTiles.Length; i++)
        {
            WforEachBase.Add(allowedTiles[i], weights[i]);
        }
    }

    static Vector3Int[] directions = {
            new Vector3Int(-1, 0, 0),
            new Vector3Int(1, 0, 0),
            new Vector3Int(0, -1, 0),
            new Vector3Int(0, 1, 0),
    };

    public IEnumerable<Vector3Int> Neighbors(Vector3Int node)
    {
        foreach (var direction in directions)
        {
            Vector3Int neighborPos = node + direction;
            TileBase neighborTile = tilemap.GetTile(neighborPos);
            if (allowedTiles.Contains(neighborTile))
                yield return neighborPos;
        }
    }

    //Returns the weight of a node at some position
    public int Weight(Vector3Int node)
    {
        TileBase t = tilemap.GetTile(node);
        return WforEachBase[t];
    }
}
