
	//moving around
	var speed : float = 10.0;
	var rotateSpeed : float = 3.0;

	//shooting
	var bulletPrefab: Transform;  

	//dying
	private var dead = false;  //bunny doesn't start dead

	//getting hit
	var tumbleSpeed = 800;
	var decreaseTime = 0.01;
	var decayTime = 0.01;
	static var gotHit = false;
	private var backup = [tumbleSpeed, decreaseTime, decayTime];

	function OnControllerColliderHit (hit : ControllerColliderHit)

	{
		if(hit.gameObject.tag == "fallout")
		{
			dead = true;
			//subtract life here
			HealthControl.LIVES -=1;
		}
		if (hit.gameObject.tag == "enemyProjectile")
		{
		gotHit = true;
		}
	}

	function Update () 
	{
		var controller : CharacterController = GetComponent(CharacterController);

		// Rotate around y - axis
		transform.Rotate(0, Input.GetAxis ("Horizontal") * rotateSpeed, 0);

		// Move forward / backward
		var forward : Vector3 = transform.TransformDirection(Vector3.forward);

		var curSpeed : float = speed * Input.GetAxis ("Vertical");
		controller.SimpleMove(forward * curSpeed);

	if(Input.GetButtonDown("Jump"))
	{
	var bullet = Instantiate(bulletPrefab, //shooting the little rabbit turds
							GameObject.Find("SpawnPoint").transform.position, 
							Quaternion.identity);
							//bullet.gameObject.tag = "enemyProjectile"; ///TAG TO MAKE RABBIT SPIN only here temp.

	bullet.rigidbody.AddForce(transform.forward * 5000);
	}

	}


	function LateUpdate()
		{

		if(dead)
			{
			transform.position = Vector3(0,4,0);     // RESPAWNS
			gameObject.find("Main Camera").transform.position = Vector3(0,4,-10);
			dead=false;
			}
		if (gotHit)
		{
			if(tumbleSpeed < 1)
			{
				//reset from hit
				tumbleSpeed = backup[0];
				decreaseTime = backup[1];
				decayTime = backup[2];
				gotHit = false;
			}
			else
			{
				//we are hit!
				transform.Rotate(0,tumbleSpeed * Time.deltaTime,0,Space.World);
				tumbleSpeed = tumbleSpeed - decreaseTime;
				decreaseTime +=decayTime;
			}


		}


		}

	@script RequireComponent(CharacterController)