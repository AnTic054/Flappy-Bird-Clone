using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public  class JSONSaving : MonoBehaviour
{
    public static JSONSaving jsonSavingInstance;

    public TopScores topScores;

    public string path = "";
    public string persistantPath = "";

    private void Awake()
    {
        if (jsonSavingInstance != null && jsonSavingInstance != this)
        {
            Destroy(this);
        }
        else
        {
            jsonSavingInstance = this;
        }
        SetPath();
        //CreatScoreData();
        //SaveData();
    }

    public static void SavePlayer(ScoreKeeper score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        FileStream stream = new FileStream(path, FileMode.Create);

        
    }
    void SetPath()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";

        persistantPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }
    public void SaveScoreData()
    {
        string savePath = path;

        Debug.Log("Saving data at " + savePath);
        string json = JsonUtility.ToJson(topScores);
        Debug.Log(json);

        StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);

    }

    public void LoadScoresData()
    {
        StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        TopScores topScoresData = JsonUtility.FromJson<TopScores>(json);
        topScores = topScoresData;
        //Debug.Log(topScores.ToString());

    }
}
