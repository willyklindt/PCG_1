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
    private Tilemap wallTilemap;

    [SerializeField]
    private TileBase groundTiles;

    [SerializeField]
    private TileBase wallTop;


    [SerializeField]
    private TileBase wallRight;


    [SerializeField]
    private TileBase wallLeft;


    [SerializeField]
    private TileBase wallBottom;


    [SerializeField]
    private TileBase wallMid;

    [SerializeField]
    private TileBase wallInnerCornerDownLeft;

    [SerializeField]
    private TileBase wallInnerCornerDownRight;


    [SerializeField]
    private TileBase wallDiagonalCornerDownRight;


    [SerializeField]
    private TileBase wallDiagonalCornerDownLeft;

    [SerializeField]
    private TileBase wallDiagonalCornerUpRight;

    [SerializeField]
    private TileBase wallDiagonalCornerUpLeft;

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

    internal void createSingleWall(Vector2Int pos, string Binary)
    {
        int IntType = Convert.ToInt32(Binary, 2);
        TileBase tile = null;
        if (WallBytes.wallTop.Contains(IntType))
        {
            tile = wallTop;
        }
        else if(WallBytes.wallSideRight.Contains(IntType))
        {
            tile = wallRight;
        }
        else if (WallBytes.wallSideLeft.Contains(IntType))
        {
            tile = wallLeft;
        }

        else if (WallBytes.wallBottm.Contains(IntType))
        {
            tile = wallBottom;
        }

        else if (WallBytes.wallFull.Contains(IntType))
        {
            tile = wallMid;
        }
        if (tile!=null)
        {
            
    
        createSingleTile(wallTilemap, tile, pos);
        }
    }

    private void createSingleTile(Tilemap tilemap, TileBase tiles, Vector2Int pos)
    {
        var localTilePos = tilemap.WorldToCell((Vector3Int)pos);
        tilemap.SetTile(localTilePos, tiles);
    }

    public void Clear()
    {
        groundTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }

    internal void createSingleCornerWall(Vector2Int pos, string Binary)
    {
        int IntType = Convert.ToInt32(Binary, 2);
        TileBase tile = null;

        if(WallBytes.wallInnerCornerDownLeft.Contains(IntType))
        {
            tile = wallInnerCornerDownLeft;
        }
        else if (WallBytes.wallInnerCornerDownRight.Contains(IntType))
        {
            tile = wallInnerCornerDownRight;
        }

        else if (WallBytes.wallDiagonalCornerDownLeft.Contains(IntType))
        {
            tile = wallDiagonalCornerDownLeft;
        }

        else if (WallBytes.wallDiagonalCornerDownRight.Contains(IntType))
        {
            tile = wallDiagonalCornerDownRight;
        }

        else if (WallBytes.wallDiagonalCornerUpRight.Contains(IntType))
        {
            tile = wallDiagonalCornerUpRight;
        }

        else if (WallBytes.wallDiagonalCornerUpLeft.Contains(IntType))
        {
            tile = wallDiagonalCornerUpLeft;
        }

        else if (WallBytes.wallFullEightDirections.Contains(IntType))
        {
            tile = wallBottom;
        }

        else if (WallBytes.wallBottmEightDirections.Contains(IntType))
        {
            tile = wallMid;
        }


        if (tile!= null)
        {

            createSingleTile(wallTilemap, tile, pos);
        }
    }
}
