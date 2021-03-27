using UnityEngine;
using System.Collections;

public class OvumQuadController : MonoBehaviour {

	private Rigidbody rb;
	private float timer;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3 (0.0f, 0.0f, 12.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= (timer + 10)) {
			rb.velocity = new Vector3(0,0,12);
		}

	}

	void FixedUpdate(){
		rb.position = new Vector3 (0.0f, 1.9f, Mathf.Clamp (rb.position.z, -14.0f, -9.55f));
	}

	public void ButtonClick() {
		rb.velocity = new Vector3 (0, 0, -12);
		timer = Time.time;
	}
}
