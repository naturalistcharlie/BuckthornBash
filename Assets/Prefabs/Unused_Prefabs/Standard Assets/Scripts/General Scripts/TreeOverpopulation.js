var lifeTime = 2.0;
var newtreePrefab: Transform;

function Awake () {
	
	
	var newtree = Instantiate(newtreePrefab ,transform.Find("Mapleseed").transform.position, 
							Quaternion.identity);
							newtree.rigidbody.AddForce(transform.forward * 5);
Destroy (gameObject, lifeTime);
}