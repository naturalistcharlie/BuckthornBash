using UnityEngine;
using System.Collections;

public static class CharliesUtil  {

	public static void Organize(Transform o) {
		GameObject dynamicObject = GameObject.Find ("Dynamic");
		if (dynamicObject == null) {
			dynamicObject = new GameObject("Dynamic");
		}
		o.parent = dynamicObject.transform;
	}
}
