using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DungeonStorage : MonoBehaviour
{
    [SerializeField]
    protected TilemapDisplay tilemapDisplay = null;
    [SerializeField]
    protected Vector2Int startPos = new Vector2Int(0, 0);

    public void MapGenerator()
    {
        tilemapDisplay.Clear();
        RunMapGenerator();
    }

    protected abstract void RunMapGenerator();
}
