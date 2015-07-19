using UnityEngine;
using System.Collections;

public class ElfBlood : MonoBehaviour {

	public GameObject[] candyArray;
	int numCandy = 10;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numCandy; i++) {
			int rand = Random.Range(0,candyArray.Length);
			Vector3 loc = Random.insideUnitSphere * 10;
			Quaternion rot = Random.rotation;
			Instantiate(candyArray[rand], loc, rot);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
