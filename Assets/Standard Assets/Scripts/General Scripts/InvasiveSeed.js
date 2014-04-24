  
  function OnCollisionEnter(collision : Collision)
  {
  if (collision.gameObject != null
        && collision.gameObject.tag == "plant"
        && gameObject.tag == "InvasiveSeed")
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
        Debug.Log("Invasive Seed Destroys Plant");
    }
      if (collision.gameObject != null
        && collision.gameObject.tag == "rabbitpoop"
        && gameObject.tag == "InvasiveSeed")
    {
        Destroy(gameObject);
       // Debug.Log("rabbit poop destroys invasive seed");
    }
   }