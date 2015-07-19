using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private GameObject _lastTarget;
        void Start () {
	
        }
	
        void Update ()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            if (Physics.Raycast(transform.position, fwd, out hit, 30))
            {
                GameObject hitObject = hit.transform.gameObject;
                Target target = hitObject.GetComponent<Target>();
                String targetType = target.GetTargetType();
                if (targetType == "Elf")
                {
                    if (_lastTarget == null)
                    {
                        _lastTarget = hitObject;
                        Debug.Log("New elf targeted!");
                    }
                    else
                    {
                        Debug.Log("Looking at the same elf!");
                    }
                }
                else
                {
                    if (_lastTarget != null)
                    {
                        _lastTarget = null;
                        Debug.Log("Looked away!");
                    }
                    else
                    {
                        Debug.Log("Still looking somewhere else!");
                    }
                }
            }
        }
    }
}
