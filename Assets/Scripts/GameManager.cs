using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Something to be done about static
    
    static int firstTime=1;
    static int score;
    static float countDown=0;
    public static  int FirstTime{ get { return firstTime;} set { firstTime=value;}}
    public static int Score{ get { return score;} set { score=value;}}
    public static float CountDown{ get{ return CountDown;}set { CountDown=value;}}
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
        countDown+=Time.deltaTime;
        Debug.Log(countDown);
    }
}
