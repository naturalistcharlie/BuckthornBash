﻿var seedPrefab: Transform;
var lowrand : float = 1.0;
var hirand : float = 30.0;


function Start () {
        GerminationCycle();
}

function GerminationCycle () {
        SeedDrop();

        // Set up a new timer for the next germination.
        var timeTillGermination : float = Random.Range(lowrand, hirand); // X to Y seconds

        // This will call itself in [X, Y] seconds.
        Invoke("GerminationCycle", timeTillGermination);
}

function SeedDrop () {
 var newseed = Instantiate(seedPrefab,gameObject.transform.position,Quaternion.identity);
	// seedPrefab.rigidbody.AddForce(transform.forward * 5);      // Drop your seed.
        //
        // Your CODE
}



function OnCollisionStay(collision : Collision)
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
    	collision.gameObject.tag = "destroyedPlant";
        Destroy(collision.gameObject);
        Debug.Log("Destroying invasive plant because of collision.");
    }
}
