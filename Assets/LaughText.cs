using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughText : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowLaughText()
    {
        animator.Play("laugh_text");
    }
}
