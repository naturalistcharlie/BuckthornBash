using UnityEngine;
using UnityEditor;

namespace seawisphunter.graphcraft {
  /*
    Editor extensions for GraphCraft.
  */
  public class GraphExtensions {

    /*
      Add a vertex to the selected objects so long as they're not
      edges and don't have vertices already.
     */
    [MenuItem("Component/GraphCraft/Vertex", false, 90)]
    private static void MakeVertex() {
      foreach (GameObject o in Selection.gameObjects) {
        if (! HasEdge(o))
          GetOrMakeVertex(o);
      }
    }
    /*
      Connect objects that are selected and not edges.
    */
    [MenuItem("Component/GraphCraft/Connect Objects", false,90)]
    private static void ConnectObjects() {
      if (Selection.gameObjects.Length < 2) {
        Debug.Log("Select two or more objects to connect them; the active object will be the source connection.");
        return;
      }
      GameObject src = Selection.activeObject as GameObject;
      if (src == null) {
        Debug.Log("Active object that would be used as a source must be a GameObject.");
        return;
      }
      for (int i = 0; i < Selection.gameObjects.Length; i++) {
        if (Selection.gameObjects[i] != src
            && ! HasEdge(Selection.gameObjects[i])) {
          Connect(src, Selection.gameObjects[i]);
        }
        if (HasEdge(Selection.gameObjects[i])) {
          // Check edges.  Fix if necessary.
          Edge e = Selection.gameObjects[i].GetComponent<Edge>();
          if (! e.fromVertex.fromEdges.Contains(e)) {
            // We have a dangling edge.  Add it to the vertex.
            e.fromVertex.AddEdge(e);
          }
        }
      }
    }

    [MenuItem("Component/GraphCraft/Connect To Self", false, 90)]
    private static void ConnectToSelf() {
      foreach(GameObject a in Selection.gameObjects) {
        if (! HasEdge(a))
          Connect(a, a);
      }
    }

    
    /*
      This will change the name of the vertices to (a,b,c,...) and it
      will change the name of the edges to whatever the vertices are.
    */
    [MenuItem("Component/GraphCraft/Relabel", false, 102)]
    private static void Relabel() {
      int i = 0;
      foreach (Vertex v in Selection.GetFiltered(typeof(Vertex), SelectionMode.Editable)) {
        Undo.RecordObject(v, "Changing name.");
        v.gameObject.name = "" + System.Convert.ToChar(97 + i);
        i++;
      }
      foreach (Edge e in Selection.GetFiltered(typeof(Edge), SelectionMode.Editable)) {
        Undo.RecordObject(e, "Changing name.");
        e.name = e.fromVertex.gameObject.name + "->" + e.toVertex.gameObject.name;
      }
    }

    [MenuItem("Component/GraphCraft/Construct Graph", false, 102)]
    private static void ConstructGraph() {
      object[] vertices = Selection.GetFiltered(typeof(Vertex), SelectionMode.Editable);
      if (vertices.Length == 0) {
        Debug.Log("Please select an object with a vertex");
        return;
      }

      GameObject gconObject = new GameObject("Graph Constructor");
      GraphConstructor gcon = gconObject.AddComponent<GraphConstructor>();
      Undo.RegisterCreatedObjectUndo(gcon, "Created Graph Constructor.");

      foreach (Vertex v in vertices) {
        if (! gcon.rootVertices.Contains(v))
          gcon.rootVertices.Add(v);
      }
      gconObject.transform.position = ((Vertex) vertices[0]).transform.position + Vector3.down;
    }

    [MenuItem("Component/GraphCraft/Preview Graph", false, 102)]
    private static void PreviewGraph() {
      object[] vertices = Selection.GetFiltered(typeof(Vertex), SelectionMode.Editable);
      if (vertices.Length == 0) {
        Debug.Log("Please select an object with a vertex");
        return;
      }

      GameObject gconObject = new GameObject("Graph Preview");
      GraphPreview gcon = gconObject.AddComponent<GraphPreview>();
      Undo.RegisterCreatedObjectUndo(gcon, "Created Graph Preview.");

      foreach (Vertex v in vertices) {
        if (! gcon.rootVertices.Contains(v))
          gcon.rootVertices.Add(v);
      }
      gconObject.transform.position = ((Vertex) vertices[0]).transform.position + Vector3.down;
    }



    [MenuItem("Component/GraphCraft/Graph Settings", false, 102)]
    private static void SelectGraphSettings() {
      string name = GraphSettings.DEFAULT_GRAPH_SETTINGS_NAME;
      GameObject o = GameObject.Find(name);
      if (o == null) {
        o = new GameObject(name);
        Undo.RegisterCreatedObjectUndo(o, "Created Graph Settings.");
      }
      if (o.GetComponent<GraphSettingsUI>() == null)
        o.AddComponent<GraphSettingsUI>();
      Selection.objects = new Object[] {o};
    }


