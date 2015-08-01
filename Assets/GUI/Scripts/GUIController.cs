using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	private Animator anim;
	public GameObject CoverHinge;
	private bool InitializeFlip = true;

	// GUI
	public GameObject MainRight;
	public GameObject MainLeft;
	public GameObject HighScoreLeftSide;
	public GameObject HighScoreRightSide;
	public GameObject CreditsLeftSide;
	public GameObject CreditsRightSide;

	void Start () 
	{
		anim = CoverHinge.GetComponent<Animator> ();
	}

	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (InitializeFlip == true)
			{
				anim.SetTrigger("FrontOpen");
				InitializeFlip = false;
			}
		}

	}
	// CLOSE CARD
	public void CloseCard()
	{
		Invoke ("ClosingCard", 1f);
	}

	void ClosingCard()
	{
		anim.SetTrigger("FrontClose");
	}

	// ACTIVATED CREDITS
	public void CreditsActivate()
	{
		Invoke ("CreditsActivated", 2.5f);
	}

	void CreditsActivated()
	{
		anim.SetTrigger("FrontOpen");
		CreditsLeftSide.SetActive (true);
		CreditsRightSide.SetActive (true);

		MainLeft.SetActive (false);
		MainRight.SetActive (false);
	}

	// ACTIVATED HIGHSCORES
	public void HighScoreActivate()
	{
		Invoke ("HighScoreActivated", 2.5f);
		Invoke ("HighScoreTable", 3.25f);
	}

	void HighScoreActivated()
	{
		anim.SetTrigger("FrontOpen");
		HighScoreRightSide.SetActive (true);

		MainLeft.SetActive (false);
		MainRight.SetActive (false);
	}

	void HighScoreTable()
	{
		HighScoreLeftSide.SetActive (true);		// HIGHER DELAY BECAUSE TEXTMESH IS VISIBLE THROUGH OBJECTS
	}

	// ACTIVATED RETURN TO MAIN MENU
	public void MainActivate()
	{
		Invoke ("MainActivated", 1.65f);
	}

	void MainActivated()
	{
		anim.SetTrigger("FrontOpen");
		MainLeft.SetActive (true);
		MainRight.SetActive (true);

		CreditsLeftSide.SetActive (false);
		CreditsRightSide.SetActive (false);
		HighScoreLeftSide.SetActive (false);
		HighScoreRightSide.SetActive (false);
	}
}
