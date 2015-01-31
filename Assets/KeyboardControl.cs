// KeyboardControl.cs
using UnityEngine;
using System.Collections;

// KeyboardControl.cs
using UnityEngine;
using System.Collections;

public class KeyboardControl : MonoBehaviour {
	public string[] levels;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int index = -1;
		if (Input.GetKeyDown(KeyCode.Space)) {
			index = 0; // SmallMapleWorld
		} else if (Input.GetKeyDown(KeyCode.Alpha1)) {
			index = 1; // SmallMapleWorld
		} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			index = 2; // 2 players
		} else if (Input.GetKeyDown(KeyCode.S)) {
			index = 3; // player select
		} else if (Input.GetKeyDown(KeyCode.U)) {
			index = 4; // splash screen
		} else if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit(); // quit
		}
		if (index >= 0 && index < levels.Length) {
			Application.LoadLevel(levels[index]);
		}
	}
}
