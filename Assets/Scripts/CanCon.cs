using UnityEngine;
using System.Collections;

public class CanCon : MonoBehaviour {

	public bool activeSound;
	private float time;


	// Use this for initialization
	void Start () 
	{
		activeSound = true;
		StartCoroutine (Desactiva ());
	}

	IEnumerator Desactiva()
	{
		Time.timeScale = 0;
		time = Time.realtimeSinceStartup;
		while (Time.realtimeSinceStartup < (time + 12.0f)) 
		{
			yield return 0;
		};
		Time.timeScale = 1;
		activeSound = false;
		gameObject.SetActive (false);

	}


}
