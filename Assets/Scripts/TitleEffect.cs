using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleEffect : MonoBehaviour
{
    public TextMeshProUGUI title;
    public Image bgImage;

    void Start()
    {
        title.text = "Sekiro: Shadows Die Thrice";
    }

    void Update()
    {
        title.fontSize = 35 + Mathf.Sin(Time.time * 2) * 10;
    }

    public void PlayButton()
    {
        bgImage.color = Color.red;
    }
}
