using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace seawisphunter.graphcraft {

  public class UsesGraphSettings : MonoBehaviour {
    public string graphSettings = GraphSettings.DEFAULT_GRAPH_SETTINGS_NAME;
    private GraphSettings _settings;
    public GraphSettings settings {
      get {
        if (_settings == null) {
          _settings = GraphSettings.GetGraphSettings(graphSettings);
          if (_settings == null)
            Debug.Log("Cannot get GraphSettings with name '" + graphSettings + "'.");
        }
        return _settings;
      }
    }

    void Start() {
      _settings = null;
    }
  }

  public class Vertex : UsesGraphSettings {

    /* fromEdges contains the list of edges that have this Vertex as a
     * from reference. */
    public List<Edge> fromEdges = new List<Edge>();
    /* Radius */
    public float radius {
      get { 
        float k = 0.5f * settings.radiusParam;
        float r = k * FoldVector3(Mathf.Max, transform.localScale);
        return r;
      }
    }

    /*
      Draw a circle around the object that contains a vertex.
    */
    void OnDrawGizmos() {
      float r = radius;
      Color c = settings.vertexColor;
      DrawCircle(transform.position, settings.drawForward, c, r);
      DrawLocalCube(transform, Vector3.one, c);

      if (settings.labelVertices) {
        #if UNITY_EDITOR
        Color oldColor = Handles.color;
        Handles.color = c;
        GUIStyle style = new GUIStyle(GUIStyle.none);
        style.alignment = TextAnchor.LowerLeft;
        GUIContent content = new GUIContent(transform.name);
        Vector2 size = style.CalcSize(content);
        style.contentOffset = -size / 2f; 
        Handles.Label(transform.position, content, style);
        Handles.color = oldColor;
        #endif
      }
    }


    public static Vector3 RotateZ(Vector3 v) {
      return new Vector3(v.y, -v.x, v.z);
    }

    private static float FoldVector3(System.Func<float, float, float> f,
                                     Vector3 v) {
      return f(f(v.x, v.y), v.z);
    }

    public static void DrawLocalCube(Transform transform, Vector3 size, Color color, Vector3 center = default(Vector3)) {
      Color oldColor = Gizmos.color;
      Gizmos.color = color;
      Matrix4x4 oldMatrix = Gizmos.matrix;
      Gizmos.matrix = transform.localToWorldMatrix;
      Gizmos.DrawWireCube(center, size); 

      Gizmos.matrix = oldMatrix;
      Gizmos.color = oldColor;
    }

    public static void DrawLocalCube(Transform transform, Vector3 size,
                                     Quaternion q, Color color,
                                     Vector3 center = default(Vector3)) {
      Color oldColor = Gizmos.color;
      Gizmos.color = color;
      Matrix4x4 oldMatrix = Gizmos.matrix;
      Matrix4x4 rotate = Matrix4x4.TRS(Vector3.zero, q, Vector3.one);
      Gizmos.matrix = transform.localToWorldMatrix * rotate;
      Gizmos.DrawWireCube(center, size); 
      Gizmos.matrix = oldMatrix;
      Gizmos.color = oldColor;
    }

    public static void DrawLocalCube(Vector3 position,
                                     Quaternion q,
                                     Vector3 size, Color color, Vector3 center = default(Vector3)) {
      Color oldColor = Gizmos.color;
      Gizmos.color = color;
      Matrix4x4 oldMatrix = Gizmos.matrix;
      Gizmos.matrix = Matrix4x4.TRS(position, q, size);
      Gizmos.DrawWireCube(center, Vector3.one);

      Gizmos.matrix = oldMatrix;
      Gizmos.color = oldColor;
    }


    public static void DrawCircle(Vector3 center, Vector3 up,
                                  Color color, float radius) {
      Color oldColor = Gizmos.color;
      Gizmos.color = color;
      Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, up);
      Vector3 lastPoint = center + rotation * Vector3.right * radius;
      Vector3 nextPoint;
      for(int i = 0; i <= 120; i++){
        nextPoint.x = Mathf.Cos((i*3)*Mathf.Deg2Rad);
        nextPoint.y = Mathf.Sin((i*3)*Mathf.Deg2Rad);
        nextPoint.z = 0;
			
        nextPoint = center + rotation * nextPoint * radius;
			
        Gizmos.DrawLine(lastPoint, nextPoint);
        lastPoint = nextPoint;
      }
      Gizmos.color = oldColor;
    }
  }
}
