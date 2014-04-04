var LookAtTarget:Transform;
var damp = 6.0;
var seedPrefab:Transform;
var savedTime=0;

function Update ()
	{
	if (LookAtTarget)
	{
		var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position);
		
		transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * damp);
		
		var seconds : float = Random.Range(0, 10);   // Integer variable of seconds
		var oddeven = (seconds % 2);
		
		if(seconds)
		{
		SeedDrop(seconds);
		}
		
		
	}
transform.LookAt(LookAtTarget);
}

function SeedDrop(seconds)

{
	if (seconds!=savedTime)
	{

	var seed = Instantiate(seedPrefab,transform.Find("Flower").transform.position, 
							Quaternion.identity);

		seed.rigidbody.AddForce(transform.forward * 5);
		savedTime=seconds;
			}
}