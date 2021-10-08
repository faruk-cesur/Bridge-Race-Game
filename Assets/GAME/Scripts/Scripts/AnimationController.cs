using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private static AnimationController _instance;
    public static AnimationController Instance => _instance;

    [SerializeField] private Animator _animator;

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