﻿var treePrefab: Transform;
var GermLow = 30;
var GermHigh = 50;


//look at me!!!!!!!!!

function OnCollisionEnter (collision : Collision) {
if(collision.gameObject.tag == "dirt"){
  var timeTillGermination : float = Random.Range(GermLow,GermHigh);
  				//Debug.Log("Seed hits the dirt");
	 Invoke("PlantTree", timeTillGermination);
}
if(collision.gameObject.tag == "rabbitpoop"){
Debug.Log("baby tree is fertillized");
Invoke("PlantTree", 0);
}
}

function PlantTree () {


        // if (collision.gameObject.tag == "dirt"){
                
                var newtree = Instantiate(treePrefab,gameObject.transform.position,Quaternion.identity); //plant the tree
                CharliesUtil.Organize(newtree);
                //transform.position = Vector3(0,0,0);  
                // TODO: Mark (x, z) as taken by a tree, so we don’t overcrowd.
                DestroyImmediate(gameObject);                      
                //remove the seed. Is each seed making multiple trees/ it isn't supposed to.
       // }   else 
        	//	{DestroyObject(gameObject); 
           //     Debug.Log("Seed died in midair.");
           //     }
            }
            
            
           // }
   