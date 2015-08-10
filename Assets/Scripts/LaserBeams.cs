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

        void Start ()
        {
            Transform tmp = transform.parent.parent.GetChild(2);
            _targets = new ArrayList();
            for (int i = 0; i < tmp.childCount; i++)
            {
                _targets.Add(tmp.GetChild(i));
            }
            PickNewTarget();
        }
	
        void Update ()
        {
            if (Quaternion.Angle(transform.rotation, _targetRotation) < 0.1f)
            {
                PickNewTarget();
                _speed += _incrementalSpeed;
            }
            else
            {
                float angle = Quaternion.Angle(transform.rotation, _targetRotation);
                float timeToComplete = angle / _speed;
                float donePercentage = Mathf.Min(1F, Time.deltaTime / timeToComplete);

                transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, donePercentage);
            }

            /*RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
	    if (Physics.Raycast(transform.position, fwd, out hit, 60))
	    {
	        GameObject hitObject = hit.collider.gameObject;
	        Elf hitObjectTarget = hitObject.GetComponent<Elf>();
	        if (hitObjectTarget != null)
	        {
                Debug.Log(hit.transform.name);
                Debug.DrawRay(transform.position, hit.transform.position);
	            hitObjectTarget.BurnToBlack();
	        }
	    }*/
        }

        private void PickNewTarget()
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
