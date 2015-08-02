using UnityEngine;
using System.Collections;

public class HighScoreBack : MonoBehaviour {

	private bool HighScoreBackFlip;
	public GameObject StarL;
	public GameObject StarR;
	
	// Animation Controller
	public GameObject AnimationControl;
	private GUIController AnimScript;
	
	public void Start()
	{
		AnimScript = AnimationControl.GetComponent<GUIController> ();
	}
	
	public void HighScoreBackButton()
	{
		if (HighScoreBackFlip) 
		{
			if (Input.GetMouseButtonDown(0))
			{
				Debug.Log("MAIN ACTIVATED");
				AnimScript.CloseCard();
				AnimScript.MainActivate();
			}
		}
	}

	public void StarsOn()
	{
		HighScoreBackFlip = true;
		StarL.SetActive (true);
		StarR.SetActive (true);
	}
	
	public void StarsOff()
	{
		HighScoreBackFlip = false;
		StarL.SetActive (false);
		StarR.SetActive (false);
	}
}
