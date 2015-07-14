#pragma strict
var anim : Animator;

function Start () {
	/*
	// this won't actually start him moving... and i don't know why...
	anim = GetComponent.<Animator>();
	anim.Play("elf arm work");
	*/
	
	anim = GetComponent.<Animator>();
	Debug.Log("anim = " + anim);
	//anim.SetFloat("Speed", 0.5);
	anim.Play("elf arm work");
	//animation.Play("elf arm work");    // old code, does not work anymore
}

function Update () {

}