using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public interface ILaserDelegate
    {
        void OnElfDestroyed(Transform elf);
    }

    public class LaserBeams : MonoBehaviour, ILaserDelegate {

        private ArrayList _targets;
        private Quaternion _targetRotation;

        [SerializeField] private float _speed;
        [SerializeField] private float _incrementalSpeed;

        private bool _isVisible;
        private bool IsVisible
        {
            set
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                _isVisible = value;
            }
            get { return _isVisible; }
        }
        void Start ()
        {
            Transform tmp = transform.parent.parent.parent.GetChild(1); //bad programming
            _targets = new ArrayList();
            for (int i = 0; i < tmp.childCount; i++)
            {
                _targets.Add(tmp.GetChild(i));
            }
            IsVisible = true;
            PickNewTarget();
        }
	
        void Update ()
        {
            if (IsVisible)
            {
                if (Quaternion.Angle(transform.rotation, _targetRotation) < 0.1f)
                {
                    PickNewTarget();
                    _speed += _incrementalSpeed;
                }
                else
                {
                    float angle = Quaternion.Angle(transform.rotation, _targetRotation);
                    float timeToComplete = angle/_speed;
                    float donePercentage = Mathf.Min(1F, Time.deltaTime/timeToComplete);

                    transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, donePercentage);
                }
            }
        }

        public void PickNewTarget()
        {
            if (_targets.Count > 0)
            {
                int newTargetIndex = Random.Range(0, _targets.Count);
                _targetRotation = Quaternion.LookRotation(((Transform) _targets[newTargetIndex]).position - transform.position);
            }
        }

        public void OnElfDestroyed(Transform elf)
        {
            _targets.Remove(elf);
        }
        
    }
}
