#pragma strict
public var bottom : float;
function Start () {

}

function LateUpdate () {
    transform.position.y = Terrain.activeTerrain.SampleHeight(transform.position) + Terrain.activeTerrain.transform.position.y;// + bottom;
}