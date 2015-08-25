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

        public GameObject PlayScratchSound(Vector3 position)
        {
            return PlaySound(ScratchSoundCollection, position);
        }

        public GameObject PlayJesusAttackSound(Vector3 position)
        {
            return PlaySound(JesusAttackSoundCollection, position, 4);
        }

        public GameObject PlayPushedSound(Vector3 position)
        {
            return PlaySound(PushedSoundCollection, position, 4);
        }

        public GameObject PlayAcknowledgeSound(Vector3 position)
        {
            return PlaySound(AcknowledgeSoundCollection, position);
        }

        private GameObject PlaySound(SoundCollection collection, Vector3 position, float duration = 2)
        {

            GameObject oneShotAudioSource = Instantiate(OneShotAudioSource, position, Quaternion.identity) as GameObject;
            if (oneShotAudioSource != null)
            {
                collection.PlayRandomSound(oneShotAudioSource.GetComponent<AudioSource>());
                oneShotAudioSource.transform.parent = transform;
                Destroy(oneShotAudioSource, duration);
            }
            return oneShotAudioSource;
        }

    }
}