using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AgentBasedParamenters_" ,menuName = "PCG_1/AgentBasedGeneratedData")]

public class AgentBasedGeneratedData : ScriptableObject
{
    public int iterations = 10;
    public int walkDist = 10;

    public bool randomWalk = true;
}
