using UnityEngine;
using System.Collections;

public class CreditScript : MonoBehaviour {

	private bool CreditFlip = false;
	public GameObject StarL;
	public GameObject StarR;
	
	// Animation Controller
	public GameObject AnimationControl;
	private GUIController AnimScript;
	
	public void Start()
	{
		AnimScript = AnimationControl.GetComponent<GUIController> ();
	}

	public void CreditActive()
	{
		if (CreditFlip == true) 
		{
			if (Input.GetMouseButtonDown(0))
			{
				Debug.Log("CREDITS ACTIVATED");
				AnimScript.CloseCard();
				AnimScript.CreditsActivate();
			}
		}
	}

	public void StarsOn()
	{
		CreditFlip = true;
		StarL.SetActive (true);
		StarR.SetActive (true);
	}

	public void StarsOff()
	{
		CreditFlip = false;
		StarL.SetActive (false);
		StarR.SetActive (false);
	}
}
