using UnityEngine;
using System.Collections;

public class QuitScript : MonoBehaviour {

	private bool QuitFlip = false;
	public GameObject StarL;
	public GameObject StarR;

	// Animation Controller
	public GameObject AnimationControl;
	private GUIController AnimScript;
	
	public void Start()
	{
		AnimScript = AnimationControl.GetComponent<GUIController> ();
	}

	public void Quit()
	{
		if (QuitFlip == true) 
		{
			if (Input.GetMouseButtonDown(0))
			{
				Invoke ("Quiting",3);
				AnimScript.CloseCard();
				Debug.Log("QUITING");
			}
		}
	}

	public void StarsOn()
	{
		QuitFlip = true;
		StarL.SetActive (true);
		StarR.SetActive (true);
	}

	public void StarsOff()
	{
		QuitFlip = false;
		StarL.SetActive (false);
		StarR.SetActive (false);
	}

	void Quiting()
	{
		Application.Quit();
		Debug.Log ("QUIT SUCCESSFUL");
	}
}
