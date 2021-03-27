using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DiafragmaController : MonoBehaviour {

    private Rigidbody rb;
    //private PlayerController playerC;
    //private Vector3 pos1;
    //private Vector3 pos2;
    private float timer;
    public Button botonC;
    private GameController gameC;
	private bool flag;

    private bool unlock;

    private int hits;

	private OC1 ovum1;
	private OC3 ovum3;
	public GameObject Ovuum1;
	public GameObject Ovuum3;

	public GameObject canvasDiafragma;
	private int cont;


    // Use this for initialization
    void Start()
    {
		cont = 0;
		ovum1 = Ovuum1.GetComponent<OC1> ();
		ovum3 = Ovuum3.GetComponent<OC3> ();
        rb = GetComponent<Rigidbody>();
		gameC = GameObject.FindWithTag ("GameController").GetComponent<GameController> ();
        //playerC = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        //pos1 = new Vector3(0.0f, 1.9f, -4.2f);
        //pos2 = new Vector3(0.0f, 1.9f, -10.0f);
        hits = 10;
		flag = true;
		timer = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sperm")
        {
            hits--;
        }
		if (other.tag == "Virus") 
		{
			hits--;
		}
    }
        // Update is called once per frame
    void Update()
    {
        if ((flag) && (Time.time >= timer + 50) && (gameC.score >= 60))
        {
            botonC.interactable = true;
			flag = false;
        }

        if (hits <= 0)
        {
            rb.velocity = new Vector3 (0,0,-10);
            hits = 15;
			flag = true;
        }
		/*
       if (gameC.score >= 5 && !unlock)
        {
            botonC.interactable = true;
            unlock = true;
        }
        */
    }

	void FixedUpdate()
	{
		rb.position = new Vector3 (0.0f, 1.9f, Mathf.Clamp (rb.position.z,-10.0f, -4.2f) );
	}

    public void ButtonClick()
    {
		rb.velocity = new Vector3 (0,0,10);
        botonC.interactable = false;
        timer = Time.time;

		if (cont != 0) 
		{
			if (Random.Range (1.0f, 4.0f) <= 2.0f)
			{
				ovum1.DiafragmaSound1 ();
			}
			else
			{
				ovum3.DiafragmaSound2 ();
			}
		}
		if (cont == 0) 
		{
			canvasDiafragma.SetActive (true);
			cont+=1;
		}


    }
}
