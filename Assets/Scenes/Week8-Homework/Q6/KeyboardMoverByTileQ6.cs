using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KeyboardMoverByTileQ6 : KeyboardMoverQ6
{
    [SerializeField] Tilemap tilemap = null;
    [SerializeField] AllowedTilesQ6 allowedTiles = null;
    [SerializeField] TileBase goal = null;
    [SerializeField] TilemapCaveGeneratorExpandedQ6 script = null;

    private TileBase TileOnPosition(Vector3 worldPosition)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return tilemap.GetTile(cellPosition);
    }

    void Update()
    {
        Vector3 newPosition = NewPosition();
        TileBase tileOnNewPosition = TileOnPosition(newPosition);
        if (allowedTiles.Contain(tileOnNewPosition))
        {
            transform.position = newPosition;
        }
        else
        {
            /*            Debug.Log("You cannot walk on " + tileOnNewPosition + "!");*/
            if (tileOnNewPosition != null && tileOnNewPosition.Equals(goal))
            {
                // TilemapCaveGenerator.res
                script.restart();
            }
        }

    }
}
