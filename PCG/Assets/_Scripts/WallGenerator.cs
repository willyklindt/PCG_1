using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator 
{
    public static void createWalls(HashSet<Vector2Int> groundPos, TilemapDisplay tilemapDisplay)
    {
        var displayWall = wallDirection(groundPos, Direction.directionList);
        foreach (var pos in displayWall)
        {
            tilemapDisplay.createSingleWall(pos);
        }
    }

    private static HashSet<Vector2Int> wallDirection(HashSet<Vector2Int> groundPos, List<Vector2Int> directions)
    {
        HashSet<Vector2Int> wallPos = new HashSet<Vector2Int>();
        foreach (var pos in groundPos)
        {
            foreach (var direction in directions)
            {
                var nextTo = pos + direction;
                if (groundPos.Contains(nextTo) == false)
                {
                    wallPos.Add(nextTo);
                }
            }
        }
        return wallPos;
    }
}
