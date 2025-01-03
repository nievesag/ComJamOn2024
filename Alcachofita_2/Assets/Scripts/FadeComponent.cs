using UnityEngine;

public class FadeComponent : MonoBehaviour
{
    #region references
    private Animator _oscurecedorAnimator;
    #endregion

    private void Start()
    {
        _oscurecedorAnimator = GetComponent<Animator>();

        if (GameManager.Instance != null)
            GameManager.Instance.RegisterOscurecedor(this);
    }

    public void Transicion()
    {
        _oscurecedorAnimator.SetBool("Fadea 0", false);
        _oscurecedorAnimator.SetBool("Fadea 0", true);
    }
}