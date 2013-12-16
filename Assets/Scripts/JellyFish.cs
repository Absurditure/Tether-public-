using UnityEngine;
using System.Collections;

public class JellyFish : MonoBehaviour 
{

	private Transform myTransform;

	private bool foundMe = false;

	void Start () 
	{
		myTransform = transform;
	}

	void Update()
	{
		if (foundMe == true)
		{
			myTransform.position = GameObject.Find("Player").GetComponent<Transform>().position;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player") )
		{

			foundMe = true;
		}

		if (other.gameObject.CompareTag("PlayerShip") )
		{
			// go to win screen
			Debug.Log("win");
		}	

	}
}
