using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	public GameObject sperm;
	private int spermCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	public GUIText spermCountText;
	public int score;
	private int sperms;
	public int Temp;
	public GameObject waves;
	private GUIText waveText;
	private Rigidbody waveRigid;
	private int number;
	private Vector3 beginning;
	public GameObject virus;

	//public GUIText restartText;
	//public GUIText gameOverText;
	public GameObject canvasOver;
	//private bool gameOver;
	//private bool restart;

	public Button pill;
	public Button shoot;
	public Button speed; 
	//private bool unlock;
	private bool unlock2;
	private bool unlock3;
	private bool canvasActive;
	public bool flagPanel;
	private bool StopThemBool;

	private OC1 ovum1; 
	private OC2 ovum2;
	private OC3 ovum3;
	public GameObject ovuum1;
	public GameObject ovuum2; 
	public GameObject ovuum3;

	private int identificator;
	public AudioClip backgroundSong;
	public AudioClip virusFault;
	public AudioClip spermFault;
	private AudioSource aud;
	private float timer;
	//private bool flag2;

	IEnumerator Start()
	{
		if (Screen.fullScreen)
			Screen.fullScreen = false; 
		Screen.SetResolution (500, 600, true);

		//flag2 = false;
		aud = GetComponent<AudioSource> ();
		ovum1 = ovuum1.GetComponent<OC1> (); 
		ovum2 = ovuum2.GetComponent<OC2> ();
		ovum3 = ovuum3.GetComponent<OC3> ();
		canvasActive = false;
		canvasOver.SetActive (false);
		waveRigid = waves.GetComponent<Rigidbody> ();
		waveText = waves.GetComponent<GUIText> ();
		beginning = new Vector3 (-0.2f, 0.5f, 0f);
		StartCoroutine (SpawnWaves ());

		//gameOver = false;
		//restart = false;
		//restartText.text = "";
		//gameOverText.text = "";

		score = 0;
		scoreText.text = "Puntos: 0";
		spermCountText.text = "Espermas: 10";
		spermCount = 10;
		sperms = spermCount;
		number = 1;
		//unlock = false;
		unlock2 = false;
		unlock3 = false;
		flagPanel = false;
		StopThemBool = false;
		
		yield return new WaitForSeconds (0.5f);
		ovum1.StartSound ();

	}


	void Update ()
	{
		if (canvasActive) 
		{
			if (identificator == 1)
			{
				if ((Input.GetKeyDown (KeyCode.R)) && (Time.realtimeSinceStartup > (timer + 7.4)))
				{
					Application.LoadLevel (Application.loadedLevel);
					canvasActive = false;
					Time.timeScale = 1;
					flagPanel = false;
					aud.clip = backgroundSong;
					aud.volume = 0.4f;
					aud.loop = true;
					aud.spatialBlend = 0.9f;
					aud.Play ();
					//flag2 = false;
				}
			}
			else if (identificator == 2)
			{
				if ((Input.GetKeyDown (KeyCode.R)) && (Time.realtimeSinceStartup > (timer + 7.8)))
				{
					Application.LoadLevel (Application.loadedLevel);
					canvasActive = false;
					Time.timeScale = 1;
					flagPanel = false;
					aud.clip = backgroundSong;
					aud.volume = 0.4f;
					aud.loop = true;
					aud.spatialBlend = 0.9f;
					aud.Play ();
					//flag2 = false;
				}
			}

		}
		/*
		if ((score >= 90) && !unlock) 
		{
			pill.interactable = true;
			unlock = true;
		}
		*/

		if ((score >= 120) && !unlock2) 
		{
			shoot.interactable = true;
			unlock2 = true;
		}

		if ((score >= 150) && !unlock3) 
		{
			speed.interactable = true;
			unlock3 = true;

		}

	}


	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);

		while (true) 
		{

			UpdateMoveTextWave(number);

			yield return new WaitForSeconds (3);

			UpdateMoveTextWave2();

			yield return new WaitForSeconds (1);
			for (int i=0; i < spermCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-4.2f, 4.2f), 2, 10);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (sperm, spawnPosition, spawnRotation);
				UpdateTextCount(-1);
				yield return new WaitForSeconds (spawnWait); 

				if ((StopThemBool) && (Random.Range (1.0f,5.0f) <= 3.0f))
				{
					ovum2.StopThem();
					StopThemBool = false;
				}

				if ((number >= 8) && (Random.Range(0,40) <= 2))
				{
					Vector3 spawnPosition1 = new Vector3(Random.Range(-4.2f, 4.2f), 2, 10);
					Quaternion spawnRotation1 = Quaternion.identity;
					Instantiate(virus, spawnPosition1, spawnRotation1);
					yield return new WaitForSeconds(spawnWait);
				}
			}

			number += 1; 
			spermCount += 5;
			UpdateTextCount(spermCount);

			if (Random.Range (1.0f,5.0f) <= 3.0f)
				StopThemBool = true;

			if (spawnWait > 0.2f)
				spawnWait -= 0.03f;

			yield return new WaitForSeconds (waveWait-3);

			if (Random.Range (1.0f,5.0f) <= 3.0f)
			{
				if (Random.Range (1.0f,4.0f) <= 2.0f)
				{
					ovum3.ThatsItSound();
				}
				else
				{
					ovum3.WellDoneSound();
				}
			}

			yield return new WaitForSeconds (3);


			/*
			if (gameOver)
			{
				//restartText.text = "Presiona 'R' para recomenzar!";
				restart = true;
				break;
			}
			*/
		};
		
	}
	
	public void UpdateText (int scoreValue)
	{
		score += scoreValue;
		scoreText.text = "Puntos: " + score.ToString();
	}

    void UpdateTextCount (int Quantity)
	{
		sperms += Quantity;
		spermCountText.text = "Espermas: " + sperms.ToString (); 
	}

	void UpdateMoveTextWave (int numb)
	{
		waveText.text = "Oleada " + numb.ToString ();
		waveRigid.velocity = new Vector3 (0.5f, 0.0f, 0.0f);
	}

	void UpdateMoveTextWave2()
	{
		waves.transform.position = beginning;
		waveRigid.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
	}

	
	public void GameOver (string word)
	{
		if (word == "sperm") 
		{
			identificator = 1;
			aud.clip = spermFault;
			aud.volume = 0.8f;
			aud.loop = false;
			aud.priority =  10;
			aud.spatialBlend = 0.0f;
			aud.Play ();
		} 
		else if (word == "virus") 
		{
			identificator = 2;
			aud.clip = virusFault;
			aud.volume = 0.8f;
			aud.loop = false;
			aud.priority = 10;
			aud.spatialBlend = 0.0f;
			aud.Play ();
		}

		canvasOver.SetActive(true);
		canvasActive = true;
		timer = Time.realtimeSinceStartup;
		Time.timeScale = 0; 
		flagPanel = true;
		//gameOver = true;
	}

	/*
	void Virus ()
	{
		aud.clip = virusFault;
		aud.Play ();
		/*
		while(Time.realtimeSinceStartup < (timer + 7.8))
		{
			yield return 0;
		};
		flag2 = true;

	}

	void Sperm ()
	{
		aud.clip = spermFault;
		aud.Play ();
		/*
		while(Time.realtimeSinceStartup < (timer + 7.4))
		{
			yield return 0;
		};
		flag2 = true;

	}
	*/



}
