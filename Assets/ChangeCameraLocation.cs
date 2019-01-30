using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraLocation : MonoBehaviour
{
    CameraController cam;

    public bool isGoingUp;
	// Use this for initialization
	void Start ()
    {
        cam = Camera.main.GetComponent<CameraController>();
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isGoingUp)
            {
                cam.cameraOffset.y = 2f;
            }
            else
            {
                cam.cameraOffset.y = 0f;
            }
        }
    }
}
