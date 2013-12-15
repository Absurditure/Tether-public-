using UnityEngine;
using System.Collections;

public class Tether : MonoBehaviour 
{
	Transform myTransform;
	Transform playerTransform;
	GameObject playerRef;
	GameObject shipOneRef;

	void Start () 
	{
		myTransform = transform;
		playerTransform = GameObject.Find("Player").transform;
		playerRef = GameObject.Find("Player");
		shipOneRef = GameObject.Find("ShipOne");
	}
	

	void Update () 
	{
		myTransform.position = shipOneRef.transform.position;


		if ( GameObject.Find("Player").GetComponent<Player>().cutTether == false)
		{
			if( GameObject.Find("Player").GetComponent<Player>().setTether == true) 
			{
				//myTransform.position = playerTransform.position;
				iTween.MoveTo(gameObject, playerTransform.position, 1);

			}
			else if (GameObject.Find("Player").GetComponent<Player>().setTether == false)
			{
				//rigidbody2D.isKinematic = true;
			}
		}
	}
}
