using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;


/**
 * This class demonstrates the CaveGenerator on a Tilemap.
 * 
 * By: Erel Segal-Halevi
 * Since: 2020-12
 */

public class TilemapCaveGeneratorExpandedQ6 : MonoBehaviour {
    [SerializeField] Tilemap tilemap = null;

    [Tooltip("The tile that represents a wall (an impassable block)")]
    [SerializeField] TileBase wallTile = null;

    [Tooltip("The tile that represents a floor (a passable block)")]
    [SerializeField] TileBase floorTile = null;

    [Tooltip("The tile that represents a bush (a passable block)")]
    [SerializeField] TileBase bushTile = null;

    [Tooltip("The tile that represents the target location to pass the level")]
    [SerializeField] TileBase goalTile = null;

    [Tooltip("The first enemy")]
    [SerializeField] GameObject enemy1 = null;

    [Tooltip("The second enemy")]
    [SerializeField] GameObject enemy2 = null;

    [Tooltip("the relative amount of different tiles on the grid")]
    [Range(0, 1)]
    [SerializeField] float randomFillPercent = 0.33f;

    [Tooltip("Length and height of the grid")]
    [SerializeField] int gridSize = 100;

    [Tooltip("How many steps do we want to simulate?")]
    [SerializeField] int simulationSteps = 20;

    [Tooltip("For how long will we pause between each simulation step so we can look at the result?")]
    [SerializeField] float pauseTime = 0.5f;

    [SerializeField] GameObject player = null;
    private CaveGeneratorExpandedQ6 caveGenerator;

    void Start()  {
        //To get the same random numbers each time we run the script
        Random.InitState(100);

        caveGenerator = new CaveGeneratorExpandedQ6(randomFillPercent, gridSize);
        caveGenerator.RandomizeMap();
                
        //For testing that init is working
        GenerateAndDisplayTexture(caveGenerator.GetMap());
            
        //Start the simulation
        StartCoroutine(SimulateCavePattern());

        if(player==null)
        {
            player = GameObject.Find("Player");
        }
    }


    //Do the simulation in a coroutine so we can pause and see what's going on
    private IEnumerator SimulateCavePattern() {
        for (int i = 0; i < simulationSteps; i++) {
            //yield return new WaitForSeconds(pauseTime); //we dont want to wait in this scenario

            //Calculate the new values
            caveGenerator.SmoothMap();

            //Generate texture and display it on the plane
            GenerateAndDisplayTexture(caveGenerator.GetMap());
        }
        Debug.Log("Simulation completed!");
        bool foundpos = false;
        int z = 1;
        while (!foundpos)
        {
            Vector3 vec = new Vector3(z, z, 0);
            TileBase tileOnNewPosition = TileOnPosition(vec);
            Debug.Log(tileOnNewPosition.name);
            if (wallTile.Equals(tileOnNewPosition))
            {
                z++;
            }
            else
            {
                Vector3 scaletofit = player.transform.localScale * 0.5f;
                scaletofit.z = 0;
                player.transform.position = vec + scaletofit;
                foundpos = true;
                Debug.Log("FOUND");
            }
        }
        bool foundPosForGoal = false;
        z = gridSize;
        while(!foundPosForGoal)
        {
            Vector3 vec = new Vector3(z, z, 0);
            TileBase tileOnNewPosition = TileOnPosition(vec);
            if (tileOnNewPosition== null || wallTile.Equals(tileOnNewPosition))
            {
                z--;
            }
            else
            {
                Vector3Int cellPosition = tilemap.WorldToCell(vec);
                tilemap.SetTile(cellPosition, goalTile);
                foundPosForGoal = true;
                Debug.Log("FOUND spot for goal tile");
            }
        }
        foundpos = false;
        while (!foundpos)
        {
            int x1 = Random.Range(1, gridSize);
            int x2 = Random.Range(1, gridSize);
            Vector3 vec = new Vector3(x1, x2, 0);
            TileBase tileOnNewPosition = TileOnPosition(vec);
            if (tileOnNewPosition == null || wallTile.Equals(tileOnNewPosition))
            {
                continue;
            }
            else
            {
                Vector3 scaletofit = enemy1.transform.localScale * 0.5f;
                scaletofit.z = 0;
                enemy1.transform.position = vec + scaletofit;
                foundpos = true;
                Debug.Log("FOUND");
            }
        }
        foundpos = false;
        while (!foundpos)
        {
            int x1 = Random.Range(1, gridSize);
            int x2 = Random.Range(1, gridSize);
            Vector3 vec = new Vector3(x1, x2, 0);
            TileBase tileOnNewPosition = TileOnPosition(vec);
            if (tileOnNewPosition == null || wallTile.Equals(tileOnNewPosition))
            {
                continue;
            }
            else
            {
                Vector3 scaletofit = enemy2.transform.localScale * 0.5f;
                scaletofit.z = 0;
                enemy2.transform.position = vec + scaletofit;
                foundpos = true;
                Debug.Log("FOUND");
            }
        }



    }
    private TileBase TileOnPosition(Vector3 worldPosition)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return tilemap.GetTile(cellPosition);
    }


    //Generate a black or white texture depending on if the pixel is cave or wall
    //Display the texture on a plane
    private void GenerateAndDisplayTexture(int[,] data) {
        for (int y = 0; y < gridSize; y++) {
            for (int x = 0; x < gridSize; x++) {
                var position = new Vector3Int(x, y, 0);
                var tile = floorTile;
                if (data[x, y] == 0) tile = floorTile;
                else if (data[x, y] == 1) tile = wallTile;
                else if (data[x, y] == 2) tile = bushTile;
                tilemap.SetTile(position, tile);
            }
        }
    }

    public void restart()
    {
        tilemap.ClearAllTiles();
        gridSize = gridSize + (int)(gridSize * 0.1);
        Start();
    }
}
