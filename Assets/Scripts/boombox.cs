using UnityEngine;
using System.Collections;

public class boombox : MonoBehaviour {

	private Rigidbody _rigidbody;
	[SerializeField] private float _force;

	// Use this for initialization
	void Start () {
		_rigidbody = gameObject.GetComponent<Rigidbody>();
		transform.rotation = Random.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		_rigidbody.AddRelativeForce(transform.forward * _force);
	}

	void OnCollisionEnter(Collision collision)
	{
		transform.rotation = Random.rotation;
	}
}
