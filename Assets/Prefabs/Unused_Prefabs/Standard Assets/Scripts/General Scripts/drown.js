	// Destroy everything that enters the trigger
	function OnTriggerEnter (other : Collider) {
		Destroy(other.gameObject);
	}