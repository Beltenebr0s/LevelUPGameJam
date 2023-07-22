using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuAnimation : MonoBehaviour
{

    [SerializeField] private Animator animator;

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        animator.SetBool("open", true);
    }

    public void Hide()
    {
        animator.SetBool("open", false);
        StartCoroutine(WaitForAnim(animator, gameObject));
    }

    private IEnumerator WaitForAnim(Animator anim, GameObject menu)
    {
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("New State"));
        menu.SetActive(false);
    }
}
