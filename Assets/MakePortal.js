var portalPrefab: Transform;
var SeedOrigin : Transform;

var dynamic : GameObject;


function Update () {


	  
	    if (Group.GetGroup("Buckthorn").count <= 1)	
	  


  // Because the population is stored in a static variable, you don't
  // need to get the instance.  So we can comment out the next line.

  //GetComponent(BuckthornSeedPopulation).seedpopulation;

if (Group.GetGroup("BuckthornSeed").count <= 1)

{
  
    PortalDrop();

  
  
}
    
    }

function PortalDrop () {

 var newseed = Instantiate(portalPrefab,SeedOrigin.transform.position,Quaternion.identity);
	// seedPrefab.rigidbody.AddForce(transform.forward * 5);      // Drop your seed.
	  CharliesUtil.Organize(newseed);
	  DestroyImmediate(gameObject); 
        //
        // Your CODE
}

