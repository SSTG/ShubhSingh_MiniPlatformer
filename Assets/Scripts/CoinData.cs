using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Coin Data")]
public class CoinData : ScriptableObject
{
    // Start is called before the first frame update
    [Header("Appearance")]
    public Material material;
    [Header("Score Variables")]
    public int scorePoints;
    public int timePoints;
    [Header("Other Info")]
    public string name;
   
}
