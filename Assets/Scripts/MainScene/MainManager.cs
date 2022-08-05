using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    
    private bool m_GameOver = false;


    [SerializeField] ScoreText scoreText;
    private int m_score;
    [SerializeField] HighScoreText highScoreText;
    private int m_highScore;
    [SerializeField] PlayerNameText playerNameText;
    private string m_playerNameHS;
   

    
    // Start is called before the first frame update
    void Start()
    {
        InitializeScoreHighScore();
      
        
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_score += point;
        scoreText.SetText($"Score {m_score}");
    }

    public void GameOver()
    {
        if(m_score > m_highScore)
        {
            if(DataPersistence.Instance != null)
            {
                DataPersistence.Instance.HighScoreLoad(m_score);
                DataPersistence.Instance.PlayerNameHSLoad(DataPersistence.Instance.GetPlayerName());
                DataPersistence.Instance.SaveHighScore();
            }

        }
        m_GameOver = true;
        GameOverText.SetActive(true);
    }

    void InitializeScoreHighScore()
    {
        m_score = 0;
        scoreText.SetText($"Score {m_score}");

        m_playerNameHS = (DataPersistence.Instance != null)? DataPersistence.Instance.GetPlayerNameHS():"H ";
        playerNameText.SetText($"Highscore: {m_playerNameHS}");
        m_highScore = (DataPersistence.Instance != null)? DataPersistence.Instance.GetHighScore(): 0 ;
        highScoreText.SetText($"{m_highScore}");
    }
}
