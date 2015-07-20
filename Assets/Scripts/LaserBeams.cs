using UnityEngine;
using System.Collections;

public class LaserBeams : MonoBehaviour {

	public Transform[] targets;
	public Transform currentTarget;
	public Transform nextTarget;
	public Quaternion dir1;
	public Quaternion dir2;
	public float startTime = 0.0f;

	// Use this for initialization
	void Start () {
		currentTarget = targets[Random.Range(0,targets.Length)];
		nextTarget = targets[Random.Range(0,targets.Length)];
		dir1 = Quaternion.LookRotation(currentTarget.transform.position - transform.position);
		dir2 = Quaternion.LookRotation(nextTarget.transform.position - transform.position);
		transform.LookAt(currentTarget);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation == dir2) {
			startTime = Time.time;
			dir1 = dir2;
			nextTarget = targets[Random.Range(0,targets.Length)];
			dir2 = Quaternion.LookRotation(nextTarget.transform.position - transform.position);
		} else {
		transform.rotation = Quaternion.Slerp(dir1, dir2, (Time.time - startTime));
		}
	}
}
