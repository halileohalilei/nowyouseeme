using UnityEngine;
using System.Collections;

public class SwoopControl : MonoBehaviour {

	private Animator anim;
	private bool InitializeFlip = true;

	void Start () 
	{
		anim = this.GetComponent<Animator> ();
	}

	public void SwoopAnim()
	{
		if (InitializeFlip == true) 
		{
			anim.SetTrigger ("SwoopOn");
			InitializeFlip = false;
			Debug.Log("Swoop Called");
		}
	}
}
