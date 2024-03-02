using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]CoinData coinData;
    MeshRenderer meshRenderer;
    UIManager uiManager;
    int scorePoints;
    SoundManager soundManager;
    int timePoints=0;//By how much the countdown would be decreased, if at all
    void Awake()
    {
        meshRenderer=GetComponent<MeshRenderer>();
        uiManager=FindObjectOfType<UIManager>();
        soundManager=FindObjectOfType<SoundManager>();
        meshRenderer.material=coinData.material;
    }
    void Start()
    {
        scorePoints=coinData.scorePoints;
        timePoints=coinData.timePoints;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Working");
        if(other.gameObject.CompareTag("Player"))
        CollectCoin(other.gameObject.GetComponent<ColorChange>());
    }
    public void CollectCoin(ColorChange colorChange)
    {
        GameManager.Score+=scorePoints;
        //GameManager.CountDown+=timePoints;
        soundManager.PlaySound(coinData.onCollectSound);
        uiManager.FadeInText(coinData.name+" Coin!!!");
        colorChange.FadeInColor(coinData.material.color);
        Invoke(nameof(uiManager.FadeOutText),2f);
        StartCoroutine(FadeOutColor(colorChange));
        Destroy(this.gameObject);
    }
    IEnumerator FadeOutColor(ColorChange colorChange)
    {
        yield return new WaitForSeconds(4f);
        colorChange.FadeOutColor();
    }
    
}
