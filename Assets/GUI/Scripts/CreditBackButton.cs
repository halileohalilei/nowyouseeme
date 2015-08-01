using UnityEngine;
using System.Collections;

public class CreditBackButton : MonoBehaviour {

	private bool CreditBackFlip = false;
	public GameObject StarL;
	public GameObject StarR;
	
	// Animation Controller
	public GameObject AnimationControl;
	private GUIController AnimScript;
	
	public void Start()
	{
		AnimScript = AnimationControl.GetComponent<GUIController> ();
	}
	
	public void CreditBack()
	{
		if (CreditBackFlip == true) 
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
		CreditBackFlip = true;
		StarL.SetActive (true);
		StarR.SetActive (true);
	}
	
	public void StarsOff()
	{
		CreditBackFlip = false;
		StarL.SetActive (false);
		StarR.SetActive (false);
	}
}
