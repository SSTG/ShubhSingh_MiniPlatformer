using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]CoinData coinData;
    MeshRenderer meshRenderer;
    int scorePoints;
    int timePoints=0;//By how much the countdown would be decreased, if at all
    void Awake()
    {
        meshRenderer=GetComponent<MeshRenderer>();
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
        Debug.Log("Working");
        if(other.gameObject.CompareTag("Player"))
        CollectCoin();
    }
    public void CollectCoin()
    {
        GameManager.Score+=scorePoints;
        //GameManager.CountDown+=timePoints;
        
        
        Destroy(this.gameObject);
    }
    
}
