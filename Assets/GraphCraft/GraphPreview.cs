using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace seawisphunter.graphcraft {
  /*
    The GraphPreview draws a gizmo preview of the vertices that it's
    given.
  */
  public class GraphPreview : MonoBehaviour {
    public List<Vertex> rootVertices = new List<Vertex>();
    public bool drawOnPlay = true; // true = draw all the time; false = draw only while not playing.
    private int vertexCount;
    private Vector3? relativePos;
    public readonly int VERTEX_COUNT_MAX = 100;
    
    void Start () {
      relativePos = transform.position - rootVertices[0].transform.position;
    }

    void OnDrawGizmos() {
      if (! drawOnPlay && Application.isPlaying) 
        return;
      Vector3 currentRelativePos = transform.position
        - rootVertices[0].transform.position;
      
      foreach (Vertex v in rootVertices) {
        vertexCount = 0;
        if (v == null)
          continue;
        RenderVertex(v,
                     v.transform.position + (relativePos == null ? currentRelativePos : relativePos.Value),
                     transform.localScale,
                     v.transform.rotation,
                     1);
      }
    }

    void RenderVertex(Vertex v,
                      Vector3 position, Vector3 scale, Quaternion rotation,
                      int count) {
      vertexCount++;
      if (vertexCount > VERTEX_COUNT_MAX) {
        Debug.Log("Constructed more than max vertex count. Stopping.");
        return;
      }
      Vertex.DrawLocalCube(position, rotation, Vector3.Scale(scale, v.transform.localScale), v.settings.vertexColor);
      foreach (Edge e in v.fromEdges) {
        if (e == null || (v == e.toVertex && count > e.count))
          continue;
        RenderVertex(e.toVertex,
                        position
                        + rotation
                        * Vector3.Scale(scale,
                                        (e.transform.position - v.transform.position)),
                        Vector3.Scale(scale, e.transform.localScale),
                        rotation * e.transform.rotation * e.toVertex.transform.rotation,
                        // If we recurse, we keep count; otherwise, start at 1.
                        v == e.toVertex ? count + 1 : 1);
      }
    }
  }
}
