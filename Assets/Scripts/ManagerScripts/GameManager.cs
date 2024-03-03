using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class GameManager : Singleton<GameManager>
{
    // Something to be done about static
    [Header("UI Elements")]
    [SerializeField]Text scoreText;
    [SerializeField]Text highScoreText;
    [SerializeField]Text countDownText;
    [Header("Final Stars")]
    [SerializeField]GameObject[] stars;
    [Header("Final Score Calculators")]
    [SerializeField]float scoreMultiplier;
    public int levelNo;
    bool isPaused=false;
     int score;
     float countDown=0;
   
    public  int Score{ get { return score;} set { score=value;}}
    public  float CountDown{ get{ return CountDown;}set { CountDown=value;}}
    public UnityEvent onPausedGame;
    public UnityEvent onUnpausedGame;
    void Awake()
    {
        Time.timeScale=1;
        countDown=0;
        score=0;
    }
    void Start()
    {
       if(PlayerPrefs.HasKey("HighScore"+levelNo))
       highScoreText.text="High Score : "+PlayerPrefs.GetInt("HighScore"+levelNo).ToString();
    }
    void OnEnable()
    {
        InputManager.onPauseGame+=PauseGame;
    }
    void OnDisable()
    {
        InputManager.onPauseGame-=PauseGame;
    }

    // Update is called once per frame
    void Update()
    {
        countDown+=Time.deltaTime;
        scoreText.text="Points Collected :"+score.ToString("00");
        countDownText.text=((int)countDown/60).ToString("00")+" : "+((int)countDown%60).ToString("00");
    }
    public void DestroyPlayer()
    {
        Destroy(GameObject.FindWithTag("Player"));
        Destroy(FindObjectOfType<CameraFollow>());
        Time.timeScale=0;
    }
    public void StarCalculator()
    {
       int noOfStars=(int)((score*scoreMultiplier)/(countDown*1.0f));
        noOfStars=noOfStars>=3 ? 3:noOfStars;
       for(int i=0;i<noOfStars;i++)
       stars[i].SetActive(true);

    }
    public void HaultGame()
    {
        Time.timeScale=0;
    }
    public void UnhaultGame()
    {
         Time.timeScale=1;
    }
    public void PauseGame()
    {
        if(isPaused){
        UnpauseGame();
        return;}
        HaultGame();
        isPaused=true;
        onPausedGame?.Invoke();
    }
    public void UnpauseGame()
    {
       UnhaultGame();
        isPaused=false;
        onUnpausedGame?.Invoke();
    }
    public void SaveScore(int levelNo)
    {
        if(!PlayerPrefs.HasKey("HighScore"+levelNo) || score>=PlayerPrefs.GetInt("HighScore"+levelNo))
        PlayerPrefs.SetInt("HighScore"+levelNo,score);
    }
}
