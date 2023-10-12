using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaughText : MonoBehaviour
{
    Animator animator;
    TextMeshProUGUI tmpro;

    void Start()
    {
        animator = GetComponent<Animator>();
        tmpro = GetComponent<TextMeshProUGUI>();
    }

    public void ShowLaughText(string laughText)
    {
        tmpro.text = laughText;
        animator.Play("laugh_text");
    }
}
