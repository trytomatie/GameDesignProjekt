using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Depricated
/// by Christian Scherzer
/// </summary>
public class TentacleController : MonoBehaviour
{

    public int length;
    public LineRenderer lr;
    public Vector3[] segmentPoses;
    private Vector3[] segmentVectors;

    public Transform anchor;
    public float anchorDist;
    public Transform targetDir;
    public float targetDist = 1;
    public float smoothSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        lr.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentVectors = new Vector3[length];
    }

    // Update is called once per frame
    void Update()
    {
        segmentPoses[0] = targetDir.position;
        segmentPoses[length-1] = anchor.position;

        for(int i = 1; i < 15;i++)
        {
            Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentVectors[i], smoothSpeed);
        }
        for (int i = 29; i > 15; i--)
        {
            Vector3 anchorPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * anchorDist;
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], anchorPos, ref segmentVectors[i], smoothSpeed);
        }
        lr.SetPositions(segmentPoses);
    }
}
