using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private float moveH;
	private float moveV;
	private Vector3 movement;
	public float maxValueX;
	public float minValueX;
	public float maxValueZ;
	public float minValueZ;
	public float shootLag;
	public GameObject magneticBeam;
	public Transform spawnBeam;
	private float fire = 0;
	private AudioSource aud;
	//private Collider col;
	private float timeRate;

	public GameObject child;
	public Texture[] textures;
	private Renderer childRend;
	public float whiteTime;
	//public Collider box;
	//public Collider ovum; 
	public bool flag;
	public Button shoot; 
	public Button velocity; 


	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		aud = GetComponent<AudioSource> ();
		//col = GetComponent<CapsuleCollider> ();
		childRend = child.GetComponent<Renderer> ();
	}

	void FixedUpdate () 
	{

		moveH = Input.GetAxis ("Horizontal");
		moveV = Input.GetAxis ("Vertical");
		movement = new Vector3 (moveH, 0.0f, moveV);
		rb.velocity = movement * speed;
		rb.position = new Vector3 ( Mathf.Clamp(rb.position.x,minValueX,maxValueX), 2.0f, 
			Mathf.Clamp (rb.position.z,minValueZ,maxValueZ) );

		if (Time.time > timeRate) 
			flag = true;
			//col.enabled = true;


		if (Input.GetKey (KeyCode.Space) && Time.time > fire) 
		{
			fire = Time.time + shootLag;
			aud.Play ();
			Instantiate (magneticBeam, spawnBeam.position, spawnBeam.rotation);

		}


	}

	public void FireDelay(float fireDelay)
	{
		fire = Time.time + fireDelay;
	}

	public void Unable(float unTime)
	{
		//col.enabled = false;

		timeRate = Time.time + unTime;
		StartCoroutine (AnimPlayer());
	}

	IEnumerator AnimPlayer ()
	{
		while (Time.time < timeRate)
		{
			childRend.material.mainTexture = textures[1];
			yield return new WaitForSeconds (whiteTime);
			childRend.material.mainTexture = textures[0];
		}
		childRend.material.mainTexture = textures [0];
	}

	public void ShootVelocity ()
	{
		shootLag = 0.25f;
		shoot.interactable = false; 
	}

	public void PlayerVelocity()
	{
		speed = 10.0f; 
		velocity.interactable = false;
	}
	


	/*
	public void Animator()
	{
	}
	*/
}
