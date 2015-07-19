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
                Elf elf = hitObject.GetComponent<Elf>();
                if (elf != null)
                {
                    
                }
            }
        }
    }
}
