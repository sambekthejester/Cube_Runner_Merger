
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoSingleton<GameManager>
{
    
    public bool IsGameOver;
    public GameObject Player { get; set; }
    public GameObject Skin { get; set; }

    public int StairScore;
    public int Bonus;
    public int Score;

    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] GameObject GameOverPanel;


    [SerializeField] Camera CharCam;
    [SerializeField] Camera GameCam;


    private void Awake()
    {
       
    }
    void Start()
    {
        Player = FindAnyObjectByType<Movement>().gameObject;


    }


    void Update()
    {
      //  Debug.Log(Player.name);
    }

    public void GameOver()
    {
        Debug.Log("gameover");
        ScoreText.gameObject.SetActive(false);
        GameOverPanel.SetActive(true);
        Player.GetComponent<Movement>().enabled = false;
    }
    public void GameOverStair()
    {
        Score = Bonus * StairScore;
        Debug.Log("GameOverStair");
        ScoreText.text = "score:" + " " + (Score.ToString());
        if (StairScore!=0)
        {
            GameOverPanel.GetComponent<Image>().color = new Color(0.46f,1,0,0.76f);
           
        }
        
        GameOverPanel.SetActive(true);
        Player.GetComponent<Movement>().enabled = false;

    }
    public void StartGenerate()
    {
        if (MapGenerate.Instance.StairNumber!=0)
        {
            MapGenerate.Instance.GenerateCubePos(4, 12, 8, 80,
                0.6f, MapGenerate.Instance.StairNumber);

        }
       
    }
    public void RestartGame()
    {

        StartCoroutine(RestartGameAsync());

    }
    public IEnumerator RestartGameAsync()
    {
        yield return new WaitForSeconds(0.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    }

    public void StartGame()
    {


    }
}
