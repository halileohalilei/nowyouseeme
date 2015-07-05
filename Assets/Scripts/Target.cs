using System.Reflection;
using UnityEngine;

namespace Assets.Scripts
{
    public class Target : MonoBehaviour
    {
        
        private float _destroyTime;
        [SerializeField] private float _lifeSpan;
        void Start()
        {
            _destroyTime = Time.time + _lifeSpan;
        }

        void Update()
        {
            if (Time.time >= _destroyTime)
            {
                Destroy(gameObject);
            }
        }

    }
}
