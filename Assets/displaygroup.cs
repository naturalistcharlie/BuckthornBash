using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class displaygroup : MonoBehaviour {
	Text txt;
	public string groupName;
	//public string displayName;
	private Group group;
	
	// Use this for initialization
	void Start () {
		//gameObject.transform === var transform = gameObject.GetComponent<Transform>();
		txt = gameObject.GetComponent<Text>();
		group = Group.GetGroup (groupName);
		txt.text=groupName + ": " + group.count;
	}
	
	// Update is called once per frame
	void Update () {
		txt.text=groupName + ": " + group.count;
	}
}
