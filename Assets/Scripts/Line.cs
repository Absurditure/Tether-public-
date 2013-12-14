using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour 
{
	private LineRenderer myLineRenderer;

	public Transform start;
	public Transform end;

	void Start () 
	{
		myLineRenderer = GetComponent<LineRenderer>();
	}

	void FixedUpdate () 
	{
		myLineRenderer.SetPosition(0, start.position); //update start position

		myLineRenderer.SetPosition(1,end.position);// update end position			
	}
}
