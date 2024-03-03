using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UIManager : Singleton<UIManager>
{
    // Start is called before the first frame update
    public Text generalText;
    Color originalColor;
    void Awake()
    {
        
    }
    public void FadeInText(string msg,Color color)
    {   
        generalText.DOColor(color,2);
        generalText.DOText(msg,2);
        StartCoroutine("FadeOutText");

    }
    public void FadeInText(string msg)
    {   
         generalText.DOText(msg,2);
        StartCoroutine("FadeOutText");

    }
    IEnumerator FadeOutText()
    {
        yield return new WaitForSeconds(5f);
       generalText.DOText("",2f);
       generalText.DOColor(originalColor,2f);
    }
}
