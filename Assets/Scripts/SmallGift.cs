using UnityEngine;
using System.Collections;

public class smallgift : MonoBehaviour {

	private Rigidbody rb;
	//private Collider coll;

	// Use this for initialization
	void Start () {
		rb = transform.GetComponent<Rigidbody>();
		Invoke("DeactivateRB", 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DeactivateRB () {
		rb.constraints = RigidbodyConstraints.FreezeAll;
	}
}
