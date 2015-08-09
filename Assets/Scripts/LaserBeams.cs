using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class LaserBeams : MonoBehaviour {

	private ArrayList _targets;
    private Quaternion _targetRotation;

    [SerializeField] private float _speed;

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
        if (Quaternion.Angle(transform.rotation, _targetRotation) < 0.00001f)
	    {
	        PickNewTarget();
//	        _speed += 5f;
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

    void PickNewTarget()
    {
        int newTargetIndex = Random.Range(0, _targets.Count);
        _targetRotation = Quaternion.LookRotation(((Transform) _targets[newTargetIndex]).position - transform.position);
    }

//    void OnTriggerEnter(Collider other)
//    {
//        Debug.Log("THAT'S MY TRIGGER");
//    }
}
