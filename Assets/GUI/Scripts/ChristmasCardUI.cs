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
	
	public GameObject Instructions1;
	public GameObject Instructions2;
	public GameObject Instructions3;
	public GameObject Instructions4;
	public GameObject Credits;
	public GameObject CreditsButton;
	public GameObject Back;
    
    [SerializeField]
    private GameObject _characters;
    [SerializeField]
    private GameObject _gui;

    void Start () 
	{
		Invoke ("GuiInitialize", 5f);
		anim = CoverHinge.GetComponent<Animator> ();
		CameraAnim = OVRCamera.GetComponent<Animator> ();
		CameraAnimAlp = AlpCamera.GetComponent<Animator> ();
	}
	
	void Update () 
	{
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
        _gui.SetActive(true);
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
		//MainTitle1.SetActive(false);
		//MainTitle2.SetActive(false);
		//MainTitle3.SetActive(false);
		//MainTitle4.SetActive(false);
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
		//MainTitle1.SetActive(true);
		//MainTitle2.SetActive(true);
		//MainTitle3.SetActive(true);
		//MainTitle4.SetActive(true);
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
