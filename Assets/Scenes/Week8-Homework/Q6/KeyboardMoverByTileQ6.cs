using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KeyboardMoverByTileQ6 : KeyboardMoverQ6
{
    [SerializeField] Tilemap tilemap = null;
    [SerializeField] AllowedTilesQ6 allowedTiles = null;
    [SerializeField] TileBase goal = null;
    [SerializeField] TilemapCaveGeneratorExpandedQ6 script = null;

    [SerializeField] float coolDownTime = 2f;
    private float carveStart = 0f;
    [SerializeField] TileBase[] destroyableTiles = null;
    [SerializeField] TileBase grassTile = null;

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
            //if the player is about to touch the goal then restart the game and make it bigger
            if (tileOnNewPosition != null && tileOnNewPosition.Equals(goal))
            {
                script.restart();
            }
        }
        carveMountain();
    }

    private void carveMountain()
    {
        // if the player clicked X 
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (carveCoolDown() == true) // If cooldown
            {
                // Tranform the right position into a Tile
                TileBase tileOnDirPosition = TileOnPosition(transform.position + dir); // Player can move only to allowed tiles

                // check if the right tile is mountain tileOnRightPosition
                if (destroyableTiles.Contains(tileOnDirPosition))
                {
                    //Debug.Log("Know its mountain ");
                    // change the mountain tile -> to grass tile
                    Vector3 playerDir = transform.position + dir;
                    tilemap.SetTile(tilemap.WorldToCell(playerDir), grassTile);
                }
            }

        }
    }
    private bool carveCoolDown()
    {
        if (Time.time > carveStart + coolDownTime)
        {
            carveStart = Time.time;
            return true;
        }
        else
        {
            return false;
        }
    }
}
