using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreTrigger : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ScoreKeeper.scoreInstance.score += .5f;
            //Debug.Log("Score Trigger Hit " + ScoreKeeper.scoreInstance.score);
        }
    }
}
