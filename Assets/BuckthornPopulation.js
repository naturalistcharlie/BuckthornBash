#pragma strict

//public class BuckthornPopulation extends Population {
public static var buckthornpopulation : int;
public var Count : int;

function Start () {
		buckthornpopulation++;
}

function Update () {
	Count = buckthornpopulation;
}

function OnDestroy() {
		buckthornpopulation--;
}

//}

