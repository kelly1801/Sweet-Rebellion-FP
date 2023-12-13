using UnityEngine;

[ExecuteInEditMode]
public class Finder : MonoBehaviour
{
    #region privatemethods
    private void FindWithNoneMaterials()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
    
        foreach (GameObject child in allObjects)
        {
            Renderer renderer = child.GetComponent<Renderer>();

            if (renderer != null && renderer.sharedMaterial == null)
            {
                Debug.Log($"{child.name} has null material");
            }
        }
        Debug.Log("Finder finished");
    }

    #if UNITY_EDITOR
    private void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 100, 100), "FIND"))
        {
            FindWithNoneMaterials();
        }
    }
    #endif

    #endregion
}
