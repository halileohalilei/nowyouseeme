using UnityEngine;
using System.Collections;

public class StarSpinner : MonoBehaviour {

	public int rotationSpeed;

	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float x = 0.0f;
		float y = 0.0f;
		float z = 6.0f * rotationSpeed * Time.deltaTime;

		transform.Rotate (x, y, z);
	}
}
