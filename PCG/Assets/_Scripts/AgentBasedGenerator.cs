using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class AgentBasedGenerator : DungeonStorage
{

    [SerializeField]
    private AgentBasedGeneratedData AgentBasedParamenters;

    protected override void RunMapGenerator()
    {
        HashSet<Vector2Int> groundPos = RandomPath();
        tilemapDisplay.Clear();
        tilemapDisplay.createGroundTiles(groundPos);
        WallGenerator.createWalls(groundPos, tilemapDisplay);
    }

    protected HashSet<Vector2Int> RandomPath()
    {
        var currPos = startPos;
        HashSet<Vector2Int> groundPos = new HashSet<Vector2Int>();
        for (int i = 0; i < AgentBasedParamenters.iterations; i++)
        {
            var path = DungeonGenerator.AgentBasedWalk(currPos, AgentBasedParamenters.walkDist);
            groundPos.UnionWith(path);
            if (AgentBasedParamenters.randomWalk == true)
            {
                currPos = groundPos.ElementAt(Random.Range(0, groundPos.Count));
            }
        }
        return groundPos;
    }

}
