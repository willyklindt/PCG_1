using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapDisplay : MonoBehaviour
{
    [SerializeField]
    private Tilemap groundTilemap, wallTilemap;

    [SerializeField]
    private TileBase groundTiles, wallTop;

    public void createGroundTiles(IEnumerable<Vector2Int> groundPos)
    {
        createTiles(groundPos, groundTilemap, groundTiles);
    }

    private void createTiles(IEnumerable<Vector2Int> tilePos, Tilemap tilemap, TileBase tiles)
    {
        foreach (var pos in tilePos)
        {
            createSingleTile(tilemap, tiles, pos);
        }
    }

    internal void createSingleWall(Vector2Int pos)
    {
        createSingleTile(wallTilemap, wallTop, pos);
    }

    private void createSingleTile(Tilemap tilemap, TileBase tiles, Vector2Int pos)
    {
        var localTilePos = tilemap.WorldToCell((Vector3Int)pos);
        tilemap.SetTile(localTilePos, tiles);
    }

    public void Clear()
    {
        groundTilemap.ClearAllTiles();
    }

}
