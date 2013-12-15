using UnityEngine;
using System.Collections;

public class GeneralAddForce : MonoBehaviour 
{
	public float forceAmount;
	public Vector3 forceDirection;

	// Use this for initialization
	void Start () 
	{
		rigidbody2D.AddForce(forceDirection * forceAmount);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
