using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour 
{
	private Transform myTransform;
	private Transform shipOneTransform;

	void Start () 
	{
		myTransform = transform;		
		shipOneTransform = GameObject.Find("ShipOne").transform;
	}

	void Update () 
	{
		myTransform.position = shipOneTransform.position;

		if(GameObject.Find("Player").GetComponent<Player>().cutTether == true)
		{
			myTransform.position = GameObject.Find("Player").GetComponent<Transform>().position;
		}

	}
}
