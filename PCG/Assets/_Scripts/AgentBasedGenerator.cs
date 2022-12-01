using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class AgentBasedGenerator : MonoBehaviour
{
    [SerializeField]
    protected Vector2Int startPos = new Vector2Int(0, 0);

    [SerializeField]
    private int iterations = 30; //CHECK DEN HER

    [SerializeField]
    public int walkDist = 10;

    [SerializeField]
    public bool randomWalk = true;

    [SerializeField]
    private TilemapDisplay tilemapDisplay;

    public void MapGenerator()
    {
        HashSet<Vector2Int> groundPos = RandomPath();
        tilemapDisplay.createGroundTiles(groundPos);
    }

    protected HashSet<Vector2Int> RandomPath()
    {
        var currPos = startPos;
        HashSet<Vector2Int> groundPos = new HashSet<Vector2Int>();
        for (int i = 0; i < iterations; i++)
        {
            var path = DungeonGenerator.AgentBasedWalk(currPos, walkDist);
            groundPos.UnionWith(path);
            if (randomWalk == true)
            {
                currPos = groundPos.ElementAt(Random.Range(0, groundPos.Count));
            }
        }
        return groundPos;
    }
}
