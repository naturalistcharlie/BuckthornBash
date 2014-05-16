#pragma strict
var population : Population;

function Start () {
	if (population != null)
		population.Count++;
}

function Update () {

}

function OnDestroy() {
	if (population != null)
		population.Count--;
	}