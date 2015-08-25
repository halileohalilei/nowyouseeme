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
	public GameObject Instructions5;
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
			Debug.Log("ALPVR CALLED");
		}
		else if (OVRCamera.activeInHierarchy == true)
		{
			CameraAnim.SetTrigger ("RealOVRSwoop");
			Debug.Log("OVR CALLED");
		}

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
		Instructions1.SetActive(false);
		Instructions2.SetActive(false);
		Instructions3.SetActive(false);
		Instructions4.SetActive(false);
		Instructions5.SetActive(false);
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
		Instructions1.SetActive(true);
		Instructions2.SetActive(true);
		Instructions3.SetActive(true);
		Instructions4.SetActive(true);
		Instructions5.SetActive(true);
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
