using UnityEngine;

public class HomeUIManager : MonoBehaviour
{
    [Tooltip("Select all GameObject panels and put the main first")]
    [SerializeField] private GameObject[] panels;

    private void Start(){
        panels[0].SetActive(true);
        for(int i = 1; i < panels.Length; i++){
            panels[i].SetActive(false);
        }
    }
}
