using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]CoinType coinType;
    int scorePoints;
    int timePoints=0;//By how much the countdown would be decreased, if at all
    void Start()
    {
        switch(coinType)
        {
            case CoinType.Bronze: scorePoints=5;break;
            case CoinType.Silver: scorePoints=10;break;
            case CoinType.Gold: scorePoints=15; timePoints=15; break;
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        CollectCoin();
    }
    void CollectCoin()
    {
        GameManager.Score+=scorePoints;
        GameManager.CountDown-=timePoints;
        Debug.Log(GameManager.Score + " "+ GameManager.CountDown);
        Destroy(this.gameObject);
    }
    public enum CoinType{ Bronze, Silver, Gold}
}
