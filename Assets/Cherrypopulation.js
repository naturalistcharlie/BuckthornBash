#pragma strict

//public class BuckthornSeedPopulation extends Population {
public static var seedpopulation : int;
public var CountSeed : int;

function Start () {
		seedpopulation++;
}

function Update () {
	CountSeed = seedpopulation;
}

function OnDestroy() {
		seedpopulation--;
}

//}

