using UnityEngine;

namespace seawisphunter.graphcraft {
  /*
    This MonoBehaviour merely contains a GraphSettings object.  Note:
    GraphSettings is not a MonoBehaviour so that it may be passed
    around with default settings (i.e., when no MonoBehaviour is
    present, and it shouldn't be automatically instantiated in Editor
    mode).
   */
  public class GraphSettingsUI : MonoBehaviour {
    public GraphSettings settings = new GraphSettings();
  }  
}
