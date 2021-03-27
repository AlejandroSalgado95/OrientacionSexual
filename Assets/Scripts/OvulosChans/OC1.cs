using UnityEngine;
using System.Collections;

public class OC1 : MonoBehaviour {
	
	public Texture[] textures;
	private Renderer childrend;
	private float animTime;
	private float temp;
	private float cont;
	public GameObject child;
	//private int index;
	private AudioSource sounds;
	public AudioClip noise1;
	public AudioClip noise2;
	public AudioClip noise3;
	private Rigidbody rb;
	private bool presence;
	private float timePresence;

	
	void Start()
	{
		childrend = child.GetComponent<Renderer> ();
		animTime = 0.2f;
		cont = 0;
		temp = 0;
		//index = 0;
		sounds = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody> ();
		presence = false;

	} 
	
	void Update ()
	{
		
		float cont2 = cont % 2;
		
		if ((Time.time > temp) && (cont2 == 0))
		{
			childrend.material.mainTexture = textures[0];
			cont +=1;
			temp = Time.time + animTime;
		}
		
		if ((Time.time > temp) && (cont2 != 0))
		{
			childrend.material.mainTexture = textures[1];
			cont +=1;
			temp = Time.time + animTime;
		}

		if (presence) 
		{
			if (Time.time > timePresence) 
			{
				rb.velocity = new Vector3(-3.0f,0.0f,0.0f);
				presence = false; 
			}
		}
		
	}

	void FixedUpdate()
	{
		rb.position = new Vector3 (Mathf.Clamp (rb.position.x,-8.0f, -3.8f), 2.0f, -5.36f);
	}

	public void StartSound()
	{
		sounds.clip = noise1;
		sounds.Play ();
		rb.velocity = new Vector3(5.0f,0.0f,0.0f);
		presence = true;
		timePresence = Time.time + 2.5f; 

	}

	public void CondomSound1()
	{
		sounds.clip = noise2;
		sounds.Play ();
		rb.velocity = new Vector3(5.0f,0.0f,0.0f);
		presence = true;
		timePresence = Time.time + 2.5f; 
	}

	public void DiafragmaSound1()
	{
		sounds.clip = noise3;
		sounds.Play ();
		rb.velocity = new Vector3(5.0f,0.0f,0.0f);
		presence = true;
		timePresence = Time.time + 2.5f; 
	}

	
}
