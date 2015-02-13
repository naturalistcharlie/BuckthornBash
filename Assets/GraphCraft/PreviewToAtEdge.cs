using UnityEngine;
using System.Collections;

namespace seawisphunter.graphcraft {

  /*
    Draws a scaled bounded box of this edge's toVertex.
   */
  public class PreviewToAtEdge : Edge {

    public override void OnDrawGizmos() {
      Color c = settings.edgeColor;
      Vertex.DrawLocalCube(transform,
                           toVertex.transform.localScale,
                           toVertex.transform.rotation, 
                           c);
      base.OnDrawGizmos();
    }
  }
}
