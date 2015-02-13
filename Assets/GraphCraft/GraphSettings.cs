using UnityEngine;

namespace seawisphunter.graphcraft {

  /*
    Graph settings holds the color preferences and which Vertex and
    Edge classes ought to be used.  It can be referenced like a
    singleton.  If it doesn't already exist in the scene, it will be
    created.
  */
  [System.Serializable]
  public class GraphSettings {
    public static string DEFAULT_GRAPH_SETTINGS_NAME = "Graph Settings";
    public Color edgeColor = Color.black;
    public Color vertexColor = Color.black;
    public string edgeClass = "seawisphunter.graphcraft.PreviewToAtEdge";
    public string vertexClass = "seawisphunter.graphcraft.Vertex";
    public float  radiusParam = 1.5f;
    /* The vector which represents the forward direction.  The vertex
     * gizmos are drawn in 2D. */
    public Vector3 drawForward = Vector3.forward;
    public bool labelVertices = true;
    public static GraphSettings defaultSettings = new GraphSettings();

    public static GraphSettings GetGraphSettings(string name) {
      GraphSettingsUI _instance;
      GameObject o = GameObject.Find(name);
      if (o == null) {
        if (! Application.isPlaying)
          return defaultSettings;
        o = new GameObject(name);
      } 
      _instance = o.GetComponent<GraphSettingsUI>() as GraphSettingsUI;
      if (_instance == null) {
        if (! Application.isPlaying)
          return defaultSettings;
        o.AddComponent<GraphSettingsUI>();
        _instance = o.GetComponent<GraphSettingsUI>() as GraphSettingsUI;
      }
      return _instance.settings;
    }

    public static GraphSettings GetGraphSettings() {
      return GetGraphSettings(DEFAULT_GRAPH_SETTINGS_NAME);
    }
  }

}
