using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform lookAt;

    public float xBound = 2.0f;
    public float yBound = 1.5f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        float xDistance = lookAt.position.x - transform.position.x;
        if(xDistance > xBound || xDistance < -xBound)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = xDistance - xBound;
            }
            else
            {
                delta.x = xDistance + xBound;
            }
        }

        float yDistance = lookAt.position.y - transform.position.y;
        if (yDistance > yBound || yDistance < -yBound)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = yDistance - yBound;
            }
            else
            {
                delta.y = yDistance + yBound;
            }
        }

        transform.position = transform.position + delta;
    }
}
