using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpenerOnClick : MonoBehaviour
{
    public GameObject panel;

    public void OnButtonClick()
    {
        panel.SetActive(true);
    }
}
