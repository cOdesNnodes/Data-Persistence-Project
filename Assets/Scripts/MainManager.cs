using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverGroup;
    
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    public TMP_Text currentScoreText;
    public string currentPlayer;
    public int lastScore;

    public TMP_Text bestScoreText;
    public int highScore;
    public string highName;

    void Awake()

    {
        CheckBestScore();
        CheckCurrentPlayer();
    }    

    // Start is called before the first frame update
    void Start()
    {
        

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartNew();
            }
        }
    }
        
    void AddPoint(int point)
    {
        m_Points += point;

        currentScoreText.text = currentPlayer + $"'s Score : {m_Points}"; //currentPlayer.ToString();

    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverGroup.SetActive(true);
        if(m_Points > highScore)
        {
            highName = currentPlayer; // needs work, highname always currentplayer
            highScore = m_Points;
            FindObjectOfType<ScoreKeeper>().UpdateHighName(highName);
            FindObjectOfType<ScoreKeeper>().UpdateHighScore(highScore);
        }
        
        bestScoreText.text = highName + $"'s Best Score : {highScore}";
        
    }

    public void UpdateCurrentScoreText(string CurrentFromScorekeeper)
    {
        currentPlayer = CurrentFromScorekeeper;

        
        Debug.Log(CurrentFromScorekeeper + " Has Been Passed from ScoreKeeper to main scene");
    }

    public void CheckCurrentPlayer()
    {
        FindObjectOfType<ScoreKeeper>().UpdateMainManager();
    }

    public void CheckBestScore()
    {
        FindObjectOfType<ScoreKeeper>().CheckHighScore(highScore);

        bestScoreText.text = highName + $"'s Best Score : {highScore}";

    }

    public void  UpdateMMHScore(int cScore)
    {
        highScore = cScore;
    }

    public void UpdateMMHName(string cName)
    {
        highName = cName;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void SkUpdateHName()
    {
        FindObjectOfType<ScoreKeeper>().UpdateHighName(highName);
    }
}
