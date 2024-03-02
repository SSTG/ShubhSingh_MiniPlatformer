using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UIManager : Singleton<UIManager>
{
    // Start is called before the first frame update
    public Text generalText;
    public void FadeInText(string msg)
    {
        generalText.DOText(msg,2);

    }
    public void FadeOutText()
    {
        generalText.DOText("",2);
    }
}
