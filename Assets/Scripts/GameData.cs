using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
	public class GameData : MonoBehaviour {

		private int _currentLevel;
		private int _currentPresentCount;
	    private int _currentRequiredPresentCount;
		private float _givenTimeOnThisLevel;
	    private float _levelStartTime;

		[SerializeField] private TextMesh YearGUI;
		[SerializeField] private TextMesh PresentCountGUI;

	    public bool IsJesusActive;
	    public bool IsGameStarted;

		private static GameData _currentGameData;

		void Start () {
			_currentGameData = this;
		    _currentRequiredPresentCount = 60;
		    _givenTimeOnThisLevel = -1;
		    //TODO: read all level specs and initialize game data accordingly
		}

	    void FixedUpdate()
	    {
	        if (_givenTimeOnThisLevel > 0)
	        {
	            if (Time.time - _levelStartTime > _givenTimeOnThisLevel)
	            {
	                OnLevelFailed();
	                _givenTimeOnThisLevel = -1;
	            }
	        }
	    }

		public void ResetGameData()
		{
			_currentLevel = 0;
			_currentPresentCount = 0;
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
		    _givenTimeOnThisLevel = 60;
		    _levelStartTime = Time.time;
			ResetGameData();
		}

		private void OnLevelCompleted()
		{
			//TODO: reset the scene
            Debug.Log("LEVEL COMPLETE");
		}

	    private void OnLevelFailed()
	    {
	        Debug.Log("LEVEL FAILED");
	    }
	}
}