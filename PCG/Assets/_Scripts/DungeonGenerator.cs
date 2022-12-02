using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DungeonGenerator
{
    public static HashSet<Vector2Int> AgentBasedWalk (Vector2Int startPos, int walkDist)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPos);
        var prevPos = startPos;

        for (int i = 0; i < walkDist; i++)
        {
            var nextPos = prevPos + Direction.GetPath();
            prevPos = nextPos;
            path.Add(nextPos);
        }
        return path;
    }

    public static List<Vector2Int> AgentBasedCorridors(Vector2Int startPos, int corriLength)
    {
        List<Vector2Int> corri = new List<Vector2Int>();
        var direction = Direction.GetPath();
        var currPos = startPos;
        corri.Add(currPos);

        for (int i = 0; i < corriLength; i++)
        {
            currPos += direction;
            corri.Add(currPos);
        }
        return corri;
    }
}

public static class Direction
{
    public static List<Vector2Int> directionList = new List<Vector2Int>
    {
        new Vector2Int (0, 1), // Direction UP
        new Vector2Int (1, 0), // Direction RIGHT
        new Vector2Int (0, -1), // Direction DOWN
        new Vector2Int (-1, 0) // Direction LEFT
    };

    public static Vector2Int GetPath()
    {
        return directionList[Random.Range(0, directionList.Count)];
    }
}