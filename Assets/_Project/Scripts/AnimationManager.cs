using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private static AnimationManager _instance;
    public static AnimationManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void RunAnimation(Animator animator, bool isRunning)
    {
        if (!isRunning)
        {
            animator.applyRootMotion = false;
            animator.SetBool("Idle", true);
            animator.SetBool("Run", false);
        }
        else
        {
            animator.applyRootMotion = false;
            animator.SetBool("Idle", false);
            animator.SetBool("Run", true);
        }
    }

    public void FallBackAnimation(Animator animator)
    {
    }

    public void WinAnimation(Animator animator)
    {
        animator.SetBool("Run", false);
        animator.SetBool("Win", true);
    }

    public void LoseAnimation(Animator animator)
    {
        animator.SetBool("Run", false);
        animator.SetBool("Lose", true);
    }
}