using UnityEngine;

namespace Assets.Scripts
{
    public class GameStarter : MonoBehaviour
    {

        public float GameStartDelay;

        void OnTriggerEnter(Collider other)
        {
            if (other.transform.name.Equals("CardboardMain") ||
                other.transform.name.Equals("OVR"))
            {
                Invoke("StartGame", GameStartDelay);
            }
        }

        private void StartGame()
        {
            GameData.GetCurrentGameData().StartGame();
        }

    }
}
