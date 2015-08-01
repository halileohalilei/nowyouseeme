using UnityEngine;
using System.Collections;

public class HighScoreScript : MonoBehaviour 
{
	private bool HighScoreScriptFlip = false;
	public GameObject StarL;
	public GameObject StarR;

	// Animation Controller
	public GameObject AnimationControl;
	private GUIController AnimScript;
	
	public void Start()
	{
		AnimScript = AnimationControl.GetComponent<GUIController> ();
	}

	public void HighScoreActive()
	{
		if (HighScoreScriptFlip == true) 
		{
			if (Input.GetMouseButtonDown(0))
			{
				Debug.Log ("HIGHSCORE ACTIVATED");
				AnimScript.CloseCard();
				AnimScript.HighScoreActivate();
			}
		}
	}

	public void StarsOn()
	{
		HighScoreScriptFlip = true;
		StarL.SetActive (true);
		StarR.SetActive (true);
	}

	public void StarsOff()
	{
		HighScoreScriptFlip = false;
		StarL.SetActive (false);
		StarR.SetActive (false);
	}
}
