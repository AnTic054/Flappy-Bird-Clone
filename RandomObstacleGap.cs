using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacleGap : MonoBehaviour
{
    public GameObject topObstacle;
    public Transform thisObstacle;
    public float initialDistance;
    public float minDistance, maxDistance;
    float newRandomDistance;
    public float minimumObstacleHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        float newDistance;
        initialDistance = Vector3.Distance(transform.position, topObstacle.transform.position);
        //Debug.Log("obstacle Spawned " + initialDistance);
        if (transform.position.y > minimumObstacleHeight)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y - MyRandomFloat(minDistance, maxDistance, newRandomDistance), transform.position.z);
            newDistance = Vector3.Distance(transform.position, topObstacle.transform.position);
            //Debug.Log("obstacle Spawned " + newDistance);
        }
    }
    private float MyRandomFloat(float min, float max, float randomFloat)
    {
        float newRandomFloat;
        newRandomFloat = Random.Range(min, max);
        randomFloat = newRandomFloat;
        return randomFloat;
    }
}
