using System.Collections;
using UnityEngine;

public class CrossfadeManager : MonoBehaviour
{
    [SerializeField] private Animator crossfadeAnimator;
    [SerializeField] private AnimationClip crossfadeAppearsClip;

    public void Activate(GameObject currentPanel, GameObject nextPanel)
    {
        StartCoroutine(ActivateCoroutine(currentPanel, nextPanel));
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