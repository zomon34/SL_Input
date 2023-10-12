using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationWrapper : MonoBehaviour
{
    public LaughText text1;
    public LaughText text2;
    public LaughText text3;
    string[] firstLaughs = { "Nyeh", "Mwuah", "Hjo", "Hark", "Hö" };
    string[] laughTexts = { "Heh", "Hah", "Ho", "Hark", "Hö" };
    int laughIndex;

    public void TriggerFirstLaughText()
    {
        laughIndex = Random.Range(0, laughTexts.Length);
        text1.ShowLaughText(firstLaughs[laughIndex]);
    }

    public void TriggerSecondLaughText()
    {
        text2.ShowLaughText(laughTexts[laughIndex]);
    }

    public void TriggerThirdLaughText()
    {
        text3.ShowLaughText(laughTexts[laughIndex] + "...");
    }
}
