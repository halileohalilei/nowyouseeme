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
		}

		private void OnLevelCompleted()
		{
			//TODO: reset the scene
		    IsGameStarted = false;
            Debug.Log("LEVEL COMPLETE");
		}

	    private void OnLevelFailed()
        {
		    IsGameStarted = false;
            _givenTimeOnThisLevel = -1;
            Debug.Log("LEVEL FAILED");
	    }
	}
}