using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	private Rigidbody rb;
	public float magnetSpeed;
	private Vector3 movement;

	void Start () 
	{
		rb = GetComponent <Rigidbody> ();
		movement = new Vector3 (0.0f, 0.0f, magnetSpeed);
		rb.velocity = movement;
	}

}
