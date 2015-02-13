
	//shooting
	var bulletPrefab: Transform;  
	var shootPrefab: Transform;
	var poopspawn: Transform;
	var pestspawn: Transform;
	var respawnPoint: Transform;

	//dying
	var dead = false;  //bunny doesn't start dead



	

	function OnControllerColliderHit (hit : ControllerColliderHit)

	{
		if(hit.gameObject.tag == "fallout")
		{
			dead = true;
			//subtract life here
			HealthControl.LIVES -=1;
		}
		//if (hit.gameObject.tag == "enemyProjectile")
		//{
		//gotHit = true;
		//}
	}
	
	function OnTriggerEnter(hit: Collider) {
		Debug.Log("trigger enter");
	    dead = true;
	}
	

	function Update () 
	{

		if(Input.GetButtonDown("Fire2"))
	{
	var bullet = Instantiate(bulletPrefab, //shooting the little pesticides
							poopspawn.position, 
							Quaternion.identity);
								CharliesUtil.Organize(bullet);
							//bullet.gameObject.tag = "enemyProjectile"; ///TAG TO MAKE RABBIT SPIN only here temp.

	bullet.rigidbody.AddForce(transform.forward * 10);
	}
	
if(Input.GetButtonDown("Fire1"))
	{
	var shoot = Instantiate(shootPrefab, //shooting the little rabbit turds
							pestspawn.position,
							Quaternion.identity);
							CharliesUtil.Organize(shoot);
							//bullet.gameObject.tag = "enemyProjectile"; ///TAG TO MAKE RABBIT SPIN only here temp.

	shoot.rigidbody.AddForce(transform.forward * 500);
	}

	}


	function LateUpdate()
		{

		if(dead)
			{
			transform.position = respawnPoint.position;     // RESPAWNS
			//gameObject.find("Main Camera").transform.position = Vector3(870,15,870);
			dead=false;
			}



		}

	@script RequireComponent(CharacterController)