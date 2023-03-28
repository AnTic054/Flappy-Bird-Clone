using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public bool canDie;
    public AudioClip deathSound;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("hit obstacle");
            if (canDie == true)
            {
                Time.timeScale = 0;

                GameManager.gameManagerInstance.gameOver = true;
                AudioManager.audioManagerinstance.PlayOneShot(deathSound);
            }
        }
        
    }
}
