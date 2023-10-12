using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleEffect : MonoBehaviour
{
    public TextMeshProUGUI title;
    public Image bgImage;
    public Image hpBarImage;

    void Start()
    {
        title.text = "Sekiro: Shadows Die Thrice";
        hpBarImage.fillAmount = 10;
    }

    void Update()
    {
        title.fontSize = 35 + Mathf.Sin(Time.time * 2) * 10;

        hpBarImage.fillAmount -= 0.1f * Time.deltaTime;
    }

    public void PlayButton()
    {
        bgImage.color = Color.red;
    }
}
