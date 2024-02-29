using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    int firstTime=1;
    int score;
    public int FirstTime{ get { return firstTime;}}
    public int Score{ get { return score;}}
    void Start()
    {
        if(!PlayerPrefs.HasKey("FirstTime"))
        {

        }
    }
    //High Score Calculation Function TBD

    // Update is called once per frame
    void Update()
    {
        
    }
}
