using UnityEngine;
using System.Collections;

public class ElfBlood : MonoBehaviour {

	public GameObject[] candyArray;
	int numCandy = 20;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numCandy; i++) {
			int rand = Random.Range(0,candyArray.Length);
			Vector3 loc = Random.insideUnitSphere * 1;
			Quaternion rot = Random.rotation;
			GameObject instance = Instantiate(candyArray[rand], loc, rot) as GameObject;
			Rigidbody rb = instance.GetComponent<Rigidbody>();
			rb.AddExplosionForce(10, transform.position, 5, 3.0F);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
