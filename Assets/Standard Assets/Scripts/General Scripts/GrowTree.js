#pragma strict

var jerky : boolean; // Jerky growth or not.

function Start () {

	
        
    if (jerky) {
        // StartCoroutine makes the GrowTree function kind of run in
        // the background.
        StartCoroutine(GrowTree());
    }
    
   
    
}

function Update () {

      
    if (! jerky) {
        // Grow this tree by ten percent per second (I think?)
        transform.localScale *= (1 + 0.1 * Time.deltaTime);
    }
}

function GrowTree() {
    var maxScale : float = 20;
    var minScale : float = 0.5;
    while (true) {
        var growRate : float = Random.Range(.9, 1.2);
        var growNext : float = Random.Range(1, 2);
        // Only grow bigger if we're less than max.
        if (growRate > 1 && transform.localScale.magnitude < maxScale) {
            transform.localScale *= growRate;
        // Only shrink smaller  if we're greater than min.
        } else if (growRate < 1 && transform.localScale.magnitude > minScale) {
            transform.localScale *= growRate;
        }
        // We wait for a certain number of seconds before growing again.
        // But we don't hold up the rest of the game while we wait.
        yield WaitForSeconds (growNext);
    }
}

function NoFlyingTrees (collision : Collision) {
 if (collision.gameObject.tag != "dirt"){
        DestroyObject(gameObject); 
        Debug.Log("Killed an airborne tree.");
        }
        }
