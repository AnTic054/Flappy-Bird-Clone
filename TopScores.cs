using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TopScores 
{
    public float[] scores = new float[5];
    
    public TopScores(float score1, float score2,float score3,float score4,float score5)
    {
        this.scores[0] = score1;
        this.scores[1] = score2;
        this.scores[2] = score3;
        this.scores[3] = score4;
        this.scores[4] = score5;
        //JSONSaving.jsonSavingInstance.LoadData();
    }
    public TopScores(TopScores topscore)
    {
        this.scores[0] = topscore.scores[0];
        this.scores[1] = topscore.scores[1];
        this.scores[2] = topscore.scores[2];
        this.scores[3] = topscore.scores[3];
        this.scores[4] = topscore.scores[4];
        //JSONSaving.jsonSavingInstance.LoadData();
    }

    void LoadScores()
    {

    }
}
