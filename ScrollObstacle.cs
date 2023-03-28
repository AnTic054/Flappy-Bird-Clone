using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObstacle : MonoBehaviour
{
    public float speed;
    public GameObject obstacle;

    // Update is called once per frame
    void FixedUpdate()
    {
        obstacle.transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
