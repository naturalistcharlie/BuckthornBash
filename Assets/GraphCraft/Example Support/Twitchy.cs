using UnityEngine;
using System.Collections;

/*
  Makes a hinge joint twitch randomly depending on the amplitude and
  frequency, only used in the examples.
 */
public class Twitchy : MonoBehaviour {
  public float amplitude = 10f;
  public float frequency = 1f;
  void Start () {
    BrainUpdate();
  }

  void BrainUpdate() {
    JointSpring spring = hingeJoint.spring;
    spring.targetPosition = Random.Range(-amplitude, amplitude);
    hingeJoint.spring = spring;
    Invoke("BrainUpdate", frequency);
  }
}
