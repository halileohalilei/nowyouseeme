using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{ 
    public class SoundManager : MonoBehaviour
    {
        public SoundCollection AcknowledgeSoundCollection;
        public SoundCollection JesusAttackSoundCollection;
        public SoundCollection PushedSoundCollection;
        public SoundCollection RandomAttackSoundCollection;
        public SoundCollection RandomIdleSoundCollection;
        public SoundCollection ScratchSoundCollection;

        [Space(15)]public GameObject OneShotAudioSource;

        private static SoundManager _sharedManager;

        void Start()
        {
            _sharedManager = this;
        }

        public static SoundManager GetSharedManager()
        {
            return _sharedManager;
        }

        public void PlayScratchSound(Vector3 position)
        {
            PlaySound(ScratchSoundCollection, position);
        }

        public void PlayJesusAttackSound(Vector3 position)
        {
            PlaySound(JesusAttackSoundCollection, position, 4);
        }

        private void PlaySound(SoundCollection collection, Vector3 position, float duration = 2)
        {

            GameObject oneShotAudioSource = Instantiate(OneShotAudioSource, position, Quaternion.identity) as GameObject;
            if (oneShotAudioSource != null)
            {
                collection.PlayRandomSound(oneShotAudioSource.GetComponent<AudioSource>());
                oneShotAudioSource.transform.parent = transform;
                Destroy(oneShotAudioSource, duration);
            }
        }
    }
}