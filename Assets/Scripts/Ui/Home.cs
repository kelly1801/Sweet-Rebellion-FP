using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Animator crossfadeAnimator;
    [SerializeField] private AnimationClip crossfadeAppearsClip;

    private static Home instance;

    public static Home Instance { get => instance; }

    private void Start()
    {
        instance = this;
    }

    public void Activate(GameObject currentPanel, GameObject nextPanel)
    {
        this.StartCoroutine(ActivateCoroutine(currentPanel, nextPanel));
    }

    private IEnumerator ActivateCoroutine(GameObject currentPanel, GameObject nextPanel)
    {
        crossfadeAnimator.SetTrigger("exit");
        yield return new WaitForSeconds(crossfadeAppearsClip.length);
        nextPanel.SetActive(true);
        currentPanel.SetActive(false);
        crossfadeAnimator.SetTrigger("open");
    }
}