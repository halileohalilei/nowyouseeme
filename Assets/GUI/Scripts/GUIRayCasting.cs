using UnityEngine;
using System.Collections;

public class GUIRayCasting : MonoBehaviour {

	// RayCasting
	public bool GUIRay;

	// The Buttons
	public GameObject StartButton;
	private StartButtonScript StartScript;

	public GameObject HighScoreButton;
	private HighScoreScript ScoreScript;

	public GameObject CreditsButton;
	private CreditScript CredScript;

	public GameObject QuitButton;
	private QuitScript QtScript;

	public GameObject HSBackButton;
	private HighScoreBack HSBack;

	public GameObject CBackButton;
	private CreditBackButton CBScript;

	// Animation Controller
	public GameObject AnimationControl;
	private GUIController AnimScript;

	void Start () 
	{
		StartScript = StartButton.GetComponent<StartButtonScript> ();
		ScoreScript = HighScoreButton.GetComponent<HighScoreScript> ();
		CredScript = CreditsButton.GetComponent<CreditScript> ();
		QtScript = QuitButton.GetComponent<QuitScript> ();
		AnimScript = AnimationControl.GetComponent<GUIController> ();
		CBScript = CBackButton.GetComponent<CreditBackButton> ();
		HSBack = HSBackButton.GetComponent<HighScoreBack> ();
	}

	public void SetRay()
	{
		GUIRay = false;
	}

	void Update () 
	{
		if (GUIRay == true) 
		{
			Ray GRay = new Ray (transform.position,transform.forward);
			RaycastHit hit;

			if (Physics.Raycast(GRay, out hit, 100))
		   	{
				Debug.DrawRay(transform.position, transform.forward, Color.green, 1);

				if (hit.collider.CompareTag("Start"))
				{
					StartScript.GameOn();				// CODE TO CALL GAME STARTING SCRIPT
					StartScript.StarsOn();

					// Other Buttons Off
					ScoreScript.StarsOff();
					CredScript.StarsOff();
					QtScript.StarsOff();
				}

				if (hit.collider.CompareTag("HighScore"))
				{
					ScoreScript.HighScoreActive();		// CODE TO CALL HIGHSCORE
					ScoreScript.StarsOn();

					// Other Buttons Off
					StartScript.StarsOff();
					CredScript.StarsOff();
					QtScript.StarsOff();
					HSBack.StarsOff();
				}

				if (hit.collider.CompareTag("Credits"))
				{
					CredScript.CreditActive();			// CODE TO CALL CREDITS
					CredScript.StarsOn();

					// Other Buttons Off
					ScoreScript.StarsOff();
					StartScript.StarsOff();
					QtScript.StarsOff();
					CBScript.StarsOff();
				}

				if (hit.collider.CompareTag("Quit"))
				{
					QtScript.StarsOn();
					QtScript.Quit();				// CODE TO QUIT

					// Other Buttons Off
					ScoreScript.StarsOff();
					CredScript.StarsOff();
					StartScript.StarsOff();
				}

				if (hit.collider.CompareTag("HighScoreBack"))
				{
					HSBack.StarsOn();
					HSBack.HighScoreBackButton();

					CBScript.StarsOff();
				}

				if (hit.collider.CompareTag("CreditsBack"))
				{
					CBScript.StarsOn();
					CBScript.CreditBack();

					HSBack.StarsOff();
				}
			}
		}
	}
}
