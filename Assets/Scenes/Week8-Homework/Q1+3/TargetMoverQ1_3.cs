using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component moves its object towards a given target position.
 */
public class TargetMoverQ1_3 : MonoBehaviour
{
    [SerializeField] Tilemap tilemap = null;
    [Tooltip("The object representing both allowedTiles and their weights")]
    [SerializeField] AllowedTilesPlusWeight allowedTiles = null;

    [Tooltip("The speed by which the object moves towards the target, in meters (=grid units) per second")]
    [SerializeField] float speed = 2f;

    [Tooltip("Maximum number of iterations before BFS algorithm gives up on finding a path")]
    [SerializeField] int maxIterations = 1000;

    [Tooltip("The target position in world coordinates")]
    [SerializeField] Vector3 targetInWorld;

    [Tooltip("The target position in grid coordinates")]
    [SerializeField] Vector3Int targetInGrid;

    protected bool atTarget;  // This property is set to "true" whenever the object has already found the target.
    private TilemapWGraph tilemapGraph = null;
    private float timeBetweenSteps;
    public void SetTarget(Vector3 newTarget)
    {
        if (targetInWorld != newTarget)
        {
            targetInWorld = newTarget;
            targetInGrid = tilemap.WorldToCell(targetInWorld);
            atTarget = false;
        }
    }

    public Vector3 GetTarget()
    {
        return targetInWorld;
    }

    protected virtual void Start()
    {
        //Crate a TilemapWGraph with weights for each tile
        tilemapGraph = new TilemapWGraph(tilemap, allowedTiles.Get(),allowedTiles.getWeights());
        timeBetweenSteps = 1 / speed;
        StartCoroutine(MoveTowardsTheTarget());
    }

    IEnumerator MoveTowardsTheTarget()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(timeBetweenSteps);
            if (enabled && !atTarget)
                MakeOneStepTowardsTheTarget();
        }
    }

    private void MakeOneStepTowardsTheTarget()
    {
        Vector3Int startNode = tilemap.WorldToCell(transform.position);
        Vector3Int endNode = targetInGrid;
        //Apply Dijkstra algorithm to find the shortest Path with weights
        List<Vector3Int> shortestPath = Dijekstra.GetPath(tilemapGraph, startNode, endNode);
        Debug.Log("shortestPath = " + string.Join(" , ", shortestPath));
        if (shortestPath.Count >= 2)
        {
            Vector3Int nextNode = shortestPath[1];
            transform.position = tilemap.GetCellCenterWorld(nextNode);
            //find and set the speed for each tile
            TileBase currTileBase = TileOnPosition(transform.position);
            int TileWeight = allowedTiles.getWeights()[allowedTiles.findTilePos(currTileBase)];
            timeBetweenSteps = TileWeight / speed;
        }
        else
        {
            atTarget = true;
        }
    }

    private TileBase TileOnPosition(Vector3 worldPosition)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return tilemap.GetTile(cellPosition);
    }


}
