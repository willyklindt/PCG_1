using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapDisplay : MonoBehaviour
{
    [SerializeField]
    private Tilemap groundTilemap;

    [SerializeField]
    private TileBase groundTiles;

    public void createGroundTiles(IEnumerable<Vector2Int> groundPos)
    {
        createTiles(groundPos, groundTilemap, groundTiles);
    }

    private void createTiles(IEnumerable<Vector2Int> tilePos, Tilemap tilemap, TileBase tiles)
    {
        foreach (var pos in tilePos)
        {
            createSingleTile(tiles, pos, tilemap);
        }
    }

    private void createSingleTile(TileBase tiles, Vector2Int pos, Tilemap tilemap)
    {
        var localTilePos = tilemap.WorldToCell((Vector3Int)pos);
        tilemap.SetTile(localTilePos, tiles);
    }
}
