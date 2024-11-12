using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOffset : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        float randomStart = Random.Range(0f, animator.GetCurrentAnimatorStateInfo(0).length);

        animator.Play(0, -1, randomStart);
    }

}
