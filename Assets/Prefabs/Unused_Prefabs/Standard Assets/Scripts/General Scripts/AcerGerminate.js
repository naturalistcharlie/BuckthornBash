var acerPrefab: Transform;

function Start () {
        GerminationCycle();
}

function acerDrop () {
  	var acer = Instantiate(acerPrefab, 
							GameObject.Find("Mapleseed").transform.position, 
							Quaternion.identity);
	acer.rigidbody.AddForce(transform.forward * 5000);      // Drop your acer.
        //
        // Your CODE
}

function GerminationCycle () {
        acerDrop();

        // Set up a new timer for the next germination.
        var timeTillGermination : float = Random.Range(1, 5); // 30 to 330seconds

        // This will call itself in [0,30] seconds.
        Invoke("GerminationCycle", timeTillGermination);
        }