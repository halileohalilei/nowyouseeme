using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class ChristmasCardUI : MonoBehaviour 
{
	public GameObject CoverHinge;
	private Animator anim;
	
	public GameObject OVRCamera;
	public GameObject AlpCamera;
	private Animator CameraAnim;
	private Animator CameraAnimAlp;
	
	public GameObject MainTitle;
	public GameObject Credits;
	public GameObject CreditsButton;
	public GameObject Back;
    
    [SerializeField]
    private GameObject _characters;

    void Start () 
	{
		Invoke ("GuiInitialize", 5f);
		anim = CoverHinge.GetComponent<Animator> ();
		CameraAnim = OVRCamera.GetComponent<Animator> ();
		CameraAnimAlp = AlpCamera.GetComponent<Animator> ();
	}
	
	void Update () 
	{
		// CREDITS CLICK
		if (Input.GetKeyDown(KeyCode.A))
		{
			CreditsActive();
		}
		
		// BACK CLICK
		if (Input.GetKeyDown(KeyCode.S))
		{
			BackActive();
		}
		
		if (Input.GetKeyDown(KeyCode.D))
		{
			GameBegins();
			Debug.Log("GAME CALLED");	
		}
		
		// QUIT WITH ESCAPE
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	
	// INITIALIZATION
	void GuiInitialize()
	{
		anim.SetTrigger("OpenCard");
	}
	
	// GAME BEGINS
	
	public void GameBegins()
	{
		Invoke("DisableUI", 2f);

		if (OVRCamera.activeInHierarchy == false)
		{
			CameraAnimAlp.SetTrigger("OVRSwoop");
		}
		else if (OVRCamera.activeInHierarchy == true)
		{
			CameraAnim.SetTrigger ("OVRSwoop");
		}
		Debug.Log("Im Called");

        Invoke("PrepareScene", 6);
	}

    public void PrepareScene()
    {
        _characters.SetActive(true);
        GameData.GetCurrentGameData().StartGame();
    }
	
	void DisableUI()
	{
		gameObject.SetActive(false);
	}
	
	// CREDITS
	public void CreditsActive()
	{
		anim.SetTrigger("CloseCard");
		Invoke("CreditsOn", 3.25f);
	}
	
	public void CreditsOn()
	{
		MainTitle.SetActive(false);
		Credits.SetActive(true);
		CreditsButton.SetActive(false);
		Back.SetActive(true);
		anim.SetTrigger("OpenCard");
	}
	
	// CREDITS BACK
	public void BackActive()
	{
		anim.SetTrigger("CloseCard");
		Invoke("BackOn",3.25f);
		Debug.Log ("Closing Card");
	}
	
	public void BackOn()
	{
		MainTitle.SetActive(true);
		Credits.SetActive(false);
		CreditsButton.SetActive(true);
		Back.SetActive(false);
		anim.SetTrigger("OpenCard");
	}
	
	// QUIT
	public void QuitActive()
	{
		anim.SetTrigger("CloseCard");
		Invoke("QuitOn", 3.5f);
	}
	
	void QuitOn()
	{
		Application.Quit();
	}
}
