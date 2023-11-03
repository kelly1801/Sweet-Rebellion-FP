using UnityEngine;

public class PreferencesDeleter : MonoBehaviour
{
    #region privatemethods
    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }
    #endregion
}
