using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static AnimationController Instance;

    [SerializeField] Animator animator;

    private void Awake()
    {
        if (Instance != this)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void IdleAnimation()
    {
        animator.SetBool("idle", true);
        animator.SetBool("running", false);
    }

    public void RunAnimation()
    {
        animator.SetBool("idle", false);
        animator.SetBool("running", true);
    }

    public void LoseGameAnimation()
    {
        animator.SetBool("running", false);
        animator.SetBool("death", true);
    }

    public void WinGameAnimation()
    {
        animator.SetBool("running", false);
        animator.SetBool("victory", true);
    }
}