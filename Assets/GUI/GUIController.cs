using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	private Animator anim;
	public GameObject CoverHinge;

	void Start () 
	{
		anim = CoverHinge.GetComponent<Animator> ();
	}

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.O)) 
		{
			anim.SetTrigger("FrontOpen");
		}

		if (Input.GetKeyDown (KeyCode.C)) 
		{
			anim.SetTrigger("FrontClose");
		}
	}
}
