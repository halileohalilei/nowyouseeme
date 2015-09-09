using System;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
	public class GameData : MonoBehaviour {

        private int _remainingElfCount;

        private int _currentLevel;
		private int _currentPresentCount;
	    private int _currentRequiredPresentCount;
		private float _givenTimeOnThisLevel;
	    private float _levelStartTime;

        [SerializeField] private TextMesh YearGUI;
        [SerializeField] private TextMesh PresentCountGUI;
        [SerializeField] private TextMesh RemainingTimeGUI;

        public bool IsJesusActive;
	    public bool IsGameStarted;

		private static GameData _currentGameData;
		
		public GameObject Boombox;
		
		//ENDING UI
		public GameObject WinLoseUI;
		public GameObject Win;
		public GameObject Lose;
		private Animator anim;
		
		//GUI
		public GameObject GUIBoard;


		void Start () {
			_currentGameData = this;
		    _currentRequiredPresentCount = 60;
            _givenTimeOnThisLevel = 60;
		    //TODO: read all level specs and initialize game data accordingly
		}

	    void FixedUpdate()
	    {
            if (IsGameStarted)
	        {
	            if (Time.time - _levelStartTime > _givenTimeOnThisLevel)
	            {
	                OnLevelFailed();
	            }
	            UpdateRemainingTimeGUI();


	        }
	    }

	    private void UpdateRemainingTimeGUI()
	    {
	        float remainingTime = _givenTimeOnThisLevel - (Time.time - _levelStartTime);
            TimeSpan timeSpan = TimeSpan.FromSeconds(remainingTime);
	        RemainingTimeGUI.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }

	    public void ResetGameData()
		{
			_currentLevel = 0;
			_currentPresentCount = 0;
            _remainingElfCount = GameObject.Find("Elves").transform.childCount;
            UpdateYearGUI ();
		}

		public void IncrementPresentCount()
		{
			_currentPresentCount++;
		    if (_currentPresentCount >= _currentRequiredPresentCount)
		    {
		        OnLevelCompleted();
		    }
			//TODO: if player reached the required amount of presents, complete level
			UpdatePresentCountGUI();
		}

	    public void DecrementRemainingElfCount()
	    {
	        if (IsGameStarted)
	        {
	            _remainingElfCount--;
	            Debug.Log("Remaining Elf Count: " + _remainingElfCount);
	            if (_remainingElfCount <= 0)
	            {
	                OnLevelFailed();
	            }
	        }
	    }

		public void IncrementLevel()
		{
			_currentLevel++;
			_currentPresentCount = 0;
			UpdateYearGUI();
		}

		private void UpdateYearGUI()
		{
			YearGUI.text = string.Format ("{0,2}", _currentLevel+1);
			UpdatePresentCountGUI();
		}

		private void UpdatePresentCountGUI()
		{
			PresentCountGUI.text = string.Format ("{0}", _currentPresentCount);
		}

		public static GameData GetCurrentGameData()
		{
			return _currentGameData;
		}

		public void StartGame()
		{
		    IsGameStarted = true;
		    _levelStartTime = Time.time;
			ResetGameData();
			GUIBoard.SetActive(true);
			Boombox.SetActive(true);

		}

		private void OnLevelCompleted()
		{
		    IsGameStarted = false;
			anim = WinLoseUI.GetComponent<Animator> ();
			anim.SetTrigger ("Go");
			Win.SetActive (true);
			Lose.SetActive (false);
            Debug.Log("LEVEL COMPLETE");
			GetComponent<AudioSource>().Play();

			Invoke("RestartLevel",10);
		}

	    private void OnLevelFailed()
        {
		    IsGameStarted = false;
			anim = WinLoseUI.GetComponent<Animator> ();
			anim.SetTrigger ("Go");
			Win.SetActive (false);
			Lose.SetActive (true);
            Debug.Log("LEVEL FAILED");
            GetComponent<AudioSource>().Play();
            Invoke("RestartLevel",10);
	    }
	    
	    void RestartLevel()
	    {
	    	Application.LoadLevel(Application.loadedLevel);	
	    }
	}
}