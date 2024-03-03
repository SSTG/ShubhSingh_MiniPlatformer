using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorChange : MonoBehaviour
{
    // Start is called before the first frame update
    Material material;
    Color originalColor;
    void Start()
    {
        material=GetComponent<MeshRenderer>().material;
        originalColor=material.color;
    }

    // Update is called once per frame
    public void FadeInColor(Color secondColor)
    {
        material.DOColor(secondColor,1f);
        StartCoroutine("FadeOutColor");
    }
    IEnumerator FadeOutColor()
    {
        yield return new WaitForSeconds(5f);
        material.DOColor(originalColor,1f);
    }
}
