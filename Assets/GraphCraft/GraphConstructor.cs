using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace seawisphunter.graphcraft {

  /*
    The GraphConstructor constructs any of the vertices that it's given.
  */
  public class GraphConstructor : MonoBehaviour {
    public List<Vertex> rootVertices = new List<Vertex>();
    public bool connectJoints = true;
    public bool stripVertexComponents = true;
    public bool organize = true;
    private int vertexCount;
    public readonly int VERTEX_COUNT_MAX = 100;
    
    void Start () {
      
      Vector3 relativePos = transform.position
        - rootVertices[0].transform.position;
      foreach (Vertex v in rootVertices) {
        vertexCount = 0;
        if (v == null)
          continue;
        ConstructVertex(v,
                     v.transform.position + relativePos,
                     transform.localScale,
                     v.transform.rotation,
                     1,
                     null,
                     organize ? new GameObject(v.name) : null);
      }
    }

    void ConstructVertex(Vertex v,
                         Vector3 position, Vector3 scale, Quaternion rotation,
                         int count, GameObject parentObject, GameObject rootObject) {
      vertexCount++;
      if (vertexCount > VERTEX_COUNT_MAX) {
        Debug.Log("Constructed more than max vertex count. Stopping.");
        return;
      }
      GameObject o;
      o = Object.Instantiate(v.gameObject, position, rotation) as GameObject;
      o.name = v.name;
      o.transform.localScale = Vector3.Scale(scale, v.transform.localScale);
      if (connectJoints && o.hingeJoint
          && parentObject && parentObject.rigidbody != null) {
        o.hingeJoint.connectedBody = parentObject.rigidbody;
      }
      if (stripVertexComponents) {
        Destroy(o.GetComponent<Vertex>());
      }
      if (rootObject != null)
        o.transform.parent = rootObject.transform;
      foreach (Edge e in v.fromEdges) {
        if (e == null || (v == e.toVertex && count > e.count))
          continue;
        ConstructVertex(e.toVertex,
                        position
                        + rotation
                        * Vector3.Scale(scale,
                                        (e.transform.position - v.transform.position)),
                        Vector3.Scale(scale, e.transform.localScale),
                        rotation * e.transform.rotation * e.toVertex.transform.rotation,
                        // If we recurse, we keep count; otherwise, start at 1.
                        v == e.toVertex ? count + 1 : 1,
                        o,
                        rootObject);
      }
    }
  }
}
