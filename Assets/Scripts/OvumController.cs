using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OvumController : MonoBehaviour {

	private Collider col;
	public Button botonC;
	private float timer;
	// Use this for initialization
	void Start () {
		col = GetComponent<CapsuleCollider> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time >= (timer + 11)) {
			col.enabled = true;
			StartCoroutine(Wait());
		}
	
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(5);
		botonC.interactable = true;
	}


	public void ButtonClick()
	{
		botonC.interactable = false;
		col.enabled = false;
		timer = Time.time;
	}
}
