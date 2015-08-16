using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
	public class GameData : MonoBehaviour {

		private int _currentLevel;
		private int _currentPresentCount;
		private float _remainingTimeOnThisLevel;

		[SerializeField] private TextMesh YearGUI;
		[SerializeField] private TextMesh PresentCountGUI;

		private static GameData _currentGameData;

		void Start () {
			_currentGameData = this;
			//TODO: read all level specs and initialize game data accordingly
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

		public void OnGameStart()
		{
			ResetGameData();
		}

		private void OnLevelCompleted()
		{
			//TODO: reset the scene
		}
	}
}