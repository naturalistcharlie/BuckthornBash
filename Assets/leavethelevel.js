#pragma strict

	function leavelevel  (hit : ControllerColliderHit)
          
          {     
	 if(hit.gameObject.tag == "Player")
	 {

	Application.LoadLevel ("BBIntro");
	}
	}