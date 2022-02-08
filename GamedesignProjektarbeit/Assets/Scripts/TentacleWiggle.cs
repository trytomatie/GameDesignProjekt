using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Depricated
/// by Christian Scherzer
/// </summary>
public class TentacleWiggle : MonoBehaviour
{

    public List<Transform> tentacles;
    public float wiggleAmount = 0.05f;
    public float wigleScale = 1;
    private List<int> randomOffset = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < tentacles.Count;i++)
        {
            randomOffset.Add(Random.Range(1, 100000));
        }
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (Transform tentacle in tentacles)
        {
            tentacle.Rotate(0,0,Mathf.Sin((Time.time * wigleScale + randomOffset[i])) * wiggleAmount);
            i++;
        }

    }
}