    // [MenuItem("Component/GraphCraft/Fix Edges")]
    // private static void FixEdges() {
    //   foreach (GameObject o in Selection.gameObjects) {
    //     Vertex v = o.GetComponent<Vertex>();
    //     if (v == null)
    //       continue;
    //     foreach(Edge e in v.fromEdges) {
    //       e.fromVertex = v;
    //     }
    //   }
    // }

    /*
      XXX For some reason setting Selection.objects on Mac OS X does
      not show the selected objects correctly, so I'm leaving it out
      until it's fixed in Unity.
    */
    // [MenuItem("Component/GraphCraft/Select Only Edges", false)]
    // private static void SelectOnlyEdges() {
    //   Object[] objects = Selection.GetFiltered(typeof(Edge), SelectionMode.Editable);
    //   Selection.objects = objects;
    // }

    // [MenuItem("Component/GraphCraft/Select Only Vertices", false)]
    // private static void SelectOnlyVertices() {
    //   Object[] objects = Selection.GetFiltered(typeof(Vertex), SelectionMode.Editable);
    //   Selection.objects = objects;
    // }


    /*
      Get the vertex for GameObject or create it if it doesn't exist.
    */
    public static Vertex GetOrMakeVertex(GameObject o) {
      Vertex v = o.GetComponent<Vertex>();
      if (v == null) {
        var type = GetType(GraphSettings.GetGraphSettings().vertexClass);
        if (type == null) {
          Debug.Log("No vertex type found for '" + GraphSettings.GetGraphSettings().vertexClass + "'.");
          return null;
        }
        Undo.AddComponent(o, type);
        //o.AddComponent(GraphSettings.instance.vertexClass);
        v = o.GetComponent<Vertex>();
      }
      return v;
    }

    // http://stackoverflow.com/questions/1825147/type-gettypenamespace-a-b-classname-returns-null
    private static System.Type GetType(string typeName) {
      var type = System.Type.GetType(typeName);
      if (type != null) return type;
      foreach (var a in System.AppDomain.CurrentDomain.GetAssemblies())
      {
        type = a.GetType(typeName);
        if (type != null)
          return type;
      }
      return null;
    }

    /*
      Connect a GameObject to a GameObject, creating Vertexes if
      necessary.
    */
    public static void Connect(GameObject src, GameObject dest) {
      Connect(GetOrMakeVertex(src), GetOrMakeVertex(dest));
    }

    /*
      Connect a Vertex to a Vertex.
    */
    public static void Connect(Vertex src, Vertex dest) {
      if (src == dest) {
        // Handle self connection.
        Vertex v = src;
        GameObject link = new GameObject(v.name + "->" + v.name);
        Undo.RegisterCreatedObjectUndo(link, "Created " + "self-edge " + v.name);
        link.transform.position = v.transform.position + 1.5f * v.radius * Vector3.right;
        Edge e = link.AddComponent(GetType(v.settings.edgeClass)) as Edge;
        e.fromVertex = v;
        e.toVertex = v;
        v.AddEdge(e);
      } else {
        // Handle directed connection from src to dest.
        Vertex v_a = src;
        Vertex v_b = dest;
        GameObject link = new GameObject(v_a.name + "->" + v_b.name);
        Undo.RegisterCreatedObjectUndo(link, "Created " + "edge " + v_a.name + "->" + v_b.name);
        Vector3 relDistance = v_b.transform.position - v_a.transform.position;
        link.transform.position = v_a.transform.position
          + relDistance.normalized * relDistance.magnitude/2f;
        Edge e = link.AddComponent(GetType(v_a.settings.edgeClass)) as Edge;
        e.fromVertex = v_a;
        e.toVertex = v_b;
        v_a.AddEdge(e);
      }
    }

    private static bool HasEdge(GameObject a) {
      return a.GetComponent<Edge>() != null;
    }
  }
  
  public static class VertexExtensions {

    public static void AddEdge(this Vertex v, Edge e) {
      if (! v.fromEdges.Contains(e)) {
        Undo.RecordObject(v, "Add From Edge");
        v.fromEdges.Add(e);
      }
    }

    public static void RemoveEdge(this Vertex v, Edge e) {
      if (v.fromEdges.Contains(e)) {
        Undo.RecordObject(v, "Remove From Edge");
        v.fromEdges.Remove(e);
      }
    }

    public static bool IsConnectedTo(this Vertex a, Vertex b) {
      foreach (Edge e in a.fromEdges) {
        if (e.toVertex == b) {
          return true;
        }
      }
      return false;
    }
  }

  // [CustomEditor(typeof(Edge))]
  // public class EdgeEditor : Editor
  // {
  //   static Edge lastEdge;
  //   Edge edge;
 
  //   protected void OnEnable() {
  //     edge = (Edge)target;
  //   }
 
  //   protected void OnDisable() {
  //     lastEdge = edge;
  //   }
  //   protected void OnDestroy() {
  //     if ( Application.isEditor && target == null) {
  //       lastEdge.fromVertex.RemoveEdge(lastEdge);
  //     }
  //   }
  // }
}
