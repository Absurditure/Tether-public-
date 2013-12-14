using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	//setup
	Rigidbody2D myRigidbody2D;
	private bool playerCanMove = false;

	//public variables
	public float moveForce;
	
	void Start () 
	{
		myRigidbody2D = rigidbody2D;
	}
	
	//Physics update
	void FixedUpdate () 
	{
		if (playerCanMove == true)
		{
			rigidbody2D.AddForce(Vector2.up * Input.GetAxis("Vertical") * moveForce);
			rigidbody2D.AddForce(Vector2.right * Input.GetAxis("Horizontal") * moveForce);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Solid") )
		{
			StartCoroutine ("Landed");
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		StartCoroutine("Floating");
	}

	IEnumerator Floating()
	{
		StopCoroutine("Landed");

		myRigidbody2D.drag = 0;
		//wait
		yield return new WaitForSeconds(.5f);
		playerCanMove =false;

		while(true)
		{

			yield return 0;
		}
	}

	IEnumerator Landed()
	{
		StopCoroutine("Floating");

		myRigidbody2D.drag = 8;
		playerCanMove = true;

		while(true)
		{

			yield return 0;
		}
	}


}
