using UnityEngine;
using System.Collections;

/*
  Makes a hinge joint move sinusoidally depending on the amplitude and
  frequency, only used in the examples.
 */
public class Snakey : MonoBehaviour {
  public float amplitude = 10f;
  public float frequency = 1f;

  // Use this for initialization
  void Start () {
    BrainUpdate();
  }
  
  // Update is called once per frame
  void Update () {
  
  }

  void BrainUpdate() {
    if (hingeJoint == null)
      return;
    JointSpring spring = hingeJoint.spring;
    spring.targetPosition = amplitude * Mathf.Sin(Time.fixedTime);
    hingeJoint.spring = spring;
    Invoke("BrainUpdate", frequency);
  }
}
