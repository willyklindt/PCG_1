using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class AgentBasedGenerator : DungeonStorage
{

    [SerializeField]
    protected AgentBasedGeneratedData AgentBasedParamenters;

    protected override void RunMapGenerator()
    {
        HashSet<Vector2Int> groundPos = RandomPath(AgentBasedParamenters, startPos);
        tilemapDisplay.Clear();
        tilemapDisplay.createGroundTiles(groundPos);
        WallGenerator.createWalls(groundPos, tilemapDisplay);
    }

    protected HashSet<Vector2Int> RandomPath(AgentBasedGeneratedData parameters, Vector2Int pos)
    {
        var currPos = pos;
        HashSet<Vector2Int> groundPos = new HashSet<Vector2Int>();
        for (int i = 0; i < parameters.iterations; i++)
        {
            var path = DungeonGenerator.AgentBasedWalk(currPos, parameters.walkDist);
            groundPos.UnionWith(path);
            if (parameters.randomWalk == true)
            {
                currPos = groundPos.ElementAt(Random.Range(0, groundPos.Count));
            }
        }
        return groundPos;
    }

}
