#pragma strict

//public class BuckthornPopulation extends Population {
public static var population : int;
public var Count : int;

function Start () {
		population++;
}

function Update () {
	Count = population;
}

function OnDestroy() {
		population--;
}

//}

