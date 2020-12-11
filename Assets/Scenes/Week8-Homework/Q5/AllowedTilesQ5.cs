using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AllowedTilesQ5 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TileBase[] allowedTiles = null;
    public bool Contain(TileBase tile)
    {
        return allowedTiles.Contains(tile);

    }

    public TileBase[] Get() { return allowedTiles; }
}
