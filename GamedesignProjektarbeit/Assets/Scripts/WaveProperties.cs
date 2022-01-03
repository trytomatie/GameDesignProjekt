using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "ScriptableObjects/WaveData", order = 1)]
public class WaveProperties : ScriptableObject
{

    public int bacteriaCount;
    public int virusCount;
    public int spawnDelay;

}
