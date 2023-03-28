using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;
    public bool gameOver;
    public bool gamePaused;
    public GameObject pauseButton;
    public GameObject panel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI mainScoreText;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI pauseScoreText;
    TopScores topScores = new TopScores(0,0,0,0,0);

    public string path = "";
    public string persistantPath = "";

    public KeyCode pauseKey;

    public GameObject audioManager;
    public AudioSource audioSOurce;
    public AudioClip clickSound;

    private void Awake()
    {
        if (gameManagerInstance != null && gameManagerInstance != this)
        {
            Destroy(this);
        }
        else
        {
            gameManagerInstance = this;
        }
        SetPath();
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gamePaused = false;
        panel.SetActive(false);
        gameOverPanel.SetActive(false);
        pauseButton.SetActive(true);
        mainScoreText.alpha = 255;
        LoadScore();
    }

    // Update is called once per frame
    void Update()
    {
        mainScoreText.text = ScoreKeeper.scoreInstance.score.ToString();
        PauseGame();
        if (gameOver == true)
        {
            GameOverPanel();
        }
    }
     void PauseGame()
    {
        if (Input.GetKeyDown(pauseKey) == true && gamePaused == false && gameOver == false)
        {
            Time.timeScale = 0;
            gamePaused = true;
            panel.SetActive(true);
            pauseButton.SetActive(false);
            mainScoreText.alpha = 0;
            pauseScoreText.text = "Score: " + ScoreKeeper.scoreInstance.score;
            SaveScore();
            audioSOurce.PlayOneShot(clickSound);
        }
        else if (Input.GetKeyDown(pauseKey) == true && gamePaused == true && gameOver == false)
        {
            Time.timeScale = 1;
            gamePaused = false;
            panel.SetActive(false);
            pauseButton.SetActive(true);
            mainScoreText.alpha = 255;
            audioSOurce.PlayOneShot(clickSound);
        }
    }
    public void PauseByButton()
    {
        if (gamePaused == false && gameOver == false)
        {
            audioSOurce.PlayOneShot(clickSound);
            Time.timeScale = 0;
            gamePaused = true;
            panel.SetActive(true);
            pauseButton.SetActive(false);
            mainScoreText.alpha = 0;
            pauseScoreText.text = "Score: " + ScoreKeeper.scoreInstance.score;
            SaveScore();
        }
        else if (gamePaused == true && gameOver == false && gameOver == false)
        {
            audioSOurce.PlayOneShot(clickSound);
            Time.timeScale = 1;
            gamePaused = false;
            panel.SetActive(false);
            pauseButton.SetActive(true);
            mainScoreText.alpha = 255;
        }
    }

    public void RestartScene()
    {
        SaveScore();
        audioSOurce.PlayOneShot(clickSound);
        SceneManager.LoadScene(1);
    }
    public void LoadTitleScene()
    {
        SaveScore();
        audioSOurce.PlayOneShot(clickSound);
        DontDestroyOnLoad(AudioManager.audioManagerinstance);
        SceneManager.LoadScene(0);
    }
    public void GameOverPanel()
    {
        if (gameOver == true && gameOverPanel.active == false)
        {
            gameOverPanel.SetActive(true);
            pauseButton.SetActive(false);
            mainScoreText.alpha = 0;
            gameOverScoreText.text = "Score: " + mainScoreText.text;
            AssignScore();
        }
    }
    void AssignScore()
    {
        //TopScores topScores = new TopScores();
        bool scoreUpdated = false;
        LoadScore();
        for (int i = 0; i < topScores.scores.Length; i++)
        {
            if (ScoreKeeper.scoreInstance.score > topScores.scores[i] && scoreUpdated == false && topScores.scores[i] == 0)
            {
                topScores.scores[i] = ScoreKeeper.scoreInstance.score;
                SaveScore();
                scoreUpdated = true;
            }
            else if (ScoreKeeper.scoreInstance.score > topScores.scores[i] && scoreUpdated == false && topScores.scores[i] != 0)
            {
                float oldScore = topScores.scores[i];
                topScores.scores[i] = ScoreKeeper.scoreInstance.score;

                if (i < topScores.scores.Length -1 && oldScore > topScores.scores[i + 1])
                {
                    topScores.scores[i + 1] = oldScore;
                }

                SaveScore();
                scoreUpdated = true;
            }
            Debug.Log(topScores.scores[i]);
        }
    }
    void SaveScore()
    {
        TopScores savedScores = new TopScores(topScores);

        string json = JsonUtility.ToJson(savedScores, true);
        File.WriteAllText(persistantPath, json);
    }
    void LoadScore()
    {
        if (File.Exists(persistantPath))
        {
            string json = File.ReadAllText(persistantPath);
            TopScores loadedScores = JsonUtility.FromJson<TopScores>(json);
            topScores = loadedScores;
        }
        else
        {
            Debug.LogError("File path not found " + persistantPath);
        }

    }
    void SetPath()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "/SaveData.json";

        persistantPath = Application.persistentDataPath + "/SaveData.json";
    }
}
