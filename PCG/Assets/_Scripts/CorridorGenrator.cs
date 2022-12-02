using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CorridorGenrator : AgentBasedGenerator
{
    [SerializeField]
    private int corriLength = 10;
    [SerializeField]
    private int corriCount = 10;
    [SerializeField]
    [Range(0.1f,1)]
    private float roomSize = 0.8f;
    [SerializeField]
    public AgentBasedGeneratedData room;

    protected override void RunMapGenerator()
    {
        CorriGenration();
    }

    private void CorriGenration()
    {
        HashSet<Vector2Int> groundPos = new HashSet<Vector2Int>();
        HashSet<Vector2Int> potentialRoomPos = new HashSet<Vector2Int>();

        createCorri(groundPos, potentialRoomPos);

        HashSet<Vector2Int> roomPos = createRoom(potentialRoomPos);

        List<Vector2Int> deadEnds = FindDeadEnds(groundPos);

        CreateRoomEnds(deadEnds, roomPos);

        groundPos.UnionWith(roomPos);

        tilemapDisplay.createGroundTiles(groundPos);
        WallGenerator.createWalls(groundPos, tilemapDisplay);
    }

    private void CreateRoomEnds(List<Vector2Int> deadEnds, HashSet<Vector2Int> roomGrounds)
    {
        foreach (var pos in deadEnds)
        {
            if(roomGrounds.Contains(pos) == false)
            {
                var room = RandomPath(AgentBasedParamenters, pos);
                roomGrounds.UnionWith(room);
            }
        }
    }

    private List<Vector2Int> FindDeadEnds(HashSet<Vector2Int> groundPos)
    {
        List<Vector2Int> deadEnds = new List<Vector2Int>();
        foreach (var pos in groundPos)
        {
            int nextTo = 0;
            foreach (var direction in Direction.directionList)
            {
                if(groundPos.Contains(pos + direction))
                {
                    nextTo++;
                }
                
            }
            if (nextTo ==1)
            {
                deadEnds.Add(pos);
            }
        }
        return deadEnds;
    }

    private HashSet<Vector2Int> createRoom(HashSet<Vector2Int> potentialRoomPos)
    {
        HashSet<Vector2Int> roomPositions = new HashSet<Vector2Int>();
        int NOrooms = Mathf.RoundToInt(potentialRoomPos.Count * roomSize);

        List<Vector2Int> roomToCreate = potentialRoomPos.OrderBy(x => Guid.NewGuid()).Take(NOrooms).ToList();

        foreach (var roomPos in roomToCreate)
        {
            var roomGround = RandomPath(AgentBasedParamenters, roomPos);
            roomPositions.UnionWith(roomGround);
        }
        return roomPositions;
    }

    private void createCorri (HashSet<Vector2Int> groundPos, HashSet<Vector2Int> roomPos)
    {
        var currPos = startPos;
        roomPos.Add(currPos);

        for (int i = 0; i < corriCount; i++)
        {
            var corridor = DungeonGenerator.AgentBasedCorridors(currPos, corriLength);
            currPos = corridor[corridor.Count - 1];
            roomPos.Add(currPos);
            groundPos.UnionWith(corridor);
        }
    }
}
