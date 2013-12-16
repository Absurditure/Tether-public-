using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	//Ref
	public Transform ropeOriginRef;
	private Vector2 otherVel;
	private GameObject line6Ref;

	//setup
	Rigidbody2D myRigidbody2D;
	private bool playerCanMove = false;
	private bool boost = false;
	private bool boostUsed = false;
	public AudioClip HitSurface;
	public AudioClip boostAudio;

	//public variables
	public float moveForce;

	//public ref 
	public bool setTether = false;
	public bool cutTether = false;

	
	void Start () 
	{
		myRigidbody2D = rigidbody2D;
		line6Ref = GameObject.Find ("line6");
		StartCoroutine("Floating");
	}
	
	//Physics update
	void FixedUpdate () 
	{
		if (playerCanMove == true)
		{
			//rigidbody2D.AddForceAtPosition(moveForce, myRigidbody2D);
			rigidbody2D.AddForce(Vector2.up * Input.GetAxis("Vertical") * moveForce);
			rigidbody2D.AddForce(Vector2.right * Input.GetAxis("Horizontal") * moveForce);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Solid") || other.gameObject.CompareTag("PlayerShip") )
		{
			StartCoroutine ("Landed");
			otherVel = other.rigidbody2D.velocity;
		}

//		if (other.gameObject.CompareTag("Tether") )
//		{
//			cutTether = false;
//
//			//GameObject.Find("line6").SetActive(true);
//			Instantiate(line6Ref , transform.position, Quaternion.identity);
//	
//			gameObject.GetComponent<SpringJoint2D>().enabled = true;
//		}

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
			CheckTether();
			CheckBoost();
			CheckRestart();

			if(boost == true & boostUsed == false)
			{
				playerCanMove = true;
				audio.PlayOneShot(boostAudio);

				yield return new WaitForSeconds(1);
				boostUsed = true;
			}
			else 
				playerCanMove = false;

			yield return 0;
		}
	}

	IEnumerator Landed()
	{
		StopCoroutine("Floating");

		audio.PlayOneShot(HitSurface);

		myRigidbody2D.drag = 8;
		playerCanMove = true;

		while(true)
		{
			CheckTether();
			CheckRestart();
				
			//stay with object player is on
			if (otherVel != null)
			{
				rigidbody2D.AddForce(otherVel * 8); // other vel * my current drag to cancel drag
			}

			if (Input.GetButtonDown("Fire1"))
			{
				//setTether = true;
			}
			else
			{
				setTether = false;
			}

			yield return 0;
		}
	}

	void CheckTether()
	{
		if (Input.GetButton("Fire1"))
		{
			cutTether = true;
			if (GameObject.Find("line6") != null)
			{
				GameObject.Find("line6").SetActive(false);
			}
			gameObject.GetComponent<SpringJoint2D>().enabled = false;
		}
	}

	void CheckBoost()
	{
		if (Input.GetButton("Fire2"))
		{
			boost = true;
		}
	}

	void CheckRestart()
	{
		if (Input.GetKeyDown("r") )
		{
			Application.LoadLevel("Test");
		}
	}
	
	
}
