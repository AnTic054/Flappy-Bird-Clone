using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public KeyCode key;
    public float jumpForce;
    public Rigidbody player;
    public bool canJump;
    public bool playerAlive;
    bool playerStarted;

    public AudioSource audioSource;
    public AudioClip jumpSound;
    private void Awake()
    {
        playerStarted = false;
        player.useGravity = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine((IEnumerator)PlayerJumpRoutine());
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key) && GameManager.gameManagerInstance.gamePaused == false) //&& canJump == true)
        {
            player.useGravity = true;
            playerStarted = true;
            player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            audioSource.PlayOneShot(jumpSound);
        }
    }

    private IEnumerator PlayerJumpRoutine()
    {
        while(playerAlive == true)
        {
            Debug.Log("can jump");
            if (Input.GetKeyDown(key))
            {
                player.useGravity = false;
                canJump = false;
                yield return new WaitForSeconds(.3f);
                player.useGravity = true;
                canJump = true;
            }
        }
    }
}
