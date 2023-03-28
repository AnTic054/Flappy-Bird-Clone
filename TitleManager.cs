using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class TitleManager : MonoBehaviour
{
    public GameObject panel;
    TopScores topScoresClass = new TopScores(0,0,0,0,0);
    public TextMeshProUGUI[] topScoreText;

    public string path = "";
    public string persistantPath = "";

    public AudioSource audioManager;
    public AudioClip clickSound;
    // Start is called before the first frame update
    void Start()
    {
        SetPath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        AudioManager.audioManagerinstance.PlayOneShot(clickSound);
        DontDestroyOnLoad(AudioManager.audioManagerinstance);
        SceneManager.LoadScene(1);
        
    }
    public void ScoresButton()
    {
        AudioManager.audioManagerinstance.PlayOneShot(clickSound);
        if (panel.active == false)
        {
            panel.SetActive(true);
            ReadScores();
        }
        else if (panel.active == true)
        {
            panel.SetActive(false);
        }
    }
    public void QuitButton()
    {
        AudioManager.audioManagerinstance.PlayOneShot(clickSound);
        Application.Quit();
    }
    void ReadScores()
    {
        LoadScore();
        //JSONSaving.jsonSavingInstance.LoadData();
        for (int i = 0; i < topScoresClass.scores.Length; i++)
        {
            topScoreText[i].text = i + 1 + ": " + topScoresClass.scores[i].ToString();
            Debug.Log(topScoresClass.scores[i]);
        }
    }
    void LoadScore()
    {
        if (File.Exists(persistantPath))
        {
            string json = File.ReadAllText(persistantPath);
            TopScores loadedScores = JsonUtility.FromJson<TopScores>(json);
            topScoresClass = loadedScores;
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
