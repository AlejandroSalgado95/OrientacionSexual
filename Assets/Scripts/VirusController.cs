using UnityEngine;
using System.Collections;

public class VirusController : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 movement;
    private GameController gameC;
	public GameObject soundDiafragma;
	public GameObject soundCondom;
	private Quaternion rotation;
	private PlayerController playerC;
	private GameObject player;
	public float fireDelay;
	public float unTime;
	public float time;
	private string word;

    // Use this for initialization
    void Start () {
		word = "virus";
		player = GameObject.FindWithTag ("Player");
		playerC = player.GetComponent <PlayerController> ();
		rotation = Quaternion.identity;
        rb = GetComponent<Rigidbody>();
        movement = new Vector3(0.0f, 0.0f, -2.5f);
        rb.velocity = movement;
        rb.angularVelocity = new Vector3(0, 3, 0);
        gameC = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ovum")
        {
			time = Time.time;
            Destroy(gameObject);
            gameC.GameOver(word);
			//sonido
        }

		if (other.tag == "Condon") 
		{
			Destroy (gameObject);
			Instantiate(soundCondom,rb.position, rotation);

		}

		if (other.tag == "Diafragma")
		{
			Destroy (gameObject);
			Instantiate(soundDiafragma,rb.position, rotation);
		}

		if (other.tag == "MagneticBeam2") 
		{
			Destroy (other.gameObject);
		}

		if (other.tag == "Player")
		{
			if (playerC.flag){
				playerC.FireDelay(fireDelay);
				playerC.Unable(unTime);
				playerC.flag = false;
			}
		}
    }
}
