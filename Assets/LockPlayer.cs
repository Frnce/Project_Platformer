using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPlayer : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LockDown());
        }
    }
    IEnumerator LockDown()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
