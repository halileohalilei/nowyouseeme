using UnityEngine;
using System.Collections;

public class StartButtonScript : MonoBehaviour {

	private bool GameOnFlip = false;
	public GameObject StarL;
	public GameObject StarR;
	public GameObject Environment;
	public GameObject Characters;
	public GameObject ParticleSystemSnow;

	// Camera Animation Controller
	public GameObject Camera;
	private SwoopControl SwoopAnim;

	// Animation Controller
	public GameObject AnimationControl;
	private GUIController AnimScript;

	// Deactive GUI Raycasting
	public GameObject RayCastingObject;
	private GUIRayCasting RayScript;

	public void Start()
	{
		AnimScript = AnimationControl.GetComponent<GUIController> ();
	}

	// !!CODE BLOCK TO START THE GAME!!

	public void GameOn()
	{
		if (GameOnFlip == true) 
		{
			if (Input.GetMouseButtonDown(0))
			{
				Debug.Log("THE GAME BEGINS");
				AnimScript.CloseCard();
				Environment.SetActive (true);
				Characters.SetActive (true);
				Invoke ("DelayedItems",1.5f);
			}
		}
	}

	void DelayedItems()
	{
		SwoopControl SwoopAnim = Camera.GetComponent<SwoopControl>();
		SwoopAnim.SwoopAnim();
		ParticleSystemSnow.SetActive (false);
		GUIRayCasting RayScript = RayCastingObject.GetComponent<GUIRayCasting> ();
		RayScript.SetRay ();
	}

	public void StarsOn()
	{
		GameOnFlip = true;
		StarL.SetActive (true);
		StarR.SetActive (true);
	}

	public void StarsOff()
	{
		GameOnFlip = false;
		StarL.SetActive (false);
		StarR.SetActive (false);
	}
}
