var seedPrefab: Transform;
var lowrand : float = 1.0;
var hirand : float = 30.0;
var SeedOrigin : Transform;
var dynamic : GameObject;
var maxseed : float = 400;
var maxbuckthorn : float = 200;

function Start () {
 	var timeTillGermination : float = Random.Range(lowrand, hirand); // X to Y seconds {

		
Invoke("GerminationCycle", timeTillGermination);
	dynamic = GameObject.Find("Dynamic GameObjects");
       
}

function GerminationCycle () {

  // Because the population is stored in a static variable, you don't
  // need to get the instance.  So we can comment out the next line.

  //GetComponent(BuckthornSeedPopulation).seedpopulation;


  // This looks good.
  if (Group.GetGroup("BuckthornSeed").count <= maxseed)
//if (BuckthornSeedPopulation.seedpopulation <= maxseed)
  {
    SeedDrop();

    // Set up a new timer for the next germination.
    var timeTillGermination : float = Random.Range(lowrand, hirand); // X to Y seconds

    // This will call itself in [X, Y] seconds.
    Invoke("GerminationCycle", timeTillGermination);
  }

  {
    var timeTillGermination2 : float = Random.Range(lowrand, hirand); // X to Y seconds

    Invoke("GerminationCycle", timeTillGermination);
    }
    
    }

function SeedDrop () {

 var newseed = Instantiate(seedPrefab,SeedOrigin.transform.position,Quaternion.identity);
	// seedPrefab.rigidbody.AddForce(transform.forward * 5);      // Drop your seed.
	  CharliesUtil.Organize(newseed);
        //
        // Your CODE
}



function OnCollisionEnter(collision : Collision)
{
    // If plant A and plant B collide, and they both use
    // PlantHitPlantDie2.js, they'll both have OnCollisionStay called
    // for each other in succession.  We want death to be on a first
    // come, first kill basis.  When a gameobject is destroyed, you
    // can check for that testing for whether its null.

    if (collision.gameObject != null
        && collision.gameObject.tag == "invasive"
        && gameObject.tag == "invasive")
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
        Debug.Log("Destroying invasive plant because of collision.");
    }
     if (collision.gameObject != null
        && collision.gameObject.tag == "rabbitpoop"
        && gameObject.tag == "invasive")
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
        //Debug.Log("Blam! You killed a buckthorn!");
    }
      if (collision.gameObject != null
        && collision.gameObject.tag == "nativeseed"
        && gameObject.tag == "invasive")
    {
        Destroy(collision.gameObject);
        Debug.Log("native seed destroyed by invasive.");
    }
      if (collision.gameObject != null
        && collision.gameObject.tag == "plant"
        && gameObject.tag == "invasive")
    {
        Destroy(collision.gameObject);
        Debug.Log("native tree outcompeted by invasive.");
    }
}
