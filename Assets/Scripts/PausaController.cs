using UnityEngine;
using System.Collections;

public class PausaController : MonoBehaviour {

    float originalTime;
	private GameController gameC;


    public GameObject panel;
	public GameObject panelCon;
	public GameObject panelDia;
	private CanCon canvasCon;
	private CanDia canvasDia;
	// Use this for initialization
	void Start () 
	{
		canvasDia = panelDia.GetComponent<CanDia> ();
		canvasCon = panelCon.GetComponent<CanCon> ();
		gameC = GameObject.FindWithTag ("GameController").GetComponent <GameController> (); 
        panel.SetActive(false);
        originalTime = Time.timeScale;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if  ((!gameC.flagPanel) && (!canvasCon.activeSound) && (!canvasDia.activeSound2))
		{
	        if (Input.GetKeyDown(KeyCode.P))
			{
	            
	            if (Time.timeScale == 0)
	            {
	                Time.timeScale = originalTime;
	                panel.SetActive(false);
	            }

	                
	            else
	            {
	                Time.timeScale = 0;
	                panel.SetActive(true);
	            }
			}
	                
        }
    }
}
