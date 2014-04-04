var LookAtTarget:Transform;
var damp = 6.0;

function Update ()
	{
	if (LookAtTarget)
	{
		var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * damp);
	}
transform.LookAt(LookAtTarget);
}