using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static AnimationController Instance;

    [SerializeField] private Animator _animator;

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
        _animator.applyRootMotion = true;
        _animator.SetBool("Idle", true);
        _animator.SetBool("Run", false);
    }

    public void RunAnimation()
    {
        _animator.applyRootMotion = false;
        _animator.SetBool("Idle", false);
        _animator.SetBool("Run", true);
    }
    
    public void WinAnimation()
    {
        _animator.SetBool("Run", false);
        _animator.SetBool("Win", true);
    }

    public void LoseAnimation()
    {
        _animator.SetBool("Run", false);
        _animator.SetBool("Lose", true);
    }
}