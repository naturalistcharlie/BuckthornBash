


var seedPrefab: Transform;

var lowrand : float = 30.0;
var hirand : float = 50.0;
				
		

function Start () {
        GerminationCycle();
}

function SeedDrop () {
 var newseed = Instantiate(seedPrefab,gameObject.transform.position,Quaternion.identity);
	// seedPrefab.rigidbody.AddForce(transform.forward * 5);      // Drop your seed.
        //
        // Your CODE
}

function GerminationCycle () {
        SeedDrop();

        // Set up a new timer for the next germination.
        var timeTillGermination : float = Random.Range(lowrand, hirand); // X to Y seconds

        // This will call itself in [X, Y] seconds.
        Invoke("GerminationCycle", timeTillGermination);
        }