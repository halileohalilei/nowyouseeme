#pragma strict
var rb : Rigidbody;
var force : float = 10;

function Start () {
	rb = GetComponent.<Rigidbody>();
	transform.rotation = Random.rotation;
}

function Update () {
	rb.AddRelativeForce(transform.forward * force);
}

function OnCollisionEnter(collision: Collision) {
	Debug.Log("gift collides");
	transform.rotation = Random.rotation;
}