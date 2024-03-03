using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]CoinData coinData;
    GameManager gameManager;
    MeshRenderer meshRenderer;
    UIManager uiManager;
    int scorePoints;
    SoundManager soundManager;
    int timePoints=0;//By how much the countdown would be decreased, if at all
    void Awake()
    {
        meshRenderer=GetComponent<MeshRenderer>();
        uiManager=FindObjectOfType<UIManager>();
        gameManager=FindObjectOfType<GameManager>();
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
        gameManager.Score+=scorePoints;
        //GameManager.CountDown+=timePoints;
        soundManager.PlaySound(coinData.onCollectSound);
        uiManager.FadeInText(coinData.name+" Coin!!!",coinData.material.color);
        colorChange.FadeInColor(coinData.material.color);
       
        
        Destroy(this.gameObject);
    }
    
    
    
}
