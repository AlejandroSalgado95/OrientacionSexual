using UnityEngine;
using System.Collections;

public class SpermController : MonoBehaviour 
{
	private Rigidbody rb;
	public float minVel;
	public float maxVel;
	private Vector3 movement;
	private PlayerController playerC;
	public float fireDelay;
	public int pointsEarned;
	private GameController gameC;
	private GameObject player;
	public float unTime;
	private Renderer spermRend;
	public Texture[] textures; 
	private int index;
	public GameObject child;
	private Renderer childRend;
	private Quaternion rotation;
	public GameObject soundDiafragma;
	public GameObject soundSplash;
	public GameObject soundCondom;
	public GameObject explosion;
	private string word;

	void Start()
	{
		word = "sperm";
		rotation = Quaternion.identity; 
		rb = GetComponent <Rigidbody> ();
		childRend = child.GetComponent <Renderer> ();
		index = 0;
		player = GameObject.FindWithTag ("Player");
		playerC = player.GetComponent <PlayerController> ();
		gameC = GameObject.FindWithTag ("GameController").GetComponent <GameController> ();
		movement = new Vector3 (0.0f,0.0f, Random.Range (minVel,maxVel));
		rb.velocity = movement;
	}

	void Update()
	{
			switch (index) {
		case 0:
			{
				childRend.material.mainTexture = textures [0];
				index += 1;
				break;
			}
		case 1:
			{
			childRend.material.mainTexture = textures [1];
				index += 1;
				break;
			}
		case 2:
			{
			childRend.material.mainTexture = textures [2];
				index += 1;
				break;
			}
		case 3:
			{
			childRend.material.mainTexture = textures [2];
				index += 1;
				break;
			}
		case 4:
			{
			childRend.material.mainTexture = textures [1];
				index += 1;
				break;
			}
		case 5:
			{
			childRend.material.mainTexture = textures [0];
				index += 1;
				break;
			}
		case 6:
			{
			childRend.material.mainTexture = textures [3];
				index += 1;
				break;
			}
		case 7:
			{
			childRend.material.mainTexture = textures [4];
				index += 1;
				break;
			}
		case 8:
			{
			childRend.material.mainTexture = textures [4];
				index += 1;
				break;
			}
		case 9:
			{
			childRend.material.mainTexture = textures [3];
				index = 0;
				break;
			}
		}

	}
	

	void OnTriggerEnter(Collider other)
	{
		Instantiate (explosion, rb.position, rotation);

		if (other.tag == "MagneticBeam2") 
		{
			Destroy (other.gameObject);
			Destroy (gameObject); 
			gameC.UpdateText(pointsEarned);
			Instantiate(soundSplash,rb.position, rotation);
		}

		if (other.tag == "Player") 
		{
			if (playerC.flag){
			Destroy (gameObject);
			playerC.FireDelay(fireDelay);
			playerC.Unable(unTime);
			playerC.flag = false;
			}

		}

		if (other.tag == "Ovum") 
		{
			Destroy (gameObject);
			gameC.GameOver(word);
		}

		if (other.tag == "Diafragma") 
		{
			Destroy (gameObject); 
			gameC.UpdateText(pointsEarned);
			Instantiate(soundDiafragma,rb.position,rotation);

		}

		if (other.tag == "Condon")
		{
			if (Random.Range(0,6) < 3)
			{
				Destroy (gameObject);
				gameC.UpdateText(pointsEarned);
			}
			Instantiate(soundCondom,rb.position, rotation);

		}
	}


}
