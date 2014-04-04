﻿var seedPrefab: Transform;
var TreeMature : float = 30.0;
var SeedFreq : float = 5.0;

var seedSpread : float = 10;
var trunkSize : float = 1;
var projectile : Rigidbody;



	// Starting in TreeMature seconds.
	// a projectile will be launched every SeedFreq seconds

	
	//function SeedDrop () {
	InvokeRepeating("LaunchProjectile", TreeMature, SeedFreq);
//	}

	
function LaunchProjectile () {
		instance = Instantiate(projectile,gameObject.transform.position,Quaternion.identity);
		instance.velocity = Random.insideUnitSphere * 5;
}


function OnCollisionStay(collision : Collision)
{
    // If plant A and plant B collide, and they both use
    // PlantHitPlantDie2.js, they'll both have OnCollisionStay called
    // for each other in succession.  We want death to be on a first
    // come, first kill basis.  When a gameobject is destroyed, you
    // can check for that testing for whether its null.

    if (collision.gameObject != null
        && collision.gameObject.tag == "plant"
        && gameObject.tag == "plant")
    {
    	collision.gameObject.tag = "destroyedPlant";
        Destroy(collision.gameObject);
        Debug.Log("Destroying tree because of collision.");
    }
    
        if (collision.gameObject != null
        && collision.gameObject.tag == "invasive"
        && gameObject.tag == "invasive")
    {
    	collision.gameObject.tag = "destroyedPlant";
        Destroy(collision.gameObject);
        Debug.Log("Destroying tree because of invasive species.");
    }
    
    
}

//Basic collision detection checking for two differently named objects
function OnCollisionEnter(theCollision : Collision){
 if(theCollision.gameObject.name == "Top"){
  Debug.Log("Hit the ceiling");
    Destroy(gameObject);
 }else if(theCollision.gameObject.name == "Bottom"){
  Debug.Log("Hit the floor");
    Destroy(gameObject);
 }
    
    }