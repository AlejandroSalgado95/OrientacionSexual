using UnityEngine;
using System.Collections;

public class CanDia : MonoBehaviour {

	public bool activeSound2;
	private float time;
	
	
	// Use this for initialization
	void Start () 
	{
		activeSound2 = true;
		StartCoroutine (Desactiva ());
	}
	
	IEnumerator Desactiva()
	{
		Time.timeScale = 0;
		time = Time.realtimeSinceStartup;
		while (Time.realtimeSinceStartup < (time + 9.0f)) 
		{
			yield return 0;
		};
		Time.timeScale = 1;
		activeSound2 = false;
		gameObject.SetActive (false);
		
	}
}
