using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationWrapper : MonoBehaviour
{
    public LaughText text1;
    public LaughText text2;
    public LaughText text3;

    public void TriggerFirstLaughText()
    {
        text1.ShowLaughText();
    }

    public void TriggerSecondLaughText()
    {
        text2.ShowLaughText();
    }

    public void TriggerThirdLaughText()
    {
        text3.ShowLaughText();
    }
}
