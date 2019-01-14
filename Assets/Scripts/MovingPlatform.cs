using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject platform;
    public float moveSpeed;
    public Transform[] points = null;
    private int pointSelection;
    private Transform currentPoint;
    // Use this for initialization
    void Start ()
    {
        currentPoint = points[pointSelection];
	}
	
	// Update is called once per frame
	void Update ()
    {
        platform.transform.position = Vector2.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

        if(platform.transform.position == currentPoint.position)
        {
            pointSelection++;
            if(pointSelection == points.Length)
            {
                pointSelection = 0;
            }

            currentPoint = points[pointSelection];
        }
	}

    private void OnDrawGizmos()
    {
        int lastPoint = points.Length - 1;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(points[0].position, points[lastPoint].position);
    }
}
