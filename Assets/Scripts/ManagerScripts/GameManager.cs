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
    
    bool isPaused=false;
    static int score;
    static float countDown=0;
   
    public static int Score{ get { return score;} set { score=value;}}
    public static float CountDown{ get{ return CountDown;}set { CountDown=value;}}
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
       if(PlayerPrefs.HasKey("HighScore"))
       highScoreText.text="High Score "+PlayerPrefs.GetInt("HighScore").ToString();
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
    public void PauseGame()
    {
        if(isPaused){
        UnpauseGame();
        return;}
        Time.timeScale=0;
        isPaused=true;
        onPausedGame?.Invoke();
    }
    public void UnpauseGame()
    {
        Time.timeScale=1;
        isPaused=false;
        onUnpausedGame?.Invoke();
    }
    public void SaveScore()
    {
        if(PlayerPrefs.HasKey("HighScore") && score>=PlayerPrefs.GetInt("HighScore"))
        PlayerPrefs.SetInt("HighScore",score);
    }
}
