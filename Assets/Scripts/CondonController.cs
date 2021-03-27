using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CondonController : MonoBehaviour {

    private Rigidbody rb;
    //private PlayerController playerC;
    public GameController gameC;

    //private Vector3 pos1;
    //private Vector3 pos2;
	//private Vector3 pos3;
    private float timer1;
    private float timer2; 

    private bool unlock;

    public Button botonC;

	private Quaternion rotation;

	public GameObject sound;
	/*
	private OC1 ovum1;
	private OC3 ovum3;
	public GameObject Ovuum1;
	public GameObject Ovuum3;
	*/
	public GameObject CanvasCondon;
	private int cont;


    // Use this for initialization
    void Start () {
		//ovum1 = Ovuum1.GetComponent<OC1> ();
		//ovum3 = Ovuum3.GetComponent<OC3> ();
		cont = 0;
		rotation = Quaternion.identity;
        rb = GetComponent<Rigidbody>();
        //playerC = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        //pos1 = new Vector3(-0.16f, 2.48f, 6);
        //pos2 = new Vector3(100, 100, 100);
		//pos3 = new Vector3 (0.0f, 2.1f, 7.0f);
        unlock = false;
    }

    // Update is called once per frame
    void Update ()
	{
	   if (rb.position.z < 10)
        {
            if (Time.time >= (timer1 + 10))
            {
				rb.velocity = new Vector3 (0.0f,0.0f,12.0f);
                StartCoroutine(Wait());
            }
         
        }
        if (gameC.score >= 30 && !unlock)
        {
            botonC.interactable = true;
            unlock = true;
        }

	}

	void FixedUpdate()
	{
		rb.position = new Vector3 (0.0f, 2.1f, Mathf.Clamp (rb.position.z,7.0f, 15.0f) );
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(20);
        botonC.interactable = true;
    }

    public void ButtonClick () 
	{
		rb.velocity = new Vector3 (0.0f, 0.0f, -12.0f);
		if (cont != 0) 
		{
			Instantiate(sound,rb.position, rotation);
		}
        botonC.interactable = false;
        timer1 = Time.time;
		if (cont == 0) 
		{
			CanvasCondon.SetActive (true);
			cont+=1;
		}
		/*
		if (Random.Range (1.0f, 4.0f) <= 2.0f) 
		{
			ovum1.CondomSound1();
		}
		else 
		{
			ovum3.CondomSound2();
		}
		*/

     }
    
}       


