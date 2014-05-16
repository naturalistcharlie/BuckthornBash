var TreeMature : float = 0.1;
var SeedFreq : float = 1.0;
var SeedOrigin : Transform;
var projectile : Rigidbody;
  
  function OnCollisionEnter(collision : Collision)
  {
  {

      if (collision.gameObject != null
        && collision.gameObject.tag == "invasive"
        && gameObject.tag == "pesticide")
         {
      
        Destroy(collision.gameObject);
        }
        
    }
      if (collision.gameObject != null
        && collision.gameObject.tag == "plant"
        && gameObject.tag == "pesticide")
         {
        
        Destroy(collision.gameObject);
        }
        
           if (collision.gameObject != null
        && collision.gameObject.tag == "nativeseed"
        && gameObject.tag == "pesticide")
         {
       
        Destroy(collision.gameObject);
        }
 
   }
	