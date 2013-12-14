using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	//Ref
	public Transform ropeOriginRef;

	//setup
	Rigidbody2D myRigidbody2D;
	private bool playerCanMove = false;

	//public variables
	public float moveForce;

	//public ref
	public bool setTether = false;
	public bool cutTether = false;
	
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
			if (Input.GetButton("Fire1"))
			{
				cutTether = true;
				GameObject.Find("line6").SetActive(false);
				gameObject.GetComponent<SpringJoint2D>().enabled = false;
			}

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
			if (Input.GetButtonDown("Fire1"))
			{
				setTether = true;
			}
			else
			{
				setTether = false;
			}

			yield return 0;
		}
	}


}
