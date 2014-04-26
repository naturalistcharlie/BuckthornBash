var TreeMature : float = 0.1;
var SeedFreq : float = 1.0;
var SeedOrigin : Transform;
var projectile : Rigidbody;
  
  function OnCollisionEnter(collision : Collision)
  {

      if (collision.gameObject != null
        && collision.gameObject.tag == "invasive"
        && gameObject.tag == "pesticide")
         {
        Destroy(gameObject);
        Destroy(collision.gameObject);
        }
        if (collision.gameObject != null
        && collision.gameObject.tag == "dirt"
        && gameObject.tag == "pesticide")
    {
        
        Destroy(gameObject);
    }
      if (collision.gameObject != null
        && collision.gameObject.tag == "plant"
        && gameObject.tag == "pesticide")
         {
        Destroy(gameObject);
        Destroy(collision.gameObject);
        }
   }
   
	InvokeRepeating("LaunchProjectile", TreeMature, SeedFreq);
//	}


function LaunchProjectile () {
		instance = Instantiate(projectile,SeedOrigin.transform.position,Quaternion.identity);
		instance.velocity = Random.insideUnitSphere * 0.2;
		}
		
		