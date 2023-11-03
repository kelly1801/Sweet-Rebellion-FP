using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Crossfade : MonoBehaviour
{
    #region serializedfields
    [Header("OPEN ANIMATION")]
    [SerializeField] private string disappearTrigger;

    [Header("EXIT ANIMATION")]
    [SerializeField] private string appearTrigger;
    #endregion

    #region privatefields
    private Animator animator;
    #endregion

    #region publicmethods
    public void AppearCrossfade()
    {
        animator.SetTrigger(appearTrigger);
    }

    public void DisappearCrossfade()
    {
        animator.SetTrigger(disappearTrigger);
    }
    #endregion

    #region privatemethods
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    #endregion
}
