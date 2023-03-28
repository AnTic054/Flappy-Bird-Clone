using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper scoreInstance;
    public float score;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (scoreInstance != null && scoreInstance != this)
        {
            Destroy(this);
        }
        else
        {
            scoreInstance = this;
        }
    }
}
