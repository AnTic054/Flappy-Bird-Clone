using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject obstacle;
    public float minHeightY, maxHeightY;
    public float minDelay, maxDelay;
    private float randomHeight;
    private float spawnDelay;
    public bool spawnObstacles;
    public bool increasSpeed;

    void Start()
    {
            SpawnObject();
            StartCoroutine((IEnumerator)Spawn());
            StartCoroutine((IEnumerator)IncreaseSpeedOT());
    }
    void SpawnObject()
    {
        Instantiate(obstacle, new Vector3(transform.position.x,MyRandomFloat(minHeightY,maxHeightY ,randomHeight), transform.position.z), Quaternion.identity);
    }
    private float MyRandomFloat(float min, float max, float randomFloat)
    {
        float newRandomFloat;
        newRandomFloat = Random.Range(min, max);
        randomFloat = newRandomFloat;
        return randomFloat;
    }
    private IEnumerator Spawn()
    {
        while(spawnObstacles == true)
        {
            yield return new WaitForSeconds(MyRandomFloat(minDelay,maxDelay,spawnDelay));
            SpawnObject();
        }
    }
    private IEnumerator IncreaseSpeedOT()
    {
        while(increasSpeed == true)
        {
            yield return new WaitForSeconds(6);
            obstacle.GetComponent<ScrollObstacle>().speed += .05f;
        }
    }
}
