using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
  This is a group game object that basically allows one to collect
  members of a group, so one can enforce policies like population
  limiting.

  The way it works in the calling code is like this:

  // Register yourself as part of the group.
  Group.GetGroup("buckthorn").Register(groupMember);

  // Unregister yourself from the group (safe to call in OnDestroy).
  Group.Deregister(groupMember);
*/
public class Group : MonoBehaviour {
	public List<GroupMember> members = new List<GroupMember>();
	public int count = 0;
	/*
    We find or create a Group Game Object with the given name.
  */
	public static Group GetGroup(string name) {
		var o = GameObject.Find(name);
		if (o == null) {
			o = new GameObject(name);
		}
		var group = o.GetComponent<Group>();
		if (group == null) {
			group = o.AddComponent<Group>();
		}
		return group;
	}
	
	public void Register(GroupMember member) {
		if (! members.Contains(member)) {
			count++;
			members.Add(member);
		}
	}
	
	/*
    This needs to be static because if the Group is destroyed before
    all of its members, then it might be inadvertently recreated.
  */
	public static void Deregister(GroupMember member) {
		var o = GameObject.Find(member.groupName);
		if (o != null) {
			Group group = Group.GetGroup(member.groupName);
			if (group.members.Contains(member)) {
				group.count--;
				group.members.Remove(member);
			}
		}
	}
}
