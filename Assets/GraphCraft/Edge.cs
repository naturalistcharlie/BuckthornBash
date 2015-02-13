using UnityEngine;
using System.Collections;

namespace seawisphunter.graphcraft {

  /*
    A directed edge from a vertex to another vertex.
  */
  public class Edge : UsesGraphSettings {

    public Vertex fromVertex;
    public Vertex toVertex;
    public int count = 1;

    public virtual void OnDrawGizmos() {
      Color c = settings.edgeColor;
    
      Edge e = this;
      Vertex fromVertex = e.fromVertex;
      if (fromVertex == null)
        return;
      Vector3 dir = (e.transform.position - fromVertex.transform.position).normalized;
      Vector3 perpDir = Vertex.RotateZ(dir);
      float width = 0.2f;
      Vector3 A = fromVertex.transform.position + fromVertex.radius *dir + width * perpDir;
      Vector3 B = e.transform.position + width * perpDir;
      Vector3 C = e.transform.position;
      DrawLine(A, B, c);
      DrawLine(B, C, c);
                      
      Vector3 dir2 = (e.toVertex.transform.position - e.transform.position).normalized;
      Vector3 D = (e.toVertex.transform.position - e.transform.position) - e.toVertex.radius * dir2;

      DrawArrow(C, D, c, 15f, 0.2f, settings.drawForward);
    }

    public static void DrawLine(Vector3 start, Vector3 end, Color c) {
      Color oldColor = Gizmos.color;
      Gizmos.color = c;
      Gizmos.DrawLine(start, end);
      Gizmos.color = oldColor;
    }

    public static void DrawArrow(Vector3 pos,
                                 Vector3 direction,
                                 Color color,
                                 float arrowHeadAngle,
                                 float arrowHeadLength,
                                 Vector3 drawForward) {
      Color oldColor = Gizmos.color;
      Gizmos.color = color;
      Gizmos.DrawRay(pos,
                     (direction.magnitude - arrowHeadLength)
                     * direction.normalized);

      Vector3 right = Quaternion.LookRotation(direction, drawForward)
        * Quaternion.Euler(0,180+arrowHeadAngle,0) * new Vector3(0,0,1);
      Vector3 left = Quaternion.LookRotation(direction, drawForward)
        * Quaternion.Euler(0,180-arrowHeadAngle,0) * new Vector3(0,0,1);
      Gizmos.DrawRay(pos + direction, right * arrowHeadLength);
      Gizmos.DrawRay(pos + direction, left * arrowHeadLength);
      Gizmos.DrawRay(pos + direction + right * arrowHeadLength,
                     pos + direction + left * arrowHeadLength
                     - (pos + direction + right * arrowHeadLength));
      Gizmos.color = oldColor;
    }
  }
}
