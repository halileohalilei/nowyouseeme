using UnityEngine;

namespace Assets.Scripts
{
    public class TargetFactory : MonoBehaviour
    {
        [SerializeField] private float _spawnRate;
        private float _timeCounter;

        public GameObject Target;

        void Awake()
        {
            _timeCounter = 0f;
        }

        void Update()
        {
            _timeCounter += Time.deltaTime;
            if (_timeCounter/_spawnRate >= 1)
            {
                _timeCounter = _timeCounter % _spawnRate;

                Vector3 position = Random.onUnitSphere * 3;
                GameObject newTarget = Instantiate(Target, position, Quaternion.identity) as GameObject;
                if (newTarget != null) newTarget.transform.parent = transform;
            }
        }
    }
}
