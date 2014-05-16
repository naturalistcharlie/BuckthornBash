#pragma strict
public static var winddirection: Vector3 = new Vector3(1,0,0); 


function Start () {

}

function Update () {

}

function FixedUpdate () {
rigidbody.AddForce(winddirection);
}
