using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

/**
 * This component allows the player to move by clicking the arrow keys,
 * but only if the new position is on an allowed tile.
 */
public class KeyboardMoverByTileQ5: KeyboardMoverQ5
{
    [SerializeField] Tilemap tilemap = null;
    [SerializeField] AllowedTilesQ5 allowedTiles = null;
    [SerializeField] TileBase[] destroyableTiles = null;
    [SerializeField] TileBase grassTile = null;
    [SerializeField] float coolDownTime = 2f;
    private float carveStart = 0f;


    private TileBase TileOnPosition(Vector3 worldPosition) {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return tilemap.GetTile(cellPosition);
    }

    void Update()  
    {
        Vector3 newPosition = NewPosition(); 

        TileBase tileOnNewPosition = TileOnPosition(newPosition);
        if (allowedTiles.Contain(tileOnNewPosition)) {
            transform.position = newPosition;
        } 
        else 
        {
            Debug.Log("You cannot walk on " + tileOnNewPosition + "!");
        }
        carveMountain(); // check
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
